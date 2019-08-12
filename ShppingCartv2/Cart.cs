using System.Collections.Generic;

namespace ShppingCartv2
{
    public class Cart
    {
        private readonly List<CartItem> _items = new List<CartItem>();
        double billAmount = 0.0;
        CartDiscount _cartDiscount = new CartDiscount();

        public void AddItemToCart(CartItem item)
        {
            if (_items.Exists(x => x.Product.ProductName.Contains(item.Product.ProductName)))
            {
                int index = _items.FindIndex(x => x.Product.ProductName.Contains(item.Product.ProductName));
                _items[index].Quantity += item.Quantity;
            }               
                                
            else
                _items.Add(item);
        }

        public void RemoveItemFromCart(CartItem item)
        {
            int index = _items.FindIndex(x => x.Product.ProductName.Contains(item.Product.ProductName));
            if (item.Quantity < _items[index].Quantity)
                _items[index].Quantity -= item.Quantity;
            else
                _items.Remove(item);
        }

        public void ApplyCouponCode(CartCoupon couponCode)
        {
            _cartDiscount.ApplyCoupon(couponCode);
        }
        
        public double CalculateCartBill()
        {
            foreach (var item in _items)
                billAmount += (item.GetPrice() * item.Quantity) * (1 - item.ItemDiscount());
            billAmount = billAmount * (1 - _cartDiscount.GetValue());
            return billAmount;
        }

        public bool CheckItemInCart(CartItem cartItem)
        {
            return (_items.Contains(cartItem))? true : false;
        }

        public int GetItemQuantity(string productName)
        {
            int index = _items.FindIndex(x => x.Product.ProductName.Contains(productName));
            return _items[index].Quantity;
        }

        
    }
}
