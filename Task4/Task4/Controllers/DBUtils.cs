namespace Task4.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    
    /// <summary>
    /// Utilities for DB.
    /// </summary>
    public class DBUtils
    {
        /// <summary>
        /// Trying to connect to DB. Returns <see cref="true"/> if connected.
        /// </summary>
        /// <returns>Returns <see cref="true"/> if connected.</returns>
        public static bool TryConnect()
        {
            try
            {
                SqlConnection sqlConnection = GetDBConnection();
                sqlConnection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Executes request.
        /// </summary>
        /// <param name="request">Text of SQL Request.</param>
        /// <returns>Returns <see cref="List{string}"/> of results.</returns>
        public static List<string> Execute(string request)
        {
            List<string> res = new List<string>();
            using (SqlConnection connection = GetDBConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(request, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    string t = string.Empty;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        t += $@"{reader.GetName(i)};";
                    }

                    res.Add(t);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string temp = string.Empty;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (reader.GetValue(i) != DBNull.Value)
                                {                                    
                                    temp += $@"{Convert.ToString(reader.GetValue(i))};";
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
                catch (Exception)
                {
                    throw new Exception(string.Format("Can not execute this request:\n{0}", request));
                }
            }

            return res;
        }

        /// <summary>
        /// Get <see cref="SqlConnection"/> for DB.
        /// </summary>
        /// <returns><see cref="SqlConnection"/> for DB.</returns>
        private static SqlConnection GetDBConnection()
        {
            string datasource = @"(localdb)\MSSQLLocalDB";
            string database = "Northwind";
            string username = string.Empty;
            string password = string.Empty;
            try
            {
                return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("Can not connect to {0} {1}", datasource, database));
            }
        }
    }
}