using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesarrolloMySQLPatronesDiseñoNetCore.Helper;
using DesarrolloMySQLPatronesDiseñoNetCore.Models;
using DesarrolloMySQLPatronesDiseñoNetCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DesarrolloMySQLPatronesDiseñoNetCore.Controllers
{
    public class LoginController
    {
        private static MySQLDBContext db;
        private static Encrypted encryted;

        public LoginController()
        {
            db = new MySQLDBContext();
            encryted = new Encrypted();
        }
        public  void main()
        {
            Console.WriteLine("Bienvenido al sistema ¿Que desea hacer? \n 1.- Logearse\n  2.- Registrarse");
            var opcion = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
            if (opcion == true)
            {
                Login();
            }
            else
            {
                Register();
            }
        }
        public void Login()
        {
            Console.WriteLine("Coloque su nombre Usuario");
            var usuario = Console.ReadLine();
            var usuarioExiste = db.UsuariosDB.FirstOrDefault(x => x.USERNAME.Equals(usuario)) != null ? true : false;
            if (!usuarioExiste)
            {
                Console.WriteLine("El usuario no existe, ¿deseas intentarlo de nuevo? \n 1.- Sí \n 2.- No");
                var deNuevo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                if (deNuevo)
                {
                    Console.Clear();
                    Login();
                }
                else
                {
                    Console.Clear();
                    main();
                }
            }
            var usuarioBD = db.UsuariosDB.FirstOrDefault(x => x.USERNAME.Equals(usuario));
            Console.WriteLine("Coloque su Contraseña");
            var password = Console.ReadLine();
            var passwordCorrecta = false;
            while (!passwordCorrecta)
            {
                if (encryted.Verificar(password, usuarioBD.PASSWORD))
                {
                    // el usuario se logeo
                    Console.Clear();
                    passwordCorrecta = true;
                }
                else
                {
                    Console.WriteLine("Contraseña Incorrecta Intenta de nuevo");
                    password = Console.ReadLine();
                }
            }
            var articulos = new ArticulosController();
            articulos.MostrarArticulos();
        }
        public void Register()
        {
            try
            {
                var nuevoUsuario = new Usuarios();
                nuevoUsuario.ID_USUARIO = 0;
                Console.WriteLine("Ingrese Nombre de Usuario");
                nuevoUsuario.USERNAME = Console.ReadLine();
                var existeUsuario = db.UsuariosDB.FirstOrDefault(x => x.USERNAME.Equals(nuevoUsuario.USERNAME)) != null ? true : false;
                if (existeUsuario)
                {
                    Console.WriteLine("este nombre de usuario ya existe ¿Deseas intentarlo de nuevo?  \n 1.- Sí \n 2.- No");
                    var deNuevo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                    if (deNuevo)
                    {
                        Console.Clear();
                        Register();
                    }
                    else
                    {
                        Console.Clear();
                        main();
                    }
                }
                Console.WriteLine("Ingresa tu Nombre");
                nuevoUsuario.NOMBRE = Console.ReadLine();
                Console.WriteLine("Ingresa tu apellido");
                nuevoUsuario.APELLIDO = Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña");
                var password = Console.ReadLine();
                nuevoUsuario.PASSWORD = encryted.Encriptar(password);
                db.UsuariosDB.Add(nuevoUsuario);
                db.SaveChanges();
                Console.WriteLine("Usuario Creado Correctamente");
                Login();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
