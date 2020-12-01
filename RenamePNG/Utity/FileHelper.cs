using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePNG.Utity
{
    public class FileHelper
    {
        public FileHelper()
        {

        }
        public bool FileSaveAs(string curentPath, string newPath)
        {
            bool res = false;
            try
            {
                FileInfo file = new FileInfo(curentPath);
                file.CopyTo(newPath);
                res = true;
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }
        public bool RenameFile(string curentPath, string newPath)
        {
            bool res = false;
            try
            {
                File.Move(curentPath, newPath);
                res = true;
               
            }
            catch (Exception e)
            {
                res = false;
            }
            return res;
        }
    }
}
