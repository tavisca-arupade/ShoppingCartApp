using System;
using Xunit;
using ShppingCartv2;
using FluentAssertions;

namespace ShoppingCartTestProject
{
    public class ShoopingCartTestClass
    {
        [Theory]
        [InlineData(true,"boots", 1000, 1, Category.Footwear)]
        [InlineData(true, "tees", 1500, 3, Category.Clothing)]
        [InlineData(true, "books", 1000, 2, Category.Education)]
        public void Test_to_add_item_to_cart(bool result, string product, double price, int quantity, Category category )
        {
            Cart cart = new Cart();
            CartItem cartItem = new CartItem(product,price,quantity,category);

            cart.AddItemToCart(cartItem);

            var actualResult = cart.CheckItemInCart(cartItem);

            actualResult.Should().Be(result);

        }

        [Theory]
        [InlineData(false, "boots", 1000, 1, Category.Footwear)]
        [InlineData(false, "tees", 1500, 3, Category.Clothing)]
        [InlineData(false, "books", 1000, 2, Category.Education)]
        public void Test_to_remove_item_from_cart(bool result, string product, double price, int quantity, Category category)
        {
            Cart cart = new Cart();
            CartItem cartItem = new CartItem(product, price, quantity, category);

            cart.AddItemToCart(cartItem);
            cart.RemoveItemFromCart(cartItem);

            var actualResult = cart.CheckItemInCart(cartItem);

            actualResult.Should().Be(result);

        }

        [Theory]
        [InlineData(600, "boots", 1000, 1, Category.Footwear)]
        [InlineData(4050, "tees", 1500, 3, Category.Clothing)]
        [InlineData(1600, "books", 1000, 2, Category.Education)]
        public void Test_to_calculate_cart_bill_when_coupon_code_not_applied(double result, string product, double price, int quantity, Category category)
        {
            Cart cart = new Cart();
            CartItem cartItem = new CartItem(product, price, quantity, category);

            cart.AddItemToCart(cartItem);

            var actualResult = cart.CalculateCartBill();
            
            actualResult.Should().Be(result);

        }

        [Theory]
        [InlineData(2475,CartCoupon.SAVE10)]
        [InlineData(2200,CartCoupon.SAVE20)]
        [InlineData(1924.9999999999998, CartCoupon.SAVE30)]
        public void Test_to_calculate_cart_bill_when_coupon_code_applied(double result, CartCoupon cartCoupon)
        {
            Cart cart = new Cart();
            CartItem cartItem1 = new CartItem("boots", 1000, 1, Category.Footwear);
            CartItem cartItem2 = new CartItem("tees", 500, 3, Category.Clothing);
            CartItem cartItem3 = new CartItem("books", 500, 2, Category.Education);

            cart.AddItemToCart(cartItem1);
            cart.AddItemToCart(cartItem2);
            cart.AddItemToCart(cartItem3);

            cart.ApplyCouponCode(cartCoupon);

            var actualResult = cart.CalculateCartBill();

            actualResult.Should().Be(result);
        }

        [Fact]

        public void Test_when_item_already_in_cart_while_adding_should_update_quantity()
        {
            Cart cart = new Cart();
            CartItem cartItem1 = new CartItem("boots", 1000, 1, Category.Footwear);
            CartItem cartItem2 = new CartItem("tees", 500, 3, Category.Clothing);
            CartItem cartItem3 = new CartItem("boots", 1000, 2, Category.Footwear);

            cart.AddItemToCart(cartItem1);
            cart.AddItemToCart(cartItem2);
            cart.AddItemToCart(cartItem3);

            Assert.Equal(3, cart.GetItemQuantity("boots"));
        }

        [Fact]

        public void Test_when_item_already_in_cart_while_removing_should_update_quantity()
        {
            Cart cart = new Cart();
            CartItem cartItem1 = new CartItem("boots", 1000, 2, Category.Footwear);
            CartItem cartItem2 = new CartItem("tees", 500, 3, Category.Clothing);
            CartItem cartItem3 = new CartItem("boots", 1000, 1, Category.Footwear);

            cart.AddItemToCart(cartItem1);
            cart.AddItemToCart(cartItem2);
            cart.RemoveItemFromCart(cartItem3);

            Assert.Equal(1, cart.GetItemQuantity("boots"));
        }
    }
}
