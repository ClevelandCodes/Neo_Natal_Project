using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Neo_Natal.Models
{
    public class SharedContext
    {
        public int id { get; set; }

        public int healthworker_id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }
    }
}