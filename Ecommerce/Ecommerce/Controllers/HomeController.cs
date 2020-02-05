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
            ContatoEmail.EnviarContatoPorEmail(contato);

            return new ContentResult()
            {
                Content = string.Format(@"Dados recebidos com sucesso!<br/> 
                                                                    Nome:{0} <br/>
                                                                    Email:{1} <br/>
                                                                    Texto:{2} <br/>", 
                                                                    contato.Nome, contato.Email, contato.Texto),
                ContentType = "text/html"
            };
            //return View();
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