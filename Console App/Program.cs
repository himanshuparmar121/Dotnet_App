using System;
using ConsoleApp.Models;
using ConsoleApp.DataLayer;
using ConsoleApp.Logic;

namespace ConsoleApp {
    public class Program {
        void StudentFunction() {

            StudentDatabase studentData = new StudentDatabase();
            StudentLogic studentLogic = new StudentLogic();

                Console.WriteLine("\t1. Add Students details. ");
                Console.WriteLine("\t2. Get student detail by ID.");
                Console.WriteLine("\t3. Exit.");
                Console.Write("Enter Choice: ");
                int Choice = Convert.ToInt32(Console.ReadLine());        

                switch(Choice) {
                    case 1:
                        // call to GiveStudentDetail to enter student's details
                        Student student = studentLogic.GetStudentDetailsFromUser();
                        // call to AddStudent method to store entered details in Database 
                        studentData.AddStudent(student);
                        break;

                    case 2:
                        // call to GetStudent method to fetch data from Database
                        studentLogic.CheckStudentDetailsFromDatabase();
                        break;

                    case 3:
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please enter Correct choice!!!");
                        break;
                }
        }
        public static void Main(String[] args) {

            do {
                Program student = new Program();
                student.StudentFunction();
            } while(true);
        }
    }
}