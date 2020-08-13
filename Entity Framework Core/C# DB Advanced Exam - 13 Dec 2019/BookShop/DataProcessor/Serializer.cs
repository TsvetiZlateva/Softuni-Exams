namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    Books = a.AuthorsBooks
                    .OrderByDescending(b => b.Book.Price)
                    .Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = $"{b.Book.Price:f2}"
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var json = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return json;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var xmlSerializer = new XmlSerializer(typeof(ExportBooksDTO[]), new XmlRootAttribute("Books"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                var books = context.Books
                    .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                    .ToArray()
                    .OrderByDescending(b => b.Pages)
                    .ThenByDescending(b => b.PublishedOn)
                    .Take(10)
                    .Select(b => new ExportBooksDTO()
                    {
                        Pages = b.Pages,
                        Name = b.Name,
                        Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                    })
                    .ToArray();

                xmlSerializer.Serialize(stringWriter, books, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}