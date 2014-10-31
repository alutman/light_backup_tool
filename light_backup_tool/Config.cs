using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool
{
    public class Config
    {
        public String id; 
        public String name; 
        public String description;
        public String source;
        public String destination;

        public Config() { }
        

        public Config(String id)
        {
            this.id = id;
        }

        public Config(String name, String description, String source, String destination)
        {
            this.id = ""+genId();
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
        }
        public Config(String id, String name, String description, String source, String destination)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
        }

        private long genId()
        {
            Random rand = new Random();
            return rand.Next();
        }


    }
}
