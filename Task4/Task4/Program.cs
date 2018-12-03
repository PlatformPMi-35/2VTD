namespace Task4
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Task4.Controllers;

    /// <summary>
    /// Class of Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Gets or sets <see cref="List{string}"/> of Requests.
        /// </summary>
        /// <value>Value is <see cref="List{string}"/></value>
        public static List<string> Requests { get; set; }

        /// <summary>
        /// Connects to Database and Loads Requests. 
        /// </summary>
        /// <returns>If Connected true.</returns>
        public static bool ConnectLoad()
        {
            Console.WriteLine("Connecting...");
            if (DBUtils.TryConnect())
            {
                Console.WriteLine("Connected!");
                Requests = IOController.Load();
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.WriteLine("Can't connect to server!");
                Thread.Sleep(1000);
                return false;
            }
        }

        /// <summary>
        /// Text of Main Program.
        /// </summary>
        /// <param name="args">Arguments of Function.</param>
        public static void Main(string[] args)
        {
            bool isConn = ConnectLoad();
            Console.Clear();

            while (isConn)
            {
                Console.WriteLine($"There are {Requests.Count} avaliable requests.\n" +
                    $"1-Show request\n" +
                    $"2-Execute request\n" +
                    $"3-Execute own request\n" +
                    $"4-Exit");
                int.TryParse(Console.ReadLine(), out int input);
                try
                {
                    switch (input)
                    {
                        case 1:
                            {
                                Console.Clear();
                                int.TryParse(Console.ReadLine(), out input);
                                Console.WriteLine(Requests[input]);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                        case 2:
                            {
                                Console.Clear();                                
                                int.TryParse(Console.ReadLine(), out input);
                                IOController.SaveTo(DBUtils.Execute(Requests[input]));
                                Console.Clear();
                                break;
                            }

                        case 3:
                            {
                                Console.Clear();
                                IOController.SaveTo(DBUtils.Execute(Console.ReadLine()));
                                Console.Clear();
                                break;
                            }

                        case 4: return;
                        default: break;
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
