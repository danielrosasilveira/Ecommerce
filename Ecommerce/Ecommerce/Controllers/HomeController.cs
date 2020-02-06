using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Email;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public IActionResult Index()
        {
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
                ContatoEmail.EnviarContatoPorEmail(contato);

                ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
            }
            catch (Exception ex)
            {
                ViewData["MSG_E"] = "Ops! Tivemos um erro, tente novamente mais tarde!";
                //TODO - Implementar Log
            } 
            return View();
        }
        #endregion

        #region Login - GET
        public IActionResult Login()
        {
            return View();
        }
        #endregion

        #region CadastroCliente - GET
        public IActionResult CadastroCliente()
        {
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