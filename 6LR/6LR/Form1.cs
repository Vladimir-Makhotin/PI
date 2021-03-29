using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6LR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] a = new string[dataGridView1.RowCount];
            int[] b = new int[dataGridView1.RowCount - 1];
            int[,] c = new int[2, 2]; int t = 100000;
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            for (int i = 0; i < dataGridView1.RowCount; i++)
                if (dataGridView1[0, i].Value != null)
                    a[i] = dataGridView1[0, i].Value.ToString();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                b[i] = Convert.ToInt32(a[i]);
            for (int i = 0; i < 2; i++)
                c[i, 0] = b[1];
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (b[i] > c[j, 0] && b[i] != t)
                    {
                        c[j, 0] = b[i];
                        c[j, 1] = i;
                    }
                }
                t = c[j, 0];
                chart2.Series[0].Points.Add(c[j, 0]);
            }
            chart2.Series[0].LegendText = "Max points";
            t = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (i == c[0, 1] || i == c[1, 1])
                    t += b[i];
                else
                    chart1.Series[0].Points.Add(b[i]);
            }
            chart1.Series[0].Points.Add(t);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
        }
    }
}
