namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public sealed class CustomerStepDefinition
{
    
    private readonly ScenarioContext _scenarioContext;

    public CustomerStepDefinition(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        
    }

    [Given("I am an operator")]
    public void GivenIAmAnOperator()
    {
       _scenarioContext.Pending();
    }

  

    [When("I create a Customer with following details")]
    public void WhenICreateACustomerWithTheFollowingDetails(Table table)
    {
        //TODO: create a customer with table data and calling the CustomerCreatedHandler for this step

        _scenarioContext.Pending();
    }

    [Then("The customer should be created successfully")]
    public void ThenTheCustomerShouldBeCreatedSuccessfully(int result)
    {
        //TODO: check the customer created in DB by querying the read model
        _scenarioContext.Pending();
    }
}