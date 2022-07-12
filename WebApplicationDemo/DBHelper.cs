using System.Data.SqlClient;
using WebApplicationDemo.Models;

namespace WebApplicationDemo
{
    public class DBHelper
    {
        SqlConnection connection;
        SqlCommand command;
        
        public void Connect()
        {
            string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\Datalabs Teacher\\source\repos\\WebApplicationDemo\\BookDepository\\BookDB.mdf; Integrated Security = True";
            connection = new SqlConnection(connectionString);
            connection.Open();
           
        }

        void Disconnect()
        {
            connection.Close();
        }

        public void Add(Models.Book newBook)
        {
            string sqlCommand = "INSERT INTO LIBRARY VALUES ${newBook}";
            connection.Open();
            command = new SqlCommand(sqlCommand, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("ola ok");
        }

        public List<Student> GetAll()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyNewDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connectionString);
            List<Student> students = new List<Student>();
            string sqlCommand = "SELECT * FROM STUDENTS";
            connection.Open();
            command = new SqlCommand(sqlCommand, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        
                    }
                }
            }
            return students;
        }
    }
}
