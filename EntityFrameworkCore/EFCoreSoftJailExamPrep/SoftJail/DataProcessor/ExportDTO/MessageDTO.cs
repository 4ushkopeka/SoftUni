using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDTO
{
    [XmlType("Message")]
    public class MessageDTO
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
