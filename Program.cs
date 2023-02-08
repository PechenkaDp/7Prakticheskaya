namespace _7Prakticheskaya
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            Console.Clear();
            List<string> dirs = new List<string>();
            int position = 0;
            Menu FirstMenu = new Menu(position);
            while (true)
            {
                int a = 0;
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    Console.SetCursorPosition(3, a);
                    Console.WriteLine($"{drive.Name}");
                    dirs.Add(drive.Name.Split("\\")[0]);
                    a++;
                }
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape) { break; }
                if (key.Key == ConsoleKey.Enter)
                {
                    getFiles.getDirectories($"{dirs[position]}\\");
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position > drives.Length - 2)
                    {
                        position = drives.Length - 2;
                    }
                    position++;
                    FirstMenu.Update(position, drives.Length - 1, 0, false);
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position < 1)
                    {
                        position = 1;
                    }
                    position--;
                    FirstMenu.Update(position, drives.Length - 1, 0, true);
                }

            }
        }
    }
}