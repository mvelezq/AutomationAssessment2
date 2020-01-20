using NUnit.Framework;
using OpenQA.Selenium.Firefox;

namespace AutomationAssessment2
{
    public class Tests
    {
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new FirefoxDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("http://34.205.174.166/");
            PropertiesCollection.driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            PrincipalPage principalPage = new PrincipalPage();
            ProductPage producPages = new ProductPage();
            CarPage carPage = new CarPage();

            principalPage.SearchProduct("AudyCH");
            producPages.ValidateProductName("AudyCH");
            producPages.ValidateProductPrice("$21.99");
            producPages.IncreaseQuantity("7");
            producPages.ValidateProductQuantity("7 items");
            producPages.labelCarCount.Click();
            carPage.ValidateNameIntoTheCar("AudyCH");
            carPage.ValidatePriceIntoTheCar("$21.99");
        }
        [Test]
        public void Test2()
        {
            PrincipalPage principalPage = new PrincipalPage();
            ProductPage producPages = new ProductPage();

            principalPage.ValidateSearchBox();
            principalPage.SearchProduct("hoodie");
            producPages.ValidateQuantityInResult("4");
            producPages.ValidateSpecificProduct("Hoodie with Pocket");

        }
        [Test]
        public void Test3()
        {
            PrincipalPage principalPage = new PrincipalPage();
            ProductPage producPages = new ProductPage();
            CarPage carPage = new CarPage();

            principalPage.AddAndIntoTheCar();
            carPage.ApplyCoupon("cupon");
            carPage.ValidateLabelCoupon("Message cupon");

        }
    }
}