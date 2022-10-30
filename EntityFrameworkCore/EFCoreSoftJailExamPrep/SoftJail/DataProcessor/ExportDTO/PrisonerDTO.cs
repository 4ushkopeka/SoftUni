using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDTO
{
    [XmlType("Prisoner")]
    public class PrisonerDTO
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }
        [XmlArray("EncryptedMessages")]
        public List<MessageDTO> EncryptedMessages { get; set; }
    }
}
