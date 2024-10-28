
internal partial class Program
{
    public class ClothingProduct : Product
    {
        public enum Size
        {
            S,
            M,
            L,
            XL,
            XXL,
            XXXL,
            XXXXL
        }
        public Size? Cloth_Size { get; init; }
        public string? Color { get; init; }

        public static bool CheckAvailability(List<ClothingProduct> clothesList, ClothingProduct cloth)
        {
            //Checks if the product is available in the desired size and color.
            return clothesList.Contains(cloth);
        }
        public static bool operator ==(ClothingProduct left,ClothingProduct right)
        {
            if (left is not null && right is not null)
            {
                return (left.Color == right.Color) && (left.Cloth_Size == right.Cloth_Size);
            }
            return false;
        }
        public static bool operator !=(ClothingProduct left,ClothingProduct right)
        { 
            return !(left == right); 
        }
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not ClothingProduct otherCloth) 
                return false;

            return this == otherCloth;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Cloth_Size, Color);
        }
    }
}