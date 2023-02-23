using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Calculus
{
    public class Options
    {
        private static void RewriteLine(string path, int lineIndex, string newValue)
        {
            int i = 0;
            string tempPath = path + ".tmp";
            using (StreamReader sr = new StreamReader(path))
            using (StreamWriter sw = new StreamWriter(tempPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (lineIndex == i)
                        sw.WriteLine(newValue);
                    else
                        sw.WriteLine(line);
                    i++;
                }
            }
            File.Delete(path);
            File.Move(tempPath, path);
        }
        public void Selector()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
            {
                RewriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat", 0, "lang=English");   /*C:\Users\Name\AppData\Roaming\MatrixCalculator\*/
                Englang eng = new Englang();
                eng.Main();

            }
        }
        public void OptionsFile_Reader(ref string lang)
        {
            bool err = false;
            using (StreamReader reader = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat"))
            {
                string opt = null;
                while ((opt = reader.ReadLine()) != null)
                {
                    if (opt == "lang=English")
                    {
                        lang = "Eng";
                    }
                    else if (opt=="-")
                    {
                        err = true;
                    }
                }
            }
            if (err==true)
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat");
                OptionsFile_Create();
                FirstSelector();
            }
        }
        public void FirstSelector()
        {
            Console.WriteLine("<Select Language>");
            Console.WriteLine("\n1 - English\n2 - Deutsche\n3 - Русский\n");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
            {
                RewriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat", 0, "lang=English");
                Englang eng = new Englang();
                eng.Main();

            }
        }
        public void OptionsFile_Create()
        {
            FileInfo options = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat");
            FileStream fs = options.Create();
            fs.Close();
            using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator\options.dat"))
            {
                writer.Write("-");
            }

        }
        public bool OptionsFile_Exist()
        {
            DirectoryInfo options = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MatrixCalculator");
            options.Create();
            FileInfo[] files = options.GetFiles("options.dat", SearchOption.AllDirectories);
            if (files.Length == 0) return false;
            else return true;
        }
    }
}
