// 代码生成时间: 2025-08-25 02:59:31
/// <summary>
/// Service for managing shopping cart functionality.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a product in the shopping cart.
/// </summary>
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

/// <summary>
/// Represents an item in the shopping cart with quantity.
/// </summary>
public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

/// <summary>
/// Shopping cart service class.
/// </summary>
public class ShoppingCartService
{
    private readonly List<CartItem> _items = new List<CartItem>();

    /// <summary>
    /// Adds a product to the shopping cart.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="quantity">The quantity of the product to add.</param>
    public void AddToCart(Product product, int quantity)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

        var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem { Product = product, Quantity = quantity });
        }
    }

    /// <summary>
    /// Removes a product from the shopping cart.
    /// </summary>
    /// <param name="productId">The ID of the product to remove.</param>
    public void RemoveFromCart(int productId)
    {
        var itemToRemove = _items.FirstOrDefault(item => item.Product.Id == productId);
        if (itemToRemove != null)
        {
            _items.Remove(itemToRemove);
        }
        else
        {
            throw new KeyNotFoundException($"No product with ID {productId} found in the cart.");
        }
    }

    /// <summary>
    /// Updates the quantity of a product in the shopping cart.
    /// </summary>
    /// <param name="productId">The ID of the product to update.</param>
    /// <param name="newQuantity">The new quantity of the product.</param>
    public void UpdateQuantity(int productId, int newQuantity)
    {
        if (newQuantity < 0) throw new ArgumentOutOfRangeException(nameof(newQuantity), "Quantity cannot be negative.");

        var itemToUpdate = _items.FirstOrDefault(item => item.Product.Id == productId);
        if (itemToUpdate != null)
        {
            itemToUpdate.Quantity = newQuantity;
        }
        else
        {
            throw new KeyNotFoundException($"No product with ID {productId} found in the cart.");
        }
    }

    /// <summary>
    /// Gets the total number of items in the shopping cart.
    /// </summary>
    /// <returns>The total number of items.</returns>
    public int GetTotalItems()
    {
        return _items.Sum(item => item.Quantity);
    }

    /// <summary>
    /// Gets the total cost of items in the shopping cart.
    /// </summary>
    /// <returns>The total cost.</returns>
    public decimal GetTotalCost()
    {
        return _items.Sum(item => item.Product.Price * item.Quantity);
    }

    /// <summary>
    /// Clears the shopping cart.
    /// </summary>
    public void ClearCart()
    {
        _items.Clear();
    }
}
