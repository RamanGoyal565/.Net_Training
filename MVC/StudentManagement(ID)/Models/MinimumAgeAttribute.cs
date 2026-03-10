using System.ComponentModel.DataAnnotations;
namespace StudentManagement_ID_.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of birth is required");

            DateTime dateOfBirth = (DateTime)value;

            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-age))
                age--;

            if (age < _minimumAge)
                return new ValidationResult($"Minimum age required is {_minimumAge}");

            return ValidationResult.Success;
        }
    }
}