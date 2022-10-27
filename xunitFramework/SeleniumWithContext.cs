using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace xunitFramework
{
    public class SeleniumWithContext : IClassFixture<WebDriverFixture>
    {
        private readonly WebDriverFixture webDriverFixture;
        private readonly ITestOutputHelper testOutputHelper;

        public SeleniumWithContext(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
        {
            this.webDriverFixture = webDriverFixture;
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ClassFixtureTestNavigate()
        {
            
            testOutputHelper.WriteLine("1st Test Global");
            webDriverFixture.ChromeDriver
                .Navigate()
                .GoToUrl("https://www.google.com");
        }

        [Theory]
        [InlineData("David Donaghy", "david@outlook.com", "50 clooney terrace", "373 abbeydale")]
        [InlineData("Gregg Hyndman", "gregg@outlook.com", "40 the beeches", "111 lincoln courts")]
        public void ClassFixtureTestFillData(string userName, string userEmail, string currentAddress, string permAddress)
        {
            var driver = webDriverFixture.ChromeDriver;

            testOutputHelper.WriteLine("1st Test Global");
            driver
                .Navigate()
                .GoToUrl("https://demoqa.com/");

            
            // Elements from landing page 
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();

            // Text Box from Elements Sub-menu
            driver.FindElement(By.CssSelector("#item-0")).Click();

            driver.FindElement(By.Id("userName")).SendKeys(userName);
            driver.FindElement(By.Id("userEmail")).SendKeys(userEmail);
            driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            driver.FindElement(By.Id("permanentAddress")).SendKeys(permAddress);

            Thread.Sleep(1000);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(3000);

        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ClassFixtureTestFillMemberData(string userName, string userEmail, string currentAddress, string permAddress)
        {
            var driver = webDriverFixture.ChromeDriver;

            testOutputHelper.WriteLine("1st Test Global");
            driver
                .Navigate()
                .GoToUrl("https://demoqa.com/");


            // Elements from landing page 
            driver.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(1)")).Click();

            // Text Box from Elements Sub-menu
            driver.FindElement(By.CssSelector("#item-0")).Click();

            driver.FindElement(By.Id("userName")).SendKeys(userName);
            driver.FindElement(By.Id("userEmail")).SendKeys(userEmail);
            driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            driver.FindElement(By.Id("permanentAddress")).SendKeys(permAddress);

            Thread.Sleep(1000);
            driver.FindElement(By.Id("submit")).Click();

            Thread.Sleep(3000);

        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                "David Donaghy",
                "david@outlook.com",
                "50 clooney terrace",
                "373 abbeydale"
            },
            new object[]
            {
                "Gregg Hyndman",
                "gregg@outlook.com",
                "40 the beeches",
                "111 lincoln courts"
            },
            new object[]
            {
                "Sam Smith",
                "sam@outlook.com",
                "123 by the sea",
                "66 canterbury"
            },
            new object[]
            {
                "Kirsty Chambers",
                "kirsty@outlook.com",
                "4 sevenoaks",
                "77 irish street"
            }
        };

    }
}
