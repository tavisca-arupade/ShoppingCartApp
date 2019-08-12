using System;

namespace ShppingCartv2
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get;  set; }

        public CartItem(string productName, double price, int quantity, Category category)
        {
            Product = new Product(productName, price, category);
            this.Quantity = quantity;
        }

        public double ItemDiscount()
        {
            return Product.CategoryDiscount(Product.Category);
        }

        public void UpdateQuantity(int quantity)
        {
            this.Quantity += quantity;
        }

        public double GetPrice()
        {
            return Product.Price;
        }

    }
}