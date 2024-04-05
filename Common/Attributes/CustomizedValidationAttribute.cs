using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomizedValidationAttribute : ValidationAttribute
    {
        public enum ValidationType
        {
            MobileNumber,
        }
        //in case we have multiple types of property validations
        private readonly ValidationType _validationType;

        public CustomizedValidationAttribute(ValidationType validationType)
        {
            _validationType = validationType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var errorMessage = "Please Enter a Valid Phone Number";
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber number = phoneUtil.Parse(value.ToString(), null);
                var isValid = phoneUtil.IsValidNumber(number);
                return isValid ? ValidationResult.Success : new ValidationResult(errorMessage);
            }
            catch (NumberParseException)
            {
                return new ValidationResult(errorMessage);
            }

        }
    }
}
