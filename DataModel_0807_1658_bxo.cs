// 代码生成时间: 2025-08-07 16:58:49
using System;

namespace XamarinApp.Models
{
    // Define a simple data model with properties and error handling.
    public class DataModel
    {
        // Auto-implemented property with a private field.
        public string Name { get; set; }
        
        // Auto-implemented property with a private field.
        public int Age { get; set; }

        // Constructor to initialize the data model.
        public DataModel(string name, int age)
        {
            // Error handling for invalid age.
            if (age < 0)
            {
                throw new ArgumentException("Age cannot be negative.", nameof(age));
            }

            Name = name;
            Age = age;
        }

        // Method to display the data model information.
        public string DisplayInfo()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
