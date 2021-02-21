using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestStefanini.TesteUi.PaginaCadastro
{
    [TestFixture]
    public class ClasseParaTesteIgnonar
    {
        public IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TesteComSetUpTearDown()
        {
            driver.Navigate().GoToUrl("https://www.google.com.br/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
