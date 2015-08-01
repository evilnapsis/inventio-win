using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/// Inventio Win
/// @author evilnapsis
/// Copyright 2015

namespace inventio_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Login.accessed = true;
            Login l = new Login();
            l.ShowDialog();
            //Splash s1 = new Splash();
            //s1.ShowDialog();
            if (Login.accessed)
            {
                InitializeComponent();
                Splash s = new Splash();
                data.Columns.Add("id", "Id");
                data.Columns.Add("nombre", "Nombre");
                data.Columns.Add("unidad", "Unidad");
                data.Columns.Add("disponible", "Disponible");
                data.Columns.Add("precio", "Precio");
                data.Columns[0].Width = 50;
                data.Columns[1].Width = 400;
                data.Columns[2].Width = 100;
                data.Columns[3].Width = 100;
                data.Columns[4].Width = 100;
                s.ShowDialog();
            }
            else
            {
//                Close();
            }
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsWindow pw = new ProductsWindow();
            pw.ShowDialog();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newProduct np = new newProduct();
            np.ShowDialog();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Re ip = new Re();
            ip.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (product.Text != "")
            {
                data.Rows.Clear();
                try
                {
                    Connection c = new Connection();
                    MySqlCommand cmd = c.con.CreateCommand();
                    cmd.CommandText = "select * from product where name like \"%" + product.Text + "%\"";
                    c.con.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        data.Rows.Add(r.GetString("id"), r.GetString("name"), r.GetString("unit"), "", r.GetInt32("price_out"));
                    }
                }
                catch (MySqlException me)
                {
                    MessageBox.Show(me.Message);
                }
            }
            else {

                data.Rows.Clear();
            }
        }

        private void data_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AddToSellDialog.id = data.Rows[e.RowIndex].Cells[0].Value.ToString();
                AddToSellDialog.name = data.Rows[e.RowIndex].Cells[1].Value.ToString();
                AddToSellDialog.price = data.Rows[e.RowIndex].Cells[4].Value.ToString();
                AddToSellDialog sd = new AddToSellDialog();
                sd.ShowDialog();
            }
            catch (NullReferenceException ne) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellDialog sd = new SellDialog();
            sd.ShowDialog();
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i.ShowDialog();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeInventaryWinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.kind = 1;
            Directory d = new Directory();
            d.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.kind = 2;
            Directory d = new Directory();
            d.ShowDialog();

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationWindow.operation_type = 2;
            OperationWindow ow = new OperationWindow();
            ow.ShowDialog();
        }

        private void abastecimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationWindow.operation_type = 1;
            OperationWindow ow = new OperationWindow();
            ow.ShowDialog();

        }
    }
}
