using System;
using System.IO;

namespace SortFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = System.Environment.UserName;
            var dir = $"C:\\Users\\{userName}\\Downloads\\";

            var directory = Directory.GetDirectories(dir);
            var files = Directory.GetFiles(dir);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var fileName = fileInfo.Name;
                var lastWriteTime = fileInfo.LastWriteTime.ToString().Split(" ")[0];
                lastWriteTime = lastWriteTime.Replace("/", "_");

                if (!Directory.Exists(Path.Combine(Path.GetDirectoryName(file), lastWriteTime)))
                {
                    Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(file), lastWriteTime));
                }
                File.Move(file, Path.Combine(Path.GetDirectoryName(file), lastWriteTime, fileName));
            }
        }
    }
}
