using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesarrolloMySQLPatronesDiseñoNetCore.Models;
using DesarrolloMySQLPatronesDiseñoNetCore.Persistence;

namespace DesarrolloMySQLPatronesDiseñoNetCore.Controllers
{
    public class ArticulosController
    {
        private static MySQLDBContext db;
        private static List<ARTICULOS> list;

        public ArticulosController()
        {
            db = new MySQLDBContext();
        }
        public void MostrarArticulos()
        {
            list = db.ArticulosDB.ToList();
            var opc = 0;
            var salir = false;
            if (list.Count != 0)
            {
                Console.WriteLine("Codigo  ||  Descripción || Precio");
                foreach (var item in list)
                {
                    Console.WriteLine(item.ID_ARTICULO+" || "+item.DESCRIPCION+" || "+item.PRECIO);
                }
                Console.WriteLine("¿Que opción desea realizar?\n1.- Agregar un Articulo\n2.- Actualizar un Articulo\n3.- Eliminar un Articulo\n4.- Salir Programa");
                opc = Convert.ToInt32(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        AddArticulo();
                        break;
                    case 2:
                        UpdateArticulo();
                        break;
                    case 3:
                        DeleteArticulo();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("No existen Articulos Deseas Agregar uno nuevo \n1.- Si \n2.- salir del programa");
                salir = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                if (salir)
                {
                    AddArticulo();
                }
            }
        }

        public void UpdateArticulo()
        {
            Console.Clear();
            Console.WriteLine("Codigo  ||  Descripción || Precio");
            foreach (var item in list)
            {
                Console.WriteLine(item.ID_ARTICULO + " || " + item.DESCRIPCION + " || " + item.PRECIO);
            }
            Console.WriteLine("¿Qué artículo desea actualizar?");
            var idArticulo = Convert.ToInt32(Console.ReadLine());
            var articulo = db.ArticulosDB.FirstOrDefault(x => x.ID_ARTICULO == idArticulo);
            if (articulo == null)
            {
                Console.WriteLine("El artículo no existe, ¿deseas intentarlo de nuevo? \n 1.- Sí \n 2.- No");
                var deNuevo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                if (deNuevo)
                {
                    Console.Clear();
                    UpdateArticulo();
                }
                else
                {
                    Console.Clear();
                    MostrarArticulos();
                }
            }
            Console.WriteLine("Coloque la nueva descripción");
            articulo.DESCRIPCION = Console.ReadLine() ?? articulo.DESCRIPCION;
            Console.WriteLine("Coloque el nuevo precio");
            articulo.PRECIO = Convert.ToDecimal(Console.ReadLine()); 
            db.ArticulosDB.Update(articulo);
            db.SaveChanges();
            Console.WriteLine("Artículo actualizado correctamente pulse enter para continuar");
            Console.ReadLine();
            Console.Clear();
            MostrarArticulos();
        }

        public void DeleteArticulo()
        {
            Console.Clear();
            Console.WriteLine("Codigo  ||  Descripción || Precio");
            foreach (var item in list)
            {
                Console.WriteLine(item.ID_ARTICULO + " || " + item.DESCRIPCION + " || " + item.PRECIO);
            }
            Console.WriteLine("¿Qué artículo desea eliminar?");
            var idArticulo = Convert.ToInt32(Console.ReadLine());
            var articulo = db.ArticulosDB.FirstOrDefault(x => x.ID_ARTICULO == idArticulo);
            if (articulo == null)
            {
                Console.WriteLine("El artículo no existe, ¿deseas intentarlo de nuevo? \n 1.- Sí \n 2.- No");
                var deNuevo = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;
                if (deNuevo)
                {
                    Console.Clear();
                    DeleteArticulo();
                }
                else
                {
                    Console.Clear();
                    MostrarArticulos();
                }
            }

            db.ArticulosDB.Remove(articulo);
            db.SaveChanges();
            Console.WriteLine("Artículo Agregado correctamente pulse enter para continuar");
            Console.ReadLine();
            Console.Clear();
            MostrarArticulos();
        }
        public void AddArticulo()
        {
            var nuevoArticulo = new ARTICULOS();
            nuevoArticulo.ID_ARTICULO = 0;
            Console.WriteLine("Coloque la Descripción del artículo");
            nuevoArticulo.DESCRIPCION = Console.ReadLine();
            Console.WriteLine("Coloque el precio");
            nuevoArticulo.PRECIO = Convert.ToDecimal(Console.ReadLine());
            db.ArticulosDB.Add(nuevoArticulo);
           db.SaveChanges();
            Console.WriteLine("Artículo Agregado correctamente pulse enter para continuar");
            Console.ReadLine();
            Console.Clear();
            MostrarArticulos();
        }
    }
}
