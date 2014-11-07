using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool.model
{
    class ExportImportHandler
    {

        public static void exportAll(Config[] configs, String configFile)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));
            System.IO.StreamWriter file = new System.IO.StreamWriter(configFile);
            s.Serialize(file, configs);
            file.Close();
        }
        public static Config[] importAll(String configFile)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(configFile);
            Config[] importedConfigs = (Config[])reader.Deserialize(fileStream);
            fileStream.Close();
            return importedConfigs;
        }

        public static void export(Config c, String filename)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);
            s.Serialize(file, c);
            file.Close();
        }
        public static Config import(String filename)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(@filename);
            Config c = (Config)reader.Deserialize(fileStream);
            fileStream.Close();
            return c;
        }
    }
}
