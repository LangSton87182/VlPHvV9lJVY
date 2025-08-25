// 代码生成时间: 2025-08-25 17:21:28
 * to specified rules and constraints.
 */

using System;

// Base interface for all validators
public interface IValidator
{
    bool IsValid(object value);
    string ErrorMessage { get; }
}

// Validator for non-empty strings
public class NonEmptyValidator : IValidator
{
    public bool IsValid(object value)
    {
        // Check if the value is a string and not empty or whitespace
        return value is string str && !string.IsNullOrWhiteSpace(str);
    }

    public string ErrorMessage => "Value cannot be empty or whitespace.";
}

// Validator for email addresses
public class EmailValidator : IValidator
{
    public bool IsValid(object value)
    {
        // Check if the value is a string and matches an email pattern
        return value is string str && System.Text.RegularExpressions.Regex.IsMatch(str, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public string ErrorMessage => "Value must be a valid email address.";
}

// Validator for positive integers
public class PositiveIntValidator : IValidator
{
    public bool IsValid(object value)
    {
        // Check if the value is an integer and greater than 0
        if (value is int intValue)
        {
            return intValue > 0;
        }
        return false;
    }

    public string ErrorMessage => "Value must be a positive integer.";
}

// FormValidator class that uses the IValidator interface to validate input
public class FormValidator
{
    private readonly IValidator _validator;

    public FormValidator(IValidator validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public bool Validate(object value)
    {
        try
        {
            return _validator.IsValid(value);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"Validation failed: {ex.Message}");
            return false;
        }
    }

    public string GetErrorMessage()
    {
        return _validator.ErrorMessage;
    }
}
