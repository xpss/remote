using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace Tests
{
    [TestFixture]
    public class UnitTest
    {
        private IWebDriver driver;

        [TestFixtureSetUp]
        public void TFSetUp()
        {
            driver = new FirefoxDriver();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://localhost:58638/");
        }

        [Test]
        public void LogOnTest()
        {
            IWebElement link = driver.FindElement(By.CssSelector("#Registration a:nth-child(2)"));

            link.Click();
            Thread.Sleep(1000);

            IWebElement login = driver.FindElement(By.Id("Login"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement button = driver.FindElement(By.CssSelector("input[value=\"LogOn\"]"));

            login.SendKeys("xpss");
            password.SendKeys("5189215");
            button.Click();

            //IWebElement slink = driver.FindElement(By.CssSelector("#Registration a[href *= \"LogOff\"]"));
            //slink.Click();
            //Thread.Sleep(5000);
        }

        [Test]
        public void RegistrationTest()
        {
            IWebElement link = driver.FindElement(By.CssSelector("#Registration a:nth-child(1)"));

            link.Click();
            Thread.Sleep(1000);

            IWebElement login = driver.FindElement(By.Id("Login"));
            IWebElement password = driver.FindElement(By.Id("Password"));
            IWebElement confirmPassword = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement email = driver.FindElement(By.Id("Email"));
            IWebElement firstName = driver.FindElement(By.Id("FirstName"));
            IWebElement lastName = driver.FindElement(By.Id("LastName"));
            IWebElement mobile = driver.FindElement(By.Id("Mobile"));
            IWebElement address = driver.FindElement(By.Id("Address"));
            IWebElement birthday = driver.FindElement(By.Id("Birthday"));
            IWebElement button = driver.FindElement(By.CssSelector("input[value=\"Register\"]"));

            login.SendKeys("xpss");
            password.SendKeys("5189215");
            confirmPassword.SendKeys("5189215");
            email.SendKeys("email@mail.ru");
            firstName.SendKeys("Ivan");
            lastName.SendKeys("Ivanov");
            mobile.SendKeys("Galaxy S4");
            address.SendKeys("pr.Nezavisimosti 65");
            birthday.SendKeys("10.05.88");
            button.Click();
        }

        [TearDown]
        public void TearDown()
        {
            IWebElement link = driver.FindElement(By.CssSelector("#Registration a[href *= \"LogOff\"]"));
            link.Click();
        }

        //[TestFixtureTearDown]
        //public void TFTearDown()
        //{
        //    driver.Quit();
        //}
    }
}
