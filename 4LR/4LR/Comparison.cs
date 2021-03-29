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
    public partial class Comparison : Form
    {
        public Comparison()
        {
            InitializeComponent();
        }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {}
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
            if (a == b)
                maskedTextBox1.Text = "=";
            if (a > b)
                maskedTextBox1.Text = ">";
            if (a < b)
                maskedTextBox1.Text = "<";
            MessageBox.Show(
                $"{a.ToString()} {maskedTextBox1.Text} {b.ToString()}", 
                "Message",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
                );
        }
    }
}
