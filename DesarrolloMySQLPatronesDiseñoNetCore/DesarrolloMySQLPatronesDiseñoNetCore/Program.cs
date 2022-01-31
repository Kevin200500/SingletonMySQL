
using System;
using System.Linq;
using DesarrolloMySQLPatronesDiseñoNetCore.Controllers;
using DesarrolloMySQLPatronesDiseñoNetCore.Persistence;


namespace DesarrolloMySQLPatronesDiseñoNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var login = new LoginController();
            login.main();
            Console.ReadKey();
        }
    }
}
