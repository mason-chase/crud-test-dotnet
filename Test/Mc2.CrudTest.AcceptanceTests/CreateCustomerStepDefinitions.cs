using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests
{
    [Binding]
    public class CreateCustomerStepDefinitions
    {
        [Given(@"the user is entering a new customer with an invalid mobile number ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAnInvalidMobileNumber(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user tries to add the customer with the invalid mobile number")]
        public void WhenTheUserTriesToAddTheCustomerWithTheInvalidMobileNumber()
        {
            throw new PendingStepException();
        }

        [Then(@"the system should display an error message indicating an invalid mobile number")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingAnInvalidMobileNumber()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is entering a new customer with a valid mobile number ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAValidMobileNumber(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds the customer with the valid mobile number")]
        public void WhenTheUserAddsTheCustomerWithTheValidMobileNumber()
        {
            throw new PendingStepException();
        }

        [Then(@"the system should successfully add the new customer to the database")]
        public void ThenTheSystemShouldSuccessfullyAddTheNewCustomerToTheDatabase()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should receive a confirmation message")]
        public void ThenTheUserShouldReceiveAConfirmationMessage()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is entering a new customer with an invalid email address ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAnInvalidEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user tries to add the customer with the invalid email address")]
        public void WhenTheUserTriesToAddTheCustomerWithTheInvalidEmailAddress()
        {
            throw new PendingStepException();
        }

        [Then(@"the system should display an error message indicating an invalid email address")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingAnInvalidEmailAddress()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is entering a new customer with a valid email address ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAValidEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds the customer with the valid email address")]
        public void WhenTheUserAddsTheCustomerWithTheValidEmailAddress()
        {
            throw new PendingStepException();
        }

        [Given(@"the system has an existing customer with the email address ""([^""]*)""")]
        public void GivenTheSystemHasAnExistingCustomerWithTheEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds a new customer with the same email address ""([^""]*)""")]
        public void WhenTheUserAddsANewCustomerWithTheSameEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the system should display an error message indicating a duplicate email")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingADuplicateEmail()
        {
            throw new PendingStepException();
        }

        [Given(@"the system has no existing customer with the email address ""([^""]*)""")]
        public void GivenTheSystemHasNoExistingCustomerWithTheEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds a new customer with the email address ""([^""]*)""")]
        public void WhenTheUserAddsANewCustomerWithTheEmailAddress(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the user is entering a new customer with an invalid bank account number ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAnInvalidBankAccountNumber(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user tries to add the customer with the invalid bank account number")]
        public void WhenTheUserTriesToAddTheCustomerWithTheInvalidBankAccountNumber()
        {
            throw new PendingStepException();
        }

        [Then(@"the system should display an error message indicating an invalid bank account number")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingAnInvalidBankAccountNumber()
        {
            throw new PendingStepException();
        }

        [Given(@"the user is entering a new customer with a valid bank account number ""([^""]*)""")]
        public void GivenTheUserIsEnteringANewCustomerWithAValidBankAccountNumber(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds the customer with the valid bank account number")]
        public void WhenTheUserAddsTheCustomerWithTheValidBankAccountNumber()
        {
            throw new PendingStepException();
        }

        [When(@"the user create a customer with a valid data")]
        public void WhenTheUserCreateACustomerWithAValidData()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see create customer successful message")]
        public void ThenTheUserShouldSeeCreateCustomerSuccessfulMessage()
        {
            throw new PendingStepException();
        }

        [Given(@"the system has no existing customer with the following details:")]
        public void GivenTheSystemHasNoExistingCustomerWithTheFollowingDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds a new customer with the same details:")]
        public void WhenTheUserAddsANewCustomerWithTheSameDetails(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"the system should display an error message indicating duplicate customer details")]
        public void ThenTheSystemShouldDisplayAnErrorMessageIndicatingDuplicateCustomerDetails()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should not be added to the database")]
        public void ThenTheCustomerShouldNotBeAddedToTheDatabase()
        {
            throw new PendingStepException();
        }

        [When(@"the user adds a new customer with different details:")]
        public void WhenTheUserAddsANewCustomerWithDifferentDetails(Table table)
        {
            throw new PendingStepException();
        }
    }
}
