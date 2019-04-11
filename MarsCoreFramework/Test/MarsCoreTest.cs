using MarsCoreFramework.AbstractMethods;
using MarsCoreFramework.Global;
using MarsCoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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
        {   //using Chrome
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            //Using Firefox
            //using (GlobalDefinitions.driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {

                SignUp newSignUp = new SignUp();
                newSignUp.Register();

            }
        }

        [TestMethod]
        public void SignIn()
        {   //using Chrome
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            //Using Firefox
            //using (GlobalDefinitions.driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {

                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();

            }

        }

        [TestMethod]
        public void UpdateProfile()
        {   //using Chrome
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            //Using Firefox
            //using (GlobalDefinitions.driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                string Profile = "Profile";
                //sign in
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();
                //MenuOption to Click
                ClickMenu clickMenu = new ClickMenu();
                clickMenu.clickMenuOptions(Profile);
                //Udate the profile
                Profile updateProfile = new Profile();
                updateProfile.EditProfile();

            }

        }

        [TestMethod]
        public void languageProfile()
        {   //using Chrome
            using (GlobalDefinitions.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            //Using Firefox
            //using (GlobalDefinitions.driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                string ProfileMenuOption = "Profile";
                string addNewOption = "Languages";

                //sign in
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();

                //MenuOption to Click
                ClickMenu clickMenu = new ClickMenu();
                clickMenu.clickMenuOptions(ProfileMenuOption);

                //click on options Language, Skills, Education, Certifications
                clickMenu.clickSubMenuOptions(addNewOption);

            }

        }

        //[AssemblyCleanup]
        //public static void TearDown()
        //{
        //    GlobalDefinitions.driver.Quit();
        //}
    }
}
