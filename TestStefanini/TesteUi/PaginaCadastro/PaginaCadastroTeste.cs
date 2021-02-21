using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;
using TestStefanini.RoboGeralAuxilar;

namespace TestStefanini
{
    [TestClass]
    public class PaginaCadastroTestes
    {
        RoboGeral roboGeral = new RoboGeral();

        [TestMethod]
        public void ValidaElementosAPaginaDeCadastro()
        {
            _ = new Robo().ObtiUrl()
                .AcesseiPagina()
                .ValideiTitulo()
                .ValideiTextoInformativo()
                .ValideiTituloFormulario()
                .ValideiCampoNome()
                .ValideiCampoEmail()
                .ValideiCampoSenha()
                .ValideiBotaoSalvar()
                .ValideiNaoExistenciaDeTabelaUsuario();
            roboGeral.Relatorio("ValidaElementosAPaginaDeCadastro");
        }

        [TestMethod]
        public void ValidaCadastroSemNome()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoEmailValido()
                .PreenchiOCampoSenhaValida()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeCampoObrigatorioExibidoParaOCampoNome();
            roboGeral.Relatorio("ValidaCadastroSemNome");
        }

        [TestMethod]
        public void ValidaCadastroComNomeInvalido()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeSomenteComPrimeiroNome()
                .PreenchiOCampoEmailValido()
                .PreenchiOCampoSenhaValida()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeNomeInvalido();
            roboGeral.Relatorio("ValidaCadastroComNomeInvalido");
        }

        [TestMethod]
        public void ValidaCadastroSemEmail()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeValido()
                .PreenchiOCampoSenhaValida()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeCampoObrigatorioExibidoParaOCampoEmail();
            roboGeral.Relatorio("ValidaCadastroSemEmail");
        }

        [TestMethod]
        public void ValidaCadastroComEmailInvalido()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeValido()
                .PreenchiOCampoEmailComEmailInvalido()
                .PreenchiOCampoSenhaValida()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeEmailInvalidoExibidoParaOCampoEmail();
            roboGeral.Relatorio("ValidaCadastroComEmailInvalido");
        }

        [TestMethod]
        public void ValidaCadastroSemSenha()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeValido()
                .PreenchiOCampoEmailValido()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeCampoObrigatorioExibidoParaOCampoSenha();
            roboGeral.Relatorio("ValidaCadastroSemSenha");
        }

        [TestMethod]
        public void ValidaCadastroComSenhaInvalida()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeValido()
                .PreenchiOCampoEmailValido()
                .PreenchiOCampoSenhaComUmaSenhaInvalida()
                .CliqueiNoBotaoCadastrar()
                .ValideiAvisoDeSenhaInvalidaExibidoParaOCampoSenha();
            roboGeral.Relatorio("ValidaCadastroComSenhaInvalida");
        }

        [TestMethod]
        public void ValidaCadastroValido()
        {
            _ = new Robo().EstouNaTelaCadastro()
                .PreenchiOCampoNomeValido()
                .PreenchiOCampoEmailValido()
                .PreenchiOCampoSenhaValida()
                .CliqueiNoBotaoCadastrar()
                .ValideiTabelaDeUsuariosCadastrados()
                .ValideiUsuarioComOsDadosInformadosNoCadastro();
            roboGeral.Relatorio("ValidaCadastroValido");
        }

        [TestMethod]
        public void ValidaCadastroEmMassa()
        {
            _ = new Robo().EstouNaTelaCadastro()
            .ExecuteiOCadastroEmMassa()
            .ValideiUsuarioCadastradosEmMassa();
            roboGeral.Relatorio("ValidaCadastroEmMassa");
        }

        [TestMethod]
        public void ValidaExclusaoUsuario()
        {
            _ = new Robo().EstouNaTelaCadastro()
            .DadoTenhaUsuariosCadastrados()
            .CliqueiEmExlcuir()
            .ValideiUsuarioRemovidoDaLista();
            roboGeral.Relatorio("ValidaExclusaoUsuario");
        }

    }
}
