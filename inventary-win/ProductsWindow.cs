using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventio_win
{
    public partial class ProductsWindow : Form
    {
        public ProductsWindow()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("unit", "Unidad");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("price_in", "Precio de entrada");
            dataGridView1.Columns.Add("price_out", "Precio de salida");
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            load_products();
        }

        private void recargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_products();
        }

        public void load_products()
        {
            dataGridView1.Rows.Clear();
            List<ProductObj> list = ProductObj.getAll();
            for (int i = 0; i < list.Count; i++)
            {
                //MessageBox.Show(input + " - " + output);
                dataGridView1.Rows.Add(list[i].id, list[i].unit, list[i].name, list[i].price_in,list[i].price_out );
            }
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProduct p = new newProduct();
            p.ShowDialog();
            load_products();
        }
    }
}
