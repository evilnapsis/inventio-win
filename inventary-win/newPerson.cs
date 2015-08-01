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
    public partial class newPerson : Form
    {
        public static int kind;
        public newPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text != "" && lastname.Text != "")
            {

                Connection c = new Connection();

                c.execute("insert into person (name,lastname,address1,email1,phone1,kind,created_at) value(\"" + name.Text + "\",\"" + lastname.Text + "\",\"" + address.Text + "\",\"" + email.Text + "\",\"" + phone.Text + "\","+kind+",NOW() )");
                MessageBox.Show("Contacto agregado exitosamente!");
                name.Text = lastname.Text = address.Text = email.Text = phone.Text = "";

            }
        }
    }
}
