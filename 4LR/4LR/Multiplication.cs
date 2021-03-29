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
    public partial class Multiplication : Form
    {
        public Multiplication()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {}
        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {}
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            Rational a = new Rational(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            Rational b = new Rational(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            Rational c = new Rational(1, 1);
            c = a * b;
            maskedTextBox1.Text = Convert.ToString(c.number(c, 1));
            maskedTextBox2.Text = Convert.ToString(c.number(c, 2));

        }
        private void label2_Click(object sender, EventArgs e)
        {}
        private void textBox4_TextChanged(object sender, EventArgs e)
        {}
        private void textBox3_TextChanged(object sender, EventArgs e)
        {}
        private void label1_Click(object sender, EventArgs e)
        {}
        private void textBox2_TextChanged(object sender, EventArgs e)
        {}
        private void button2_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu();
            frm.Show();
            this.Hide();
        }
        private void Multiplication_Load(object sender, EventArgs e)
        {}
    }
}
