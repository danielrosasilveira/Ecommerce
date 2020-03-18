using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.Repositories.Contracts
{
    public interface IClienteRepository
    {
        ClienteModel Login(string Email, string Senha);

        void Cadastrar(ClienteModel cliente);

        void Atualizar(ClienteModel cliente);
        
        void Excluir(int Id);

        ClienteModel ObterCliente(int Id);

        IEnumerable<ClienteModel> ObterTodosClientes();

    }
}
