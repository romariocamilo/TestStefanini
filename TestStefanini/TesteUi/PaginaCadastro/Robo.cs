using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestStefanini.Configuration;
using TestStefanini.PageObject;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using TestStefanini.Modelo;
using System.IO;
using TestStefanini.RoboGeralAuxilar;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace TestStefanini
{
    [Binding]
    public class Robo : RoboGeral
    {
        PaginaCadastro paginaCadastro = new PaginaCadastro(new Driver().driver);
        string url;
        List<Usuario> listaUsuarioMassa = new List<Usuario>();

        //Acessar pagina de cadastro
        [Given("que eu tenha a url destino")]
        public Robo ObtiUrl()
        {
            url = paginaCadastro.url;
            return this;
        }

        [When("eu acessei a url")]
        public Robo AcesseiPagina()
        {
            paginaCadastro.driver.Manage().Window.Maximize();
            paginaCadastro.driver.Navigate().GoToUrl(url);
            return this;
        }

        [Then("a pagina é aberta com titulo Cadastro de Usuários")]
        public Robo ValideiTitulo()
        {
            string tituloDaPagina = "Cadastro de usuários";
            Assert.IsTrue(paginaCadastro.tituloDaPagina.Text == tituloDaPagina);
            return this;
        }

        [Then(@"exibe o texto informativo Para realizar o cadastro de um usuário, insira dados válidos no formulário e acione a opção Cadastrar :\)")]
        public Robo ValideiTextoInformativo()
        {
            string textoInformativo = "Para realizar o cadastro de um usuário, insira dados válidos no formulário\r\ne acione a opção Cadastrar :)";
            Assert.IsTrue(paginaCadastro.textoInformativo.Text == textoInformativo);
            return this;
        }

        [Then(@"exibe o formulario de cadastro com titulo Formulário")]
        public Robo ValideiTituloFormulario()
        {
            string tituloFormulario = "Formulário";
            Assert.IsTrue(paginaCadastro.tituloFormulario.Text == tituloFormulario);
            return this;
        }

        [Then(@"exibe o campo Nome")]
        public Robo ValideiCampoNome()
        {
            string labelNome = "Nome";
            string placeHolder = "João da Silva";
            string textoCampo = "";

            Assert.IsTrue(paginaCadastro.labelNome.Text == labelNome);

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.Id("name"))).Displayed;
            Assert.IsTrue(visivel);

            Assert.IsTrue(paginaCadastro.campoNome.GetAttribute("placeholder") == placeHolder);
            Assert.IsTrue(paginaCadastro.campoNome.Text == textoCampo);
            return this;
        }

        [Then(@"exibe o E-mail")]
        public Robo ValideiCampoEmail()
        {
            string labelEmail = "E-mail";
            string placeHolder = "joao.silva@email.com";
            string textoEmail = "";

            Assert.IsTrue(paginaCadastro.labelEmail.Text == labelEmail);

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.Id("email"))).Displayed;
            Assert.IsTrue(visivel);

            Assert.IsTrue(paginaCadastro.campoEmail.GetAttribute("placeholder") == placeHolder);
            Assert.IsTrue(paginaCadastro.campoEmail.Text == textoEmail);

            return this;
        }

        [Then(@"exibe o campo Senha")]
        public Robo ValideiCampoSenha()
        {
            string labelSenha = "Senha";
            string placeHolder = "********";
            string textoSenha = "";
            string tipoCampo = "password";

            Assert.IsTrue(paginaCadastro.labelSenha.Text == labelSenha);

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.Id("email"))).Displayed;
            Assert.IsTrue(visivel);

            Assert.IsTrue(paginaCadastro.campoSenha.GetAttribute("placeholder") == placeHolder);          
            Assert.IsTrue(paginaCadastro.campoSenha.GetAttribute("type") == tipoCampo);
            Assert.IsTrue(paginaCadastro.campoSenha.Text == textoSenha);

            return this;
        }

        [Then(@"exibe o botão Cadastrar")]
        public Robo ValideiBotaoSalvar()
        {
            string textoBotao = "Cadastrar";

            Assert.IsTrue(paginaCadastro.botaoCadastrar.Text == textoBotao);
            return this;
        }

        [Then(@"não exibe a tabela de usuarios cadastrados")]
        public Robo ValideiNaoExistenciaDeTabelaUsuario()
        {
            bool visivel = false;
            
            try
            {
                visivel = paginaCadastro.tabelaUsuarios.Displayed;
            }
            catch(Exception ex)
            {
                visivel = false;
            }
            finally
            {
                Assert.IsFalse(visivel);
            }

            Printar(paginaCadastro.driver, "Validar elementos da pagina".Replace(' ', '_'), "ValidaElementosAPaginaDeCadastro", true);

            return this;
        }



        //Validar cadastro sem nome
        [Given(@"que eu esteja na tela de cadastro")]
        public Robo EstouNaTelaCadastro()
        {
            ObtiUrl();
            AcesseiPagina();
            return this;
        }

        [When(@"preenchi o campo Email")]
        public Robo PreenchiOCampoEmailValido()
        {
            Preencher(paginaCadastro.campoEmail, paginaCadastro.emailValido);
            return this;
        }

        [When(@"preenchi o campo Senha")]
        public Robo PreenchiOCampoSenhaValida()
        {
            Preencher(paginaCadastro.campoSenha, paginaCadastro.senhalValido);
            return this;
        }

        [When(@"cliquei no botao Cadastrar")]
        public Robo CliqueiNoBotaoCadastrar()
        {
            Clicar(paginaCadastro.botaoCadastrar);
            return this;
        }

        [Then(@"entao um aviso de campo obrigatório é exibido para o campo nome")]
        public Robo ValideiAvisoDeCampoObrigatorioExibidoParaOCampoNome()
        {
            string aviso = "O campo Nome é obrigatório.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[1]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoNome.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro sem nome".Replace(' ', '_'), "ValidaCadastroSemNome", true);

            return this;
        }



        //Validar cadastro com nome invalido
        [When(@"eu preenchi o campo nome somente com primeiro nome")]
        public Robo PreenchiOCampoNomeSomenteComPrimeiroNome()
        {
            Preencher(paginaCadastro.campoNome, paginaCadastro.nomeInvalido);
            return this;
        }

        [Then(@"entao um aviso de nome invalido é exibido para o campo nome")]
        public Robo ValideiAvisoDeNomeInvalido()
        {
            string aviso = "Por favor, insira um nome completo.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[1]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoNome.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro com nome invalido".Replace(' ', '_'), "ValidaCadastroComNomeInvalido", true);

            return this;
        }



        //Validar cadastro sem email
        [When(@"eu preenchi o campo Nome")]
        public Robo PreenchiOCampoNomeValido()
        {
            Preencher(paginaCadastro.campoNome, paginaCadastro.nomeValido + " " + paginaCadastro.sobreNomeValido);
            return this;
        }

        [Then(@"entao um aviso de campo obrigatório é exibido para o campo email")]
        public Robo ValideiAvisoDeCampoObrigatorioExibidoParaOCampoEmail()
        {
            string aviso = "O campo E-mail é obrigatório.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[2]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoEmail.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro sem email".Replace(' ', '_'), "ValidaCadastroSemEmail", true);

            return this;
        }



        //Validar cadastro com email invalido
        [When(@"eu preenchi o campo Email com email invalido")]
        public Robo PreenchiOCampoEmailComEmailInvalido()
        {
            Preencher(paginaCadastro.campoEmail, paginaCadastro.emailInvalido);
            return this;
        }

        [Then(@"entao um aviso de email invalido é exibido para o campo email")]
        public Robo ValideiAvisoDeEmailInvalidoExibidoParaOCampoEmail()
        {
            string aviso = "Por favor, insira um e-mail válido.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[2]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoEmail.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro com email invalido".Replace(' ', '_'), "ValidaCadastroComEmailInvalido", true);

            return this;
        }



        //Validar cadastro sem senha
        [Then(@"entao um aviso de campo obrigatório é exibido para o campo senha")]
        public Robo ValideiAvisoDeCampoObrigatorioExibidoParaOCampoSenha()
        {
            string aviso = "O campo Senha é obrigatório.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[3]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoSenha.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro sem senha".Replace(' ', '_'), "ValidaCadastroSemSenha", true);

            return this;
        }



        //Validar cadastro com senha invalida
        [When(@"preenchi o campo Senha com uma senha invalida")]
        public Robo PreenchiOCampoSenhaComUmaSenhaInvalida()
        {
            Preencher(paginaCadastro.campoSenha, paginaCadastro.senhaInvalido);
            return this;
        }

        [Then(@"entao um aviso de senha invalida é exibido para o campo senha")]
        public Robo ValideiAvisoDeSenhaInvalidaExibidoParaOCampoSenha()
        {
            string aviso = "A senha deve conter ao menos 8 caracteres.";

            bool visivel = paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='root']/div/div/div[2]/form/div[3]/p"))).Displayed;
            Assert.IsTrue(visivel);
            Assert.IsTrue(paginaCadastro.avisoSenha.Text == aviso);
            Printar(paginaCadastro.driver, "Validar cadastro com senha invalida".Replace(' ', '_'), "ValidaCadastroComSenhaInvalida", true);

            return this;
        }



        //Validar cadastro valido
        [Then(@"entao o sistema exibe da tabela de usuarios cadasdtrados")]
        public Robo ValideiTabelaDeUsuariosCadastrados()
        {
            paginaCadastro.espera.Until(ExpectedConditions.ElementIsVisible(By.TagName("table")));
            return this;
        }

        [Then(@"exibe o usuario com os dados informados no cadastro")]
        public Robo ValideiUsuarioComOsDadosInformadosNoCadastro()
        {
            string idValido = "1";
            string nomeValido = paginaCadastro.nomeValido + " " + paginaCadastro.sobreNomeValido;
            string emailValido = paginaCadastro.emailValido;
            string textoExluir = paginaCadastro.excluirUsuario;

            Assert.IsTrue(paginaCadastro.idUsuarioTabela.Text == idValido);
            Assert.IsTrue(paginaCadastro.nomeUsuarioTabela.Text == nomeValido);
            Assert.IsTrue(paginaCadastro.emailUsuarioTabela.Text == emailValido);
            Assert.IsTrue(paginaCadastro.excluirUsuarioTabela.Text == textoExluir);
            Printar(paginaCadastro.driver, "Validar cadastro valido".Replace(' ', '_'), "ValidaCadastroValido", true);

            return this;
        }



        //Validar cadastro em massa
        [When(@"eu executei o cadastro em massa")]
        public Robo ExecuteiOCadastroEmMassa()
        {
            string path = Directory.GetCurrentDirectory();
            string[] linhas = System.IO.File.ReadAllLines(path + "//Massa//massa.txt");
            int contador = 1;

            foreach (var varredor in linhas)
            {
                string[] linhasQuebradas = varredor.Split(' ');

                Usuario novoUsuario = new Usuario(contador, linhasQuebradas[0], linhasQuebradas[1], linhasQuebradas[2]);
                listaUsuarioMassa.Add(novoUsuario);
                paginaCadastro.campoNome.SendKeys(novoUsuario.NomeUsuario + " " + novoUsuario.SobreNomeUsuario);
                paginaCadastro.campoEmail.SendKeys(novoUsuario.EmailUsuario);
                PreenchiOCampoSenhaValida();
                CliqueiNoBotaoCadastrar();
                Printar(paginaCadastro.driver, "Validar cadastro em massa".Replace(' ', '_'), "ValidaCadastroEmMassa" + contador.ToString(), false);
                contador++;
            }

            return this;
        }

        [Then(@"exibe os usuarios com os dados informados no cadastro")]
        public Robo ValideiUsuarioCadastradosEmMassa()
        {
            var listaUsuariosCadastrados = paginaCadastro.driver.FindElements(By.TagName("tr"));
            int contador = 0;
            bool massaValidada = false;
            foreach(var varredor in listaUsuariosCadastrados)
            {
                string[] usuarioFront = varredor.Text.Split(' ');
                string usuarioFrontId = usuarioFront[0];
                string usuarioFrontNome = usuarioFront[1];
                string usuarioFrontSobreNome = usuarioFront[2];
                string usuarioFrontEmail = usuarioFront[3];
                string usuarioFrontExluir = usuarioFront[4];

                if (usuarioFrontId == listaUsuarioMassa[contador].IdUsuario.ToString()
                    && usuarioFrontNome == listaUsuarioMassa[contador].NomeUsuario
                    && usuarioFrontSobreNome == listaUsuarioMassa[contador].SobreNomeUsuario
                    && usuarioFrontEmail == listaUsuarioMassa[contador].EmailUsuario
                    && usuarioFrontExluir == paginaCadastro.excluirUsuario)
                {
                    massaValidada = true;
                }
                else
                {
                    massaValidada = false;
                    break;
                }
                contador++;
            }

            Assert.IsTrue(massaValidada);
            Fechar(paginaCadastro.driver);
            return this;
        }



        //Remover usuarios cadastrados
        [Given(@"tenha usuarios cadastrados")]
        public Robo DadoTenhaUsuariosCadastrados()
        {
            ExecuteiOCadastroEmMassa();
            return this;
        }

        [When(@"eu clicar em Exlcuir")]
        public Robo CliqueiEmExlcuir()
        {
            var elemento = paginaCadastro.driver.FindElements(By.TagName("tr"));
            int contador = 1; ;

            foreach(var varredor in elemento)
            {
                Printar(paginaCadastro.driver, "Remover usuarios cadastrados".Replace(' ', '_'), "ValidaExclusaoUsuario" + contador.ToString(), false);
                Clicar(paginaCadastro.driver.FindElement(By.Id("removeUser" + contador.ToString())));
                contador++;
            }

            return this;
        }

        [Then(@"então o sistema remove usuarios da lista")]
        public Robo ValideiUsuarioRemovidoDaLista()
        {
            Printar(paginaCadastro.driver, "Remover usuarios cadastrados".Replace(' ', '_'), "ValidaExclusaoUsuario5", true);
            return this;
        }
    }
}
