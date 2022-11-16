using FakeItEasy;
using RESTApiTestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTestApp.Tests.Controller
{
    public class TestAppControllerTests
    {
        private readonly ITestAppService _testAppService;

        public TestAppControllerTests() 
        {
            _testAppService = A.Fake<ITestAppService>();
        }

        [Fact]
        public void TestAppController_GetAll_ReturnOK()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
