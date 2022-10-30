﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.DTOs
{
    [Serializable]
    [XmlType("Category")]
    public class CategoryDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
