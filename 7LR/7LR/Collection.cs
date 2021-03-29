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
    public partial class Collection : Form
    {
        public string choise { get; set; }
        List<Rational> fraction = new List<Rational>();
        public int RowCount { get; set; }
        public Collection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (choise)
            {
                case "Create":
                    RowCount = 0;
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        Rational f = new Rational(Convert.ToInt32(dataGridView1[0, i].Value.ToString()), Convert.ToInt32(dataGridView1[1, i].Value.ToString()));
                        fraction.Add(f);
                        RowCount++;
                    }
                    break;
                case "Read":
                    break;
                case "Update":
                    RowCount = 0;
                    for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                    {
                        Rational f = new Rational(Convert.ToInt32(dataGridView1[0, i].Value.ToString()), Convert.ToInt32(dataGridView1[1, i].Value.ToString()));
                        fraction[i] = fraction[i].Fraction(f);
                        RowCount++;
                    }
                    break;
                case "Delete":
                    RowCount = 0;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Selected)
                        {
                            int del = dataGridView1.CurrentRow.Index;
                            dataGridView1.Rows.Remove(dataGridView1.Rows[del]);                        
                        } 
                    }
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        RowCount++;
                    }
                        break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            if (choise=="Create")
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    int a = fraction[i].Nominator();
                    int b = fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            if(choise=="Read")
            {
                for (int i = 0; i < fraction.Count; i++)
                {
                    int a = fraction[i].Nominator();
                    int b = fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            if(choise=="Update")
            {
                for (int i = 0; i < fraction.Count; i++)
                {
                    int a = fraction[i].Nominator();
                    int b = fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            if(choise=="Delete")
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int a =Convert.ToInt32(dataGridView1[0, i].Value);// fraction[i].Nominator();
                    int b = Convert.ToInt32(dataGridView1[1, i].Value);// fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            if(choise=="In ascending order")
            {
                for (int i = 0; i < fraction.Count; i++)
                {
                    int a = fraction[i].Nominator();
                    int b = fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            if(choise== "In descending order")
            {
                for (int i = 0; i < fraction.Count; i++)
                {
                    int a = fraction[i].Nominator();
                    int b = fraction[i].Denominator();
                    menu.Data(a, b);
                }
                menu.RowCounts(RowCount);
            }
            menu.Show();
            this.Hide();
        }

        private void Collection_Load(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            Rational tmp;
            switch (choise)
            {
                case "Create":
                    break;
                case "Read":
                    this.Text = "Read";
                    button1.Visible=false;
                    dataGridView1.RowCount = fraction.Count;
                    for (int i = 0; i < fraction.Count; i++)
                    {
                        dataGridView1[0, i].Value = fraction[i].Nominator();
                        dataGridView1[1, i].Value = fraction[i].Denominator();
                    }
                    menu.RowCounts(RowCount);
                    break;
                case "Update":
                    this.Text = "Update";
                    dataGridView1.RowCount = fraction.Count;
                    for (int i = 0; i < fraction.Count; i++)
                    {
                        dataGridView1[0, i].Value = fraction[i].Nominator();
                        dataGridView1[1, i].Value = fraction[i].Denominator();
                    }
                    break;
                case "Delete":
                    this.Text = "Delete";
                    button1.Text = "Delete";
                    dataGridView1.RowCount = fraction.Count;
                    for (int i = 0; i < fraction.Count; i++)
                    {
                        dataGridView1[0, i].Value = fraction[i].Nominator();
                        dataGridView1[1, i].Value = fraction[i].Denominator();
                    }
                    break;
                case "In ascending order":
                    button1.Visible = false;
                    this.Text = "In ascending order";
                    for (int i = 0; i < fraction.Count; i++)
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
                    dataGridView1.RowCount = fraction.Count;
                    for (int i = 0; i < fraction.Count; i++)
                    {
                        dataGridView1[0, i].Value = fraction[i].Nominator();
                        dataGridView1[1, i].Value = fraction[i].Denominator();
                    }
                    menu.RowCounts(RowCount);
                    break;
                case "In descending order":
                    button1.Visible = false;
                    this.Text = "In descending order";
                    for (int i = 0; i < fraction.Count - 1; i++)
                    {
                        for (int j = i + 1; j < fraction.Count; j++)
                        {
                            if (fraction[i] < fraction[j])
                            {
                                tmp = fraction[i];
                                fraction[i] = fraction[j];
                                fraction[j] = tmp;
                            }
                        }
                    }
                    dataGridView1.RowCount = fraction.Count;
                    for (int i = 0; i < fraction.Count; i++)
                    {
                        dataGridView1[0, i].Value = fraction[i].Nominator();
                        dataGridView1[1, i].Value = fraction[i].Denominator();
                    }
                    menu.RowCounts(RowCount);
                    break;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
