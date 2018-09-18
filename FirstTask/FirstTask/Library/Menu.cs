using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask.Library
{
    internal class Menu
    {
        public Menu()
        {

        }

        private void FirstTask()
        {

        }

        private void SecondTask()
        {

        }

        private void ThirdTask()
        {

        }

        public void Run()
        {
            string choise = "";
            bool isWorking = true;
            do
            {
                Console.WriteLine("-----Select task----- ");
                Console.WriteLine("1) Read the data in the SortedList collection of colored triangles.");
                Console.WriteLine("The figures should be sorted around the perimeters. Output result in file1.");
                Console.WriteLine();
                Console.WriteLine("2) Define those triangles in which all sides of the same color and rewrite the information about them in the pairs collection: ");
                Console.WriteLine("The color is the number of triangles of that color.");
                Console.WriteLine();
                Console.WriteLine("3) Repaint the third side of the triangles, in which there are two sides of the same color, ");
                Console.WriteLine("in that color, so that they become single-colored.");
                Console.WriteLine();
                Console.WriteLine("4) Exit.");

                choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        FirstTask();
                        break;
                    case "2":
                        SecondTask();
                        break;
                    case "3":
                        ThirdTask();
                        break;
                    case "4":
                        isWorking = false;
                        Console.WriteLine("Thank you, Good bye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid choise! Please, try again!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
                Console.Clear();
            }
            while (isWorking == true);
        }
    }
}
