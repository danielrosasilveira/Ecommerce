using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        void Cadastrar(NewsletterEmailModel newsletter);

        IEnumerable<NewsletterEmailModel> ObterTodasNewsletter();
    }
}
