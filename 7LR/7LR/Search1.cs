using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7LR
{
    public partial class Search1 : Form
    {
        public string searchchoice { get; set; }
        List<Rational> fraction = new List<Rational>();
        public int RowCount { get; set; }
        public Search1()
        {
            InitializeComponent();
            dataGridView2.RowCount = 1;
        }

        private void Search1_Load(object sender, EventArgs e)
        {
            if (searchchoice == "Linear")
            {
                this.Text = "Linear";
            }
            if (searchchoice == "Binary")
            {
                this.Text = "Binary";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rational f = new Rational(Convert.ToInt32(dataGridView2[0, 0].Value), Convert.ToInt32(dataGridView2[1, 0].Value));
            int count = -1;
            Rational tmp;
            if (searchchoice == "Linear")
            {
                for(int i=0; i< fraction.Count; i++)
                {
                    count++;
                    if(fraction[i]==f)
                    {
                        label4.Text = Convert.ToString(i+1);
                        break;
                    }
                }
                if(label4.Text=="")
                {
                    label4.Text = "NULL";
                }
            }
            if(searchchoice == "Binary")
            {
                for (int i = 0; i < fraction.Count - 1; i++)
                {
                    for (int j = i + 1; j < fraction.Count; j++)
                    {
                        if (fraction[i] > fraction[j])
                        {
                            tmp = fraction[i];
                            fraction[i] = fraction[j];
                            fraction[j] = tmp;
                        }
                    }
                }
                while (true)
                {
                    var result = BinarySearch(fraction, f, 0, RowCount);
                    if(result<0)
                    {
                        label4.Text = "NULL";
                    }
                    else
                    {
                        label4.Text = Convert.ToString(result+1);
                        break;
                    }
                }
            }
        }
        public void Data(int a, int b, int RC)
        {
            Rational f = new Rational(a, b);
            fraction.Add(f);
        }
        public void RowCounts(int RC)
        {
            RowCount = RC;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            for (int i = 0; i < fraction.Count; i++)
            {
                int a = fraction[i].Nominator();
                int b = fraction[i].Denominator();
                menu.Data(a, b);
            }
            menu.RowCounts(RowCount);
            menu.Show();
            this.Hide();
        }
        static int BinarySearch(List<Rational> array, Rational searchedValue, int left, int right)
        {
            while (left <= right)
            { 
                var middle = (left + right) / 2;
                if (searchedValue == array[middle])
                {
                    return middle;
                }
                else if (searchedValue < array[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }
            return -1;
        }
    }
}
