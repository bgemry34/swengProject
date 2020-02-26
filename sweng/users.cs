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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                MySqlCommand cm = new MySqlCommand();
                cm.Connection = con;
                cm.CommandText = "insert into login(name,username,password) values (@name,@username,@password)";
                cm.Parameters.AddWithValue("@name", txtname.Text);
                cm.Parameters.AddWithValue("@username", txtuser.Text);
                cm.Parameters.AddWithValue("@password", txtpass.Text);
              
                con.Open();
                cm.ExecuteNonQuery();
                MessageBox.Show("Record added");
                con.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
