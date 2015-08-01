using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace inventio_win
{
    public partial class Input : Form
    {
        List<int> ids = new List<int>();
        public Input()
        {
            InitializeComponent();
            try
            {
                Connection c = new Connection();

                MySqlCommand cmd = c.con.CreateCommand();
                cmd.CommandText = "select * from product";
                c.con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    product.Items.Add(r.GetString("Name"));
                    ids.Add(r.GetInt32("id"));

                }
            }
            catch (MySqlException me)
            {
                MessageBox.Show(me.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (product.Text != "" && q.Text != "") {
                //MessageBox.Show(""+ids[product.SelectedIndex]);
                Connection c = new Connection();
                c.execute("insert into operation(product_id,q,operation_type_id,created_at) value (" + ids[product.SelectedIndex] + ","+q.Text+",1,NOW())");
                q.Text = "";
                MessageBox.Show("Alta en inventario exitosa!");
            
            }
            else {
                MessageBox.Show("Campos Requeridos: Producto, Cantidad");
            }
        }
    }
}
