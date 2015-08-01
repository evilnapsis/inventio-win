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
    public partial class OperationWindow : Form
    {
        public static int operation_type;
        List<SellObj> sells;
        public OperationWindow()
        {
            InitializeComponent();
            if (operation_type == 1)
            {
                Text = "Abastecimiento de Inventario";
            }
            else if(operation_type==2){
                Text = "Ventas";
            }
            sells = SellObj.getAllByOperationTypeId(operation_type);
            foreach (SellObj s in sells) { thelist.Items.Add("#" + s.id + " - " + s.created_at); }
            data.Columns.Add("id", "Id");
            data.Columns.Add("unidad", "Unidad");
            data.Columns.Add("nombre", "Nombre");
            data.Columns.Add("cantidad", "Cantidad");
            data.Columns.Add("precio", "Precio");
            data.Columns.Add("Total", "Total");
            data.Columns[0].Width = 50;
            data.Columns[1].Width = 100;
            data.Columns[2].Width = 350;
            data.Columns[3].Width = 80;
            data.Columns[4].Width = 80;
            data.Columns[5].Width = 80;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thelist.SelectedIndex != -1)
            {
                data.Rows.Clear();
                List<OperationObj> ops = OperationObj.getAllBySellId(sells[thelist.SelectedIndex].id);
                float total = 0;
                foreach (OperationObj op in ops) {
                    ProductObj p = ProductObj.getById(op.product_id);
                    float price=0;
                    if (operation_type == 1) { price = p.price_in; }
                    else if (operation_type == 2) { price = p.price_out; }
                    data.Rows.Add(p.id, p.unit, p.name, op.q, price, op.q * price);
                    total += op.q * price;
                }
                data.Rows.Add("", "", "Total", "", "", total);
            }
        }
    }
}
