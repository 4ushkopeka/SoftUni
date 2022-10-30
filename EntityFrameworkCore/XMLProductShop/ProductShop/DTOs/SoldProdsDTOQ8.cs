using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [Serializable]
    [XmlType("SoldProducts")]
    public class SoldProdsDTOQ8
    {
        [XmlElement("count")]
        public int Count => Products.Any() ? Products.Count : 0;
        [XmlArray("products")]
        public List<ProductDTOQ6> Products { get; set; }
    }
}
