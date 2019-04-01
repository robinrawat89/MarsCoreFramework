using MarsCoreFramework.Global;
using MarsCoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;

namespace MarsCoreFramework
{
    [TestClass]
    public class MarsCoreTest
    {
        //[ClassInitialize]
        
        [TestMethod]
        public void SignUp()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {

                SignUp newSignUp = new SignUp();
                newSignUp.Register();
                
            }
        }

        [TestMethod]
        public void SignIn()
        {
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {

                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();

            }

        }

        //[AssemblyCleanup]
        //public static void TearDown()
        //{
        //    GlobalDefinitions.driver.Quit();
        //}
    }
}
