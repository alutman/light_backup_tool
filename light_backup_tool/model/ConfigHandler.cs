using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace light_backup_tool.model
{
    class ConfigHandler
    {
        private Dictionary<String, Config> configs = new Dictionary<String, Config>();
        private readonly String dateFormat = "yyyy-MM-dd_HH-mm";
        private readonly String dateRegex = "\\d{4}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])_(0[0-9]|1[0-9]|2[0-3])-([0-5][0-9]).*";
        private String configFile;
        private Controller controller;
        private Thread currentThread;

        public ConfigHandler(String configFile, Controller controller)
        {
            this.configFile = configFile;
            this.controller = controller;
        }

        public void put(Config c)
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

        public Config[] allConfigs()
        {
            return configs.Values.ToArray();
        }

        public long countPastBackups(String id)
        {
            return getBackupDirs(id).Length;
        }

        public String getLastBackupFull(String id)
        {
            try
            {
                String[] sa = getBackupDirs(id);
                if (sa.Length > 0)
                {
                    String last = sa[sa.Length - 1];
                    return last;
                }
                else
                {
                    return null;
                }
            }
            catch (DirectoryNotFoundException)
            {
                return null;
            }
        }


        public String getLastBackup(String id)
        {
            String full = getLastBackupFull(id);
            return full == null ? "none" : Path.GetFileName(full);       
        }

        public void restore(String id, String backupFolder)
        {
            Config c = configs[id];
            String backupPath = Path.Combine(c.destination, c.namedFolder ? c.name : "", backupFolder);
            BackupThread backupThread = new BackupThread(c, "", dateFormat, controller);
            currentThread = new Thread(() => backupThread.restore(backupPath));
            currentThread.Start();

        }

        public void deleteSingle(String id, String backupFolder)
        {
            Config c = configs[id];
            String deletePath = Path.Combine(c.destination, c.namedFolder ? c.name : "", backupFolder);
            BackupThread backupThread = new BackupThread(c, "", dateFormat, controller);
            currentThread = new Thread(() => backupThread.delete(deletePath));
            currentThread.Start();

        }

         //IList, ICollection, IEnumerable
        public void delete(String id, System.Collections.IList backupFolders)
        {
            Config c = configs[id];

            List<String> deletePaths = new List<String>();

            foreach (String s in backupFolders)
            {
                deletePaths.Add(Path.Combine(c.destination, c.namedFolder ? c.name : "", s));

            }
            BackupThread backupThread = new BackupThread(c, "", dateFormat, controller);
            currentThread = new Thread(() => backupThread.delete(deletePaths));
            currentThread.Start();
        }

        public void restoreLast(String id)
        {
            String lastBackup = getLastBackupFull(id);
            BackupThread backupThread = new BackupThread(configs[id], "", dateFormat, controller);
            currentThread = new Thread(() => backupThread.restore(lastBackup));
            currentThread.Start();

        }
        public void backup(String id, String tag)
        {
            BackupThread backupThread = new BackupThread(configs[id],tag,dateFormat,controller);
            currentThread = new Thread(new ThreadStart(backupThread.backup));
            currentThread.Start();
        }

        public void stop()
        {
            try
            {
                currentThread.Abort();
            }
            catch (Exception ex)
            {
                controller.sendError(ex.Message);
            }
            
        }

        public String export(String id)
        {
            String filename = "config_"+configs[id].name;
            ExportImportHandler.export(configs[id], filename);
            return filename;
        }

        public Config import(String filename)
        {
            Config c = ExportImportHandler.import(filename);
            this.put(c);
            return c;
        }

        public void exportAll()
        {
            exportAll(configFile);
        }
        public void exportAll(String fileName)
        {
            ExportImportHandler.exportAll(allConfigs(), fileName);
        }

        public void importAll()
        {
            importAll(configFile);
        }

        public void importAll(String fileName)
        {
            importToDict(ExportImportHandler.importAll(fileName));
        }

        private void importToDict(Config[] configArray)
        {
            for (int i = 0; i < configArray.Length; i++)
            {
                try
                {
                    configs.Add(configArray[i].id, configArray[i]);
                }
                catch (ArgumentException)
                {
                    Console.Write("Skipped adding an already existing config");
                }
                
            }

        }

        public String[] getBackupDirs(String id)
        {
            return getBackupDirs(id, false);
        }

        public String[] getBackupDirs(String id, Boolean nameOnly)
        {
            Config c = configs[id];
            List<String> backupDirs = new List<String>();
            String[] dirs;
            if(!FileTools.checkExists(c.destination)) return new String[0];
            try
            {
                if (c.namedFolder)
                {
                    dirs = Directory.GetDirectories(Path.Combine(c.destination, c.name));

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
                    if (nameOnly)
                    {
                        backupDirs.Add(new DirectoryInfo(s).Name);
                    }
                    else
                    {
                        backupDirs.Add(s);
                    }
                }
            }
            return backupDirs.ToArray();
        }

    }
}
