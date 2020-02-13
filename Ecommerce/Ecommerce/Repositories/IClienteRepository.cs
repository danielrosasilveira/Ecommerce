﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    interface IClienteRepository
    {
        ClienteModel Login(string Email, string Senha);

        void Cadastrar(ClienteModel cliente);

        void Atualizar(ClienteModel cliente);
        
        void Excluir(int Id);

        ClienteModel ObterCliente(int Id);

        List<ClienteModel> ObterTodosClilentes();

    }
}