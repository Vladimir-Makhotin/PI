using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4LR
{
    public partial class Reduction : Form
    {
        public Reduction()
        {
            InitializeComponent();
        }
        private void Reduction_Load(object sender, EventArgs e)
        {}
        private void button2_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu();
            frm.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Rational b = new Rational(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            b = b.Reduce();
            maskedTextBox1.Text = Convert.ToString(b.number(b, 1));
            maskedTextBox2.Text = Convert.ToString(b.number(b, 2));
        }
    }
}
