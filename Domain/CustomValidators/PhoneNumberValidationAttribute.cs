using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace Domain.CustomValidators;

public class PhoneNumber : ValidationAttribute
{
	public PhoneNumber()
	{
		ErrorMessage = "Phone Number is not valid!";
	}

	protected override ValidationResult IsValid(object value, ValidationContext validationContext)
	{
		// Add your custom validation logic here
		if (value != null && !IsValueValid(value))
		{
			return new ValidationResult(ErrorMessage);
		}

		return ValidationResult.Success;
	}

	private bool IsValueValid(object value)
	{
		bool blnResult = false;
		PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

		try
		{
			string strPhoneNumber = (string)value;

			var number = phoneUtil.Parse(strPhoneNumber.Substring(3), strPhoneNumber.Substring(0, 3));

			blnResult = phoneUtil.IsValidNumber(number);
		}
		catch
		{
			blnResult = false;
		}

		return (blnResult);
	}
}
