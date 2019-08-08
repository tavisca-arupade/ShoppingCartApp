namespace ShppingCartv2
{
    public class Product
    {
        public string productName;
        public double price;
        public Category category;
        DiscountFactory discountFactory = new DiscountFactory();
        

        public Product(string productName, double price, Category category)
        {
            this.productName = productName;
            this.price = price;
            this.category = category;
        }

        public double CategoryDiscount(Category category)
        {
            IDiscount discount = discountFactory.GetDiscount(category);
            return discount.GetValue();
        }
    }
}