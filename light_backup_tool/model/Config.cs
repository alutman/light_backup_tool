﻿using System;
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

        public Config() { }

        public Config(String name, String description, String source, String destination, Boolean namedFolder)
        {
            this.id = genId();
            this.name = name;
            this.description = description;
            this.source = source;
            this.destination = destination;
            this.namedFolder = namedFolder;
        }

        private String genId()
        {
            return Guid.NewGuid().ToString();
        }

    }
}