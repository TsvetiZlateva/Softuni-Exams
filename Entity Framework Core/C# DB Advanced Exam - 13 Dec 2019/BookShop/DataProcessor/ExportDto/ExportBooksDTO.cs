using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ExportDto
{
    [XmlType("Book")]
    public class ExportBooksDTO
    {
        [XmlAttribute(AttributeName = "Pages")]
        public int Pages { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

    }
}
