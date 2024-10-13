using System;
using System.Data.SqlClient;

namespace EmployeeCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Database=mommy;User Id=root;Password=Server098#;";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                // Your code here
            }
        }
    }
}c