using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Imitation
{
    public partial class Form1 : Form
    {
        Model m = new Model();
        public Form1()
        {
            InitializeComponent();
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            int number_of_events = (int)numericUpDown1.Value;
            m.simulate(number_of_events,pictureBox1,label2, label4);
            label9.Text = m.Statistic2[0].ToString("N3") + "%";
            label10.Text = m.Statistic2[1].ToString("N3") + "%";
            label11.Text = m.Statistic2[2].ToString("N3") + "%";


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
