using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MarsCoreFramework.AbstractMethods
{
    public class ProfileOptions
    {
        //Click on Add New button to enter the options Languages, Skills, Education, Certifications
        public void clickAddNew(string addNewItem)
        {
            switch (addNewItem)
            {
                case "Languages":
                case "Skills":
                    //Thread.Sleep(5000);
                    IWebElement addNew = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[3]/div"));
                    addNew.Click();
                    break;

                case "Education":
                    //Driver.TurnOnWait();
                    IWebElement addNewEducation = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[6]/div"));
                    addNewEducation.Click();
                    break;

                case "Certifications":
                    //Driver.TurnOnWait();
                    IWebElement addNewCertifications = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table/thead/tr/th[4]/div"));
                    addNewCertifications.Click();

                    break;

            }

        }
    }
}
