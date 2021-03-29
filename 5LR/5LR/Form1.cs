using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5LR
{
    public partial class Form1 : Form
    {
        delegate void Message1();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Message1 mes=new Message1();
            if (radioButton1.Checked == true)
                mes = solutionfunc1;
            if (radioButton2.Checked == true)
                mes = solutionfunc2;
            mes();
            if (radioButton1.Checked == true)
            {
                
                

            }
            if (radioButton2.Checked == true)
            {
                
            }
        }
        private void solutionfunc1()
        {
            Equation f = new Equation(Convert.ToDouble(dataGridView1[0, 0].Value.ToString()), Convert.ToDouble(dataGridView1[1, 0].Value.ToString()));
            chart1.Series[0].Points.Clear();
            double h = 0.1, x, y;
            x = f.firstvalue();
            while (x <= f.seconvalue())
            {
                y = 1 - x * Math.Cos(x);
                chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }
            try
            {
                if (checkBox1.Checked == checkBox2.Checked)
                    throw new Exception();
                if (checkBox1.Checked == true)
                {
                    label3.Text = Convert.ToString(f.Newtonfunc1());
                    label4.Text = Convert.ToString(f.function1(f.Newtonfunc1()));
                }
                if (checkBox2.Checked == true)
                {
                    label3.Text = Convert.ToString(f.HalfDivisionfunct1());
                    label4.Text = Convert.ToString(f.function1(f.HalfDivisionfunct1()));
                }
            }
            catch (Exception)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }
        private void solutionfunc2()
        {
            Equation f = new Equation(Convert.ToDouble(dataGridView1[0, 0].Value.ToString()), Convert.ToDouble(dataGridView1[1, 0].Value.ToString()));
            chart1.Series[0].Points.Clear();
            double h = 0.1, x, y;
            x = f.firstvalue();
            while (x <= f.seconvalue())
            {
                y = Math.Pow(x, 3) + 2 * Math.Pow(x, 2) - 3 * x - 2;
                chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }
            try
            {
                if (checkBox3.Checked == checkBox4.Checked)
                    throw new Exception();
                if (checkBox3.Checked == true)
                {
                    label3.Text = Convert.ToString(f.Newtonfunct2());
                    label4.Text = Convert.ToString(f.function2(f.Newtonfunct2()));
                }
                if (checkBox4.Checked == true)
                {
                    label3.Text = Convert.ToString(f.HalfDivisionfunct2());
                    label4.Text = Convert.ToString(f.function2(f.HalfDivisionfunct2()));
                }
            }
            catch (Exception)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
