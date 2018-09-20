﻿namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents Menu to navigate between tasks.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Path to file.
        /// </summary>
        private static string path = @"..\..\Data\TextFile.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu" /> class.
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// Shows Menu lets choose which task to run.
        /// </summary>
        /// <remarks>
        /// Works until user will not exit program.
        /// </remarks>
        public void Run()
        {
            string choise = string.Empty;
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
                        {
                            this.FirstTask();
                            break;
                        }

                    case "2":
                        {
                            this.SecondTask();
                            break;
                        }

                    case "3":
                        {
                            this.ThirdTask(path);
                            break;
                        }

                    case "4":
                        {
                            isWorking = false;
                            Console.WriteLine("Thank you, Good bye!");
                            Console.ReadKey();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choise! Please, try again!");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                }

                Console.Clear();
            }
            while (isWorking == true);
        }

        /// <summary>
        /// Runs First Task.
        /// </summary>
        private void FirstTask()
        {
        }

        /// <summary>
        /// Runs Second Task.
        /// </summary>
        private void SecondTask()
        {
        }

        /// <summary>
        /// Runs Third Task.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        private void ThirdTask(string path)
        {
            try
            {
                TriangleManager triangleManager = new TriangleManager();
                IEnumerable<Triangle> almostOneColor = from triangle in triangleManager.Load(path)
                                                       where (triangle.GetSides()[0].Color == triangle.GetSides()[1].Color && triangle.GetSides()[2].Color != triangle.GetSides()[0].Color) ||
                                                       (triangle.GetSides()[0].Color == triangle.GetSides()[2].Color && triangle.GetSides()[1].Color != triangle.GetSides()[0].Color) ||
                                                       (triangle.GetSides()[1].Color == triangle.GetSides()[2].Color && triangle.GetSides()[0].Color != triangle.GetSides()[1].Color)
                                                       select triangle;
                foreach (var triangle in almostOneColor)
                {
                    ColorSide[] sides = triangle.GetSides();
                    if (sides[0].Color == sides[1].Color)
                    {
                        sides[2].Color = sides[0].Color;
                    }
                    else if (sides[1].Color == sides[2].Color)
                    {
                        sides[0].Color = sides[1].Color;
                    }
                    else
                    {
                        sides[1].Color = sides[2].Color;
                    }

                    triangle.SetSides(sides[0], sides[1], sides[2]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}