namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public sealed class CustomerManagerStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public CustomerManagerStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I have entered FirstName ""([^""]*)""")]
        public void GivenIHaveEnteredFirstName(string firstName)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered LastName ""([^""]*)""")]
        public void GivenIHaveEnteredLastName(string lastName)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered DateOfBirth ""([^""]*)""")]
        public void GivenIHaveEnteredDateOfBirth(string dateOfBirth)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered PhoneNumber ""([^""]*)""")]
        public void GivenIHaveEnteredPhoneNumber(string phoneNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"the PhoneNumber ""([^""]*)"" is a valid mobile number")]
        public void GivenThePhoneNumberIsAValidMobileNumber(string phoneNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered Email ""([^""]*)""")]
        public void GivenIHaveEnteredEmail(string email)
        {
            throw new PendingStepException();
        }

        [Given(@"the Email ""([^""]*)"" is valid")]
        public void GivenTheEmailIsValid(string email)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered BankAccountNumber ""([^""]*)""")]
        public void GivenIHaveEnteredBankAccountNumber(string bankAccountNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"the BankAccountNumber ""([^""]*)"" is valid")]
        public void GivenTheBankAccountNumberIsValid(string bankAccountNumber)
        {
            throw new PendingStepException();
        }

        [When(@"I create a new customer")]
        public void WhenICreateANewCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be saved successfully")]
        public void ThenTheCustomerShouldBeSavedSuccessfully()
        {
            throw new PendingStepException();
        }

        [Given(@"there is a customer with FirstName ""([^""]*)"", LastName ""([^""]*)""")]
        public void GivenThereIsACustomerWithFirstNameLastName(string firstName, string lastName)
        {
            throw new PendingStepException();
        }

        [When(@"I request customer information")]
        public void WhenIRequestCustomerInformation()
        {
            throw new PendingStepException();
        }

        [Then(@"I should see the details of the customer including DateOfBirth, PhoneNumber, Email, and BankAccountNumber")]
        public void ThenIShouldSeeTheDetailsOfTheCustomerIncludingDateOfBirthPhoneNumberEmailAndBankAccountNumber()
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered new DateOfBirth ""([^""]*)""")]
        public void GivenIHaveEnteredNewDateOfBirth(string newDateOfBirth)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered new PhoneNumber ""([^""]*)""")]
        public void GivenIHaveEnteredNewPhoneNumber(string newPhoneNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"the new PhoneNumber ""([^""]*)"" is a valid mobile number")]
        public void GivenTheNewPhoneNumberIsAValidMobileNumber(string newPhoneNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered new Email ""([^""]*)""")]
        public void GivenIHaveEnteredNewEmail(string newEmail)
        {
            throw new PendingStepException();
        }

        [Given(@"the new Email ""([^""]*)"" is valid")]
        public void GivenTheNewEmailIsValid(string newEmail)
        {
            throw new PendingStepException();
        }

        [Given(@"I have entered new BankAccountNumber ""([^""]*)""")]
        public void GivenIHaveEnteredNewBankAccountNumber(string newBankAccountNumber)
        {
            throw new PendingStepException();
        }

        [Given(@"the new BankAccountNumber ""([^""]*)"" is valid")]
        public void GivenTheNewBankAccountNumberIsValid(string newBankAccountNumber)
        {
            throw new PendingStepException();
        }

        [When(@"I update the customer information")]
        public void WhenIUpdateTheCustomerInformation()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer information should be updated successfully")]
        public void ThenTheCustomerInformationShouldBeUpdatedSuccessfully()
        {
            throw new PendingStepException();
        }

        [When(@"I delete the customer")]
        public void WhenIDeleteTheCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be removed from the system")]
        public void ThenTheCustomerShouldBeRemovedFromTheSystem()
        {
            throw new PendingStepException();
        }

        [Given(@"a user with email ""([^""]*)"" already exists")]
        public void GivenAUserWithEmailAlreadyExists(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I attempt to add a new user with email ""([^""]*)""")]
        public void WhenIAttemptToAddANewUserWithEmail(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I should receive an error message indicating the email is already in use")]
        public void ThenIShouldReceiveAnErrorMessageIndicatingTheEmailIsAlreadyInUse()
        {
            throw new PendingStepException();
        }

        [Given(@"a customer with FirstName ""([^""]*)"", LastName ""([^""]*)"", and DateOfBirth ""([^""]*)"" already exists")]
        public void GivenACustomerWithFirstNameLastNameAndDateOfBirthAlreadyExists(string john, string doe, string p2)
        {
            throw new PendingStepException();
        }

        [When(@"I attempt to add a new customer with FirstName ""([^""]*)"", LastName ""([^""]*)"", and DateOfBirth ""([^""]*)""")]
        public void WhenIAttemptToAddANewCustomerWithFirstNameLastNameAndDateOfBirth(string john, string doe, string p2)
        {
            throw new PendingStepException();
        }

        [Then(@"I should receive an error message indicating the customer already exists")]
        public void ThenIShouldReceiveAnErrorMessageIndicatingTheCustomerAlreadyExists()
        {
            throw new PendingStepException();
        }

        [Given(@"the combination of FirstName ""([^""]*)"", LastName ""([^""]*)"" and DateOfBirth ""([^""]*)"" is not duplicate")]
        public void GivenTheCombinationOfFirstNameLastNameAndDateOfBirthIsNotDuplicate(string firstName, string lastName, string dateOfBirth)
        {
            throw new PendingStepException();
        }

        [Given(@"the Email ""([^""]*)"" is not duplicate")]
        public void GivenTheEmailIsNotDuplicate(string email)
        {
            throw new PendingStepException();
        }

        [Given(@"there is a customer with Email ""([^""]*)""")]
        public void GivenThereIsACustomerWithEmail(string email)
        {
            throw new PendingStepException();
        }

    }
}
