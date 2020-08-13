namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBooksDTO[]), new XmlRootAttribute("Books"));
            var booksDto = (ImportBooksDTO[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Book> books = new List<Book>();

            StringBuilder sb = new StringBuilder();

            foreach (var bookDTO in booksDto)
            {
                bool isValidBook = IsValid(bookDTO);

                if (!isValidBook)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book
                {
                    Name = bookDTO.Name,
                    Genre = (Genre)Enum.ToObject(typeof(Genre), bookDTO.Genre),
                    Price = bookDTO.Price,
                    Pages = bookDTO.Pages,
                    PublishedOn = DateTime.ParseExact(bookDTO.PublishedOn, @"MM/dd/yyyy", CultureInfo.InvariantCulture)
                    
                };

                books.Add(book);
                sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDto = JsonConvert.DeserializeObject<ImportAuthorDTO[]>(jsonString);

            List<Author> authors = new List<Author>();

            StringBuilder sb = new StringBuilder();

            foreach (var authorDTO in authorsDto)
            {
                bool isValidAuthor = IsValid(authorDTO);

                if (isValidAuthor == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var existingEmail = authors.FirstOrDefault(a => a.Email == authorDTO.Email);

                if (existingEmail != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Phone = authorDTO.Phone,
                    Email = authorDTO.Email
                };

              

                foreach (var authorBookDTO in authorDTO.Books)
                {
                    Book book = context.Books.Find(authorBookDTO.Id);

                    if (book == null)
                    {
                        //sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    author.AuthorsBooks.Add(
                        new AuthorBook
                        {
                            Author = author,
                            Book = book
                        });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, author.AuthorsBooks.Count));

            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}