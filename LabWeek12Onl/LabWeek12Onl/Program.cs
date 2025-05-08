using System.Data.Common;

namespace LabWeek12Onl
{
    // Files 1) Text eg txt, CSV etc...
    // 2) Data eg Photos etc...
    internal class Program
    {
        public static string Menu()
        {
            Console.WriteLine("1 - Record Sales to a new file");
            Console.WriteLine("2 - Update Sales to an existing file");
            Console.WriteLine("3 - View the existing sales");
            Console.WriteLine("4 -  Update existing sales in existing file");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Enter 1,2,3,4,5: ");
            return Console.ReadLine();
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }

            public double Price { get; set; }

            public override string ToString()
            {
                return $"{Id}, {Name}, {Quantity}, {Price}";
            }

            public static Product CollectUserInformation()


            static void Main(string[] args)
            {
                while (true)
                {
                    var choice = Menu();
                    if (choice == "1") { RecordSalesNewFile(); }
                    else if (choice == "2") { RecordSalesExistingFile(); }
                    else if (choice == "3") { ViewTheExistingFile(); }
                    else if (choice == "4") { UpdateExistingSales(); }
                    else if (choice == "5") { break; }
                    else
                    {
                        Console.WriteLine("Bad choice Try Again");
                        Console.Clear();
                    }
                }











                /*
                string[] name = { "Benz Stephen", "Jaylyn Chavez" };

                File.WriteAllLines("loverNames.txt", name);


                string[] output = File.ReadAllLines("loverNames.txt");

                foreach (var line in output)  // Dumping Information
                {
                    Console.WriteLine(line);
                }

                // Two streamers
                // 1) StreamReader
                // 2) StreamWriter

                StreamReader sr = new StreamReader("loverNames.txt");

                string line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();           // You need to have enough memory to store
                } */

                //---------------------------------------------------------------


            }

            private static void UpdateExistingSales()
            {
                throw new NotImplementedException();
            }

            private static void ViewTheExistingFile()
            {
                throw new NotImplementedException();
            }

            private static void RecordSalesExistingFile()
            {
                throw new NotImplementedException();
            } 

    

              private static void RecordSalesNewFile()
             {
            throw new NotImplementedException();
            }
 
