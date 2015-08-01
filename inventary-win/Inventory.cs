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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Producto", "Producto");
            dataGridView1.Columns.Add("existencia", "Existencia");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 100;
            load_products();
        }

        public void load_products()
        {
            dataGridView1.Rows.Clear();
            List<ProductObj> list = ProductObj.getAll();
            for (int i = 0; i < list.Count; i++) {
                int input = OperationObj.getSumByProduct(list[i].id, 1);
                int output= OperationObj.getSumByProduct(list[i].id,2);
                //MessageBox.Show(input + " - " + output);
                dataGridView1.Rows.Add(list[i].id,list[i].name,(input-output));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            load_products();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Input ip = new Input();
            ip.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            History.pid = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            History.pname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            History h = new History();
            h.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Input ip = new Input();
            ip.ShowDialog();
            load_products();
        }

        private void recargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_products();
        }
    }
}
