using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace NameCleanerForMusic
{
    public class FileManager
    {
        DirectoryInfo directory;

        public DirectoryInfo[] GetDirectories(string path)
        {
            directory = new DirectoryInfo(path);

            DirectoryInfo[] directories = directory.GetDirectories();

            return directories;
        }

        public FileInfo[] GetFiles()
        {
            FileInfo[] files = directory.GetFiles();

            return files;
        }

    }
}
