using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [Serializable]
    [XmlRoot("Users")]
    public class MasterDTOQ8
    {
        [XmlElement("count")]
        public int Count  => Users.Any() ? Users.Count() : 0;
        [XmlArray("users")]
        public List<UserDTOQ8> Users { get; set; }

    }
}
