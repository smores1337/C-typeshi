using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class myCourse
    {
        private static int idCounter = 1;

       
        public int CourseID { get; private set; }
        public string CourseName { get; set; }
        public int CreditHours { get; set; }
        public myCourse(string courseName, int creditHours)
        {
            CourseID = idCounter++;
            CourseName = courseName;
            CreditHours = creditHours;
        }

        public myCourse(int id, string courseName, int creditHours)
        {
            CourseID = id;
            CourseName = courseName;
            CreditHours = creditHours;

            if (id >= idCounter)
            {
                idCounter = id + 1;
            }
        }

      /* ---------------------------------------------------------------------------------------- */

        public void DisplayInfo()
        {
            Console.WriteLine($"Course ID: {CourseID}");
            Console.WriteLine($"Course Name: {CourseName}");                 // Here I use a method to display course information
            Console.WriteLine($"Credit Hours: {CreditHours}");
        }

        public bool IsFullCreditCourse()
        {
            return CreditHours >= 3;
        }
                
        public string ToCSV()
        {
            return $"{CourseID},{CourseName},{CreditHours}";         // used a  Method to get course data as CSV string

        }

        public static myCourse FromCSV(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            return new myCourse(
                int.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2])                       // Here I use static method to parse a CSV string into a  object like you taught us in lab
            );
        }
    }
}
