
internal partial class Program
{
    public class ElectronicsProduct : Product
    {
        public string? Brand { get; init; }
        public string? Model { get; init; }
        public DateOnly ProductionDate { get; init; }
        public ElectronicsProduct() { }
        public ElectronicsProduct(string name, decimal price, int quantity,
                                  string brand,string model, DateOnly productionDate) : base(name, price, quantity) { }
        public void DisplaySpecs()
        {
            Console.WriteLine($"{base.ToString()}\nBrand: {Brand}\tModel: {Model}\tProductionDate{ProductionDate.ToString("yyyy:MM:dd")}");
        }
    }
}