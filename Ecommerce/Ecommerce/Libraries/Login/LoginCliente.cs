using Ecommerce.Models;
using Newtonsoft.Json;

namespace Ecommerce.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Session.Session _session;

        #region Constructor
        public LoginCliente(Session.Session session )
        {
            _session = session;
        }
        #endregion

        #region Login
        public void Login(ClienteModel cliente)
        {
            //Serializar
            string clienteJsonString = JsonConvert.SerializeObject(cliente);
            _session.Cadastrar(Key, clienteJsonString);
        }
        #endregion

        #region GetCliente
        public ClienteModel GetCliente()
        {
            //Deserializar
            if (_session.Existe(Key))
            {
                string clienteJsonString = _session.Consultar(Key);
                return JsonConvert.DeserializeObject<ClienteModel>(clienteJsonString);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Logout
        public void Logout()
        {
            _session.RemoverTodos();
        }
        #endregion
    }
}
