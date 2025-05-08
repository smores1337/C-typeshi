using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    // All my comments in mycourse.cs should be the same explanation why and what I used those syntaxes and rules.
    public class Student  
    {
        private static int idCounter = 1;

        public int StudentID { get; private set; }
       public string Name { get; set; }
        public string Email { get; set; }

        public Student(string name, string email)
        {
            StudentID = idCounter++;
           Name = name;
            Email = email;
        }

        public Student(int id, string name, string email)
        {
            StudentID = id;
           Name = name;
            Email = email;

            if (id >= idCounter)
            {
                idCounter = id + 1;
            }
        }
        public void DisplayInfo()
        {
           Console.WriteLine($"Student ID: {StudentID}");
           Console.WriteLine($"Name: {Name}");
           Console.WriteLine($"Email: {Email}");
        }

        public string ToCSV()
        {
          return $"{StudentID},{Name},{Email}";
        }

        public static Student FromCSV(string csvLine)
        {
           string[] parts = csvLine.Split(',');
           return new Student(
               int.Parse(parts[0]),
               parts[1],
               parts[2]
            );
        }
    }
}
