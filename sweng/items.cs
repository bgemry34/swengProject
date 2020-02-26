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
    public partial class items : Form
    {
        public items()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database=posn; username=root; password=; SslMode=none;");

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            try
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into category(name, description)values(@name,@description)";
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@description", txtdes.Text);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record added..................");
                con.Close();


            }

            catch(Exception ex)

            {

               MessageBox.Show(ex.Message);

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = con;
                cmd1.CommandText = "insert into brands(name, description)values (@name,@description)";
                cmd1.Parameters.AddWithValue("@name", txtbname.Text);
                cmd1.Parameters.AddWithValue("@description", txtbdes.Text);

                con.Open();

                cmd1.ExecuteNonQuery();
                MessageBox.Show("Record added..................");
            
            }

            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);

            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
