using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [Serializable]
    [XmlType("Product")]
    public class ProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("price")]

        public decimal Price { get; set; }
        [XmlElement("buyer")]
        public string Buyer { get; set; }

    }
}
