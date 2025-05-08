namespace LabTest2_Onl
{
    // Benz Stephen


    // UML  Diag for reference 

    /* +---------------------------------------------------------------+
    |                           Product                             |
    +---------------------------------------------------------------+
    | - productId: int                                              |
    | - productName: string                                           |
    | - price: double                                                 |
    | - ratings: double[]                                             |
    +---------------------------------------------------------------+
    | + Product()                                                   |
    | + Product(productName: string, price: double)                   |
    | + Product(productName: string, price: double, ratings: double[])  |
    | + ProductId: int { get; }                                       |
    | + ProductName: string { get; set; }                              |
    | + Price: double { get; set; }                                    |
    | + Ratings: double[] { get; set; }                                |
    | + GetAverageRating(): double                                    |
    | + ToString(): string                                            |
    +---------------------------------------------------------------+ */

    internal class Product     // This classs represent a product that customers can rate
    {
        private static int nextId = 1;      // This is counter to create unique IDs for each product


        private int productId;
        private string productName;  // Important Infos about the products below
        private double price;
        private double[] ratings;

        public Product()
        {
            this.productId = nextId++;
            this.productName = "Unnamed";
            this.price = 0.0;
            this.ratings = new double[0];
        }
        public Product(string productName, double price)
        {
            this.productId = nextId++;
            this.productName = productName;                 // Thios creates a product when we know its name and price
            this.price = price;
            this.ratings = new double[0];
        }

        // The  complete product with name, price, and ratings
        public Product(string productName, double price, double[] ratings)
        {
            this.productId = nextId++;
            this.productName = productName;
            this.price = price;

            // Make a copy of the ratings
            this.ratings = new double[ratings.Length];
            Array.Copy(ratings, this.ratings, ratings.Length);
        }
        public int ProductId
        {
            get { return productId; }
      }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }        // Get or change the product's name
        }


        public double Price
        {
            get { return price; }           // Same thing  Get or change s the product price 
            set { price = value; }
       }
        public double[] Ratings
        {
            get { return ratings; }
            set
            {
                ratings = new double[value.Length];
                Array.Copy(value, ratings, value.Length);
            }
        }
        public double GetAverageRating()
        {
            if (ratings.Length == 0)
            {
              return 0.0;               // Calculating the average rating of the product
            }
            double sum = 0;
            foreach (double rating in ratings)
            {
                sum += rating;
            } 
            return sum / ratings.Length;
        }
        public override string ToString()
        {
            string result = $"Product ID: {productId}\n";
            result += $"Name of the Product: {productName}\n";
            result += $"Price: ${price:F2}\n";
            result += "Ratings: ";


            if (ratings.Length == 0)
            {
                result += "No ratings yet";
            }
            else
            {
                result += string.Join(", ", ratings);
                // Removed the average rating line here
            }
            return result;
        }
    }
    internal class Program     // Main program  that shows how to use the Product class

    {
        static void Main(string[] args)
        {

            Product[] inventory = new Product[3];             // Thios code creates a list for 3 products

            inventory[0] = new Product();
            inventory[1] = new Product("RTX 5090", 1999.99); // This is the a list for 3 products
            inventory[1].Ratings = new double[] { 4.8, 5.0, 4.7, 4.9 };

            double[] IphoneRatings = { 4.5, 5.0, 4.4, 4.8, 3.9 };
            inventory[2] = new Product("Iphone 16 Pro Max", 1799.99, IphoneRatings);


            // RAM 
            inventory[0].ProductName = "RAM";
            inventory[0].Price = 199.99;
            inventory[0].Ratings = new double[] { 3.0, 2.5, 3.5 };


            // Print all the products Info
            Console.WriteLine("=============================== Product Information: =============================");
            Console.WriteLine(); // Empty CW to create space to make it look good 
            foreach (Product product in inventory)
            {
               Console.WriteLine(product);
               Console.WriteLine($"Average Rating: {product.GetAverageRating():F1}\n");
            }

            Product highestRatedProduct = FindHighestRatedProduct(inventory); 
            
            // This finds and showw the highest rated product

            // I add spaces each to make look good
           Console.WriteLine("Product with the Highest Rating:");
           Console.WriteLine();
           Console.WriteLine("-------------------------------------------------------------------------------------------");
           Console.WriteLine();
           Console.WriteLine($"The highest rated product is '{highestRatedProduct.ProductName}' with an average rating of {highestRatedProduct.GetAverageRating():F1}");
           Console.WriteLine();
           Console.WriteLine("\nPlease press anything in keyboard to exit the program");
           Console.ReadKey();
        }

       // This finds the products with the highest average rating
        static Product FindHighestRatedProduct(Product[] products)
        {
            if (products == null || products.Length == 0)
            {
            return null;
            }
            Product highestRated = products[0];
            double highestRating = products[0].GetAverageRating();

          for (int i = 1; i < products.Length; i++)
            {
                double currentRating = products[i].GetAverageRating();
              if (currentRating > highestRating)
                {
                   highestRated = products[i];
                   highestRating = currentRating;
               }
           }
          return highestRated;
        }
    }
}