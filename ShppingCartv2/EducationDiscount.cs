namespace ShppingCartv2
{
    public class EducationDiscount : IDiscount
    {
        public double _discount  = 0.2; 

        public double GetValue()
        {
            return _discount;
        }
    }
}