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

        public string resultPath = "";
        public DirectoryInfo[] GetDirectories(string path)
        {
            DirectoryInfo[] directories;     
            try
            {
                directory = new DirectoryInfo(path);
                directories = directory.GetDirectories();
                resultPath = path;
                return directories;
            }
            catch (Exception e)
            {
                int indexOfLastSlash = path.LastIndexOf('\\');
                path = path.Remove(indexOfLastSlash);
                resultPath = path;
                directory = new DirectoryInfo(path);
                directories = directory.GetDirectories();
                
                Console.WriteLine($"Возникло исключение {e.Message}");
            }
            return directories;
        }


        public FileInfo[] GetFiles()
        {
            FileInfo[] files = directory.GetFiles();
            return files;
        }

        public static List<string> GetSystemDrivesPaths() 
        {
            List<string> listOfPaths = new List<string>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    listOfPaths.Add(drive.Name);
                } 
            }
            return listOfPaths;
        }
    }
}
