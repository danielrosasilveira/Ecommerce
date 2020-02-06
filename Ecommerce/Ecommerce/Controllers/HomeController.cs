﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Libraries.Email;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text;

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