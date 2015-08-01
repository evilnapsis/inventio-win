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
    public partial class Re : Form
    {
        List<ProductObj> prods;
        List<PersonObj> provs;
        public Re()
        {
            InitializeComponent();
            prods = ProductObj.getAll();
            provs = PersonObj.getAllByKindId(2);
            foreach (ProductObj p in prods) { product.Items.Add(p.name); }
            foreach (PersonObj p in provs) { provider.Items.Add(p.name + " " + p.lastname); }
            data.Columns.Add("id", "Id");
            data.Columns.Add("unidad", "Unidad");
            data.Columns.Add("nombre", "Nombre");
            data.Columns.Add("cantidad", "Cantidad");
            data.Columns.Add("precio", "Precio");
            data.Columns[0].Width = 50;
            data.Columns[1].Width = 100;
            data.Columns[2].Width = 350;
            data.Columns[3].Width = 100;
            data.Columns[4].Width = 100;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (product.SelectedIndex ==-1)
            {
                MessageBox.Show("Debes seleccionar un producto");
            }
            else if (q.Text == "")
            {
                MessageBox.Show("Debes introducir una cantidad");
            }
            else {
                int index = product.SelectedIndex;
                data.Rows.Add(prods[index].id, prods[index].unit, prods[index].name,q.Text, prods[index].price_in);
                SellObj s = new SellObj();
                s.product_id = prods[index].id;
                s.q = int.Parse(q.Text);
                SellObj.re.Add(s);
                product.SelectedIndex = -1;
                q.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.Rows.Clear();
            SellObj.re.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection c = new Connection();
            if (provider.SelectedIndex != -1)
            {
                c.execute("insert into sell (person_id,operation_type_id,created_at) value (" + provs[provider.SelectedIndex].id + ",1,NOW())");
            }
            else
            {
                c.execute("insert into sell (operation_type_id,created_at) value (1,NOW())");
            }
            long sell_id = c.insert_id;
            List<SellObj> sell = SellObj.re;
            for (int i = 0; i < sell.Count; i++)
            {
                c.execute("insert into operation (product_id,q,sell_id,operation_type_id,created_at) value (" + sell[i].product_id + "," + sell[i].q + "," + sell_id + ",1,NOW())");
            }
            data.Rows.Clear();
            SellObj.sell.Clear();
            MessageBox.Show("Abastecimiento Aplicado Exitosamente");
//            Dispose();

        }
    }
}
