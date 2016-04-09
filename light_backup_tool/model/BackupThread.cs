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


        public void delete(String deletePath)
        {
            try
            {
                Directory.Delete(deletePath, true);
                controller.setProgressBar(100);
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException)
                {
                    controller.sendError("Delete may have partially completed");
                }
                else
                {
                    controller.sendError(ex.Message);
                }
                controller.setProgressBar(0);

            }
        }
        public void restore(String restorePath)
        {
            try
            {
                String[] allFiles = Directory.GetFiles(restorePath, "*");
                String[] allDirs = Directory.GetDirectories(restorePath, "*", SearchOption.TopDirectoryOnly);
                if (allFiles.Length == 1)
                {
                    this.tag = "before_restore";
                    //backupFile(config, tag);
                    restoreFile(config, restorePath);
                }
                else if (allDirs.Length == 1)
                {
                    this.tag = "before_restore";
                    //backupFolder(config, tag);
                    restoreFolder(config, restorePath);
                }
                else
                {
                    throw new Exception("Backup is not in a valid structure");
                }
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException)
                {
                    controller.sendError("Restore may have partially completed");
                }
                else
                {
                    controller.sendError(ex.Message);
                }
                controller.setProgressBar(0);

            }
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

        private void copyFile(String srcPath, String destPath, Boolean overrwrite)
        {
            if (!FileTools.checkExists(srcPath)) throw new FileNotFoundException("Could not find file '"+srcPath+"'");
            try
            {
                FileTools.makeDirSoft(Path.GetDirectoryName(destPath));
            }
            catch (IOException ioe)
            {
                if (!overrwrite) throw ioe;
            }
            File.Copy(srcPath, destPath, overrwrite);
        }


        private void backupFile(Config c, String tag)
        {
            String newPath = createNewPath();
            String filename = Path.GetFileName(c.source);
            controller.addToProgressBar(20);
            copyFile(c.source, Path.Combine(newPath, filename), false);
            controller.setProgressBar(100);
            
        }

        private void restoreFile(Config c, String restorePath)
        {
            String fileName = Path.GetFileName(c.source);
            controller.addToProgressBar(20);
            copyFile(Path.Combine(restorePath, fileName), c.source, true);
            controller.setProgressBar(100);

        }

        private void copyFolder(String srcDir, String destDir, Boolean overwrite)
        {
            if (!FileTools.checkExists(srcDir)) throw new FileNotFoundException("Could not find directory '" + srcDir + "'");
            try
            {
                FileTools.makeDirSoft(destDir);
            }
            catch (IOException ioe)
            {
                if (!overwrite) throw ioe;
            }


            String[] allDirs = Directory.GetDirectories(srcDir, "*", SearchOption.AllDirectories);

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
                Directory.CreateDirectory(dirPath.Replace(srcDir, destDir));
            }


            String[] allFiles = Directory.GetFiles(srcDir, "*", SearchOption.AllDirectories);

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

                File.Copy(filePath, filePath.Replace(srcDir, destDir), overwrite);
            }

            controller.setProgressBar(100);

        }
        private void backupFolder(Config c, String tag)
        {
            String destPath = createNewPath();
            destPath = Path.Combine(destPath, Path.GetFileName(c.source));
            copyFolder(c.source, destPath, false);
        }
        private void restoreFolder(Config c, String restorePath)
        {
            String source = Path.Combine(restorePath, new DirectoryInfo(c.source).Name);
            copyFolder(source, c.source, true);
        }


        private void backupFolderOld(Config c, String tag)
        {
            String newPath = createNewPath();
            newPath = Path.Combine(newPath, Path.GetFileName(c.source));

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
