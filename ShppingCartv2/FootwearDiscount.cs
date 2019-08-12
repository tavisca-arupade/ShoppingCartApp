namespace ShppingCartv2
{
    public class FootwearDiscount : IDiscount
    {
        public double _discount = 0.4;

        public double GetValue()
        {
            return _discount;
        }
    }
}