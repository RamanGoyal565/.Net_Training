using System.ComponentModel.DataAnnotations;

namespace EmployeeAppl.Models
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
            DateTime dob = (DateTime)value;
            if (dob > DateTime.Today)
                return new ValidationResult("Date Of Birth cannot be in the future");
            int age = DateTime.Today.Year - dob.Year;
            if (dob.Date > DateTime.Today.AddYears(-age))
                age--;
            if (age < _minimumAge)
                return new ValidationResult($"Employee must be at least {_minimumAge} years old");
            return ValidationResult.Success;
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Name is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Address is Required")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Address must be between 5 and 100 characters")]
        public string Address { get; set; }
        
        [Required(ErrorMessage ="Adhaar is Required")]
        [Range(100000000000,999999999999,ErrorMessage = "Adhaar must be a 12-digit number")]
        public long Adhaar { get; set; }

        [Required(ErrorMessage ="Date Of Birth is Required")]
        [DataType(DataType.Date)]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }
    }
}
