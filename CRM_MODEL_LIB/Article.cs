using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public class Article
    {
        public int id { get; set; }
        public string thread { get; set; }
        public string author { get; set; }
        public string brief { get; set; }
        public string content { get; set; }
        public System.DateTime create_date { get; set; }
        public byte[] imageData { get; set; }
    }
}
