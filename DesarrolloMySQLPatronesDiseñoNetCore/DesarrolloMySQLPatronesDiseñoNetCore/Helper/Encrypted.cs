using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesarrolloMySQLPatronesDiseñoNetCore.Helper
{
    public class Encrypted
    {
        public string Encriptar(string password)
        {
            try
            {
                var passEncrypted = BCrypt.Net.BCrypt.HashPassword(password);
                return passEncrypted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool Verificar(string passwordIngresada, string passwordBD)
        {
            try
            {
                var verified = BCrypt.Net.BCrypt.Verify(passwordIngresada, passwordBD);
                return verified;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
