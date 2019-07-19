using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool.model
{
    public class Config
    {
        public String id;
        public String name; 
        public String description;
        public String source;
        public String destination;
        public Boolean namedFolder;
        public Boolean compress;
        public int backupLimit;

        public Config() { }

        public Config(String name, String description, String source, String destination, Boolean namedFolder, Boolean compress, int backupLimit)
        {
            this.id = genId();
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
            this.namedFolder = namedFolder;
            this.compress = compress;
            this.backupLimit = backupLimit;
        }

        private String genId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}
