
using System.Collections.Generic;
using static Program;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var products = new List<Product>()
{
    new ElectronicsProduct()
    {
        Name = "QLED Smart Tv 40\"",
        Price = 120M,
        Quantity = 35,
        Brand = "Samsung",
        Model = "QLED-40H12",
        ProductionDate = new DateOnly(2024,1,15)
    },
    new ElectronicsProduct()
    {
        Name = "Laptop",
        Price = 850M,
        Quantity = 20,
        Brand = "Dell",
        Model = "XPS 13",
        ProductionDate = new DateOnly(2023, 5, 10)
    },
    new ElectronicsProduct()
    {
        Name = "Smartphone",
        Price = 600M,
        Quantity = 50,
        Brand = "Apple",
        Model = "iPhone 14",
        ProductionDate = new DateOnly(2023, 9, 5)
    },
    new ClothingProduct
    {
        Name = "Polo Tshirt",
        Price = 25.75M,
        Quantity = 60,
        Cloth_Size = ClothingProduct.Size.M,
        Color = "Red"
    },
    new ClothingProduct
    {
        Name = "Denim Jeans",
        Price = 45.99M,
        Quantity = 40,
        Cloth_Size = ClothingProduct.Size.L,
        Color = "Blue"
    },
    new ClothingProduct
    {
        Name = "Winter Jacket",
        Price = 120.50M,
        Quantity = 15,
        Cloth_Size = ClothingProduct.Size.XL,
        Color = "Black"
    },
    new Product()
    {
        Name = "Generic Notebook",
        Price = 2.50M,
        Quantity = 100
    },
    new Product()
    {
        Name = "Water Bottle",
        Price = 10.00M,
        Quantity = 75
    },
    new ElectronicsProduct()
    {
        Name = "Smart Watch",
        Price = 200M,
        Quantity = 30,
        Brand = "Fitbit",
        Model = "Versa 3",
        ProductionDate = new DateOnly(2024, 2, 20)
    },
    new ClothingProduct
    {
        Name = "Sneakers",
        Price = 70.00M,
        Quantity = 25,
        Cloth_Size = ClothingProduct.Size.L,
        Color = "White"
    }
};
        var EscapePressed = false;
        DisplayMenu();
        while (!EscapePressed)
        {
            Console.Write("\n> ");
            var option = Console.ReadKey();
            Console.Clear();
            DisplayMenu();
            switch (option.KeyChar)
            {
                case '1':
                    Console.WriteLine("\nAll Products:\n");
                    Product.PrintListOfProducts<Product>(products);
                    break;

                case '2':
                    Console.WriteLine("\nElectronics Products:\n");
                    Product.PrintListOfProducts<ElectronicsProduct>(products);
                    break;

                case '3':
                    Console.WriteLine("\nClothing Products:\n");
                    Product.PrintListOfProducts<ClothingProduct>(products);
                    break;

                case '4':
                    // Clear Screen
                    Console.Clear();
                    Console.WriteLine("\nPlacing an Order:\n");
                    HandleOrder(products);
                    Console.Write("Press Enter To go to Main menu: > ");
                    if(Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        DisplayMenu();
                    }
                    break;

                case (char)ConsoleKey.Escape:
                    EscapePressed = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please choose a valid option.");
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Thanks For using Our Online Store System");
    }
    private static void DisplayMenu()
    {
        Console.WriteLine("\t\t================[ Welcome To Our Online Store ]================");
        Console.WriteLine("\n\t\tPlease Select Between these options: (or press Esc to exit)\n\n" +
                              "\t\t[1]View All Products\t\t[2]View Electronics Products\n" +
                              "\n\t\t[3]View Clothing Products\t[4]Place an Order");
        Console.Write("\n\n\t\t===============================================================\n");
    }
    private static void HandleOrder(List<Product> products)
    {
        string str = new string('=', 85);
        Console.WriteLine(str + "\n");
        Product.PrintListOfProducts<Product>(products);
        Console.WriteLine("\n" + str);
        List<Product> OrderList = new List<Product>();

        #region GET Order Products

        bool continueOrdering = true;

        while (continueOrdering)
        {
            Console.Write("\nPlease Select the Product Number you are interested in (or press Enter): ");
            var input = Console.ReadLine();

            if (input == "")
            {
                Console.Clear();
                Console.WriteLine("\nSTATUS: Order is Cofirmed.");
                continueOrdering = false;
                break;
            }

            Console.WriteLine();

            //Get Product index
            if (int.TryParse(input, out int number) && number > 0 && number <= products.Count)
            {
                //Get Product Quantity
                Console.Write("Please Enter the Quantity of this product: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    // Check if requested quantity is available in stock
                    if (quantity <= products[--number].Quantity)
                    {
                        Product? product = Product.ModifyStockProduct(products[number], quantity);

                        // Add the Product to the OrderList
                        if (product is not null)
                        {
                            OrderList.Add(product);
                            Console.WriteLine($"\nSTATUS: {quantity} x {product.Name} Added Successfully!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Stock. Only {0} available.", products[number].Quantity);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Quantity Entered. Please enter a positive integer.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Number Entered");
            }
        }
        #endregion
        #region GET Customer Information 

        bool validInput = false;
        string? name = "";
        string? address = "";

        while (!validInput)
        {
            Console.Write("\nPlease Enter Your Name: ");
            name = Console.ReadLine();

            Console.Write("\nPlease Enter Your Address: ");
            address = Console.ReadLine();

            // Basic validation: Check for empty strings
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Name and address cannot be empty. Please try again.");
            }
            else
            {
                validInput = true;
            }
        }

        Customer customer = new(name, address);

        #endregion

        // Clear Screen
        Console.Clear();

        // Place a new Order
        Console.WriteLine(customer.PlaceOrder(OrderList));
    }
}