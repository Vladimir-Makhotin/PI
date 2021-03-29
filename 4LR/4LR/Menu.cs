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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {}
        private void button1_Click(object sender, EventArgs e)
        {
            Addition frmAdd = new Addition();
            frmAdd.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Subtraction frmSub = new Subtraction();
            frmSub.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Multiplication frmM = new Multiplication();
            frmM.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Division frmDiv = new Division();
            frmDiv.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Comparison frmComp = new Comparison();
            frmComp.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Reduction frmReduction = new Reduction();
            frmReduction.Show();
            this.Hide();
        }
    }
}
