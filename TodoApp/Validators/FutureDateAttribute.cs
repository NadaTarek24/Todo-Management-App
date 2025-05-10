using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Validators
{
    // Custom validation attribute to ensure a date is in the present or future.
    public class FutureDateAttribute : ValidationAttribute
    {
        // Override IsValid to implement custom validation logic.
        public override bool IsValid(object value)
        {
            // Allow null values — this makes the field optional.
            if (value == null)
                return true; 

            // Check if the input value is a DateTime and whether it's today or in the future.
            if (value is DateTime date)
            {
                return date.Date >= DateTime.Today;
            }
            // If the value is not a DateTime, validation fails.
            return false;
        }
    }
}

