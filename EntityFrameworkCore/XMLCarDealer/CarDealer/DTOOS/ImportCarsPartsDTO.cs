using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTOOS
{
    [XmlType("partId")]
    public class ImportCarsPartsDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
