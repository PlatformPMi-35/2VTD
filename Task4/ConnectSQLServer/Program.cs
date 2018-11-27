using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.SqlClient;

namespace ConnectSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sqlExpression = "SELECT * FROM Northwind.dbo.Customers"; // Select

            using (SqlConnection connection = DBUtils.GetDBConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {                  
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetString(0)}\t{reader.GetString(2)}\t{reader.GetString(8)}");
                    }
                }

                reader.Close();
            }

            Console.Read();
        }
    }

}