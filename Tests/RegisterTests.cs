using System;
using KS.API.Controllers.Authorization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RegisterTests
    {
        private RegisterController _controller;
        private MockRegisterUserManager _mockManager;

        [TestInitialize]
        public void Arrange()
        {
            _mockManager = new MockRegisterUserManager { ReturnValue = true };
            _controller = new RegisterController(_mockManager);
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
