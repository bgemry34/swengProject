using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sweng
{
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");
        public static int totalPrice = 0;
        public static int payment = 0;
        public static int balance = 0;




        public void invoice()
        {
            con.Open();
            string query = "select max(id) from salesmain ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader r;
            r = cmd.ExecuteReader();
            if (r.Read())
            {

                string val = r[0].ToString();
                if (val == "")
                {
                    lbinvoice.Text = "1";

                }
                else
                {

                    int a;

                    a = int.Parse(r[0].ToString());
                    a = a + 1;
                    lbinvoice.Text = a.ToString();

                }
                con.Close();

            }
        }

        private string name;

        public string Staffname
        {
            get { return name; }
            set { name = value; }


        }



        public void updatedb()
        {

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {

                string itmno = dataGridView1.Rows[row].Cells[1].Value.ToString();
                string itmqty = dataGridView1.Rows[row].Cells[3].Value.ToString();


                string t = "select * from products where id= '" + itmno + "'";

                string oldqty = "", newqty = "";

                Connnew.DbSearch(t);
                while (Connnew.dr.Read())

                {

                    oldqty = Connnew.dr["qty"].ToString();
                    newqty = (int.Parse(oldqty) - int.Parse(itmqty)).ToString();
                }

                string t2 = "update products SET qty = '" + newqty + "' WHERE id '" + itmno + "'";

                Connnew.DbUpdate(t2);

            }
        }


        public void RemoveItem()
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string tot = row.Cells[5].Value.ToString();


                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);

                lbtotal.Text = (int.Parse(lbtotal.Text) - int.Parse(tot)).ToString();

                int finaltot = int.Parse(lbtotal.Text);

                totalPrice = finaltot;

                lbitems.Text = " " + (dataGridView1.RowCount - 0) + "";

            }
        }

        private void sales_Load(object sender, EventArgs e)
        {
            label6.Text = Staffname;
            lbldate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            lbltime.Text = DateTime.Now.ToString("h:mm tt");

            invoice();

            String query = "select * from products order by id desc";

            MySqlCommand command2 = new MySqlCommand(query, con);
            con.Open();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("id", "Product id");
            dataGridView2.Columns.Add("prorductName", "Product Name");
            dataGridView2.Columns.Add("productPrice", "Product price");


            dataGridView2.Columns[0].HeaderText = "Product ID";
            dataGridView2.Columns[1].HeaderText = "Product Name";
            dataGridView2.Columns[2].HeaderText = "Product Price";
            MySqlDataReader reader = command2.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(new String[] { reader[0].ToString(), reader[1].ToString(), reader[4].ToString()});
                }
            }
            con.Close();
        }

        private void txtno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtqty.Enabled = true;
                txtqty.Focus();

            }
        }

        private void sales_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {

                    string txt = "select * from products where id ='" + txtno.Text + "'";
                    MySqlCommand cmd2 = new MySqlCommand(txt, con);
                    con.Open();
                    MySqlDataReader dr = cmd2.ExecuteReader();

                    while (dr.Read())

                    {

                        int price = int.Parse(txtqty.Text.ToString()) * int.Parse(dr[4].ToString());
                        totalPrice = totalPrice + price;


                        dataGridView1.Rows.Add(dataGridView1.RowCount, dr[0], dr[1], txtqty.Text.Trim(), dr[4], price);

                    }
                    lbitems.Text = " " + (dataGridView1.RowCount + 0) + "";
                    lbtotal.Text = " " + totalPrice + " ";

                    con.Close();

                }

                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Error From Database");
                }

                txtno.Focus();
                txtno.Clear();

                txtqty.Enabled = false;
                txtqty.Clear();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "insert into salesproducts(saleid,productname,qty,price,grosstotal)values(@saleid,@productname,@qty,@price,@grosstotal)";
                    cmd.Parameters.AddWithValue("@saleid", lbinvoice.Text);
                    cmd.Parameters.AddWithValue("@productname", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@qty", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@grosstotal", dataGridView1.Rows[i].Cells[5].Value);



                    MySqlCommand cmd1 = new MySqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandText = "insert into salesmain(id,date,time,cashier,qty,grosstotal)values(@id,@date,@time,@cashier,@qty,@grosstotal)";
                    cmd1.Parameters.AddWithValue("@id", lbinvoice.Text);
                    cmd1.Parameters.AddWithValue("@date", lbldate.Text);
                    cmd1.Parameters.AddWithValue("@time", lbltime.Text);
                    cmd1.Parameters.AddWithValue("@cashier", label6.Text);
                    cmd1.Parameters.AddWithValue("@qty", lbitems.Text);
                    cmd1.Parameters.AddWithValue("@grosstotal", lbtotal.Text);



                    con.Open();
                    int x = cmd.ExecuteNonQuery();
                    int y = cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record added.............");

                    updatedb();

                    dataGridView1.Rows.Clear();
                    lbtotal.Text = "0";
                    lbitems.Text = "0";
                    txtno.Focus();
                    totalPrice = 0;

                    con.Close();
                    invoice();

                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                con.Close();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            pay p = new pay();
            p.Show();
        }

        private void sales_Activated(object sender, EventArgs e)
        {
            label7.Text = "\nBalance /= " + balance;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No Transactions");
                txtno.Focus();


            }
            else
            {

                DialogResult result = MessageBox.Show("Are you sure you want to remove?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    RemoveItem();
                    txtno.Focus();

                }
            }




        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    
    

