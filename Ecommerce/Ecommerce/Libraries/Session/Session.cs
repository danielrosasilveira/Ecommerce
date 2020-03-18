using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Libraries.Session
{
    public class Session
    {

        //Injeção de dependência
        private IHttpContextAccessor _context;

        #region Constructor
        public Session(IHttpContextAccessor context)
        {
            _context = context;
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(string Key, string Valor)
        {
            _context.HttpContext.Session.SetString(Key, Valor);
        }
        #endregion

        #region Atualizar
        public void Atualizar(string Key, string Valor)
        {
            Remover(Key);
            _context.HttpContext.Session.SetString(Key, Valor);
        }
        #endregion

        #region Remover
        public void Remover(string Key)
        {
            if (Existe(Key))
            {
                _context.HttpContext.Session.Remove(Key);
            }
        }
        #endregion

        #region Consultar
        public string Consultar(string Key)
        {
            return _context.HttpContext.Session.GetString(Key);
        }
        #endregion

        #region Existe
        public bool Existe(string Key)
        {
            if (_context.HttpContext.Session.GetString(Key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region RemoverTodos
        public void RemoverTodos()
        {
            _context.HttpContext.Session.Clear();
        }
        #endregion
    }
}
