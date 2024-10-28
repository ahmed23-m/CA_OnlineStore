
internal partial class Program
{
    public class Order
    {
        public int OrderID { get; init; }
        public DateTime OrderDate { get; init; }
        public Customer? Customer { get; init; }
        public List<Product>? Products { get; set; }
        private string? GetListofOrderProducts()
        {
            string? listofOrderProducts = "";
            if (Products is not null)
            {
                foreach (var product in Products)
                {
                    listofOrderProducts += product.ToString();
                    listofOrderProducts += $"\n\n\t{' ',-32}{product.Price:C} x {product.Quantity} = {product.Price * product.Quantity:C}\n\n";
                }
            }
            return listofOrderProducts;
        }
        public decimal CalculateTotalPrice()
        {
            //Calculates the total price of all products in the order.
            if(Products is null ||Products.Count == 0) return decimal.Zero;

            decimal totalPrice = 0;

            foreach (var product in Products)
            {
                totalPrice += product.Price * product.Quantity;
            }
            return totalPrice;
        }
        public override string ToString()
        {
            return $"OrderID: #{OrderID}\nOrderDate: {OrderDate.ToString("yyyy/MMM/dd hh:mm")}\tExpected Dilevery Date: {OrderDate.AddDays(3).ToString("yyyy/MMM/dd")}\n" +
                $"Customer Name: {Customer?.Name}\nAddress: {Customer?.Address}\n" +
                $"\n========================[ List of Order Products ]========================\n\n" +
                $"{GetListofOrderProducts()}" +
                "\n\n==========================================================================\n\n" +
                $"TotalPrice: {CalculateTotalPrice():C}\n";
        }
    }
}