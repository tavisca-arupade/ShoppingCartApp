namespace ShppingCartv2
{
    public class ClothingDiscount : IDiscount
    {
        public double _discount = 0.1;

        public double GetValue()
        {
            return _discount;
        }
    }
}