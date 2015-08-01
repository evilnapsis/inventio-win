using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace inventio_win
{
    class PersonObj
    {
        public int id;
        public String name;
        public String lastname;
        public String address;
        public String email;
        public String phone;

        public static PersonObj getById(int product_id) {
            Connection c = new Connection();
            MySqlCommand cmd = c.con.CreateCommand();
            cmd.CommandText = "select * from product where id=" + product_id;
            c.con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            PersonObj product = new PersonObj();
            while (r.Read())
            {

                product.id= r.GetInt32("id");
                product.name = r.GetString("name");
                product.lastname = r.GetString("lastname");

                product.address = r.GetString("address1");
                product.phone = r.GetString("phone1");
                product.email = r.GetString("email1");
                break;

            }
            return product;
        }

        public static List<PersonObj> getAllByKindId(int kind)
        {
                List<PersonObj> list = new List<PersonObj>();
                try
                {
                    Connection c = new Connection();
                    MySqlCommand cmd = c.con.CreateCommand();
                    cmd.CommandText = "select * from person where kind=" + kind;
                    c.con.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        PersonObj product = new PersonObj();
                        product.id = r.GetInt32("id");
                        product.name = r.GetString("name");
                        product.lastname = r.GetString("lastname");

                        product.address = r.GetString("address1");
                        product.phone = r.GetString("phone1");
                        product.email = r.GetString("email1");
                        list.Add(product);
                    }
                }
                catch (MySqlException me)
                {

                    MessageBox.Show(me.Message);

                }
            return list;
        }

    }
}
