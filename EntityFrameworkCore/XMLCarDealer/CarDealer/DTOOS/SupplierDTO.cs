using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTOOS
{
    [Serializable]
    [XmlType("Supplier")]
    public class SupplierDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
