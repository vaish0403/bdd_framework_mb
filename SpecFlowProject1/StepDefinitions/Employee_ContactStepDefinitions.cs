using NUnit.Framework;
using OpenQA.Selenium;
using Specflow_Automation.Hooks;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class Employee_ContactStepDefinitions
    {
        private string name = string.Empty;
        private string relationship = string.Empty;
        private string home_telephone = string.Empty;
        private string mobile = string.Empty;
        private string work_telephone = string.Empty;
        [When(@"I click on My Info")]
        public void WhenIClickOnMyInfo()
        {
            AutomationHooks.driver.FindElement(By.XPath("//span[text()='My Info']")).Click();

        }

        [When(@"I click on Emergency Contacts")]
        public void WhenIClickOnEmergencyContacts()
        {
            AutomationHooks.driver.FindElement(By.XPath("//a[text()='Emergency Contacts']")).Click();
        }

        [When(@"I click on Add")]
        public void WhenIClickOnAdd()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[text()=' Add ']")).Click();

        }

        [When(@"I click on emergency contact")]
        public void WhenIClickOnEmergencyContact(Table table)
        {
            table.Rows.ElementAt(0).TryGetValue("name", out name);
            table.Rows.ElementAt(0).TryGetValue("relationship", out relationship);
            table.Rows.ElementAt(0).TryGetValue("home_telephone", out home_telephone);
            table.Rows.ElementAt(0).TryGetValue("mobile", out mobile);
            table.Rows.ElementAt(0).TryGetValue("work_telephone", out work_telephone);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Name')]/following::input"))
                .SendKeys(name);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Relationship')]/following::input"))
                .SendKeys(relationship);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Home Telephone')]/following::input"))
                .SendKeys(home_telephone);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Mobile')]/following::input"))
                .SendKeys(mobile);
            AutomationHooks.driver.FindElement(By.XPath("//label[contains(text(),'Work Telephone')]/following::input"))
                .SendKeys(work_telephone);
        }

        [When(@"I click on save")]
        public void WhenIClickOnSave()
        {
            AutomationHooks.driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then(@"I should navigate to emergency conact details")]
        public void ThenIShouldNavigateToEmergencyConactDetails()
        {
            var actualName = AutomationHooks.driver.FindElement(By.XPath($"//div[contains(text(),'{name}')]"));
            Assert.NotNull(actualName);

            var actualRelationship = AutomationHooks.driver.FindElement(By.XPath($"//div[contains(text(),'{relationship}')]"));
            Assert.NotNull(actualRelationship);

            var actualHomeTelephone = AutomationHooks.driver.FindElement(By.XPath($"//div[contains(text(),'{home_telephone}')]"));
            Assert.NotNull(actualHomeTelephone);

            var actualMobile = AutomationHooks.driver.FindElement(By.XPath($"//div[contains(text(),'{mobile}')]"));
            Assert.NotNull(actualMobile);

            var actualWorkTelephone = AutomationHooks.driver.FindElement(By.XPath($"//div[contains(text(),'{work_telephone}')]"));
            Assert.NotNull(actualWorkTelephone);
        }
    }
}
