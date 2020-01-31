using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
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