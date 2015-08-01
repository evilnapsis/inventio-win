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
    public partial class SellDialog : Form
    {
        List<PersonObj> lp;
        public SellDialog()
        {
            InitializeComponent();
            data.Columns.Add("id", "Id");
            data.Columns.Add("cant", "Cant");
            data.Columns.Add("producto", "Producto");
            data.Columns.Add("unidad", "Unidad");
            data.Columns.Add("pu", "Precio Unitario");
            data.Columns.Add("total", "Total");
            data.Columns[0].Width = 50;
            data.Columns[1].Width = 50;
            data.Columns[2].Width = 200;
            data.Columns[3].Width = 100;
            data.Columns[4].Width = 100;
            data.Columns[5].Width = 100;

             lp = PersonObj.getAllByKindId(1);
            foreach (PersonObj p in lp) {
                client_.Items.Add(p.name + " " + p.lastname);
            }


            List<SellObj> sell = SellObj.sell;
            float total = 0;
            for (int i = 0; i < sell.Count; i++)
            {
                ProductObj product = ProductObj.getById(sell[i].product_id);
                data.Rows.Add(product.id, sell[i].q, product.name, product.unit, product.price_out, sell[i].q * product.price_out);
                total += sell[i].q * product.price_out;
            }
            data.Rows.Add("","","Total","","",total);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void procesarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection c = new Connection();
            if (client_.SelectedIndex != -1)
            {
                c.execute("insert into sell (person_id,created_at) value (" + lp[client_.SelectedIndex].id + ",NOW())");
            }
            else
            {
                c.execute("insert into sell (created_at) value (NOW())");
            }
            long sell_id = c.insert_id;
            List<SellObj> sell = SellObj.sell;
            for (int i = 0; i < sell.Count; i++)
            {
                c.execute("insert into operation (product_id,q,sell_id,operation_type_id,created_at) value (" + sell[i].product_id + "," + sell[i].q + "," + sell_id + ",2,NOW())");
            }
            data.Rows.Clear();
            SellObj.sell.Clear();
            MessageBox.Show("Venta Aplicada Exitosamente");
            Dispose();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            SellObj.sell.Clear();

        }
    }
}
