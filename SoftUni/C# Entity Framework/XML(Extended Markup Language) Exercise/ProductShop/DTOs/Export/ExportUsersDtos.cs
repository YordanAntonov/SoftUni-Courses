using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("Users")]
    public class ExportUsersDtos
    {  
            [XmlElement("count")]
            public int Count { get; set; }

            [XmlArray("users")]
            public ExportUserDto[]? Users { get; set; }
        
    }
}
