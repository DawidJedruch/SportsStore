using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "admin")).Returns(true);

            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "admin"
            };

            AccountController target = new AccountController(mock.Object);

            ActionResult result = target.Login(model, "/MyURL");

            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("nieprawidłowyUżytkownik",
                "nieprawidłoweHasło")).Returns(false);

            LoginViewModel model = new LoginViewModel
            {
                UserName = "nieprawidłowyUzytkownik",
                Password = "nieprawidłoweHasło"
            };

            AccountController target = new AccountController(mock.Object);

            ActionResult result = target.Login(model, "/MyURL");

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}