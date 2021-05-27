using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTests
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://dziennikprojekt.herokuapp.com/");
        }

        [Test]
        public void LoginAsAdmin()
        {
            IWebElement Txt_Login = driver.FindElement(By.Id("login"));
            IWebElement Txt_Password = driver.FindElement(By.Id("password"));
            IWebElement Btn_Submit = driver.FindElement(By.XPath("//*[contains(@class, 'btn-primary')]"));

            Txt_Login.SendKeys("admin");
            Txt_Password.SendKeys("admin");
            Btn_Submit.Click();

            string logedAs =  driver.FindElement(By.XPath("//ul[contains(@class, 'navbar')]/h5/b")).Text;

            StringAssert.AreEqualIgnoringCase("admin", logedAs, "Incorrect login");
            Assert.IsNotNull(driver.FindElement(By.XPath("//div[@id='navbarSupportedContent']//a[contains(@href, '/AdminPage')]")));
        }

        [Test]
        public void TryLoginWithoutLoginAndPass()
        {
            IWebElement Btn_Submit = driver.FindElement(By.XPath("//*[contains(@class, 'btn-primary')]"));

            Btn_Submit.Click();

            Assert.IsEmpty(driver.FindElements(By.XPath("//div[@id='navbarSupportedContent']")));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }


    }
}