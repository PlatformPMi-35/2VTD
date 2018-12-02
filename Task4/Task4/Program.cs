using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Task4.Controllers;


namespace Task4
{
    class Program
    {
        public static List<string> Requests { get; set; }

        public static void ConnectLoad()
        {
            Console.WriteLine("Connecting...");
            if (DBUtils.TryConnect())
            {
                Console.WriteLine("Connected!");
                Requests = IOController.Load();
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Can't connect to server!");
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            ConnectLoad();
            while (true)
            {
                Console.Clear();
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
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();                                
                                int.TryParse(Console.ReadLine(), out input);
                                IOController.SaveTo(DBUtils.Execute(Requests[input]));
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                IOController.SaveTo(DBUtils.Execute(Console.ReadLine()));
                                break;
                            }
                        case 4: return;
                        default: break;
                    }
                }
                catch (Exception)
                {
                    // TODO                   
                }
            }
        }
    }
}
