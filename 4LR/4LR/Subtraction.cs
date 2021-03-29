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
    public partial class Subtraction : Form
    {
        public Subtraction()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu();
            frm.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Rational a = new Rational(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            Rational b = new Rational(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            Rational c = new Rational(1, 1);
            c = a - b;
            maskedTextBox1.Text = Convert.ToString(c.number(c, 1));
            maskedTextBox2.Text = Convert.ToString(c.number(c, 2));
        }
        private void Subtraction_Load(object sender, EventArgs e)
        {}
    }
}
