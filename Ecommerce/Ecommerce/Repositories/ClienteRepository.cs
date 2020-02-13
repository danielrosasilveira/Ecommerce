using Ecommerce.Database;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private EcommerceContext _banco;

        public ClienteRepository(EcommerceContext banco)
        {
            _banco = banco;
        }

        public void Atualizar(ClienteModel cliente)
        {
            _banco.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(ClienteModel cliente)
        {
            _banco.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            ClienteModel cliente = ObterCliente(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public ClienteModel Login(string Email, string Senha)
        {
            ClienteModel cliente = _banco.Clientes.Where(m => m.Email == Email && m.Senha == Senha).First();
            return cliente;
        }

        public ClienteModel ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }

        public List<ClienteModel> ObterTodosClilentes()
        {
            return _banco.Clientes.ToList();
        }
    }
}
