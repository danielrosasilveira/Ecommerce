using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {

        private EcommerceContext _banco;

        public NewsletterRepository(EcommerceContext banco)
        {
            _banco = banco;
        }

        public void Cadastrar(NewsletterEmailModel newsletter)
        {
            _banco.NewsletterEmails.Add(newsletter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsletterEmailModel> ObterTodasNewsletter()
        {
            return _banco.NewsletterEmails.ToList();
        }
    }
}
