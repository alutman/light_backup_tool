using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace light_backup_tool.model
{
    class BackupThread
    {

        private Config config;
        private String tag;
        private String dateFormat;
        private Controller controller;

        public BackupThread(Config config, String tag, String dateFormat, Controller controller)
        {
            this.config = config;
            this.tag = tag;
            this.dateFormat = dateFormat;
            this.controller = controller;
        }



        public void backup()
        {
            try
            {
                FileAttributes attr = File.GetAttributes(config.source);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    backupFolder(config, tag);
                }
                else
                {
                    backupFile(config, tag);
                }
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException)
                {
                    controller.sendError("Backup may have partially completed");
                }
                else 
                {
                    controller.sendError(ex.Message);
                }
                controller.setProgressBar(0);
                
            }
            
        }
        private String createNewPath()
        {
            Config c = config;
            String dateFolder = DateTime.Now.ToString(dateFormat);
            String newPath = c.namedFolder ? Path.Combine(c.destination, c.name, dateFolder) : Path.Combine(c.destination, dateFolder);
            if (tag.Length > 0)
            {
                newPath += "_" + tag;
            }
            return newPath;
        }

        private void backupFile(Config c, String tag)
        {
            String newPath = createNewPath();
            String filename = Path.GetFileName(c.source);
            FileTools.makeDirSoft(newPath);

            controller.addToProgressBar(50);
            File.Copy(c.source, Path.Combine(newPath, filename));
            controller.setProgressBar(100);
            
        }

        private void backupFolder(Config c, String tag)
        {
            String newPath = createNewPath();
            newPath += Path.GetFileName(c.source);

            FileTools.makeDirSoft(newPath);

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

            controller.setProgressBar(100);

        }
    }
}
