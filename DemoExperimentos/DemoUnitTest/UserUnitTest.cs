using DemoService;
using NUnit.Framework;
using System;

namespace DemoUnitTest
{
    [TestFixture]
    public class UserUnitTest
    {
        private readonly UserService userService = new UserService();

        [Test]
        [TestCase("admin", "1234", true)]
        [TestCase("admin", "1222", false)]
        public void UserLogin(string username, string password, bool shouldSucceed)
        {
            try
            {
                bool isValid = userService.Authenticate(username, password);

                Assert.That(isValid, Is.EqualTo(shouldSucceed));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
              
        }
    }
}
