using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace light_backup_tool
{
    class ConfigContainer
    {
        private Dictionary<String, Config> configs = new Dictionary<String, Config>();
        private readonly String dateFormat = "yyyy-MM-dd_HH-mm";
        private readonly String dateRegex = "\\d{4}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])_(0[0-9]|1[0-9]|2[0-3])-([0-5][0-9]).*";
        private readonly String CONFIG_FILE = "configs.xml";

        private Controller controller;

        public ConfigContainer(Controller controller)
        {
            this.controller = controller;
        }

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

        public Boolean checkExists(String path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException ||
                    ex is FileNotFoundException ||
                    ex is ArgumentException)
                {
                    return false;
                }
                throw;
            }
        }

        private void makeDirSoft(String path)
        {
            if (checkExists(path))
            {
                throw new IOException(path+" already exists");
            }
            Directory.CreateDirectory(path);
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

            makeDirSoft(newPath);
            controller.addToProgressBar(50);
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

            makeDirSoft(newPath);

            String[] allDirs = Directory.GetDirectories(c.source, "*", SearchOption.AllDirectories);

            double dirPart = 40d / (double)allDirs.Length;
            double count = 0;

            foreach (string dirPath in allDirs)
            {
                count += dirPart;
                if (count >= 1)
                {
                    controller.addToProgressBar((int)Math.Max(count, dirPart));
                    count = 0;
                }
                Directory.CreateDirectory(dirPath.Replace(c.source, newPath));
            }
               

            String[] allFiles = Directory.GetFiles(c.source, "*", SearchOption.AllDirectories);

            double filePart = 60d / (double)allFiles.Length;
            count = 0;

            foreach (string filePath in allFiles)
            {
                count += filePart;
                if (count >= 1)
                {
                    controller.addToProgressBar((int)Math.Max(count, filePart));
                    count = 0;
                }
                
                File.Copy(filePath, filePath.Replace(c.source, newPath), true);
            }
                
        }

        private String[] getBackupDirs(String id)
        {
            Config c = configs[id];
            List<String> backupDirs = new List<String>();
            String[] dirs;
            try
            {
                if (c.namedFolder)
                {
                    dirs = Directory.GetDirectories(c.destination + "\\" + c.name);

                }
                else
                {
                    dirs = Directory.GetDirectories(c.destination);
                }
            }
            catch (DirectoryNotFoundException)
            {
                return new String[0];
            }

            foreach (String s in dirs)
            {
                Regex r = new Regex(dateRegex);
                Match m = r.Match(s);
                if (m.Success)
                {
                    backupDirs.Add(s);
                }
            }
            return backupDirs.ToArray();
        }

        public long countPastBackups(String id)
        {
            return getBackupDirs(id).Length;
        }

        public String getLastBackup(String id)
        {
            try
            {
                String[] sa = getBackupDirs(id);
                if (sa.Length > 0)
                {
                    String last = sa[sa.Length - 1];
                    return last.Substring(last.LastIndexOf("\\") + 1);
                }
                else
                {
                    return "none";
                }
            }
            catch (DirectoryNotFoundException)
            {
                return "none";
            }

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
