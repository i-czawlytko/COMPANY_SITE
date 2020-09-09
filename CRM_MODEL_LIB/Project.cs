using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_MODEL_LIB
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public string thread { get; set; }
        public string content { get; set; }
        public byte[] imageData { get; set; }
        //public string imageMimeType { get; set; }
    }
}
