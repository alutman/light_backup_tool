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
            ExportImportHandler.exportAll(allConfigs(), configFile);
        }

        public void importAll()
        {
            importToDict(ExportImportHandler.importAll(configFile));
        }

        private void importToDict(Config[] configArray)
        {
            for (int i = 0; i < configArray.Length; i++)
            {
                configs.Add(configArray[i].id, configArray[i]);
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

    }
}
