using Core.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Core.Validators
{
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly string _type;

        public UniqueAttribute(string type)
        {
            _type = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"{_type} is required.");
            }

            var userRepo = (IUserRepository)validationContext.GetService(typeof(IUserRepository));
            bool exists;
            if (_type == "Username")
            {
                exists = userRepo.IsUsernameTaken(value.ToString());
            }
            else if (_type == "Email")
            {
                exists = userRepo.IsEmailTaken(value.ToString());
            }
            else
            {
                throw new ArgumentException("Invalid type for uniqueness check.");
            }

            if (exists)
            {
                return new ValidationResult($"{_type} already exists.");
            }

            return ValidationResult.Success;
        }
    }
    public class AlphabeticAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str && str.All(char.IsLetter))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The field must contain only alphabetic characters.");
        }
    }

    public class AlphaNumericAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string str && str.All(char.IsLetter))
            {
                return ValidationResult.Success;
            }
            else if (value is string numeric && numeric.All(char.IsNumber))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("The field must contain only alphabetic characters.");
        }
    }
}
