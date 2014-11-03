using System;
using System.Collections.Generic;
using System.IO;
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
        public Boolean namedFolder;

        public Config() { }
        

        public Config(String id)
        {
            this.id = id;
        }

        public Config(String name, String description, String source, String destination, Boolean namedFolder)
        {
            this.id = ""+genId();
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
            this.namedFolder = namedFolder;
        }
        public Config(String id, String name, String description, String source, String destination, Boolean namedFolder)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
            this.namedFolder = namedFolder;
        }
        public void newId()
        {
            this.id = genId();
        }

        private String genId()
        {
            return Guid.NewGuid().ToString();
        }


    }
}
