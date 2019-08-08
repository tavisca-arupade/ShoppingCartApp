using System;

namespace ShppingCartv2
{
    public class CartItem
    {
        public Product product;
        public int quantity;

        public CartItem(string productName, double price, int quantity, Category category)
        {
            product = new Product(productName, price, category);
            this.quantity = quantity;
        }

        public double ItemDiscount()
        {
            return product.CategoryDiscount(product.category);
        }

        public void UpdateQuantity(int quantity)
        {
            this.quantity += quantity;
        }

        public double GetPrice()
        {
            return product.price;
        }

    }
}