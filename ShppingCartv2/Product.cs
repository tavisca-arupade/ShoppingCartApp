namespace ShppingCartv2
{
    public class Product
    {
        public string ProductName { get; private set; }
        public double Price { get; private set; }
        public Category Category { get; private set; }
        DiscountFactory discountFactory = new DiscountFactory();
        

        public Product(string productName, double price, Category category)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        public double CategoryDiscount(Category category)
        {
            IDiscount discount = discountFactory.GetDiscount(category);
            return discount.GetValue();
        }
    }
}