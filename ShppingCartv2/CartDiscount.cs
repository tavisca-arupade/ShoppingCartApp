namespace ShppingCartv2
{
    public class CartDiscount : IDiscount
    {
        double discount = 0.0;

        public void ApplyCoupon(CartCoupon cartCoupon)
        {
            double.TryParse(cartCoupon.GetHashCode().ToString(), out discount);
            discount = discount / 100;
        }
        public double GetValue()
        {
            return discount;
        }
    }
}