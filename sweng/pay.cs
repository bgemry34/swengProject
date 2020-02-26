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
    public partial class pay : Form
    {
        public pay()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pay_Load(object sender, EventArgs e)
        {

            txtntot.Text = sales.totalPrice.ToString();
            txtpay.Focus();

        }

        public void paymentProccesing()
        {

            int a = int.Parse(txtpay.Text);
            int b = int.Parse(txtntot.Text);

            if (a < b)
            {
                MessageBox.Show( "Insufficient Balance.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sales.payment = a;
                sales.balance = a - b;
                this.Close();
                MessageBox.Show("Success", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new sales().Activate();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            paymentProccesing();
        }
    }
}
