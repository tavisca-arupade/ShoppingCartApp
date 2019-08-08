using System.Collections.Generic;

namespace ShppingCartv2
{
    public class Cart
    {
        public List<CartItem> _items = new List<CartItem>();
        double billAmount = 0.0;
        CartDiscount _cartDiscount = new CartDiscount();

        public void AddItemToCart(CartItem item)
        {
            if (_items.Exists(x => x.product.productName.Contains(item.product.productName)))
            {
                int index = _items.FindIndex(x => x.product.productName.Contains(item.product.productName));
                _items[index].quantity += item.quantity;
            }               
                                
            else
                _items.Add(item);
        }

        public void RemoveItemFromCart(CartItem item)
        {
            int index = _items.FindIndex(x => x.product.productName.Contains(item.product.productName));
            if (item.quantity < _items[index].quantity)
                _items[index].quantity -= item.quantity;
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
                billAmount += (item.GetPrice() * item.quantity) * (1 - item.ItemDiscount());
            billAmount = billAmount * (1 - _cartDiscount.GetValue());
            return billAmount;
        }

        public bool CheckItemInCart(CartItem cartItem)
        {
            return (_items.Contains(cartItem))? true : false;
        }

        public int GetItemQuantity(string productName)
        {
            int index = _items.FindIndex(x => x.product.productName.Contains(productName));
            return _items[index].quantity;
        }

        
    }
}
