using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowNetCoreDemo.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SpecflowNetCoreDemo.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        //Anti-Context Injection code - 100% wrong
        LoginPage loginPage = null;

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            var options = new OpenQA.Selenium.Chrome.ChromeOptions();
            string caminhoChromeDriver = @"C:\Users\bruna\Downloads\chromedriver-win64\chromedriver-win64";
            options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            IWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver(caminhoChromeDriver, options);

            webDriver.Navigate().GoToUrl("http://eaapp.somee.com/");
            loginPage = new LoginPage(webDriver);

        }

        [Given(@"I click login link")]
        public void GivenIClickLoginLink()
        {
            loginPage.ClickLogin();
        }

        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.Login((string)data.UserName, (string)data.Password);
        }

        [Given(@"I click login button")]
        public void GivenIClickLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"I should see Employee details link")]
        public void ThenIShouldSeeEmployeeDetailsLink()
        {
            Assert.That(loginPage.IsEmployeeDetailsExist(), Is.True);

        }
    }
}
