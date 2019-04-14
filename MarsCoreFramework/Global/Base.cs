using MarsCoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static MarsCoreFramework.Global.CommonMethods;

namespace MarsCoreFramework.Global
{ 
    public class Base
    {
        [TestInitialize]
        //public void SignIn()
        //{   //using Chrome
        //    using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
        //    //Using Firefox
        //    //using (GlobalDefinitions.driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
        //    {

        //        SignIn newSignIn = new SignIn();
        //        newSignIn.LoginSteps();
        //        //taking screenshot
        //        SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SignInSuccessfully");

        //    }

        //}
        [TestCleanup]
        public void CleanUp()
        {

        }
         
        

    }
}
