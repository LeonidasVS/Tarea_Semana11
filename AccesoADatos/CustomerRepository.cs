using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class CustomerRepository
    {
        public ActividadPrograEntities1 contexto = new ActividadPrograEntities1();

        public List<Productos> ObtenerProductos()
        {
            var producto = from pro in contexto.Productos select pro;
            return producto.ToList();
        }

        public Productos ObtenerPorId(string id)
        {
            var obtenerId = from c in contexto.Productos where c.idProducto == id select c;
            return obtenerId.FirstOrDefault();
        }

        public int InsertarCliente(Productos producto)
        {
            contexto.Productos.Add(producto);
            return contexto.SaveChanges();
        }
    }
}
