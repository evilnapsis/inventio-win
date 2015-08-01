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
    public partial class Login : Form
    {
        public static Boolean accessed;
        public static String name;
        public static int user_id ;
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accessed = false;
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "") {
                MessageBox.Show("Debes escribir el nombre de usuario");
            }
            else if (password.Text == "")
            {
                MessageBox.Show("Debes escribir un password");
            }
            else {

                Connection c = new Connection();

                MySqlCommand cmd = c.con.CreateCommand();
                cmd.CommandText = "select * from user where username= \"" + username.Text + "\" and password = \"" + password.Text + "\" and is_active = 1";
                c.con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {

                    name = r.GetString("name");
                    user_id = r.GetInt32("id");
                    break;

                }
                accessed = true;
                Dispose();
            
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
