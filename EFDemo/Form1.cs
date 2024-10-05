using AccesoADatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerRepository repository = new CustomerRepository();
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            var producto = repository.ObtenerProductos();
            dataGridView1.DataSource = producto;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var producto = repository.ObtenerPorId(txtBuscar.Text);
            List<Productos> pro = new List<Productos>
            {
                producto
            };

            dataGridView1.DataSource = pro;
        }

        public Productos crearProducto()
        {
            int stock = int.Parse(textStock.Text);
            int precio = int.Parse(textPrecio.Text);
            var producto = new Productos
            {
                idProducto = txtProductoId.Text,
                Nombre = txtNombre.Text,
                Precio = precio,
                Stock = stock,
                Descripcion = textDescripcion.Text,
                Marca = textMarca.Text,
                Proveedor = txtProveedor.Text
            };

            return producto;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var insertar = crearProducto();
            var resutado = repository.InsertarCliente(insertar);
            if (resutado>0)
            {
                MessageBox.Show("Producto Ingresado");
            }
            else
            {
                MessageBox.Show("Producto NO INSERTADO");
            }
        }
    }
}
