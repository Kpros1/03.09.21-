using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static DirectoryInfo _rootDirectory;
        private static string[] _specDirectory = new string[] { "izobrahenie", "Dokymenti", "prochee" };
        private static int _imagesCount = 0, _documentsCount = 0, _othersCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к диску");
            string directoryPath = Console.ReadLine();
            var driveinfo = new DriveInfo(directoryPath);
            Console.WriteLine($"информация о диске:{driveinfo.VolumeLabel}, всего {driveinfo.TotalSize / 1024 / 1024}мб ",
                $"svobodno{driveinfo.AvailableFreeSpace / 1024 / 1024} mb.");
            _rootDirectory = driveinfo.RootDirectory;
            SearchDirectories(_rootDirectory);

            foreach (var directory in _rootDirectory.GetDirectories())
            {
                if (!_specDirectory.Contains(directory.Name))
                    directory.Delete(true);
            }
            var resultText = $"vsego obrabotano {_imagesCount + _documentsCount + _othersCount} failov" +
                $" iz nih {_imagesCount} izobrazenie, {_documentsCount} documenti, {_othersCount} prochix";
            Console.WriteLine(resultText);
            File.WriteAllText(_rootDirectory + "\\info.txt", resultText);
            Console.ReadLine();
        }
        private static void SearchDirectories(DirectoryInfo currentDirectory)
        {
            if (!_specDirectory.Contains(currentDirectory.Name))
            {
                FilterFiles(currentDirectory);
                foreach (var childDirectory in currentDirectory.GetDirectories())
                {
                    SearchDirectories(childDirectory);
                }
            }

        }
        private static void FilterFiles(DirectoryInfo currentDirectory)
        {
            var currentFiles = currentDirectory.GetFiles();
            foreach(var fileInfo in currentFiles)
            {
                if (new string[] { ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".svg" }.Contains(fileInfo.Extension.ToLower()))
                {
                    var photoDirectory = new DirectoryInfo(_rootDirectory + $"{_specDirectory[0]}\\");
                    if (!photoDirectory.Exists)
                        photoDirectory.Create();
                    var yearDirectory = new DirectoryInfo(photoDirectory + $"{fileInfo.LastWriteTime.Date.Year}\\");
                    if (!yearDirectory.Exists)
                        yearDirectory.Create();
                    MoveFile(fileInfo, yearDirectory);
                    _imagesCount++;
                }
                else if(new string[] { ".doc", ".doxc", ".pdf", ".xls", ".xlsx", ".ppt", ".pptx" }.Contains(fileInfo.Extension.ToLower()))
                {
                    var documentsDirectory = new DirectoryInfo(_rootDirectory + $"{_specDirectory[1]}\\");
                    if (!documentsDirectory.Exists)
                        documentsDirectory.Create();

                    DirectoryInfo lengthDirectory = null;
                    if (fileInfo.Length / 1024 / 1024 < 1)
                        lengthDirectory = new DirectoryInfo(documentsDirectory + "menee 1 mb\\");
                    else if (fileInfo.Length / 1024 / 1024 > 10)
                        lengthDirectory = new DirectoryInfo(documentsDirectory + "bolee 10 mb\\");
                    else
                        lengthDirectory = new DirectoryInfo(documentsDirectory + "ot 1 do 10 mb\\");
                    if (!lengthDirectory.Exists)
                        lengthDirectory.Create();
                    MoveFile(fileInfo, lengthDirectory);
                    _documentsCount++;


                }
                else
                {
                    var otherDirectory = new DirectoryInfo(_rootDirectory + $"{_specDirectory[2]}\\");
                    if (!otherDirectory.Exists)
                        otherDirectory.Create();
                    MoveFile(fileInfo, otherDirectory);
                    _othersCount++;


                }

            }

        }
        private static void MoveFile(FileInfo fileInfo, DirectoryInfo directoryInfo)
        {
            var newFileInfo = new FileInfo(directoryInfo + $"\\{fileInfo.Name}");
            while (newFileInfo.Exists)
                newFileInfo = new FileInfo(directoryInfo + $"\\{Path.GetFileNameWithoutExtension(fileInfo.FullName)}(1)" + $"{newFileInfo.Extension}");
            fileInfo.MoveTo(newFileInfo.FullName);
        }

    }
}
