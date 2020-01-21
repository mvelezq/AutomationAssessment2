using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationAssessment2
{
    class CarPage
    {

        public IWebElement productNameInCar
            => PropertiesCollection.driver.FindElement(By.XPath("//td[@class='product-name']"));
        public IWebElement productPriceInCar
            => PropertiesCollection.driver.FindElement(By.XPath("//td[@class='product-price']"));
        public IWebElement btnApplyCoupon
            => PropertiesCollection.driver.FindElement(By.XPath("//button[@name='apply_coupon']"));
        public IWebElement textBoxApplyCoupon
            => PropertiesCollection.driver.FindElement(By.XPath("//input[@id='coupon_code']"));
        public IWebElement labelCoupon
            => PropertiesCollection.driver.FindElement(By.XPath("(//div[@class='entry-content']//*[contains(text(),'Coupon')])[1]"));
        public IWebElement txtTotalDiscount
            => PropertiesCollection.driver.FindElement(By.XPath("//tr[contains(@class,'cart-discount')]//span[@class='woocommerce-Price-amount amount']"));
        
        public void ValidateNameIntoTheCar(string name)
        {
            
            Assert.AreEqual(productNameInCar.Text.ToLower(), name.ToLower());
            Console.WriteLine("The Name " + name + " is in the car page");
        }
        public void ValidatePriceIntoTheCar(string price)
        {

            Assert.AreEqual(productPriceInCar.Text.ToLower(), price.ToLower());
            Console.WriteLine("The Price " + price + " is in the car page");
        }

        public void ApplyCoupon(string coupon)
        {
            textBoxApplyCoupon.SendKeys(coupon);
            btnApplyCoupon.Click();
        }

        public void ValidateLabelCoupon(string message)
        {
            Assert.AreEqual(labelCoupon.Text, message);
            Console.WriteLine("The coupon was applied successfully");
            
        }

        public void ValidateDiscountApplied(string price)
        {
            Assert.AreEqual(txtTotalDiscount.Text, price);
            Console.WriteLine("The discout is correct = " + price);
        }

    }
}
