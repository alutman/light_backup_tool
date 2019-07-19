using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.IO.Compression;

namespace light_backup_tool.model
{
    class BackupThread
    {

        private Config config;
        private String dateFormat;
        private Controller controller;

        public BackupThread(Config config, String dateFormat, Controller controller)
        {
            this.config = config;
            this.dateFormat = dateFormat;
            this.controller = controller;
        }

        public void delete(IList<String> deletePaths)
        {
            double deletePart = 100d / (double)deletePaths.Count;

            try
            {
                foreach (String s in deletePaths)
                {
                    Directory.Delete(s, true);
                    controller.addToProgressBar((int)deletePart);        
                }
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
                    restoreFile(config, restorePath);
                }
                else if (allDirs.Length == 1)
                {
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

        public void backup(String tag)
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
                if (config.backupLimit > 0)
                {
                    String[] sa = ConfigHandler.getBackupDirsForConfig(config, false);
                    if (sa.Length > config.backupLimit)
                    {
                        int newSize = sa.Length - config.backupLimit;
                        String[] saNew = new String[newSize];
                        
                        Array.Copy(sa, 0, saNew, 0, newSize);
                        this.delete(saNew.ToList());

                    }
      
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
        private String createNewPath(String tag)
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
            String newPath = createNewPath(tag);
            String filename = Path.GetFileName(c.source);
            controller.addToProgressBar(20);
            Console.WriteLine(c.name + " " +c.compress);
            if(c.compress)
            {
                FileTools.makeDirSoft(newPath);
                using (ZipArchive za = new ZipArchive(new FileStream(Path.Combine(newPath, filename + ".zip"), FileMode.Create), ZipArchiveMode.Create))
                {
                    za.CreateEntryFromFile(c.source, filename);
                }
            }
            else
            {
                FileTools.copyFile(c.source, Path.Combine(newPath, filename), false);
            }
            
            controller.setProgressBar(100);
            
        }

        private void restoreFile(Config c, String restorePath)
        {
            if (c.compress)
            {
                String source = Path.Combine(restorePath, new DirectoryInfo(c.source).Name + ".zip");
                controller.addToProgressBar(20);
                using (ZipArchive za = new ZipArchive(new FileStream(source, FileMode.Open)))
                {
                    FileTools.ExtractZipToDirectory(za, Path.GetDirectoryName(c.source), true);
                }
                    
                controller.setProgressBar(100);
            }
            else
            {
                String fileName = Path.GetFileName(c.source);
                controller.addToProgressBar(20);
                FileTools.copyFile(Path.Combine(restorePath, fileName), c.source, true);
                controller.setProgressBar(100);
            }
        }

        private void backupFolder(Config c, String tag)
        {
            String destPath = createNewPath(tag);
            destPath = Path.Combine(destPath);
            FileTools.makeDirSoft(destPath);
            if(c.compress)
            {
                ZipFile.CreateFromDirectory(c.source, Path.Combine(destPath, Path.GetFileName(c.source) + ".zip"));
            }
            else
            {
                FileTools.copyFolder(c.source, destPath, false);
            }
            
            controller.setProgressBar(100);
        }
        private void restoreFolder(Config c, String restorePath)
        {
            Console.WriteLine(restorePath);
            String source = Path.Combine(restorePath, new DirectoryInfo(c.source).Name + ".zip");
            Console.WriteLine(source);
            if(c.compress)
            {
                ZipFile.ExtractToDirectory(source, c.source);
            }
            else
            {
                FileTools.copyFolder(source, c.source, true);
            }

        }
    }
}
