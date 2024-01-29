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
    internal class TypeOperations : ITypeOperations
    {
        string source = "server=DESKTOP-C4UVIUM\\SQLEXPRESS ;integrated security=SSPI;database=shopping";
        SqlConnection connection;
        public void Add_Type(string typeName)
        {
            try
            {
                SetConnection();
                string addClient = "INSERT INTO Type (TypeName) VALUES (@name)";
                SqlCommand comand = new SqlCommand(addClient, connection);
                comand.Parameters.AddWithValue("name", typeName);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success: New Type is added");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_TypeById(int id)
        {
            SetConnection();
            string removeClient = "DELETE FROM Type WHERE id=@ID";
            SqlCommand command = new SqlCommand(removeClient, connection);
            command.Parameters.AddWithValue("ID", id);
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine($"Success : Type number {id} is deleted");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Type GetTypes()
        {
            Type type = new Type();
            try
            {
                SetConnection();
                string removeClient = "SELECT * FROM Type ";
                SqlCommand command = new SqlCommand(removeClient, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    type.id = Convert.ToInt32(reader[0]);
                    type.type_name = reader[1].ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return type;
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

        public void Update_Type(int id, string typeName)
        {
            try
            {
                SetConnection();
                string updateClient = "UPDATE Type SET TypeName=@name WHERE Id=@ID";
                SqlCommand comand = new SqlCommand(updateClient, connection);
                comand.Parameters.AddWithValue("name", typeName);
                comand.Parameters.AddWithValue("ID", id);
                comand.ExecuteNonQuery();
                Console.WriteLine("Success: Type is updated");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
