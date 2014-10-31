using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool
{
    class Controller
    {
        private Dictionary<String, Config> configs = new Dictionary<String, Config>();

        public void add(Config c)
        {
            configs[c.id] = c;
        }
        public Config get(String id)
        {
            return configs[id];
        }

        public Config[] all()
        {
            return configs.Values.ToArray();
        }

        public String export(Config c)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            String fileName = "config-"+c.name+".xml";
            System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName);
            s.Serialize(file, configs);
            file.Close();
            return fileName;
        }

        public Config import(String filename)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(@filename);
            Config c = (Config)reader.Deserialize(fileStream);
            configs[c.id] = c;
            fileStream.Close();
            return c;
        }

        public void exportAll()
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));
            String fileName = "configs.xml";
            System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName);

            s.Serialize(file, all());
            file.Close();
        }

        public void importAll(String filename)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(@filename);
            Config[] importedConfigs = (Config[])reader.Deserialize(fileStream);
            fileStream.Close();
            importToDict(importedConfigs);
            Console.WriteLine("Configs count: "+configs.Count);
        }

        private void importToDict(Config[] configArray)
        {
            for (int i = 0; i < configArray.Length; i++)
            {
                configs.Add(configArray[i].id, configArray[i]);
            }

        }


    }
}
