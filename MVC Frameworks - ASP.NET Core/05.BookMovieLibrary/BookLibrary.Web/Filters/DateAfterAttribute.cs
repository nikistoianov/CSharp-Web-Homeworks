using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Web.Filters
{
    public class DateAfterAttribute : ValidationAttribute
    {
        private readonly string otherPropertyName;

        public DateAfterAttribute(string otherPropertyName) 
        {
            this.otherPropertyName = otherPropertyName;
        }

        public DateAfterAttribute(string otherPropertyName, string errorMessage) : base (errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;
            var otherProperty = validationContext.ObjectType.GetProperty(otherPropertyName);
            if (otherProperty == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = (DateTime)otherProperty.GetValue(validationContext.ObjectInstance);
            if (currentValue <= comparisonValue)
                return new ValidationResult(this.ErrorMessageString);

            return ValidationResult.Success;
        }
    }
}
