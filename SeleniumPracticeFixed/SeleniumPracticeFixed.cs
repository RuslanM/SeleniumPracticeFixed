using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumPrаctice
{
    public class PetNameWebsite
    {
        public ChromeDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

        }

        private By BoyButtonLocator = By.Id("boy");
        private By GirlButtonLocator = By.Id("girl");
        private By emailInputLocator = By.Name("email");
        private By sendButtonLocator = By.Id("sendMe");
        private By emailResultLocator = By.ClassName("your-email");
        private By anotherEmailLinkLocator = By.Id("anotherEmail");
        private By ResultTextLocator = By.ClassName("result-text");

        [Test]
        public void PetNameWebsite_GetBoysName_Success()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(BoyButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual(expectedEmail, driver.FindElement(emailResultLocator).Text, "Сделали заявку не на тот e-mail");

        }

        [Test]
        public void PetNameWebsite_GetGirlsName_Success()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(GirlButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();

            Assert.AreEqual(expectedEmail, driver.FindElement(emailResultLocator).Text, "Сделали заявку не на тот e-mail");

        }

        [Test]
        public void PetNameWebsite_IsBoysNameABoysName_True()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(BoyButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();

            Assert.IsTrue(driver.FindElement(ResultTextLocator).Text.Contains("мальчика"), "Перепутан пол");
        }

        [Test]
        public void PetNameWebsite_IsGirlsNameAGirlsName_True()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(GirlButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();

            Assert.IsTrue(driver.FindElement(ResultTextLocator).Text.Contains("девочки"), "Перепутан пол");
        }

        [Test]
        public void PetNameWebsite_ClickAnotherEmail_Boy_EmailInputIsEmpty()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(BoyButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();
            driver.FindElement(anotherEmailLinkLocator).Click();

            Assert.AreEqual("true", driver.FindElement(BoyButtonLocator).GetAttribute("checked"));
            Assert.AreEqual(string.Empty, driver.FindElement(emailInputLocator).Text, "После клика по ссылке поле не очистилось");
            Assert.IsFalse(driver.FindElement(anotherEmailLinkLocator).Displayed, "Не исчезла ссылка для ввода другого e-mail");

        }

        [Test]
        public void PetNameWebsite_ClickAnotherEmail_Girl_EmailInputIsEmpty()
        {
            var expectedEmail = "test@mail.ru";

            driver.Navigate().GoToUrl("https://qa-course.kontur.host/selenium-practice/");

            driver.FindElement(GirlButtonLocator).Click();
            driver.FindElement(emailInputLocator).SendKeys(expectedEmail);
            driver.FindElement(sendButtonLocator).Click();
            driver.FindElement(anotherEmailLinkLocator).Click();

            Assert.AreEqual("true", driver.FindElement(GirlButtonLocator).GetAttribute("checked"));
            Assert.AreEqual(string.Empty, driver.FindElement(emailInputLocator).Text, "После клика по ссылке поле не очистилось");
            Assert.IsFalse(driver.FindElement(anotherEmailLinkLocator).Displayed, "Не исчезла ссылка для ввода другого e-mail");

        }

        [TearDown]
        public void TeadDown()
        {
            driver.Quit();
        }

    }
}
