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
    public partial class productsMain : Form
    {
        MySqlConnection con = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");
        public string idselected = "";
        public productsMain()
        {
            InitializeComponent();
        }
        MySqlConnection con1 = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void refresh()
        {
            MySqlDataAdapter ada = new MySqlDataAdapter("SELECT products.id,category.name,brands.name, products.name, products.price, products.qty FROM products INNER JOIN category ON products.catid = category.id INNER JOIN brands ON products.brid = brands.id", con1);

            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[0].HeaderText = "Item Code";
            dataGridView1.Columns[1].HeaderText = "Category";
            dataGridView1.Columns[2].HeaderText = "Brands";
            dataGridView1.Columns[3].HeaderText = "Products";
            dataGridView1.Columns[4].HeaderText = "Price";
            dataGridView1.Columns[5].HeaderText = "StockIn";
            label5.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                label5.Text = Convert.ToString(int.Parse(label5.Text) + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
            }
        }
        public void refreshbtn()
        { 
            
            MySqlDataAdapter ada = new MySqlDataAdapter("SELECT products.id,category.name,brands.name, products.name, products.price, products.qty FROM products INNER JOIN category ON products.catid = category.id INNER JOIN brands ON products.brid = brands.id WHERE category.name = '" + textBox1.Text + "' || brands.name = '" + textBox2.Text + "'", con1);

        DataTable dt = new DataTable();
        ada.Fill(dt);
            dataGridView1.DataSource = dt;


            dataGridView1.Columns[0].HeaderText = "Item Code";
            dataGridView1.Columns[1].HeaderText = "Category";
            dataGridView1.Columns[2].HeaderText = "Brands";
            dataGridView1.Columns[3].HeaderText = "Products";
            dataGridView1.Columns[4].HeaderText = "Price";
            dataGridView1.Columns[5].HeaderText = "StockIn";
            label5.Text = "0";
            for (int i = 0; i<dataGridView1.Rows.Count - 1; i++)
            {
                label5.Text = Convert.ToString(int.Parse(label5.Text) + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));
            }

            }

    private void ProductsMain_Load(object sender, EventArgs e)
        {
            refresh();


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure You wanna Delete this product?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                String addquery = "Delete from " + "products" + " where id = @id";
                MySqlCommand addcmd = new MySqlCommand(addquery, con);
                con.Open();
                addcmd.Parameters.AddWithValue("@id", idselected);
                addcmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("deleted succezzfully");
                this.refresh();
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                idselected = this.dataGridView1[0, e.RowIndex].Value.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (var addProduct = new products(this))
            {
                addProduct.ShowDialog();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            refreshbtn();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
