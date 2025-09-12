// 代码生成时间: 2025-09-12 22:37:27
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    // Represents a product that can be added to the cart.
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Represents an item in the shopping cart.
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartService
    {
        private List<CartItem> cartItems = new List<CartItem>();

        // Adds a product to the shopping cart.
        public void AddToCart(Product product, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
            }

            var existingItem = cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        // Removes a product from the shopping cart.
        public void RemoveFromCart(int productId)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.Product.Id == productId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
            else
            {
                throw new InvalidOperationException($"Product with ID {productId} not found in the cart.");
            }
        }

        // Lists all items in the shopping cart.
        public List<CartItem> ListCartItems()
        {
            return cartItems;
        }

        // Clears all items from the shopping cart.
        public void ClearCart()
        {
            cartItems.Clear();
        }
    }
}
