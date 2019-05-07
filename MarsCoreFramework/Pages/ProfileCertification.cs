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
    public class ProfileCertification
    {

        //Certificate field
        private IWebElement addCertificate => GlobalDefinitions.driver.FindElement(By.Name("certificationName"));

        //Certificate From field
        private IWebElement addCertificateFrom => GlobalDefinitions.driver.FindElement(By.Name("certificationFrom"));

        //Year table
        private IWebElement DropDownList => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));

        //click Add button
        private IWebElement clickAdd => GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='five wide field']/input[1]"));



        public void addNewCertification()
        {

            GlobalDefinitions.ExcelOperations.PopulateInCollection(GlobalDefinitions.ReadJson(), "AddCertification");



            //Enter value in Add Certificate field
            //IWebElement addCertificate = GlobalDefinitions.driver.FindElement(By.Name("certificationName"));

            addCertificate.Clear();
            addCertificate.Click();
            addCertificate.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "Certificate"));

            //Add Certifiacte From
            //IWebElement addCertificateFrom = GlobalDefinitions.driver.FindElement(By.Name("certificationFrom"));

            addCertificateFrom.Clear();
            addCertificateFrom.Click();
            addCertificateFrom.SendKeys(GlobalDefinitions.ExcelOperations.ReadData(1, "From"));

            //Select value for year
            //IWebElement DropDownList = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='ui fluid dropdown']"));

            IList<IWebElement> options = DropDownList.FindElements(By.TagName("option"));
            int optionCount = options.Count();
            for (int i = 0; i < optionCount; i++)
            {
                if (options[i].Text == GlobalDefinitions.ExcelOperations.ReadData(1, "Year"))
                {
                    options[i].Click();
                    break;
                }

            }

            //Click Add Button after enter Education deatils
            //IWebElement clickAdd = GlobalDefinitions.driver.FindElement(By.XPath("//*[@class='five wide field']/input[1]"));

            clickAdd.Click();
            Thread.Sleep(5000);

        }


        //Verify Certificate is added

        public void rowCertificatePresent()
        {

            bool certificatePresent = false;
            IWebElement tableElement = GlobalDefinitions.driver.FindElement(By.XPath("//*[contains(@class,'active') and contains(@class, 'tab')]/div/div[2]/div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tbody"));

            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(GlobalDefinitions.ExcelOperations.ReadData(1, "Certificate")))
                {
                    certificatePresent = true;
                    SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "CertificateAdded");
                    //CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");

                    break;
                }

            }
            //certificatePresent = false;
            //SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "CertificateNotAdded");
            //CommonMethods.test.Log(LogStatus.Fail, "Test Failed, Failed to Add a Language Successfully");

        }
    }
}
