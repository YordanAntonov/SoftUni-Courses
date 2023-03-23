using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("partId")]
    public class ImportPartDto2
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
