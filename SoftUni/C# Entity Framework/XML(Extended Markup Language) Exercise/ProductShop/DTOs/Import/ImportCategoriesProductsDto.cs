using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class ImportCategoriesProductsDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

    }
}
