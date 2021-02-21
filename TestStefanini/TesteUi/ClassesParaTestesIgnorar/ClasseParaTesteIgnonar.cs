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
using TestStefanini.TesteUi.ClassesParaTestesIgnorar;

namespace TestStefanini.TesteUi.PaginaCadastro
{
    ////Testestando depêndencias do NUnit Adapter
    //[TestFixture]
    //public class ClasseParaTesteIgnonar
    //{
    //    public IWebDriver driver;

    //    [SetUp]
    //    public void setUp()
    //    {
    //        driver = new ChromeDriver();
    //    }

    //    [Test]
    //    public void TesteComSetUpTearDown()
    //    {
    //        driver.Navigate().GoToUrl("https://www.google.com.br/");
    //        driver.Manage().Window.Maximize();
    //        Thread.Sleep(5000);
    //    }

    //    [Test]
    //    public void TestarBdd()
    //    {
    //        RoboIgnorar robo = new RoboIgnorar();
    //        robo.GivenTheFirstNumberIs("1");
    //        robo.GivenTheSecondNumberIs("2");
    //        robo.WhenTheTwoNumbersAre("soma");
    //        robo.ThenTheResultShouldBe("3");

    //    }

    //    [TearDown]
    //    public void tearDown()
    //    {
    //        driver.Quit();
    //    }
    //}
}
