
internal partial class Program
{
    public class Product
    {
        public string? Name { get; init; }
        public decimal Price { get; init; }
        public int Quantity { get; set; }
        public Product() { }

        public Product(string? name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string CalculateTotalPrice() => $"TotalStockPrice: {(Price * Quantity):C}";
        public static void PrintListOfProducts<T>(List<Product> products)
        {
            int index = 1;
            foreach (var item in products.OfType <T> ())
            {
                Console.Write($"[{index++}]");
                Console.WriteLine($"\t{item}");                
            }
        }
        public static Product? ModifyStockProduct(Product? product, int quantity)
        {
            if (product is null) { return null; }

            // Modify the Product quantity
            product.Quantity -= quantity;

            // Check for the Typeof Product
            if(product is ElectronicsProduct)
            {
                var obj = product as ElectronicsProduct;
                if(obj is null) { return null; }
                return new ElectronicsProduct()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    Brand = obj.Brand,
                    Model = obj.Model,
                };
            }
            else if(product is ClothingProduct) 
            {
                var obj = product as ClothingProduct;
                if (obj is null) { return null; }
                return new ClothingProduct()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    Cloth_Size = obj.Cloth_Size,
                    Color = obj.Color,
                };
            }
            else { return null; }

        }
        public override string ToString()
        {
            return $"Product Name: {Name,-20}\tUnit Price: {Price:C}\tQuantity: {Quantity}";
        }
    }
}