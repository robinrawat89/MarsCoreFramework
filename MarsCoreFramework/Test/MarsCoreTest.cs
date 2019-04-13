using MarsCoreFramework.AbstractMethods;
using MarsCoreFramework.Global;
using MarsCoreFramework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using static MarsCoreFramework.Global.CommonMethods;

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
                //taking screenshot
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SignUpSuccessfully");

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
                //taking screenshot
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "SignInSuccessfully");

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

                //taking screenshot
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "BeforeProfileUpdate");

                //Udate the profile
                Profile updateProfile = new Profile();
                updateProfile.EditProfile();

                //taking screenshot
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "UpdateProfileSuccessfully");

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
                //string langauge = "English";
                //string dropdownOption = "Fluent";

                //sign in
                SignIn newSignIn = new SignIn();
                newSignIn.LoginSteps();

                //MenuOption to Click
                ClickMenu clickMenu = new ClickMenu();
                clickMenu.clickMenuOptions(ProfileMenuOption);

                //click on options Language, Skills, Education, Certifications
                clickMenu.clickSubMenuOptions(addNewOption);

                //click on Add New button
                ProfileOptions addNewButton = new ProfileOptions();
                addNewButton.clickAddNew(addNewOption);


                //add langauge
                ProfileLanguage addLangauge = new ProfileLanguage();
                addLangauge.addNewLanguage();
                //taking screenshot
                SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "LangaugeAddedSuccessfully");

            }

        }

        //[AssemblyCleanup]
        //public static void TearDown()
        //{
        //    GlobalDefinitions.driver.Quit();
        //}
    }
}
