using webapi.DomainModels;

namespace webapi.Tests
{
    /// <summary>
    /// TDD development is happening here
    /// In TDD we start form tests that can be defined from the business domain
    /// Normally the business models will be developed with TDD
    /// (because the OpenAPI is the test for the rest of the app)
    /// </summary>
    public class CustomerModelTest
    {
        private CustomerModel customerModel = new CustomerModel();
        public void CheckPhoneNumberTest()
        {
            string samplePhoneNumber = "09355329942";
            bool modelResult = customerModel.CheckPhoneNumber(samplePhoneNumber);
            //Assert.
            //assertion happenes here to check the validity
        }

    }
}