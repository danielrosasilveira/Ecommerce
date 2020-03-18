using System;
using System.Collections.Generic;
using Ecommerce.Libraries.Email;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Ecommerce.Repositories.Contracts;
using Ecommerce.Libraries.Login;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private IClienteRepository _repositoryCliente;
        private INewsletterRepository _repositoryNewsletter;
        private LoginCliente _loginCliente;

        #region Constructor
        public HomeController(IClienteRepository repositoryCliente, INewsletterRepository repositoryNewsletter, LoginCliente loginCliente)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryNewsletter = repositoryNewsletter;
            _loginCliente = loginCliente;
        }
        #endregion

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Index - POST
        [HttpPost]
        public IActionResult Index(NewsletterEmailModel newsletter)
        {
            if (ModelState.IsValid)
            {
                _repositoryNewsletter.Cadastrar(newsletter);
                
                TempData["MSG_S"] = "E-mail cadastrado! Agora você irá receber promoções especiais no seu e-mail!";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        #endregion

        #region Contato - GET
        public IActionResult Contato()
        {
            return View();
        }
        #endregion

        #region Contato - POST
        [HttpPost]
        public IActionResult Contato(ContatoModel contato)
        {           
            try
            {
                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid = Validator.TryValidateObject(contato, contexto, listaMensagens, true);

                if (isValid)
                {

                    ContatoEmail.EnviarContatoPorEmail(contato);
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;
                }
            }
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Ops! Tivemos um erro, tente novamente mais tarde!<br/>" +
                    "Error: " + ex.Message;
                //TODO - Implementar Log
            }

            return View();
        }
        #endregion

        #region Login - GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region Login - POST
        [HttpPost]
        public IActionResult Login(ClienteModel cliente)
        {
            ClienteModel clienteDB = _repositoryCliente.Login(cliente.Email, cliente.Senha);
            if (clienteDB != null)
            {
                _loginCliente.Login(clienteDB);
                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário ou Senha Inválido";
                return View();
            }
        }
        #endregion

        #region Painel - GET
        [HttpGet]
        public IActionResult Painel()
        {
            ClienteModel cliente = _loginCliente.GetCliente();
            if (cliente != null)
            {
                return new ContentResult() { Content = "Acesso concedido: " + cliente.Id };
            }
            else
            {
                return new ContentResult() { Content = "Acesso Negado!" };
            }
        }
        #endregion

        #region CadastroCliente - GET
        public IActionResult CadastroCliente()
        {
            return View();
        }
        #endregion

        #region CadastroCliente - POST
        [HttpPost]
        public IActionResult CadastroCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _repositoryCliente.Cadastrar(cliente);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
                //TODO - Implemento redirecionamentos diferentes (Painel, Carrinho de Compras, etc).
                return RedirectToAction(nameof(CadastroCliente));                
            }
            return View();
        }
        #endregion

        #region CarrinhoCompras - GET
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
        #endregion

    }
}