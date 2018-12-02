using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Task4.Controllers
{
    class DBUtils
    {
        private static SqlConnection GetDBConnection()
        {
            string datasource = @"(localdb)\MSSQLLocalDB";
            string database = "Northwind";
            string username = "";
            string password = "";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }

        public static bool TryConnect()
        {
            SqlConnection sqlConnection = GetDBConnection();
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<string> Execute(string request)
        {
            List<string> res = new List<string>();
            using (SqlConnection connection = GetDBConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string temp = string.Empty;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                // Convert.ChangeType(reader[i], reader.GetType());
                                if (reader.GetValue(i) != DBNull.Value)
                                {
                                    temp += $@"{reader.GetString(i)};";
                                }
                                else
                                {
                                    temp += $@";";
                                }
                            }

                            res.Add(temp);
                        }
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return res;
        }
    }
}