using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloMySQLPatronesDiseñoNetCore.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int ID_USUARIO { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
    }
}
