using System;
using System.Collections.Generic;
namespace TestHttpClient
{
    public class Utilities
    {
        string key;

        public string GetRequestLogin(Dictionary<string, string> data)
        {
            // recorremos el diccionario para extrar la informacion del key 
            foreach (var index in data)
            {
                if (index.Value.Equals("logged_out"))
                {
                    Console.WriteLine("Has cerrado sesion correctamente");
                }
                if (index.Key.Equals("key"))
                {
                    key = index.Value;
                    Console.WriteLine("Login exitoso!! \n");
                    Console.Clear();
                }
                if (index.Key.Equals("message") || index.Value.Equals("wrong_credentials"))
                {
                   Console.WriteLine(@$"
                   Ha ocurrido un erro:
                   Mensaje de error: {index.Value}
                   ");
                }
            }
            return key;
        }
        
    }
}