using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Prakticheskaya
{
    internal class getFiles
    {
        public static void getDirectories(string path)
        {
            Console.Clear();
            int posInDirs = 0;
            Menu secondMenu = new Menu(posInDirs);
            while (true)
            {
                int help = 0;
                string[] alldirs = Directory.GetFileSystemEntries(path);
                foreach (string item in alldirs)
                {
                    DateTime birthdate = Directory.GetCreationTime(item);
                    if (Path.HasExtension(item))
                    {
                        Console.SetCursorPosition(3, help);
                        string[] all = item.Split("\\");
                        string realItem = all[all.Length - 1];
                        Console.Write(realItem.Replace(Path.GetExtension(item), ""));
                        help++;
                    }
                    else
                    {
                        string[] all = item.Split("\\");
                        string realItem = all[all.Length - 1];
                        Console.SetCursorPosition(3, help);
                        Console.Write(realItem);
                        help++;
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Open(alldirs[posInDirs]);
                    break;
                }
                if (key.Key == ConsoleKey.Escape) { Console.Clear(); break; }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (posInDirs > alldirs.Length - 2)
                    {
                        posInDirs = alldirs.Length - 2;
                    }
                    posInDirs++;
                    secondMenu.Update(posInDirs, alldirs.Length - 1, 0, false);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (posInDirs < 1)
                    {
                        posInDirs = 1;
                    }
                    posInDirs--;
                    secondMenu.Update(posInDirs, alldirs.Length - 1, 0, true);
                }

            }
        }


        private static void Open(string npath)
        {
            if (Directory.Exists(npath))
            {
                Console.Clear();
                getDirectories(npath);
            }
            else if (File.Exists(npath))
            {
                Process.Start(new ProcessStartInfo { FileName = npath, UseShellExecute = true });
            }
        }
    }
}
