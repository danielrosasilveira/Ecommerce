using Ecommerce.Database;
using Ecommerce.Models;
using Ecommerce.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Repositories
{
    public class NewsletterRepository : INewsletterRepository
    {

        private EcommerceContext _banco;

        #region Constructor
        public NewsletterRepository(EcommerceContext banco)
        {
            _banco = banco;
        }
        #endregion

        #region Cadastrar
        public void Cadastrar(NewsletterEmailModel newsletter)
        {
            _banco.NewsletterEmails.Add(newsletter);
            _banco.SaveChanges();
        }
        #endregion

        #region ObterTodasNewsletter
        public IEnumerable<NewsletterEmailModel> ObterTodasNewsletter()
        {
            return _banco.NewsletterEmails.ToList();
        }
        #endregion

    }
}
