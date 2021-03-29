using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6LRnonchart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] b = new int[dataGridView1.RowCount]; int s = 0; int[,] c = new int[2, 2]; int t = 100000; float anglsum = 0;
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White); float[] angl = new float[dataGridView1.RowCount];
            SolidBrush[] p = new SolidBrush[dataGridView1.RowCount];
            p[0] = new SolidBrush(Color.Red);
            p[1] = new SolidBrush(Color.Orange);
            p[2] = new SolidBrush(Color.Yellow);
            p[3] = new SolidBrush(Color.Green);
            p[4] = new SolidBrush(Color.Blue);
            SolidBrush pp = new SolidBrush(Color.Black);
            float smallsum = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                b[i] = Convert.ToInt32(dataGridView1[0, i].Value.ToString());
                s += b[i];
            }
            for (int i = 0; i < 2; i++)
            {
                c[i, 0] = -1000;
                c[i,1]=-1;
            }
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (b[i] >= c[j, 0])
                    {
                        if(i!=c[0,1])
                        {
                            c[j, 0] = b[i];
                            c[j, 1] = i;
                        }
                    }
                }
            }
            smallsum = c[0, 0] + c[1, 0];
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                angl[i] = b[i] * 360 / s;
                if (i == 0)
                {
                    if (i == c[0, 1] || i == c[1, 1])
                    {
                        g.FillPie(pp, 0, 0, 125, 125, anglsum, angl[i]);
                        anglsum += angl[i];
                    }
                    else
                    {
                        g.FillPie(p[i], 0, 0, 125, 125, 0, angl[i]);
                        anglsum += angl[i];
                    }
                }
                else
                {
                    if (i == c[0, 1] || i == c[1, 1])
                    {
                        g.FillPie(pp, 0, 0, 125, 125, anglsum, angl[i]);
                        anglsum += angl[i];
                    }
                    else
                    {
                        g.FillPie(p[i], 0, 0, 125, 125, anglsum, angl[i]);
                        anglsum += angl[i];
                    }
                }
            }
            g.FillRectangle(p[c[0, 1]], 125, 125, 100, 100 * c[0,0] / smallsum);
            g.FillRectangle(p[c[1, 1]], 125, 125 + 100 * c[0,0] / smallsum,100, 100 * c[1,0] / smallsum);
        }
    }
}
