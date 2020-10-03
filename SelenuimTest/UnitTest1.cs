using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace SelenuimTest
{
    public class Tests
    {
        public enum WebDriversEnum
        {
            Chrome, Firefox
        }

        [Theory]
        [InlineData(WebDriversEnum.Chrome, "http://demo.guru99.com/test/newtours/", "Welcome: Mercury Tours")]
        [InlineData(WebDriversEnum.Chrome, "https://www.google.com/", "Google")]
//        [InlineData(WebDriversEnum.Firefox, "http://demo.guru99.com/test/newtours/", "Welcome: Mercury Tours")]
//        [InlineData(WebDriversEnum.Firefox, "https://www.google.com/", "Google")]
        public void TestWebPageTitles(WebDriversEnum driver, string baseUrl, string expectedTitle)
        {
            //Arrange
            var webDriver = GetWebDriverInstance(driver);
            webDriver.Navigate().GoToUrl(baseUrl);

            //Act
            var actualTitle = webDriver.Title;

            //Assert
            Assert.Equal(expectedTitle, actualTitle);

            //Cleanup
            webDriver.Dispose();
        }

        private IWebDriver GetWebDriverInstance(WebDriversEnum driver) 
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArguments("--no-sandbox");
            switch (driver)
            {
                case WebDriversEnum.Chrome:
                    return new ChromeDriver(chromeOptions);
                case WebDriversEnum.Firefox:
                    return new FirefoxDriver();
                default:
                    throw new NotImplementedException("Driver not valid");
            }
        }
    }
}


