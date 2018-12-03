namespace Task4.Controllers
{
    using System.Data.SqlClient;

    /// <summary>
    /// Additional class.
    /// </summary>
    internal class DBSQLServerUtils
    {
        /// <summary>
        /// Get <see cref="SqlConnection"/> to Database.
        /// </summary>
        /// <param name="datasource">Source of Database.</param>
        /// <param name="database">Name of Database.</param>
        /// <param name="username">Username of user.</param>
        /// <param name="password">Password for this user.</param>
        /// <returns>Returns <see cref="SqlConnection"/> to Database.</returns>
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            string connString = @"Data Source=" +
                datasource +
                ";Initial Catalog=" +
                database +
                ";Persist Security Info=True;User ID=" +
                username +
                ";Password=" +
                password;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}