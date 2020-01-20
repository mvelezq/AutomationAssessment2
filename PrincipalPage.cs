using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationAssessment2
{
    class PrincipalPage
    {
        public IWebElement inputSearch
            => PropertiesCollection.driver.FindElement(By.XPath("//input[@id='woocommerce-product-search-field-0']"));
        public IWebElement btnAddToCar
            => PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'Add to car')]"));
        public IWebElement brnViewTheCar
            => PropertiesCollection.driver.FindElement(By.XPath("//a[@class='added_to_cart wc-forward']"));
        


        public void SearchProduct(string product)
        {
            inputSearch.Clear();
            inputSearch.SendKeys(product);
            inputSearch.SendKeys(Keys.Enter);
        }

        public void ValidateSearchBox()
        {
            if (inputSearch.Displayed)
                Console.WriteLine("The search box is displayed");
            else
                Console.WriteLine("The search box is not displayed");
        }

        public void AddAndIntoTheCar()
        {
            btnAddToCar.Click();
            brnViewTheCar.Click();
        }


    }
}
