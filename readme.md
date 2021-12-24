# CRUD Code Test 

Please read each note very carefully!
Feel free to add/change project structure to a clean architecture to your view.
and if you are not able to work on FrontEnd project, you can add a Swagger UI
in a new Front project.

Create a simple CRUD application with ASP NET Core that implements the below model:
```
Customer {
	FirstName
	LastName
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and patterns (Must):

- Tdd and Bdd.
- CQRS pattern.
- Clean git commits that shows your work progress.

### Validations (Must)

- During Create; validate the phone number to be a valid mobile number only.

- A Valid email and a valid account number must be checked before submitting the form.
- You can use [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend:


### Storage (Must)

- Store the phone number in a database with minimized space storage (choose varchar, or `ulong` whichever store less space).
- Email must be unique in the database

## Nice to do:
- Blazor Web.
- Docker-compose project that loads database service automatically which `docker-compose up`

Please clone this repository in a new github repository in private mode and share with ID: `mason-chase` in private mode on github.com
