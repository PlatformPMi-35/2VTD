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


namespace Task4
{
    class Program
    {
        private static List<string> LoadRequests(string path= @"../../Requests.xml")
        {
            List<string> res = new List<string>();
            XmlSerializer xmlSerializer = new XmlSerializer(res.GetType());
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlReader xmlReader = XmlReader.Create(fileStream, null);
                if (xmlSerializer.CanDeserialize(xmlReader))
                {
                    res = (List<string>)xmlSerializer.Deserialize(xmlReader);
                }
                else
                {
                    throw new XmlException("Cannot Deserialize!");
                }

            }

            return res;
        }

        private static void CreateFile(string path = @"../../")
        {
            path += "Requests.xml";
            List<string> lst = new List<string>();
            lst.Add(string.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(lst.GetType());
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, lst);
            }
        }

        public static void ConnectLoad()
        {
            Console.Clear();
            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                Console.WriteLine("Connecting...");
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connected!");
                    Thread.Sleep(1000);
                    LoadRequests();
                }
                else
                {
                    throw new Exception("Connection Error");
                }
                //SqlCommand command = new SqlCommand(sqlExpression, connection);
                //SqlDataReader reader = command.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                //    while (reader.Read())
                //    {
                //        Console.WriteLine($"{reader.GetString(0)}\t{reader.GetString(2)}\t{reader.GetString(8)}");
                //    }
                //}
                //reader.Close();
            }
        }

        static void Main(string[] args)
        {
            //CreateFile();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1-Load requests\n" +
                                    "2-Exit");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:     ConnectLoad(); break;
                    case 2:     return;
                    default:    break;
                }
            }
        }
    }
}
