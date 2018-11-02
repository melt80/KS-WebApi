using AutoMapper;
using KS.API.Controllers.Authorization;
using KS.API.DataContract.Authorization;
using KS.Business.MockManagers.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace KS.API.Tests
{
    [TestClass]
    public class RegisterTests
    {
        private RegisterController _controller;
        private MockRegisterUserManager _mockManager;  

        [TestInitialize]
        public void Arrange()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _mockManager = new MockRegisterUserManager {ReturnValue = Task.FromResult(true)};
            _controller = new RegisterController(_mockManager, mapper);
        }

        [TestMethod]
        public void RegisterController_Register_ShouldReturnCallCountOfOne()
        {
            var result = _controller.Register(new NewUserCreateRequest {Username = "neilt@test.com", Password = "test"});
            Assert.AreEqual(1, _mockManager.CallCount);
        }

        [TestMethod]
        public void RegisterController_Register_ShouldReturnCreated()
        {
            var request = new NewUserCreateRequest { Username = "testName", Password = "testPassword" };
            StatusCodeResult result = (StatusCodeResult)_controller.Register(request).Result;
            var expected = 201;
            Assert.AreEqual(result.StatusCode, expected);
        }
    }
}
