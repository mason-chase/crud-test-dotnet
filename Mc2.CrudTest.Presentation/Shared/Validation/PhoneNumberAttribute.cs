
using System.ComponentModel.DataAnnotations;


namespace Mc2.CrudTest.Presentation.Shared.Validation
{

    public class PhoneNumberValidateAttribute : ValidationAttribute
    {
        public PhoneNumberValidateAttribute()
        {
            const string defaultErrorMessage = "PhoneNumber is not Valid.";
            ErrorMessage ??= defaultErrorMessage;
        }

        public string PhoneNumber { get; }

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {

            var stringValue = value?.ToString()?.Trim();

            if (string.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult("PhoneNumber is required.");
            }

            if (stringValue.StartsWith("00"))
            {
                // Replace 00 at beginning with +
                stringValue = "+" + stringValue.Remove(0, 2);
            }
            bool validNumber = false;
            try
            {
                var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
                var number = phoneNumberUtil.Parse(stringValue, null);
                validNumber = phoneNumberUtil.IsValidNumber(number);
            }
            catch
            {
                validNumber = false;
            }


            if (!validNumber)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}
