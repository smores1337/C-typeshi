namespace Assignment2
{

    // Group 157 
    // Student: Benz Stephen Farinas
    // Course: T197 Online
    internal class Program                                            
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
           Console.WriteLine("Welcome to George Brown College");
            Console.WriteLine();
            College college = new College();
            try
            {
                college.LoadData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not load existing data: {ex.Message}");
               Console.WriteLine();
                Console.WriteLine("Starting with empty data.");
            }

            bool exit = false;

            
            while (!exit) 
            {
                // I put spaces each option for formality like I did last assignment
               Console.WriteLine("\nMain Menu:");
                Console.WriteLine();
               Console.WriteLine("1. Add a new Student");
                Console.WriteLine();
                Console.WriteLine("2. Add a new Course");
                Console.WriteLine();
               Console.WriteLine("3. Register a Student to a Course");
                Console.WriteLine();
                Console.WriteLine("4. Students");
                Console.WriteLine();
                Console.WriteLine("5. Courses");
                Console.WriteLine();
               Console.WriteLine("6. Registrations");
                Console.WriteLine();
                Console.WriteLine("7. Save Data");
               Console.WriteLine();
                Console.WriteLine("8. Load Data");
                Console.WriteLine();
                Console.WriteLine("9. Exit");
                Console.WriteLine();
                Console.Write("\n Please Choose Number from 1 to 9: ");
 
                string choiceStr = Console.ReadLine(); // Here we get the user choicee
                int choice;

                if (!int.TryParse(choiceStr, out choice) || choice < 1 || choice > 9)
                {
                   Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
               
               switch (choice)
                {
                    case 1: 
                       AddStudent(college);                        // First case add the new student
                        break;
                    case 2: 
                       AddCourse(college);                    // Second case add new course
                        break;
                    case 3: 
                       RegisterStudentToCourse(college);              // Third case register  a student to a specific course 
                        break;
                    case 4: 
                       college.DisplayAllStudents();                             // Display all student that inputs their name
                        break;
                    case 5: 
                       college.DisplayAllCourses();                             // To display all course that available
                       break;
                    case 6: 
                       college.DisplayRegistrations();                                                   // Display registrations
                        break;
                    case 7: 
                       college.SaveData();
                       break;
                    case 8: 
                      college.LoadData();
                        break;
                    case 9: 
                        Console.WriteLine("Saving data before exit.");
                        college.SaveData();
                      Console.WriteLine("Thank you for using our application!");
                        exit = true;
                        break;
                }
            }
        }
        static void AddStudent(College college) // Here I use helper method to add a student
        {
            Console.WriteLine("\nAdd a new Student:");
            Console.WriteLine();
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter student email: ");
            string email = Console.ReadLine();
            Console.WriteLine();
            Student student = new Student(name, email);
            college.AddStudent(student);
            Console.WriteLine();
            Console.WriteLine($"Student added successfully! Student ID: {student.StudentID}");
        }


        static void AddCourse(College college)                          // Here I also use helper method to add a course
        {
            Console.WriteLine("\nAdd a new Course:");
            Console.WriteLine();
            Console.Write("Enter course name: ");
            string courseName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter credit hours: ");
            int creditHours;
            if (!int.TryParse(Console.ReadLine(), out creditHours) || creditHours < 0)
            {
                Console.WriteLine("Invalid credit hours. Using default value of 3.");
                creditHours = 3;
            }
            Console.WriteLine();
            myCourse course = new myCourse(courseName, creditHours);
            college.AddCourse(course);

            Console.WriteLine($"Course added successfully! Course ID: {course.CourseID}");
        }

        // Same thing helper method to register a student to a course
        static void RegisterStudentToCourse(College college)
        {
            Console.WriteLine("\nRegister a Student to a Course:");
            Console.WriteLine();
            var students = college.GetStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("No students available. Please add students first.");                                   // Display available student and courses
                return;
            }
            Console.WriteLine();
            Console.WriteLine("\nAvailable Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentID}, Name: {student.Name}");
            }
            Console.WriteLine();
            var courses = college.GetCourses();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available. Please add courses first.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("\nAvailable Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.CourseID}, Name: {course.CourseName}");
            }
            Console.WriteLine();
            Console.Write("\nEnter Student ID: ");
            Console.WriteLine(); 
            int studentId;
            if (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.WriteLine("Invalid Student ID.");
                return;
            }
            Console.WriteLine();
            // Get course ID
            Console.Write("Enter Course ID: ");
            Console.WriteLine();
            int courseId;
            if (!int.TryParse(Console.ReadLine(), out courseId))
            {
                Console.WriteLine("Invalid Course ID.");
                return;
            }
                Console.WriteLine();
                                                                                
           bool success = college.RegisterStudentToCourse(studentId, courseId);          //   When  register student to course

            if (success)
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed. Invalid Student ID or Course ID.");
            }
        }
    }
}
