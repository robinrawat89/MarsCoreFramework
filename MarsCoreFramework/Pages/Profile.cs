using MarsCoreFramework.AbstractMethods;
using MarsCoreFramework.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MarsCoreFramework.Pages
{
    public class Profile
    {
        #region  Initialize Web Elements 

        //Click on Name
        private IWebElement clickUserName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='title']/i"));

        //Edit First Name
        private IWebElement firstName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]"));
        
        //Edit Last Name
        private IWebElement lastName => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[2]"));

        //Click Save button for Name
        private IWebElement clickSave => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui fluid accordion']/div[2]/div/div[2]/button"));

        //Click on Availability Edit button
        private IWebElement availabilityTimeEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/i"));

        //Click on Hours Edit button
        private IWebElement hoursEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/i"));

        //Click on Earn target Edit button
        private IWebElement earnTargetEditIcon => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/i"));

        //Click on fulltime option
        private IWebElement fullTime => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[3]"));
        
        //Click on parttime option
        private IWebElement partTime => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[2]"));

        //Click on lessHours option
        private IWebElement lessHours => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[2]"));

        //Click on moreHours option
        private IWebElement moreHours => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[3]"));

        //Click on AsneddedHours option
        private IWebElement asNeeded => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[4]"));
       
        //Click on earnoption1 option
        private IWebElement lessEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[2]"));
       
        //Click on earnoption2 option
        private IWebElement moreEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[3]"));
        
        //Click on earnoption3 option
        private IWebElement doubleEarn => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[4]"));

        //click on Profile
        private IWebElement clickProfile => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='nav-secondary']//a[text()[normalize-space(.)='Profile']]"));

        //*[@class='nav-secondary']//a[text()[normalize-space(.)='Profile']]

        #endregion

        internal void EditProfile()
        {
            
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "Profile");
            //GlobalDefinitions.wait(5);

            //click on Profile from menu
            
            //clickProfile.Click();

            //Click on user name 
            clickUserName.Click();

            //Edit First Name
            //GlobalDefinitions.wait(5);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Click();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).Clear();
            GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='field']/input[1]")).SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "FirstName"));

            //Edit Last Name
            lastName.Click();
            lastName.Clear();
            lastName.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "LastName"));

            //click Save button
            clickSave.Click();
            Thread.Sleep(5000);

            //Click Availiable  Edit Icon

            availabilityTimeEditIcon.Click();
            Thread.Sleep(5000);
            //GlobalDefinitions.wait(5);

            //Availability Time option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "AvailableTime"))
            {

                case "Full Time":
                    // IWebElement fullTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[3]"));
                    fullTime.Click();
                    break;
                case "Part Time":
                    //IWebElement partTime = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[2]/div/span/select/option[2]"));
                    partTime.Click();
                    break;
            }
            // Hours Edit Icon

            hoursEditIcon.Click();
            //GlobalDefinitions.wait(5);

            //Availability Hours option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "Hours"))
            {

                case "Less than 30hours a week":
                    //IWebElement lessHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[2]"));
                    lessHours.Click();
                    break;
                case "More than 30hours a week":
                    //IWebElement moreHours = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[3]"));
                    moreHours.Click();
                    break;
                case "As needed":
                    //IWebElement asNeeded = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[3]/div/span/select/option[4]"));
                    asNeeded.Click();
                    break;
            }

            //Click edit for earn Target

            earnTargetEditIcon.Click();
            Thread.Sleep(5000);

            //Earn Target option

            switch (GlobalDefinitions.ExcelOperations.ReadData(1, "EarnTarget"))
            {

                case "Less than $500 per month":
                    //IWebElement lessEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[2]"));
                    lessEarn.Click();
                    break;
                case "Between $500 and $1000 per month":
                    //IWebElement moreEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[3]"));
                    moreEarn.Click();
                    break;
                case "More than $1000 per month":
                    //IWebElement doubleEarn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='extra content']/div/div[4]/div/span/select/option[4]"));
                    doubleEarn.Click();
                    break;
            }
        }
    }
}
