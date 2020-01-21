using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using static AutomationAssessment2.Constants;


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
            RequestProduct requestProduct = new RequestProduct();

            requestProduct.SendRequestProduct();

            principalPage.SearchProduct(product);
            producPages.ValidateProductName(product);
            producPages.ValidateProductPrice(price);
            producPages.IncreaseQuantity(quantityItemsInCar);
            producPages.ValidateProductQuantity(itemsQuantity);
            producPages.labelCarCount.Click();
            carPage.ValidateNameIntoTheCar(product);
            carPage.ValidatePriceIntoTheCar(price); 
        }
        
        
        
        
        [Test]
        public void Test2()
        {
            PrincipalPage principalPage = new PrincipalPage();
            ProductPage producPages = new ProductPage();

            principalPage.ValidateSearchBox();
            principalPage.SearchProduct(hoodieProduct);
            producPages.ValidateQuantityInResult(quantityInResult);
            producPages.ValidateSpecificProduct(randomItemHoodies);

        }
        [Test]
        public void Test3()
        {
            PrincipalPage principalPage = new PrincipalPage();
            ProductPage producPages = new ProductPage();
            CarPage carPage = new CarPage();

            principalPage.AddAndIntoTheCar();
            carPage.ApplyCoupon(coupon);
            carPage.ValidateLabelCoupon(couponMessage);
            carPage.ValidateDiscountApplied(price);
        }

        [TearDown]
        public void CLoseNavegator()
        {
            PropertiesCollection.driver.Close();
        }
    }
}