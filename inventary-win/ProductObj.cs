using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace inventio_win
{
    class ProductObj
    {
        public int id;
        public String name;
        public float price_in;
        public float price_out;
        public String unit;

        public static ProductObj getById(int product_id) {
            Connection c = new Connection();
            MySqlCommand cmd = c.con.CreateCommand();
            cmd.CommandText = "select * from product where id=" + product_id;
            c.con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            ProductObj product = new ProductObj();
            while (r.Read())
            {

                product.id= r.GetInt32("id");
                product.name = r.GetString("name");
                product.price_in = r.GetFloat("price_in");
                product.price_out = r.GetFloat("price_out");
                product.unit = r.GetString("unit");
                break;

            }
            return product;
        }

        public static List<ProductObj> getAll()
        {
                List<ProductObj> list = new List<ProductObj>();
                try
                {
                    Connection c = new Connection();
                    MySqlCommand cmd = c.con.CreateCommand();
                    cmd.CommandText = "select * from product";
                    c.con.Open();
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        ProductObj product = new ProductObj();
                        product.id = r.GetInt32("id");
                        product.name = r.GetString("name");
                        product.price_in = r.GetFloat("price_in");
                        product.price_out = r.GetFloat("price_out");
                        product.unit = r.GetString("unit");
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
