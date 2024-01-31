using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Pages
{
    public class LoginPage
    {
        public IWebDriver WebDriver { get; }

        //UI Elements
        public IWebElement lnkLogin => WebDriver.FindElement(By.LinkText("Login"));
        public IWebElement txUserName => WebDriver.FindElement(By.Name("UserName"));
        public IWebElement txPassword => WebDriver.FindElement(By.Name("Password"));
        public IWebElement btnLogin => WebDriver.FindElement(By.CssSelector(".btn-default"));
        public IWebElement lnkEmployeeDetails => WebDriver.FindElement(By.LinkText("Employee Details"));


        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public void ClickLogin()
        {
            lnkLogin.Click();
        }

        public void Login(string username, string password)
        {
            txUserName.SendKeys(username);
            txPassword.SendKeys(password);
        }

        public void ClickLoginButton() => btnLogin.Submit();
        public bool IsEmployeeDetailsExist() => lnkEmployeeDetails.Displayed;

    }
}
