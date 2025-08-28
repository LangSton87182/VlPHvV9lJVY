// 代码生成时间: 2025-08-29 06:38:44
using System;
using System.Collections.Generic;
using System.Linq;

// Represents a product that can be added to the cart
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

// Represents a shopping cart
public class ShoppingCart
{
    private List<CartItem> items = new List<CartItem>();

    // Adds a product to the cart
    public void AddProduct(Product product, int quantity)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null.");
        }

        var existingItem = items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            items.Add(new CartItem { ProductId = product.Id, ProductName = product.Name, Price = product.Price, Quantity = quantity });
        }
    }

    // Removes a product from the cart
    public void RemoveProduct(int productId)
    {
        var itemToRemove = items.FirstOrDefault(i => i.ProductId == productId);
        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }
        else
        {
            throw new InvalidOperationException($"Product with ID {productId} does not exist in the cart.");
        }
    }

    // Represents a cart item
    private class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    // Gets the total price of all items in the cart
    public decimal GetTotalPrice()
    {
        return items.Sum(item => item.Price * item.Quantity);
    }

    // Gets the total number of items in the cart
    public int GetTotalQuantity()
    {
        return items.Sum(item => item.Quantity);
    }
}

// Example usage of ShoppingCart
public class CartServiceExample
{
    public static void Main(string[] args)
    {
        var cart = new ShoppingCart();
        var product1 = new Product { Id = 1, Name = "Product 1", Price = 10.99m };
        var product2 = new Product { Id = 2, Name = "Product 2", Price = 22.99m };

        try
        {
            // Add products to the cart
            cart.AddProduct(product1, 2);
            cart.AddProduct(product2, 1);

            // Display cart total
            Console.WriteLine($"Total Price: {cart.GetTotalPrice()}");
            Console.WriteLine($"Total Quantity: {cart.GetTotalQuantity()}");

            // Remove a product from the cart
            cart.RemoveProduct(1);

            // Display cart total after removal
            Console.WriteLine($"Total Price after removal: {cart.GetTotalPrice()}");
            Console.WriteLine($"Total Quantity after removal: {cart.GetTotalQuantity()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}