using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloMySQLPatronesDiseñoNetCore.Models
{
    [Table("ARTICULOS")]
    public class ARTICULOS
    {
        [Key]
        public int ID_ARTICULO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
    }
}
