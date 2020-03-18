using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private EcommerceContext _banco;

        #region Constructor
        public ClienteRepository(EcommerceContext banco)
        {
            _banco = banco;
        }
        #endregion

        #region Atualizar
        public void Atualizar(ClienteModel cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(ClienteModel cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }
        #endregion

        #region Excluir
        public void Excluir(int Id)
        {
            ClienteModel cliente = ObterCliente(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }
        #endregion

        #region Login
        public ClienteModel Login(string Email, string Senha)
        {
            ClienteModel cliente = _banco.Clientes.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return cliente;
        }
        #endregion

        #region ObterCliente
        public ClienteModel ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }
        #endregion

        #region ObterTodosClientes
        public IEnumerable<ClienteModel> ObterTodosClientes()
        {
            return _banco.Clientes.ToList();
        }
        #endregion

    }
}
