using System;
using System.Collections.Generic;
using System.IO;
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
                    ex is ArgumentException)
                {
                    return false;
                }
                throw;
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
