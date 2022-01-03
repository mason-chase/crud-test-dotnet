# CRUD Code Test 

Please read each note very carefully!
Feel free to add/change project structure to a clean architecture to your view.
and if you are not able to work on FrontEnd project, you can add a Swagger UI
in a new Front project.

Create a simple CRUD application with ASP NET Core that implements the below model:
```
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Practices and patterns (Must):

- Tdd and Bdd.
- Clean acrhitecture.
- At least a basic CQRS pattern (Refer to tutorial from [Nick Chapsas](https://www.youtube.com/watch?v=YzOBrVlthMk) or [Tim Corey](https://www.youtube.com/watch?v=yozD5Tnd8nw)).
- Clean git commits that shows your work progress.

### Validations (Must)

- During Create; validate the phone number to be a valid *mobile* number only (You can use [Google LibPhoneNumber](https://github.com/google/libphonenumber) to validate number at the backend).

- A Valid email and a valid account number must be checked before submitting the form.

- Customers must be unique in database: By `Firstname`, `Lastname` and `DateOfBirth`.

- Email must be unique in the database.

### Storage (Must)

- Store the phone number in a database with minimized space storage (choose `varchar`/`string`, or `ulong` whichever store less space).

## Nice to do:
- Blazor Web.
- Docker-compose project that loads database service automatically which `docker-compose up`

Please clone this repository in a new github repository in private mode and share with ID: `mason-chase` in private mode on github.com
