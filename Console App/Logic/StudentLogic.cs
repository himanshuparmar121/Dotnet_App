using System;
using System.Configuration;
using MySqlConnector;
using ConsoleApp.Models;

namespace ConsoleApp.Logic {
    public class StudentLogic {
        public Student GetStudentDetailsFromUser() {
           
            Student student = new Student();
            
            Console.Write("Enter Student ID: ");
            student.ID = Console.ReadLine();

            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Student Roll No.: ");
            student.RollNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Student Grade: ");
            student.Grade = Convert.ToChar(Console.ReadLine());

            Console.Write("Enter Student Marks: ");
            student.Marks = Convert.ToSingle(Console.ReadLine());

            return student;
        }

        public void CheckStudentDetailsFromDatabase() {

            string Connection_String = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
            MySqlConnection Connection = new MySqlConnection(Connection_String);

            Console.Write("Enter a Student ID to search in Database: ");
            String ID = Console.ReadLine();

            bool Input = false;
            Console.WriteLine("Fetching The Data from Database...");
            
            try {
                Connection.Open();

                string FetchString = "SELECT Name, Roll_No FROM studentdetails WHERE ID = '" + ID + "'";
                
                MySqlCommand Command = new MySqlCommand(FetchString, Connection);
                MySqlDataReader Data = Command.ExecuteReader();

                while(Data.Read()) {
                    Console.WriteLine("Name: " + Data[0]);
                    Console.WriteLine("Roll No: " + Data[1]);
                    Input = true;            
                }

                if(Input == false) {
                    Console.WriteLine("Student with given ID is not present");
                }
                Data.Close();
            } catch(Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            Connection.Close();
            Console.WriteLine("Done.\n\n");
        }
    }
}