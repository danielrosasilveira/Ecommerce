using Ecommerce.Libraries.Lang;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class NewsletterEmailModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E004")]
        public string Email { get; set; }
    }
}
