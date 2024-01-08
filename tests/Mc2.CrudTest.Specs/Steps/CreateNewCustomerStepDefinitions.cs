namespace Mc2.CrudTest.Specs.Steps;

[Binding]
public sealed class CreateNewCustomerStepDefinitions(ScenarioContext scenarioContext)
{
    [Given(@"There is no Customer with following data")]
    public void GivenThereIsNoCustomerWithFollowingData(Table table)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"Create new Customer api is called with the given data")]
    public void WhenCreateNewCustomerApiIsCalledWithTheGivenData()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"Customer should Be created with the given data")]
    public void ThenCustomerShouldBeCreatedWithTheGivenData()
    {
        ScenarioContext.StepIsPending();
    }
}