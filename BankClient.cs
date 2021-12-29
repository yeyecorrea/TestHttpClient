using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestHttpClient
{
    public class BankClient : CostantsUrl
    {
        // variable que almacena la key
        string key;
        bool validKey;
        // intancia estatica del HttpClient
        private static HttpClient client = new HttpClient();

        // instancia de clase Utilities que se encarga de manejar las respuestas
        Utilities utilidad = new Utilities();

        // metodo que crea sesion de usuario
        public async Task<bool> SesionUser(string provider, string username, string password, string type = "")
        {
            // diccionario que va a recibir la respuesta
            Dictionary<string, string> data = new Dictionary<string, string> { };

            // cadena con las credenciales
            var cadena = $"provider={provider}&username={username}&password={password}&type={type}";

            // clase que Proporciona contenido HTTP basado en una cadena.
            var content = new StringContent(cadena, Encoding.UTF8, "application/x-www-form-urlencoded");

            // metodo PostAsync que recibe la url y el cuerpo de la solicitu Post
            var respuesta = await client.PostAsync(urlLogin, content);

            // lee el contenido de la respuesta
            var contenido = await respuesta.Content.ReadAsStringAsync();
            // convertimos la respuesta en un diccionario
            data = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenido);
            // pasamos la data al metodo GetRequestLogin() que manega la respuesta del login
            key = utilidad.GetRequestLogin(data);
            var validateKey = key == null ? validKey = false : validKey = true;
            return validKey;
        }

        // metodo que cierra la sesion del usuario
        public async Task<bool> LogoutSesion()
        {
            Dictionary<string, string> logoutData = new Dictionary<string, string> { };
            var urlKey = $"{urlLogout}?key={key}";
            var respuesta = await client.GetAsync(urlKey);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            logoutData = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenido);
            utilidad.GetRequestLogin(logoutData);
            key = null;
            var validateKey = key == null ? validKey = false : validKey = true;
            return validateKey;
        }
     
        public async Task GetClient()
        {
            Dictionary<string, string> clientData = new Dictionary<string, string>{};
            var urlKey = $"{urlClient}?key={key}";
            var respuesta = await client.GetAsync(urlKey);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            clientData = JsonConvert.DeserializeObject<Dictionary<string, string>>(contenido);
            key = utilidad.GetRequestLogin(clientData);
        }
    }
}