namespace FirstTask.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents Menu to navigate between tasks.
    /// </summary>
    public class Menu
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
                            this.FirstTask(path);
                            Console.ReadKey();
                            break;
                        }

                    case "2":
                        {
                            this.SecondTask(path);
                            Console.ReadKey();
                            break;
                        }

                    case "3":
                        {
                            this.ThirdTask(path);
                            Console.ReadKey();
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
        /// <returns>Returns <see cref="SortedList{int, Triangle}"/></returns>
        /// <param name="path">Path to the file.</param>
        public SortedList<int, Triangle> FirstTask(string path)
        {
            try
            {
                TriangleManager triangleManager = new TriangleManager();
                IEnumerable<Triangle> triangles = triangleManager.Load(path);

                SortedList<int, Triangle> sortedTriangles = new SortedList<int, Triangle>();
                foreach (var triang in triangles)
                {
                    sortedTriangles.Add(triang.GetPerim(), triang);
                }

                foreach (var triang in sortedTriangles)
                {
                    Console.WriteLine(triang.Value);
                }

                return sortedTriangles;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Runs Second Task.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Returns <see cref="Dictionary{Color, int}"/></returns>
        public Dictionary<Color, int> SecondTask(string path)
        {
            try
            {
                TriangleManager triangleManager = new TriangleManager();
                IEnumerable<Triangle> triangles = triangleManager.Load(path);
                var selectedTriangles = from triangle in triangles

                                        where
                                        (triangle.Sides[0].Color == triangle.Sides[1].Color &&
                                        triangle.Sides[0].Color == triangle.Sides[2].Color)
                                        group triangle by triangle.Sides[0].Color;


                Dictionary<Color, int> trianglesPairs = new Dictionary<Color, int>();
                foreach (IGrouping<Color, Triangle> g in selectedTriangles)
                {
                    trianglesPairs.Add(g.Key, g.Count());
                }

                foreach (var p in trianglesPairs)
                {
                    Console.WriteLine($"{p.Key} - {p.Value} items");
                }

                return trianglesPairs;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Runs Third Task.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <returns>Returns <see cref="IEnumerable{Triangle}"/>.</returns>
        public IEnumerable<Triangle> ThirdTask(string path)
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
                    Console.WriteLine(triangle);
                }

                return almostOneColor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
