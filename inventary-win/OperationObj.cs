using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace inventio_win
{
    class OperationObj
    {
        public int product_id;
        public int q;
        public int operation_type_id;
        public int sell_id;
        public DateTime created_at;

        public ProductObj getProduct() { return ProductObj.getById(this.product_id); }

        public static List<OperationObj> getAllBySellId(int sell_id)
        {
            List<OperationObj> list = new List<OperationObj>();
            Connection c = new Connection();
            MySqlCommand cmd = c.con.CreateCommand();
            cmd.CommandText = "select * from operation where sell_id=" + sell_id + " order by created_at desc";
            c.con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                OperationObj product = new OperationObj();
                product.product_id = r.GetInt32("product_id");
                //product.sell_id= r.GetInt32("sell_id");
                product.q = r.GetInt32("q");
                product.operation_type_id = r.GetInt32("operation_type_id");
                product.created_at = r.GetDateTime("created_at");
                list.Add(product);
            }
            return list;
        }
        
        public static List<OperationObj> getAllByProduct(int product_id)
        {
            List<OperationObj> list = new List<OperationObj>();
            Connection c = new Connection();
            MySqlCommand cmd = c.con.CreateCommand();
            cmd.CommandText = "select * from operation where product_id="+product_id+" order by created_at desc";
            c.con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                OperationObj product = new OperationObj();
                product.product_id = r.GetInt32("id");
                //product.sell_id= r.GetInt32("sell_id");
                product.q = r.GetInt32("q");
                product.operation_type_id= r.GetInt32("operation_type_id");
                product.created_at = r.GetDateTime("created_at");
                list.Add(product);
            }
            return list;
        }

        public static int getSumByProduct(int product_id, int op_type_id)
        {
            int total = 0;
            Connection c = new Connection();
            MySqlCommand cmd = c.con.CreateCommand();
            String sql = "select q from operation where product_id=" + product_id + " and operation_type_id=" + op_type_id;
            Console.WriteLine(sql);
            cmd.CommandText = sql;
            c.con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {

                    total += r.GetInt32("q");
                }
            return total;
        }
    }
}
