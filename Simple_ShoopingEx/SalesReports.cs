using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal class SalesReports : ISalesReports
    {
        string source = "server=DESKTOP-C4UVIUM\\SQLEXPRESS ;integrated security=SSPI;database=shopping";
        SqlConnection connection;
        public void SetConnection()
        {
            try
            {
                connection = new SqlConnection(source);
                connection.Open();
                Console.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SalesPerDay()
        {
            SetConnection();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SalesReport", connection)
                {
                    CommandType = CommandType.StoredProcedure
            };
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("DateTime :" + reader[0] + " Amount : " + reader[1]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($" Error Occured: {ex.Message}");
            }

           
        }
    }
}
