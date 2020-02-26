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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("SslMode=none; server=localhost; database=posn; username=root; password=;");
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter ada = new MySqlDataAdapter("select * from salesmain where date between'" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' and '" + dateTimePicker2.Value.ToString("dd/MM/yyyy") + "'", con);

            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;


            label4.Text = "0";

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                label4.Text = Convert.ToString(int.Parse(label4.Text) + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()));

            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
