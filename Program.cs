using System.IO.Compression;
using System.Data;
using System;
using System.Threading.Tasks;

namespace TestHttpClient
{
    class Program
    {
        static string provider;
        static string username;
        static string password;
        // se crea la instancia de la case BankClient que es la que maneja las peticiones HTTP
        static BankClient iniciar = new BankClient();
        static async Task Main(string[] args)
        {
            await Program.LoginUser();
        }

        static async Task LoginUser()
        {
            // mensaje de bienvenida
            Console.WriteLine(@"Bienvenido a Bank
            Ingrese los siguientes datos para iniciar sesion
            ");

            // se reciben los datos del usuario
            Console.WriteLine("Ingrese su proveedor: ");
            provider = Console.ReadLine();
            Console.WriteLine("Ingrese usurio: ");
            username = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña: ");
            password = Console.ReadLine();

            // llamamos a su metodo SesionUser el cual inicia la sesion
            var validUser = await iniciar.SesionUser(provider, username, password);

            if (validUser)
            {
                await MenuPrincipal();
            }
            else
            {
                Console.WriteLine("No se pudo iniciar la sesion");
            }
        }
        static async Task MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine(@$"Bienvenido de nuevo
                -Tu usuario es: {username}
                -Tu proveedor es: {provider}
            ");
            string numberOption = "";
            while (numberOption != "6")
            {
                Console.WriteLine(@" Lo que puedes hacer
                    1. Ver todo sobre Clientes
                    2. Ver todo sobre Datos Transaccionales
                    3. Ver todo sobre Transferencias
                    4. Ver todo sobre Meta
                    5. Cerrar sesion
                    6. Terminar ejecucion
                ");
                numberOption = Console.ReadLine();
                if (numberOption == "1")
                {
                    Console.WriteLine("Clientes \n");
                    Console.WriteLine(@"Lo que puedes hacer
                        1.Listar Clientes
                        2.Listar Clientes por Id
                    ");
                    string numberOptionClient = Console.ReadLine();
                    if (numberOptionClient == "1")
                    {
                        await iniciar.GetClient();
                    }
                    else if (numberOptionClient == "2")
                    {
                        
                    }
                }
                else if (numberOption == "2")
                {
                    Console.WriteLine("Datos Transaccionales \n");
                }
                else if (numberOption == "3")
                {
                    Console.WriteLine("Transferencias \n");
                }
                else if (numberOption == "4")
                {
                    Console.WriteLine("Meta \n");
                }
                else if (numberOption == "5")
                {
                    await iniciar.LogoutSesion();
                }
                else if (numberOption == "6")
                {
                    Console.WriteLine("Programa terminado \n");
                }
                else
                {
                    Console.WriteLine("Opcion no valida ");
                }
            }
        }
    }

}
