namespace Domain;

public class Customer
{
	public int Id { get; set; }
	public string Firstname { get; set; }
	public string Lastname { get; set; }
	public DateTime DateOfBirth { get; set; }

	[System.ComponentModel.DataAnnotations.Required]
	[CustomValidators.PhoneNumber]
	public string PhoneNumber { get; set; }

	[System.ComponentModel.DataAnnotations.Required]
	[System.ComponentModel.DataAnnotations.EmailAddress]
	public string Email { get; set; }

	[System.ComponentModel.DataAnnotations.Required]
	[System.ComponentModel.DataAnnotations.RegularExpression("^\\d{9,18}$")]
	public string BankAccountNumber { get; set; }
}
