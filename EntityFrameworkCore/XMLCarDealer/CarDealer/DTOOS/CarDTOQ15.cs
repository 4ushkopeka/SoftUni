using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTOOS
{
    [XmlType("car")]
    public class CarDTOQ15
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("model")]
        public string Model { get; set; }
        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}