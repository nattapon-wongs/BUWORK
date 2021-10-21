using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_62
{
    public partial class Form_intro : Form
    {
        public Form_intro()
        {
            InitializeComponent();
        }

        private void Form_intro_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1500;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string text = "";
            Form_Main fm = new Form_Main(text);
            fm.Show();
            Form_Discount f1 = new Form_Discount();
            f1.Show();
            this.Hide();
            timer1.Stop();
        }
    }
}
