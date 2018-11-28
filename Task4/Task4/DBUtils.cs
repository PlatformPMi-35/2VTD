using System.Data.SqlClient;

namespace Task4
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"(localdb)\MSSQLLocalDB";

            string database = "Northwind";
            string username = "";
            string password = "";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }

}