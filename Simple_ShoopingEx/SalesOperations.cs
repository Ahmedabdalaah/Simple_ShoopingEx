using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Simple_ShoopingEx
{
    internal class SalesOperations : ISaleOperations
    {
        string source = "server=DESKTOP-C4UVIUM\\SQLEXPRESS ;integrated security=SSPI;database=shopping";
        SqlConnection connection;
        public void Add_Sale(DateTime saleDate, int product_id, int client_id)
        {
            try
            {
                SetConnection();
                string addClient = "INSERT INTO Sales (SaleDate,Product_Id,Client_Id) VALUES (@date,@productId,@clientId)";
                SqlCommand comand = new SqlCommand(addClient, connection);
                comand.Parameters.AddWithValue("date", saleDate);
                comand.Parameters.AddWithValue("productId", product_id);
                comand.Parameters.AddWithValue("clientId", client_id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success: New Sale is added");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_SaletById(int id)
        {
            SetConnection();
            string removeClient = "DELETE FROM Sales WHERE id=@ID";
            SqlCommand command = new SqlCommand(removeClient, connection);
            command.Parameters.AddWithValue("ID", id);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Success : Sale number {id} is deleted");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Sales GetSales()
        {
            Sales sale = new Sales();
            try
            {
                SetConnection();
                string removeClient = "SELECT * FROM Sales ";
                SqlCommand command = new SqlCommand(removeClient, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sale.id = Convert.ToInt32(reader[0]);
                    sale.sale_date = Convert.ToDateTime(reader[1]);
                    sale.product_id = Convert.ToInt32(reader[2]);
                    sale.client_id = Convert.ToInt32(reader[3]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sale;
        }

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

        public void Update_Sale(int id, DateTime saleDate)
        {
            try
            {
                SetConnection();
                string updateClient = "UPDATE Sales SET SaleDate=@date WHERE Id=@ID";
                SqlCommand comand = new SqlCommand(updateClient, connection);
                comand.Parameters.AddWithValue("date", saleDate);
                comand.Parameters.AddWithValue("ID", id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success:  Sale is updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
