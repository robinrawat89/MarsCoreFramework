using MarsCoreFramework.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MarsCoreFramework.Pages
{
    public class ProfileLanguage
    {
        //Add Lanaguage Name Locator
        private IWebElement addLanguageName => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/input"));

        //Lanaguge Level DropdownList Locator
        private IWebElement DropDownList => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]//select"));

        //Add button Locatore
        private IWebElement clickAdd => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='six wide field']/input[1]"));


        //Locate table for languages
        private IWebElement tableElement => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));


        //Adding New Language
        public void addNewLanguage()
        {
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "AddLanguage");

            //Enter value in Add Language field
            //IWebElement addLanguageName = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/input"));
            addLanguageName.Clear();
            addLanguageName.Click();
            addLanguageName.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Language"));

            //Select value for level
            //IWebElement DropDownList = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]//select"));
            IList<IWebElement> options = DropDownList.FindElements(By.TagName("option"));
            int optionCount = options.Count();
            for (int i = 0; i < optionCount; i++)
            {
                if (options[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "LanguageLevel"))
                {
                    options[i].Click();
                }
            }

            //Click Add Button after enter lanaguage and language level
            //IWebElement clickAdd = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='six wide field']/input[1]"));
            clickAdd.Click();
            Thread.Sleep(5000);



        }
        //Verify Lamguage is added
        public void rowPresent(string language)
        {


            bool languageFound = false;
            //IWebElement tableElement = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Language")))
                {
                    languageFound = true;
                    break;
                }
                //else;

                //languageFound = false;
                //SaveScreenShotClass.SaveScreenshot(Driver.webDriver, "LanguageNotAdded");
                ////CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Failed to Add a Language Successfully");


            }

        }

        //Deleting a Language

        public void deleteLanguage()
        {
            var deleteLanguage = new Profile();
            IWebElement barXpath = GlobalDefinitions.driver.FindElement(By.XPath("//tr[.//td='" + GlobalDefinitions.ExcelOperations.ReadData(1, "Language") + "']/td[3]/span[2]/i"));
            //IWebElement _menuClickoption = deleteLanguage.deleteLanguageOptions(barXpath);
            barXpath.Click();
            Thread.Sleep(5000);
            Global.GlobalDefinitions.driver.SwitchTo().DefaultContent();

        }
                
        //Verify Langauge is deleted from profile
        public void languageDeletedConfirm()
        {
            bool languagePresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));
            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;

                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Language")))
                {
                    languagePresent = true;
                    //SaveScreenShotClass.SaveScreenshot(Driver.webDriver, "LanguageNotDeleted");

                }
            }

            languagePresent = false;
            //SaveScreenShotClass.SaveScreenshot(Driver.webDriver, "LanguageDeleted");

            // CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Failed to Add a Language Successfully");
        }
    }
}
