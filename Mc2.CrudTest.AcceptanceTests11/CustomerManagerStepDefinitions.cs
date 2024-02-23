using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests
{
    [Binding]
    public class CustomerManagerStepDefinitions
    {
        [Given(@"a customer with the following details:")]
        public void GivenACustomerWithTheFollowingDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"the user adds the customer")]
        public void WhenTheUserAddsTheCustomer()
        {
            throw new PendingStepException();
        }

        [Then(@"the customer should be successfully added")]
        public void ThenTheCustomerShouldBeSuccessfullyAdded()
        {
            throw new PendingStepException();
        }
    }
}
