// 代码生成时间: 2025-09-15 09:51:24
 * comments, and adherence to C# best practices for maintainability and scalability.
 */

using System;

namespace XamarinApp.Models
{
    // A simple data model representing a user
    public class User
    {
        // Unique identifier for the user
        public int Id { get; set; }

        // User's full name
        public string FullName { get; set; }

        // User's email address
        public string Email { get; set; }

        // Constructor to create a new User object
        public User(int id, string fullName, string email)
        {
            // Simple validation to ensure the email is not empty
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            Id = id;
            FullName = fullName;
            Email = email;
        }
    }

    // A simple data model representing a product
    public class Product
    {
        // Unique identifier for the product
        public int Id { get; set; }

        // Product name
        public string Name { get; set; }

        // Product price
        public decimal Price { get; set; }

        // Constructor to create a new Product object
        public Product(int id, string name, decimal price)
        {
            // Simple validation to ensure the price is not negative
            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.", nameof(price));
            }

            Id = id;
            Name = name;
            Price = price;
        }
    }
}
