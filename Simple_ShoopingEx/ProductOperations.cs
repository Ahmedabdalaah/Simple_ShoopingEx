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
    internal class ProductOperations : IProductOperations
    {
        string source = "server=DESKTOP-C4UVIUM\\SQLEXPRESS ;integrated security=SSPI;database=shopping";
        SqlConnection connection;
        public void Add_Product(string productName, float price, int amount, int type_id)
        {
            try
            {
                SetConnection();
                string addClient = "INSERT INTO Product (ProductName,Price,Amount,Type_Id) VALUES (@name,@price,@amount,@type)";
                SqlCommand comand = new SqlCommand(addClient, connection);
                comand.Parameters.AddWithValue("name", productName);
                comand.Parameters.AddWithValue("Price", price);
                comand.Parameters.AddWithValue("Amount", amount);
                comand.Parameters.AddWithValue("type", type_id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success: New product is added");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_ProductById(int id)
        {
            SetConnection();
            string removeClient = "DELETE FROM Product WHERE id=@ID";
            SqlCommand command = new SqlCommand(removeClient, connection);
            command.Parameters.AddWithValue("ID", id);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Success : Product number {id} is deleted");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Product GetProducts()
        {
            Product product = new Product();
            try
            {
                SetConnection();
                string removeClient = "SELECT * FROM Product ";
                SqlCommand command = new SqlCommand(removeClient, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.id = Convert.ToInt32(reader[0]);
                    product.product_name = reader[1].ToString();
                    product.price = Convert.ToInt32(reader[2]);
                    product.amount = Convert.ToInt32(reader[3]);
                    product.type_id = Convert.ToInt32(reader[4]);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return product;
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

        public void Update_Product(int id, string ProductName, int amount)
        {
            try
            {
                SetConnection();
                string updateClient = "UPDATE Product SET ProductName=@name , Amount=@amount WHERE Id=@ID";
                SqlCommand comand = new SqlCommand(updateClient, connection);
                comand.Parameters.AddWithValue("name", ProductName);
                comand.Parameters.AddWithValue("amount", amount);
                comand.Parameters.AddWithValue("ID", id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success:  Product is updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
