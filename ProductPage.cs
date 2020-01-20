using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationAssessment2
{
    class ProductPage
    {
        public IWebElement productName
            => PropertiesCollection.driver.FindElement(By.XPath("//*[@class='product_title entry-title']"));

        public IWebElement productPrice
            => PropertiesCollection.driver.FindElement(By.XPath("//div[@class='summary entry-summary']//span[@class='woocommerce-Price-amount amount']"));

        public IWebElement quiantityProduct
            => PropertiesCollection.driver.FindElement(By.XPath("//input[contains(@id,'quantity_')]"));

        public IWebElement btnAddToCar
            => PropertiesCollection.driver.FindElement(By.XPath("//button[@name='add-to-cart']"));

        public IWebElement btnCarContents
            => PropertiesCollection.driver.FindElement(By.XPath("//a[@class='cart-contents']"));

        public IWebElement labelCarCount
            => PropertiesCollection.driver.FindElement(By.XPath("//a[@class='cart-contents']/span[@class='count']"));

        public IWebElement labelHoodiesPocket
            => PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'Hoodie with Pocket')]"));

        public IWebElement productsInResult
            => PropertiesCollection.driver.FindElement(By.XPath("//ul[@class=('products columns-3')]/li"));

        public IWebElement numberproductsInResult
            => PropertiesCollection.driver.FindElement(By.XPath("//*[contains(text(),'Showing all') and contains(text(),'results')]"));


        public void ValidateProductName(string name)
        {
            
            Assert.AreEqual(productName.Text.ToLower(), name.ToLower());
            Console.WriteLine("The Producto "+ productName.Text + " is in the page");

        }
        public void ValidateProductPrice(string price)
        {
            Assert.AreEqual(productPrice.Text, price);
            Console.WriteLine("The Price " + productPrice.Text + " is in the page");
        }
        public void ValidateProductQuantity(string number)
        {
          
            Assert.AreEqual(labelCarCount.Text, number);
            Console.WriteLine("The Quantity " + labelCarCount.Text + " is in the page");
        }

        public void IncreaseQuantity(string number)
        {
            quiantityProduct.Clear();
            quiantityProduct.SendKeys(number);
            btnAddToCar.Click();

        }

        public void ValidateSpecificProduct(string product)
        {
            Assert.AreEqual(labelHoodiesPocket.Text, product);
            Console.WriteLine("The Product " + labelHoodiesPocket.Text + " is in the page and loads properly");
            labelHoodiesPocket.Click();
        }

        public void ValidateQuantityInResult(string number)
        {
            string textComplete = numberproductsInResult.Text;
            string[] parceText = textComplete.Split(' ');
            string value = parceText[2];
            Assert.AreEqual(value.ToString(), number);
            Console.WriteLine("The page shows up " + value.ToString() + " hoodie products");

        }

        

    }
}
