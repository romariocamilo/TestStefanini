using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStefanini.Configuration
{
    public class Driver
    {
        public IWebDriver driver { get; private set; } = new ChromeDriver();
    }
}
