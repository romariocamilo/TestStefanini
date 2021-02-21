using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStefanini.RoboGeralAuxilar
{
    public class RoboGeral
    {
        public void Clicar(IWebElement elemento)
        {
            elemento.Click();
        }

        public void Preencher(IWebElement elemento, string texto)
        {
            elemento.SendKeys(texto);
        }

        public void Printar(IWebDriver driver, string nomeCenario, string nomeImagem, bool fechar)
        {
            string path = Directory.GetCurrentDirectory() + "\\Evidencias\\" + nomeCenario + "\\";
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();

            if (Directory.Exists(path))
            {
                foto.SaveAsFile(path + nomeImagem + ".png", ScreenshotImageFormat.Png);
            }
            else
            {
                Directory.CreateDirectory(path);
                foto.SaveAsFile(path + nomeImagem + ".png", ScreenshotImageFormat.Png);
            }

            if (fechar)
            {
                Fechar(driver);
            }
        }

        public void Fechar(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
        }

        public void Relatorio(string nomeCenario)
        {
            var htmlReporter = new ExtentHtmlReporter("Relatorios\\" + nomeCenario + "\\");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            var test = extent.CreateTest(nomeCenario);
            extent.Flush();
        }
    }
}
