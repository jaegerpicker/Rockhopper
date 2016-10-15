using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rockhopper.Models
{
    public class AppModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Status { get; set; }
        public DateTime Started { get; set; }
        public DateTime LastUpdate { get; set; }
        public string[] Arguements { get; set; }
    }
}
