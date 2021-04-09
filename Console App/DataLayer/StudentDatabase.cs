using System;
using System.Configuration;
using MySqlConnector;
using ConsoleApp.Models;

namespace ConsoleApp.DataLayer {
    public class StudentDatabase {

        // connection string in which the user, database, server and password is stored.
        public void AddStudent(Student student) {

            string Connection_String = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            MySqlConnection Connection = new MySqlConnection(Connection_String);

            Console.WriteLine("Connecting to MySQL...");

            try {
                Connection.Open();

                // Insert values into studentdetails table
                string InsertString = "INSERT INTO studentdetails(ID, Name, Roll_No, Grade, Marks) VALUES(@ID, @Name, @RollNo, @Grade, @Marks)";

                MySqlCommand Command = new MySqlCommand(InsertString, Connection);

                Command.Parameters.AddWithValue("@ID", student.ID);
                Command.Parameters.AddWithValue("@Name", student.Name);
                Command.Parameters.AddWithValue("@RollNo", student.RollNo);
                Command.Parameters.AddWithValue("@Grade", student.Grade);
                Command.Parameters.AddWithValue("@Marks", student.Marks);

                Command.ExecuteNonQuery();
                
                Connection.Close();
                Console.WriteLine("Done.\n\n");
            } catch (Exception ex) {

                Console.WriteLine(ex.ToString());
            }
        } 
    }
}
