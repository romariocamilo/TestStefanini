using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;


namespace TestStefanini.PageObject
{
    public class PaginaCadastro
    {
        public IWebDriver driver { get; private set; }

        public WebDriverWait espera;

        public string url { get; private set; } = "http://prova.stefanini-jgr.com.br/teste/qa/";
        public string nomeValido { get; private set; } = "usuario";
        public string sobreNomeValido { get; private set; } = "valido";
        public string nomeInvalido { get; private set; } = "usuarioinvalido";
        public string emailValido { get; private set; } = "emailvalido@teste.com";
        public string emailInvalido { get; private set; } = "emailinvalido.com";
        public string senhalValido { get; private set; } = "12345678";
        public string senhaInvalido { get; private set; } = "1234567";
        public string excluirUsuario { get; private set; } = "Excluir";

        public PaginaCadastro(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            espera = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
        }

        #region Elementos da página

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[1]/h1")]
        public IWebElement tituloDaPagina { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[1]/p")]
        public IWebElement textoInformativo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/h2")]
        public IWebElement tituloFormulario { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[1]/label")]
        public IWebElement labelNome { get; set; }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement campoNome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[2]/label")]
        public IWebElement labelEmail{ get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement campoEmail{ get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[3]/label")]
        public IWebElement labelSenha { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement campoSenha { get; set; }

        [FindsBy(How = How.Id, Using = "register")]
        public IWebElement botaoCadastrar { get; set; }

        [FindsBy(How = How.TagName, Using = "table")]
        public IWebElement tabelaUsuarios { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[1]/p")]
        public IWebElement avisoNome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[2]/p")]
        public IWebElement avisoEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='root']/div/div/div[2]/form/div[3]/p")]
        public IWebElement avisoSenha { get; set; }

        [FindsBy(How = How.Id, Using = "tdUserId1")]
        public IWebElement idUsuarioTabela { get; set; }

        [FindsBy(How = How.Id, Using = "tdUserName1")]
        public IWebElement nomeUsuarioTabela { get; set; }

        [FindsBy(How = How.Id, Using = "tdUserEmail1")]
        public IWebElement emailUsuarioTabela { get; set; }

        [FindsBy(How = How.Id, Using = "removeUser1")]
        public IWebElement excluirUsuarioTabela { get; set; }

        #endregion
    }
}
