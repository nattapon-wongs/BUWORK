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
using System.IO;

namespace project_62
{
    public partial class Form_Detail : Form
    {
        public Form_Detail(string textsearch,string textsearch2,string textuser)
        {
           InitializeComponent();
            textBox1.Text = textsearch2;
            label23.Text = textsearch;
            if(textuser != "")
            {
                label25.Text = textuser;
                label34.Text = "สวัสดี";
                label26.Text = "ออกจากระบบ";
                pictureBox18.Show();
            }
            else
            {
                pictureBox18.Hide();
            }
            
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form_Main fm = new Form_Main(label25.Text);
            fm.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Form_Detail fd = new Form_Detail( "",textBox1.Text,label3.Text);

                this.Hide(); 
                fd.Show();
            }
        }

        private void Form_Detail_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Table_Product  WHERE PRO_ID = '"+label23.Text+"' OR PRO_NAME = '"+textBox1.Text+"'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label23.Text = rd["PRO_ID"].ToString();
                label5.Text = rd["PRO_NAME"].ToString();
                label6.Text = rd["PRO_GROUP"].ToString();
                label8.Text = rd["PRO_DETAIL"].ToString();
                label7.Text = rd["PRO_PRICE"].ToString();
                label10.Text = rd["PRO_WRITER"].ToString();
                label12.Text = rd["PUBLISHER"].ToString();
                label15.Text = rd["PAGE"].ToString() + " หน้า";
                label16.Text = rd["PRO_H"].ToString() + " มม.";
                label20.Text = rd["PRO_L"].ToString() + " มม.";
                label19.Text = rd["PRO_W"].ToString() + " มม.";
                label22.Text = rd["WEIGHT"].ToString() + " กรัม";
                numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox5.Image = Image.FromStream(ms);
            }
            else
            {
                label1.Text = "ไม่พบข้อมูล";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label15.Text = "";
                label16.Text = "";
                label17.Text = "";
                label18.Text = "";
                label19.Text = "";
                label20.Text = "";
                label22.Text = "";
                label21.Text = "";
                label24.Text = "";
                numericUpDown1.Hide();
                button1.Hide();
            }
        }

        private void Label25_Click(object sender, EventArgs e)
        {
            Form_Person fp = new Form_Person(label25.Text);
            fp.Show();
            this.Hide();
        }

        private void Label25_MouseMove(object sender, MouseEventArgs e)
        {
            label34.ForeColor = System.Drawing.Color.Yellow;
            label25.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label25_MouseLeave(object sender, EventArgs e)
        {
            label34.ForeColor = System.Drawing.Color.White;
            label25.ForeColor = System.Drawing.Color.White;
        }
        Form_Login fln = new Form_Login();
        Form_Invoice fn = new Form_Invoice();
        Form_Main fm = new Form_Main("");
        private void Button1_Click(object sender, EventArgs e)
        {
            if (label25.Text == "")
            {
                fln.ShowDialog();
                this.Hide();
            }
            else
            {
                if (numericUpDown1.Value != 0)
                {
                    fn.listBox1.Items.Add(label23.Text);
                    fn.listBox3.Items.Add(label5.Text);
                    fn.listBox4.Items.Add(numericUpDown1.Value);
                    fn.listBox5.Items.Add(label7.Text);
                    fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                    fn.listBox2.Items.Add(Convert.ToInt32(label7.Text) * numericUpDown1.Value);
                    MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                }
                else
                {
                    MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                }
            }
        }

        private void Label26_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่", "ออกจากระบบ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Form_Main fm = new Form_Main("");
                fm.Show();
            }
        }

        private void Label26_MouseMove(object sender, MouseEventArgs e)
        {
            label26.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label26_MouseLeave(object sender, EventArgs e)
        {
            label26.ForeColor = System.Drawing.Color.White;
        }

        private void PictureBox18_Click(object sender, EventArgs e)
        {
            fn.ShowDialog();
        }
    }
}
