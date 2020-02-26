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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost; database=posn; username=root; password=; SslMode=none;");
        int count;

        private void btnlog_Click(object sender, EventArgs e)
        {

            string username, password;

            username = txtuser.Text;
            password = txtpass.Text;

            count = count + 1;

            if (count > 3)
            {
                MessageBox.Show("Pos system has been Blocked", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();

            }

            else if(username == "" && password == "")
            {

                label4.Text = "Username and password cannot be blank";

            }


            else
            {

                string query = "select * from login where username = '" + username + "' && password = '" + password + "' ";

                MySqlDataAdapter data = new MySqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                data.Fill(dt);

                if (dt.Rows.Count == 1)
                {

                    Main mn = new Main();
                    this.Hide();
                    mn.Staffname = txtuser.Text;
                    mn.Show();


                }
                else
                {

                    label4.Text = "Please try again.......";
                    txtuser.Clear();
                    txtpass.Clear();
                    txtuser.Focus();


                }


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void btncan_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
