using MarsCoreFramework.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using static MarsCoreFramework.Global.CommonMethods;

namespace MarsCoreFramework.Pages
{
    public class ProfileEducation
    {
        //college Name
        private IWebElement addCollege => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[1]/input"));

        //Dropdownlistcountry
        private IWebElement DropDownListCountry => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[2]/select"));

        //Dropdown List title
        private IWebElement DropDownListTitle => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[1]/select"));

        //Degree field
        private IWebElement addDegree => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[2]/input"));

        //Year field
        private IWebElement DropDownListYear => GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[3]/select"));

        //add button
        private IWebElement clickAdd => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='sixteen wide field']/input[1]"));

        //Adding New Education
        public void addNewEducation()
        {

            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "AddEducation");


            //Enter value in College/University name field
            //IWebElement addCollege = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[1]/input"));
            addCollege.Clear();
            addCollege.Click();
            addCollege.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "InstituteName"));

            //Select value for Country
            //IWebElement DropDownListCountry = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[1]/div[2]/select"));
            IList<IWebElement> optionsCountry = DropDownListCountry.FindElements(By.TagName("option"));
            int optionCountCountry = optionsCountry.Count();
            for (int i = 0; i < optionCountCountry; i++)
            {
                if (optionsCountry[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Country"))
                {
                    optionsCountry[i].Click();
                    break;
                }

            }

            //Select value for Title
           //IWebElement DropDownListTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[1]/select"));
            IList<IWebElement> optionsTitle = DropDownListTitle.FindElements(By.TagName("option"));
            int optionCountTitle = optionsTitle.Count();
            for (int i = 0; i < optionCountTitle; i++)
            {
                if (optionsTitle[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Title"))
                {
                    optionsTitle[i].Click();
                    break;
                }

            }

            //Enter value in Degree field
            //IWebElement addDegree = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[2]/input"));
            addDegree.Clear();
            addDegree.Click();
            addDegree.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Degree"));

            //Select value for Year
            //IWebElement DropDownListYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/div/div[2]/div[3]/select"));
            IList<IWebElement> optionsYear = DropDownListYear.FindElements(By.TagName("option"));
            int optionCountYear = optionsYear.Count();
            for (int i = 0; i < optionCountYear; i++)
            {
                if (optionsYear[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Year"))
                {
                    optionsYear[i].Click();
                    break;
                }

            }

            //Click Add Button after enter Education deatils
            //IWebElement clickAdd = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='sixteen wide field']/input[1]"));
            clickAdd.Click();
            Thread.Sleep(5000);
        }

        //Verify Education is added
        public void rowEducationPresent()
        {

            bool educationPresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "InstituteName")) && row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Country")))
                {
                    educationPresent = true;
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationAdded");
                    //CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    break;
                }

            }
            //educationPresent = false;
            //SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "EducationNotAdded");
            //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Failed to Add a Language Successfully");

        }
    }
}
