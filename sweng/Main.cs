using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sweng
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Windows is going to shutdown. are your sure?","Please Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                System.Diagnostics.Process.Start("shutdown", "/s /t 0");

            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Windows is going to restart. are your sure?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                System.Diagnostics.Process.Start("shutdown", "/r /t 0");

            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            items it = new items();
            it.Show();
        

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Are you going to exit the POS?", "Please Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                Application.Exit();

            }


           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            productsMain p = new productsMain();
            p.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            sales sls = new sales();
            sls.Staffname = label6.Text;
            sls.Show();

        }


        private string name;

        public string Staffname
        {
            get { return name; }
            set { name = value; }


        }




        private void pictureBox8_Click(object sender, EventArgs e)
        {
            users user = new users();

            user.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            label6.Text = Staffname;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Report rs = new Report();
            rs.Show();
        }
    }
}
