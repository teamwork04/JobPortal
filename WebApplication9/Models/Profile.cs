using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string img_url { get; set; }
    }
}