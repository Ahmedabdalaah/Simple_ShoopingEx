using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Net;
using System.Security.Policy;

namespace Simple_ShoopingEx
{
    internal class ClientOperations : IClient_Operation
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
        public void Add_Client(string firstName, string lastName, string address, int phone, string email)
        {
            try
            {
                SetConnection();
                string addClient = "INSERT INTO Client (FirstName,LastName,Address,Phone,Email) VALUES (@first,@last,@address,@phone,@email)";
                SqlCommand comand = new SqlCommand(addClient,connection);
                comand.Parameters.AddWithValue("first", firstName);
                comand.Parameters.AddWithValue("last", lastName);
                comand.Parameters.AddWithValue("address", address);
                comand.Parameters.AddWithValue("phone", phone);
                comand.Parameters.AddWithValue("email", email);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success: New Client is added");
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_ClientById(int id)
        {
            SetConnection();
            string removeClient = "DELETE FROM Client WHERE id=@ID";
            SqlCommand command = new SqlCommand(removeClient, connection);
            command.Parameters.AddWithValue("ID", id);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Success : Client number {id} is deleted");
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Client GetClients()
        {
            Client client = new Client();
            try
            {
                SetConnection();
                string removeClient = "SELECT * FROM Client ";
                SqlCommand command = new SqlCommand(removeClient, connection);
                SqlDataReader  reader =command.ExecuteReader();
                while (reader.Read())
                {
                    client.id = Convert.ToInt32(reader[0]);
                    client.firstName = reader[1].ToString();
                    client.lastName = reader[2].ToString();
                    client.address = reader[3].ToString();
                    client.phone = Convert.ToInt32(reader[4]);
                    client.email = reader[5].ToString();
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return client;
        }

        public void Update_Client(int id, string firstName, string lastName)
        {
            try
            {
                SetConnection();
                string updateClient = "UPDATE Client SET FirstName=@first ,LastName=@last WHERE Id=@ID";
                SqlCommand comand = new SqlCommand(updateClient, connection);
                comand.Parameters.AddWithValue("first", firstName);
                comand.Parameters.AddWithValue("last", lastName);
                comand.Parameters.AddWithValue("ID", id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success:  Client is updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
