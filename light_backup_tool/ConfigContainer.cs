﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool
{
    class ConfigContainer
    {
        private Dictionary<String, Config> configs = new Dictionary<String, Config>();
        private readonly String dateFormat = "yyyy-MM-dd_HH-mm";
        private readonly String CONFIG_FILE = "configs.xml";

        public void add(Config c)
        {
            configs[c.id] = c;
        }
        public void remove(String id)
        {
            configs.Remove(id);
        }
        public Config get(String id)
        {
            return configs[id];
        }

        public void backup(String id, String tag)
        {
            FileAttributes attr = File.GetAttributes(configs[id].source);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                backupFolder(id, tag);
            }
            else
            {
                backupFile(id, tag);
            }


        }
        private void backupFile(String id, String tag)
        {
            Config c = configs[id];
            String dateFolder = DateTime.Now.ToString(dateFormat);
            String newPath = c.namedFolder ? c.destination + "\\" + c.name + "\\" + dateFolder : c.destination + "\\" + dateFolder;
            String filename = c.source.Substring(c.source.LastIndexOf('\\') + 1);

            if (tag.Length > 0)
            {
                newPath += "_" + tag;
            }

            Directory.CreateDirectory(newPath);
            File.Copy(c.source, newPath + "\\" + filename);
        }

        private void backupFolder(String id, String tag)
        {
            Config c = configs[id];
            String dateFolder = DateTime.Now.ToString(dateFormat);
            String newPath = c.namedFolder ? c.destination + "\\" + c.name + "\\" + dateFolder : c.destination + "\\" + dateFolder;

            if (tag.Length > 0)
            {
                newPath += "_" + tag;
            }

            newPath += c.source.Substring(c.source.LastIndexOf('\\'));

            Directory.CreateDirectory(newPath);

            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(c.source, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(c.source, newPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string filePath in Directory.GetFiles(c.source, "*",
                SearchOption.AllDirectories))
                File.Copy(filePath, filePath.Replace(c.source, newPath), true);
        }


        public Config[] all()
        {
            return configs.Values.ToArray();
        }

        public String export(String id)
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            Config c = configs[id];
            String fileName = "config-"+c.name+".xml";
            System.IO.StreamWriter file = new System.IO.StreamWriter(@fileName);
            s.Serialize(file, configs[c.id]);
            file.Close();
            return fileName;
        }

        public Config import(String filename)
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(@filename);
            Config c = (Config)reader.Deserialize(fileStream);
            c.newId();
            configs[c.id] = c;
            fileStream.Close();
            return c;
        }

        public void exportAll()
        {
            System.Xml.Serialization.XmlSerializer s = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));

            System.IO.StreamWriter file = new System.IO.StreamWriter(@CONFIG_FILE);
            s.Serialize(file, all());
            file.Close();
        }

        public void importAll()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Config[]));
            System.IO.StreamReader fileStream = new System.IO.StreamReader(@CONFIG_FILE);

            Config[] importedConfigs = (Config[])reader.Deserialize(fileStream);
            fileStream.Close();
            importToDict(importedConfigs);
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