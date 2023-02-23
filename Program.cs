using System;
namespace Matrix_Calculus
{
    class Program
    {
        static void StartScreen()
        {
            string startText = "MATRIX CALCULATOR";
            int centerX = (Console.WindowWidth / 2) - (startText.Length / 2);
            int centerY = (Console.WindowHeight / 2) - 1;
            for (int i=0;i<startText.Length;i++)
            {
                Console.SetCursorPosition(centerX+i, centerY);
                Console.Write(startText[i]);
                Thread.Sleep(75);
            }
            Thread.Sleep(1200);
            Console.Clear();
        }

        static void Main()
        {
            Console.Title = "Matrix Calculator";
            StartScreen();
            Options options= new Options();

            if (options.OptionsFile_Exist()==false)
            {
                options.OptionsFile_Create();
                options.FirstSelector();
            }
            if (options.OptionsFile_Exist()==true)
            {
                string lang=null;
                options.OptionsFile_Reader(ref lang);
                if (lang=="Eng")
                {
                    Englang eng = new Englang();
                    eng.Main();
                }
            }
        }
    }
}