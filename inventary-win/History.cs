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
    public partial class History : Form
    {
        public static String pid;
        public static String pname;
        public History()
        {
            InitializeComponent();
            label1.Text = pname;
            dataGridView1.Columns.Add("q","Cant");
            dataGridView1.Columns.Add("tipo", "Tipo");
            dataGridView1.Columns.Add("fecha", "Fecha");
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 200;

            List<OperationObj> operations = OperationObj.getAllByProduct(int.Parse(pid));
            for (int i = 0; i < operations.Count; i++)
            {
                dataGridView1.Rows.Add(operations[i].q,operations[i].operation_type_id,operations[i].created_at);

            }

        }
    }
}
