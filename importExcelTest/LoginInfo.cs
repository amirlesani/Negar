using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace negar
{
   public class LoginInfo
    {
        public string Name { get; set; }
        public string family { get; set; }
        public int Id { get; set; }
        public long cityID { get; set; }
        public string cityName { get; set; }
        public string user { get; set; }
        public bool permission { get; set; }

        public string messages { get; set; }
        public bool update { get; set; }

        public bool adminVersion { get; set; }
        public int version { get; set; }
    }
}
