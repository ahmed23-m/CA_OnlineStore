
internal partial class Program
{
    public class Customer
    {
        public string? Name { get; init; }
        public string? Address { get; init; }
        public Customer(string? name, string? address)
        {
            Name = name;
            Address = address;
        }

        public Order PlaceOrder(List<Product> products)
        {
            // Places an order for a list of products
            return new()
            {
                OrderID = new Random().Next(1, 1000),// Generate a random order ID for demonstration
                OrderDate = DateTime.Now,// Get the Current DateTime for the order
                Customer = this,
                Products = products
            };
        }
    }
}