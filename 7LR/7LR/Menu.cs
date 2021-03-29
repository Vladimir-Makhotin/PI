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
    public partial class Menu : Form
    {   
        Collection create = new Collection();
        List<Rational> fraction = new List<Rational>();
        private int a;
        private int b;
        private int RowCount;
        public Menu()
        {
            InitializeComponent();
            
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collection create = new Collection();
            create.choise = "Create";
            create.Show();
            this.Hide();
        }
        private void посмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collection create = new Collection();
            for (int i = 0;i<fraction.Count;i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                create.Data(a, b, RowCount);
            }
            create.RowCounts(RowCount);
            create.choise = "Read";
            create.Show();
            this.Hide();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collection create = new Collection();
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                create.Data(a, b, RowCount);
            }
            create.RowCounts(RowCount);
            create.choise = "Update";
            create.Show();
            this.Hide();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Collection create = new Collection();
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                create.Data(a, b, RowCount);
            }
            create.RowCounts(RowCount);
            create.choise = "Delete";
            create.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
        public void Data(int a, int b)
        {
            Rational f = new Rational(a, b);
            fraction.Add(f);
        }
        public void RowCounts(int RC)
        {
            RowCount = RC;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            this.Hide();
            about.Show();
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void поВозрастаниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                create.Data(a, b, RowCount);
            }
            create.RowCounts(RowCount);
            create.choise = "In ascending order";
            create.Show();
            this.Hide();
        }

        private void поУбываниюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                create.Data(a, b, RowCount);
            }
            create.RowCounts(RowCount);
            create.choise = "In descending order";
            create.Show();
            this.Hide();
        }
        private void линейныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search1 search = new Search1();
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                search.Data(a, b, RowCount);
            }
            search.RowCounts(RowCount);
            this.Hide();
            search.searchchoice = "Linear";
            search.Show();
        }

        private void бинарныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Search1 search = new Search1();
            for (int i = 0; i < fraction.Count; i++)
            {
                a = fraction[i].Nominator();
                b = fraction[i].Denominator();
                search.Data(a, b, RowCount);
            }
            search.RowCounts(RowCount);
            this.Hide();
            search.searchchoice = "Binary";
            search.Show();
        }
    }
}
