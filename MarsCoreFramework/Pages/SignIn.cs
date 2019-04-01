using MarsCoreFramework.Global;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MarsCoreFramework.Pages
{
    public class SignIn
    {
        #region  Initialize Web Elements 
        //Finding the Sign button
        private IWebElement SignIntab => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui secondary menu inverted']/div/a"));

        // Finding the Email Field
        private IWebElement Email => GlobalDefinitions.driver.FindElement(By.Name("email"));

        //Finding the Password Field
        private IWebElement Password => GlobalDefinitions.driver.FindElement(By.Name("password"));

        //Finding the Login Button
        private IWebElement LoginBtn => GlobalDefinitions.driver.FindElement(By.XPath("//div[@class ='field']/button"));

        #endregion

        public void LoginSteps()
        {
            GlobalDefinitions.driver.Manage().Window.Maximize();

            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "SignIn"); //Populating second sheet of excel sheet
            
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelOperations.ReadData(1, "Url"));

            //Click on Sign In tab
            SignIntab.Click();
            Thread.Sleep(500);

            //Enter the data in Username textbox
            Email.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Email"));
            Thread.Sleep(500);

            //Enter the password
            Password.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Password"));
            Thread.Sleep(500);

            //Click on Login button
            LoginBtn.Click();
            Thread.Sleep(7000);

            //Verification
            Thread.Sleep(1000);

            //Verification
            var  text = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='item']/button"));
            Assert.IsTrue(text.Text.Contains("Sign Out"));


            //string msg = GlobalDefinitions.ExcelOperations.ReadData(1, "DATA");
            //string Actualmsg = Test.Text;
            //Thread.Sleep(500);
            //if (msg == Actualmsg)
            //{
            //    Console.WriteLine("Login into application");
            //}

            //else
            //    Console.WriteLine("Login Fail");
        }
    }
}
