using System.ComponentModel.DataAnnotations;

namespace todoApi;

// This class is used to validate that the collection contains distinct values.
public class UniqueTodoIdAttribute : ValidationAttribute
    {
        // The default error message is used if no error message is provided.
        public UniqueTodoIdAttribute()
        {
            ErrorMessage = $"The collection should contain distinct values";
        }

        // The error message can be set to a custom value.
        public UniqueTodoIdAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        // The IsValid method is used to validate the value.
        public override bool IsValid(object value)
        {
            // The value is cast to an enumerable of objects.
            var values = value as IEnumerable<object>;

            // If the value is not null and contains values, the distinct values are counted and compared to the original values.
            if (values != null && values.Any())
            {
                return values.Distinct().Count() == values.Count();
            }

            // If the value is null or empty, the value is valid.
            return true;
        }
    }