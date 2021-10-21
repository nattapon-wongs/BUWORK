using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_62
{
    public partial class Form_Forgetpass : Form
    {
       
       
        public Form_Forgetpass()
        {
            InitializeComponent();
        }

        private int checkemp()
        {
            if (textBox1.Text == "")
            {
                label6.Text = "*";
                label6.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label6.Text = "";
            }
            if (textBox2.Text == "")
            {
                label7.Text = "*";
                label7.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label7.Text = "";
            }
            if (textBox3.Text == "")
            {
                label8.Text = "*";
                label8.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label8.Text = "";
            }
            if(textBox1.Text != "" && textBox2.Text !="" && textBox3.Text != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            int check = 0;
            check = checkemp();
            if(check == 1)
            {
                string sql = "SELECT *FROM TBInformations WHERE IFmail ='" + textBox1.Text + "' AND IFfname ='" + textBox2.Text + "'AND IFlname = '"+ textBox3.Text+"'";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox4.Text = rd["IFpass"].ToString();
                }
                else
                {
                    MessageBox.Show("ข้อมูลไม่ถูกต้อง","ฉันลืมรหัสผ่าน");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
