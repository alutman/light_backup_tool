using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace light_backup_tool.model
{
    class FileTools
    {

        public static Boolean checkExists(String path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                return true;
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException ||
                    ex is FileNotFoundException ||
                    ex is ArgumentException ||
                    ex is NotSupportedException)
                {
                    return false;
                }
                throw;
            }
        }

        public static Boolean isDirectory(String path)
        {
            try
            {
                FileAttributes attr = File.GetAttributes(path);
                return (attr & FileAttributes.Directory) != 0;
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException ||
                    ex is FileNotFoundException ||
                    ex is ArgumentException ||
                    ex is NotSupportedException)
                {
                    return false;
                }
                throw;
            }
        }

        public static void copyFile(String srcPath, String destPath, Boolean overrwrite)
        {
            if (!FileTools.checkExists(srcPath)) throw new FileNotFoundException("Could not find file '" + srcPath + "'");
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

        public static void copyFolder(String srcDir, String destDir, Boolean overwrite)
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

            foreach (string dirPath in allDirs)
            {
                Directory.CreateDirectory(dirPath.Replace(srcDir, destDir));
            }


            String[] allFiles = Directory.GetFiles(srcDir, "*", SearchOption.AllDirectories);

            foreach (string filePath in allFiles)
            {
                File.Copy(filePath, filePath.Replace(srcDir, destDir), overwrite);
            }

        }

        public static void ExtractZipToDirectory(ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }
            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.Combine(destinationDirectoryName, file.FullName);
                if (file.Name == "")
                {// Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
            }
        }

        public static void makeDirSoft(String path)
        {
            if (checkExists(path))
            {
                throw new IOException(path + " already exists");
            }
            Directory.CreateDirectory(path);
            
        }
    }
}
