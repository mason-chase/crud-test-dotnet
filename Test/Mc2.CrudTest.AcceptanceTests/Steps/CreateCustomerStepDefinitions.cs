using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CreateCustomerStepDefinitions
    {
        [When(@"the user creates a customer with an invalid Mobile Number")]
        public void WhenTheUserCreatesACustomerWithAnInvalidMobileNumber()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see a Mobile Number validation error")]
        public void ThenTheUserShouldSeeAMobileNumberValidationError()
        {
            throw new PendingStepException();
        }

        [When(@"the user creates a customer with an invalid Email")]
        public void WhenTheUserCreatesACustomerWithAnInvalidEmail()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see an Email validation error")]
        public void ThenTheUserShouldSeeAnEmailValidationError()
        {
            throw new PendingStepException();
        }

        [Given(@"there is a customer with Email '([^']*)' in the database")]
        public void GivenThereIsACustomerWithEmailInTheDatabase(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user creates a customer with Email '([^']*)'")]
        public void WhenTheUserCreatesACustomerWithEmail(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see an Email duplication error")]
        public void ThenTheUserShouldSeeAnEmailDuplicationError()
        {
            throw new PendingStepException();
        }

        [When(@"the user creates a customer with an invalid Bank Account Number")]
        public void WhenTheUserCreatesACustomerWithAnInvalidBankAccountNumber()
        {
            throw new PendingStepException();
        }

        [Then(@"the user should see a Bank Account Number validation error")]
        public void ThenTheUserShouldSeeABankAccountNumberValidationError()
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
    }
}
