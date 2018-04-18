using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListView
{
    class Room
    {
        public String id { get; set; }
        public String name { get; set; }

        public Room(String id, String name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
