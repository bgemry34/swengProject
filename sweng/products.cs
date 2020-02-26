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
    public partial class products : Form
    {
        public productsMain productsmain;
        public products(productsMain productsMain)
        {
            InitializeComponent();
            fillcombocat();
            fillcombobrand();
            this.productsmain = productsMain;
        }

        MySqlConnection con = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");

        void fillcombocat()

        {

            try
            {


                string catquery = "select * from category";
                MySqlCommand cmd = new MySqlCommand(catquery, con);
                con.Open();
                DataSet ds = new DataSet();
                MySqlDataAdapter ada = new MySqlDataAdapter(cmd);
                ada.Fill(ds);
                comcat.DataSource = ds.Tables[0];
                comcat.DisplayMember = "name";
                comcat.ValueMember = "id";
                con.Close();
                    

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }


        void fillcombobrand()

        {

            try
            {


                string brandquery = "select * from brands";
                MySqlCommand cmd1 = new MySqlCommand(brandquery, con);
                con.Open();
                DataSet ds1 = new DataSet();
                MySqlDataAdapter ada1 = new MySqlDataAdapter(cmd1);
                ada1.Fill(ds1);
                combrand.DataSource = ds1.Tables[0];
                combrand.DisplayMember = "name";
                combrand.ValueMember = "id";
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }


        private void products_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            try

            {

                MySqlCommand cm = new MySqlCommand();
                cm.Connection = con;
                cm.CommandText = "insert into products(name,catid,brid,price,qty) values(@name,@catid,@brid,@price,@qty)";
                cm.Parameters.AddWithValue("@name", txtname.Text);
                cm.Parameters.AddWithValue("@catid", comcat.SelectedValue);
                cm.Parameters.AddWithValue("@brid", combrand.SelectedValue);
                cm.Parameters.AddWithValue("@price", txtpri.Text);
                cm.Parameters.AddWithValue("@qty", txtqty.Text);

                con.Open();
                cm.ExecuteNonQuery();
                MessageBox.Show("Record added");
                con.Close();
                txtname.Text = "";
                txtpri.Text = "";
                txtqty.Text = "";
                productsmain.refresh();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }





        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
