using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class College
    {
        
        private List<Student> students;  // This where I  list to store students and courses
        private List<myCourse> courses;

        private bool[,] registrations; // This is 2d array to track

        private const string STUDENTS_FILE = "students.csv";
        private const string COURSES_FILE = "courses.csv";              // toooo storagee
        private const string REGISTRATIONS_FILE = "registrations.csv";

        public College()
        {       
            students = new List<Student>();      // Here I use contructor
            courses = new List<myCourse>();
            registrations = new bool[0, 0]; 
        }

        public void AddStudent(Student student)                             // I used method then resize the registration array to accomodatee the neww student.
        {
            students.Add(student);

            ResizeRegistrationsArray();
        }
        public void AddCourse(myCourse course)
        {
            courses.Add(course);

                                                                                        //  Same thing above I use method then resize the registrations array to accommodate the new course
            ResizeRegistrationsArray();
        }

        private void ResizeRegistrationsArray()                  // Here I made the class private then use a  nethod to resize the registrations array when students or courses are added

        {
            bool[,] newRegistrations = new bool[students.Count, courses.Count];

            for (int i = 0; i < Math.Min(registrations.GetLength(0), students.Count); i++)
            {
                for (int j = 0; j < Math.Min(registrations.GetLength(1), courses.Count); j++)
                {
                    newRegistrations[i, j] = registrations[i, j];
                }
            }

                                                                                     // Here I replace the old array with the new one
            registrations = newRegistrations;
        }

                                                                                  
        public bool RegisterStudentToCourse(int studentId, int courseId)       // Same thing above I usea  method to registerr a student for a course then find student and course indices
        {
            int studentIndex = FindStudentIndex(studentId);
           int courseIndex = FindCourseIndex(courseId);

            if (studentIndex == -1 || courseIndex == -1)
            {
                return false; 
            }

            registrations[studentIndex, courseIndex] = true;
            return true;
        }

                                                            
        private int FindStudentIndex(int studentId)
        {
            for (int i = 0; i < students.Count; i++)     // Here I use a  helper method to find a student's index by idd
            {
               if (students[i].StudentID == studentId)
                {
                    return i;
                }
            }
            return -1; 
        }
        private int FindCourseIndex(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
               if (courses[i].CourseID == courseId)
                {
                    return i;
                }
            }
            return -1; 
        }

        // I use a method to display all students
        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
              Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\nAll Students:");
            Console.WriteLine();
            foreach (var student in students)
            {
                student.DisplayInfo();
                Console.WriteLine();
            }
        }

        // display all courses
        public void DisplayAllCourses()
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses found.");
                return;
            }

            Console.WriteLine("\nAll Courses:");
            Console.WriteLine();
            foreach (var course in courses)
            {
                course.DisplayInfo();
                Console.WriteLine();
            }
        }

        //  display all registrations
        public void DisplayRegistrations()
        {
            if (students.Count == 0 || courses.Count == 0)
            {
                Console.WriteLine("No registrations available (no students or courses).");
                return;
            }

            Console.WriteLine("\nRegistrations:");
            Console.WriteLine();
            bool hasRegistrations = false;

            for (int i = 0; i < students.Count; i++)
            {
                List<string> studentCourses = new List<string>();

                for (int j = 0; j < courses.Count; j++)
                {
                    if (registrations[i, j])
                    {
                        studentCourses.Add(courses[j].CourseName);
                        hasRegistrations = true;
                    }
                }

                if (studentCourses.Count > 0)
                {
                    Console.WriteLine($"Student: {students[i].Name} (ID: {students[i].StudentID})");
                    Console.WriteLine("Registered Courses:");
                    foreach (var courseName in studentCourses)
                    {
                        Console.WriteLine($" - {courseName}");
                    }
                    Console.WriteLine();
                }
            }

            if (!hasRegistrations)
            {
                Console.WriteLine("No student is registered for any course yet.");
            }
        }

        // Display a method to count total of registrations
        public int CountTotalRegistrations()
        {
            int count = 0;

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    if (registrations[i, j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        // Here I use a Method to save data to files
        public void SaveData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(STUDENTS_FILE))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine(student.ToCSV());
                    }
                }
                using (StreamWriter writer = new StreamWriter(COURSES_FILE))         // Saving student, courses and lastly the registration....
                {
                    foreach (var course in courses)
                    {
                        writer.WriteLine(course.ToCSV());
                    }
                }
                using (StreamWriter writer = new StreamWriter(REGISTRATIONS_FILE))
                {
                    for (int i = 0; i < students.Count; i++)
                    {
                        for (int j = 0; j < courses.Count; j++)
                        {
                            if (registrations[i, j])
                            {
                                writer.WriteLine($"{students[i].StudentID},{courses[j].CourseID}");
                            }
                        }
                    }
                }

                Console.WriteLine("Data saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        // Used a Method to load data from files
        public void LoadData()
        {
            try
            {
                students.Clear();
                courses.Clear();
                if (File.Exists(STUDENTS_FILE))
                {
                    string[] studentLines = File.ReadAllLines(STUDENTS_FILE);
                    foreach (var line in studentLines)
                    {
                       if (!string.IsNullOrWhiteSpace(line))
                        {
                            students.Add(Student.FromCSV(line));
                        }
                    }
                }
                if (File.Exists(COURSES_FILE))
                {
                    string[] courseLines = File.ReadAllLines(COURSES_FILE);
                    foreach (var line in courseLines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                       {
                            courses.Add(myCourse.FromCSV(line));
                        }
                    }
                }

                registrations = new bool[students.Count, courses.Count];

                if (File.Exists(REGISTRATIONS_FILE))
                {
                    string[] registrationLines = File.ReadAllLines(REGISTRATIONS_FILE);
                    foreach (var line in registrationLines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            string[] parts = line.Split(',');
                           int studentId = int.Parse(parts[0]);
                            int courseId = int.Parse(parts[1]);
                            RegisterStudentToCourse(studentId, courseId);
                        }
                    }
                }
               Console.WriteLine("^_^");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        public List<Student> GetStudents()
        {
            return students;
        }
        public List<myCourse> GetCourses()  // Here I use gettersd for students and courses  
        {
            return courses;
        }
    }
}
