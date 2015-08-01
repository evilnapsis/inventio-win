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
    public partial class Directory : Form
    {
        public static int kind;
        public Directory()
        {
            InitializeComponent();
            if (kind == 1)
            {
                Text = "Directorio de Clientes";
            }
            else if (kind == 2) {
                Text = "Directorio de Proveedores";
            }
            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("name", "Nombre");
            dataGridView1.Columns.Add("Apellido", "Apellido");
            dataGridView1.Columns.Add("Direccion", "Direccion");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("Telefono", "Telefono");
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            load_persons();

        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPerson.kind = Directory.kind;
            newPerson p = new newPerson();
            p.ShowDialog();
            load_persons();
        }

        public void load_persons()
        {
            dataGridView1.Rows.Clear();
            List<PersonObj> list = PersonObj.getAllByKindId(kind);
            for (int i = 0; i < list.Count; i++)
            {
                //MessageBox.Show(input + " - " + output);
                dataGridView1.Rows.Add(list[i].id, list[i].name, list[i].lastname, list[i].address, list[i].email, list[i].phone);
            }
        }

        private void recargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_persons();
        }

    }
}
