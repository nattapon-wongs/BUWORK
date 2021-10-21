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
    public partial class Form_Main : Form
    {
        public Form_Main(string textname)
        {
            InitializeComponent();
            if(textname != "")
            {
                label3.Text = textname;
                label1.Text = "";
                label35.Text = "";
                label2.Text = "";
                label34.Text = "สวัสดี";
                label36.Text = "ออกจากระบบ";
                pictureBox18.Show();
            }
            else
            {
                pictureBox18.Hide();
            }
        }
        
        
        private void reset()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            numericUpDown7.Value = 0;
            numericUpDown8.Value = 0;
        }
        private void Label1_Click(object sender, EventArgs e)
        {
            Form_Login fln = new Form_Login();
            fln.ShowDialog();
            this.Close();
        }
                
        private void Label2_Click(object sender, EventArgs e)
        {
            Form_Register rg = new Form_Register();
            rg.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Show();
            reset();
;        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                Form_Detail fd = new Form_Detail("", textBox1.Text, label3.Text);
                this.Hide();
                fd.Show();
            }
            
        }
        private void Label3_Click(object sender, EventArgs e)
        {
            Form_Person fp = new Form_Person(label3.Text);
            fp.Show();
        }

        private void Label30_MouseMove(object sender, MouseEventArgs e)
        {
            label30.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label30_MouseLeave(object sender, EventArgs e)
        {
            label30.ForeColor = System.Drawing.Color.White;
        }

        private void Label31_MouseMove(object sender, MouseEventArgs e)
        {
            label31.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label31_MouseLeave(object sender, EventArgs e)
        {
            label31.ForeColor = System.Drawing.Color.White;
        }
        private void Label32_MouseMove(object sender, MouseEventArgs e)
        {
            label32.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label32_MouseLeave(object sender, EventArgs e)
        {
            label32.ForeColor = System.Drawing.Color.White;
        }

        private void Label33_MouseMove(object sender, MouseEventArgs e)
        {
            label33.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label33_MouseLeave(object sender, EventArgs e)
        {
            label33.ForeColor = System.Drawing.Color.White;
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.White;
        }

        private void Label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.White;
        }

        private void Label36_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่", "ออกจากระบบ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Form_Main fm = new Form_Main("");
                fm.Show();
            }

        }

        private void Label36_MouseMove(object sender, MouseEventArgs e)
        {
            label36.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label36_MouseLeave(object sender, EventArgs e)
        {
            label36.ForeColor = System.Drawing.Color.White;
        }

        private void Label3_MouseMove(object sender, MouseEventArgs e)
        {
            label34.ForeColor = System.Drawing.Color.Yellow;
            label3.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label3_MouseLeave(object sender, EventArgs e)
        {
            label34.ForeColor = System.Drawing.Color.White;
            label3.ForeColor = System.Drawing.Color.White;
        }
        

        private void Label30_Click(object sender, EventArgs e)
        {
            reset();
            string sql = "SELECT * FROM Table_Product  WHERE PRO_ID LIKE 'L%'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label4.Text = rd["PRO_NAME"].ToString();
                label37.Text = rd["PRO_PRICE"].ToString();
                label45.Text = rd["PRO_ID"].ToString();
                numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString()) ;
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox5.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label7.Text = rd["PRO_NAME"].ToString();
                label38.Text = rd["PRO_PRICE"].ToString();
                label46.Text = rd["PRO_ID"].ToString();
                numericUpDown2.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox6.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label10.Text = rd["PRO_NAME"].ToString();
                label39.Text = rd["PRO_PRICE"].ToString();
                label47.Text = rd["PRO_ID"].ToString();
                numericUpDown3.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox7.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label13.Text = rd["PRO_NAME"].ToString();
                label40.Text = rd["PRO_PRICE"].ToString();
                label48.Text = rd["PRO_ID"].ToString();
                numericUpDown4.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox8.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label16.Text = rd["PRO_NAME"].ToString();
                label41.Text = rd["PRO_PRICE"].ToString();
                label49.Text = rd["PRO_ID"].ToString();
                numericUpDown5.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox9.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label19.Text = rd["PRO_NAME"].ToString();
                label42.Text = rd["PRO_PRICE"].ToString();
                label50.Text = rd["PRO_ID"].ToString();
                numericUpDown6.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox10.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label22.Text = rd["PRO_NAME"].ToString();
                label43.Text = rd["PRO_PRICE"].ToString();
                label51.Text = rd["PRO_ID"].ToString();
                numericUpDown7.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox11.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label25.Text = rd["PRO_NAME"].ToString();
                label44.Text = rd["PRO_PRICE"].ToString();
                label52.Text = rd["PRO_ID"].ToString();
                numericUpDown8.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox12.Image = Image.FromStream(ms);
            }

        }

        private void Label31_Click(object sender, EventArgs e)
        {
            reset();
            string sql = "SELECT * FROM Table_Product  WHERE PRO_ID LIKE 'C%'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label4.Text = rd["PRO_NAME"].ToString();
                label37.Text = rd["PRO_PRICE"].ToString();
                label45.Text = rd["PRO_ID"].ToString();
                numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox5.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label7.Text = rd["PRO_NAME"].ToString();
                label38.Text = rd["PRO_PRICE"].ToString();
                label46.Text = rd["PRO_ID"].ToString();
                numericUpDown2.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox6.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label10.Text = rd["PRO_NAME"].ToString();
                label39.Text = rd["PRO_PRICE"].ToString();
                label47.Text = rd["PRO_ID"].ToString();
                numericUpDown3.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox7.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label13.Text = rd["PRO_NAME"].ToString();
                label40.Text = rd["PRO_PRICE"].ToString();
                label48.Text = rd["PRO_ID"].ToString();
                numericUpDown4.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox8.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label16.Text = rd["PRO_NAME"].ToString();
                label41.Text = rd["PRO_PRICE"].ToString();
                label49.Text = rd["PRO_ID"].ToString();
                numericUpDown5.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox9.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label19.Text = rd["PRO_NAME"].ToString();
                label42.Text = rd["PRO_PRICE"].ToString();
                label50.Text = rd["PRO_ID"].ToString();
                numericUpDown6.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox10.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label22.Text = rd["PRO_NAME"].ToString();
                label43.Text = rd["PRO_PRICE"].ToString();
                label51.Text = rd["PRO_ID"].ToString();
                numericUpDown7.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox11.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label25.Text = rd["PRO_NAME"].ToString();
                label44.Text = rd["PRO_PRICE"].ToString();
                label52.Text = rd["PRO_ID"].ToString();
                numericUpDown8.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox12.Image = Image.FromStream(ms);
            }
        }

        private void Label32_Click(object sender, EventArgs e)
        {
            reset();
            string sql = "SELECT * FROM Table_Product  WHERE PRO_ID LIKE 'N%'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label4.Text = rd["PRO_NAME"].ToString();
                label37.Text = rd["PRO_PRICE"].ToString();
                label45.Text = rd["PRO_ID"].ToString();
                numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox5.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label7.Text = rd["PRO_NAME"].ToString();
                label38.Text = rd["PRO_PRICE"].ToString();
                label46.Text = rd["PRO_ID"].ToString();
                numericUpDown2.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox6.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label10.Text = rd["PRO_NAME"].ToString();
                label39.Text = rd["PRO_PRICE"].ToString();
                label47.Text = rd["PRO_ID"].ToString();
                numericUpDown3.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox7.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label13.Text = rd["PRO_NAME"].ToString();
                label40.Text = rd["PRO_PRICE"].ToString();
                label48.Text = rd["PRO_ID"].ToString();
                numericUpDown4.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox8.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label16.Text = rd["PRO_NAME"].ToString();
                label41.Text = rd["PRO_PRICE"].ToString();
                label49.Text = rd["PRO_ID"].ToString();
                numericUpDown5.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox9.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label19.Text = rd["PRO_NAME"].ToString();
                label42.Text = rd["PRO_PRICE"].ToString();
                label50.Text = rd["PRO_ID"].ToString();
                numericUpDown6.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox10.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label22.Text = rd["PRO_NAME"].ToString();
                label43.Text = rd["PRO_PRICE"].ToString();
                label51.Text = rd["PRO_ID"].ToString();
                numericUpDown7.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox11.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label25.Text = rd["PRO_NAME"].ToString();
                label44.Text = rd["PRO_PRICE"].ToString();
                label52.Text = rd["PRO_ID"].ToString();
                numericUpDown8.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox12.Image = Image.FromStream(ms);
            }
        }

        private void Label33_Click(object sender, EventArgs e)
        {
            reset();
            string sql = "SELECT * FROM Table_Product  WHERE PRO_ID LIKE 'T%'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label4.Text = rd["PRO_NAME"].ToString();
                label37.Text = rd["PRO_PRICE"].ToString();
                label45.Text = rd["PRO_ID"].ToString();
                numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox5.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label7.Text = rd["PRO_NAME"].ToString();
                label38.Text = rd["PRO_PRICE"].ToString();
                label46.Text = rd["PRO_ID"].ToString();
                numericUpDown2.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox6.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label10.Text = rd["PRO_NAME"].ToString();
                label39.Text = rd["PRO_PRICE"].ToString();
                label47.Text = rd["PRO_ID"].ToString();
                numericUpDown3.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox7.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label13.Text = rd["PRO_NAME"].ToString();
                label40.Text = rd["PRO_PRICE"].ToString();
                label48.Text = rd["PRO_ID"].ToString();
                numericUpDown4.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox8.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label16.Text = rd["PRO_NAME"].ToString();
                label41.Text = rd["PRO_PRICE"].ToString();
                label49.Text = rd["PRO_ID"].ToString();
                numericUpDown5.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox9.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label19.Text = rd["PRO_NAME"].ToString();
                label42.Text = rd["PRO_PRICE"].ToString();
                label50.Text = rd["PRO_ID"].ToString();
                numericUpDown6.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox10.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label22.Text = rd["PRO_NAME"].ToString();
                label43.Text = rd["PRO_PRICE"].ToString();
                label51.Text = rd["PRO_ID"].ToString();
                numericUpDown7.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox11.Image = Image.FromStream(ms);
            }
            if (rd.Read())
            {
                label25.Text = rd["PRO_NAME"].ToString();
                label44.Text = rd["PRO_PRICE"].ToString();
                label52.Text = rd["PRO_ID"].ToString();
                numericUpDown8.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                byte[] img = (byte[])rd["PRO_IMG"];
                MemoryStream ms = new MemoryStream(img);
                ms.Seek(0, SeekOrigin.Begin);
                pictureBox12.Image = Image.FromStream(ms);
            }
        }
       
        private void Form_Main_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Table_Product";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            string sql1 = "SELECT * FROM Table_Product ";
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            cmd = new SqlCommand(sql1, con1);
            con1.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {               
                if(rd["PRO_ID"].ToString() == label45.Text)
                    numericUpDown1.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label46.Text)
                    numericUpDown2.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label47.Text)
                    numericUpDown3.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label48.Text)
                    numericUpDown4.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label49.Text)
                    numericUpDown5.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label50.Text)
                    numericUpDown6.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label51.Text)
                    numericUpDown7.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
                if (rd["PRO_ID"].ToString() == label52.Text)
                    numericUpDown8.Maximum = Convert.ToInt32(rd["PRO_AMOUNT"].ToString());
            }

        }

        
        private void Label4_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label45.Text,"",label3.Text);
            f1.Show();
            this.Hide();
           
        }
    
        private void Label7_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label46.Text,"", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label47.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label48.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label16_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label49.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label19_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label50.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label22_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label51.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        private void Label25_Click(object sender, EventArgs e)
        {
            Form_Detail f1 = new Form_Detail(label52.Text, "", label3.Text);
            f1.Show();
            this.Hide();
        }

        
        public static Form_Invoice fn =  new Form_Invoice();
        private void Button1_Click(object sender, EventArgs e)
        {
            if(fn.listBox1.Items.Count <15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown1.Value != 0)
                    {
                        fn.listBox1.Items.Add(label45.Text);
                        fn.listBox3.Items.Add(label4.Text);
                        fn.listBox4.Items.Add(numericUpDown1.Value);
                        fn.listBox5.Items.Add(label37.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label37.Text) * numericUpDown1.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown2.Value != 0)
                    {
                        fn.listBox1.Items.Add(label46.Text);
                        fn.listBox3.Items.Add(label7.Text);
                        fn.listBox4.Items.Add(numericUpDown2.Value);
                        fn.listBox5.Items.Add(label38.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label38.Text) * numericUpDown2.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown3.Value != 0)
                    {
                        fn.listBox1.Items.Add(label47.Text);
                        fn.listBox3.Items.Add(label10.Text);
                        fn.listBox4.Items.Add(numericUpDown3.Value);
                        fn.listBox5.Items.Add(label39.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label39.Text) * numericUpDown3.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown4.Value != 0)
                    {
                        fn.listBox1.Items.Add(label48.Text);
                        fn.listBox3.Items.Add(label13.Text);
                        fn.listBox4.Items.Add(numericUpDown4.Value);
                        fn.listBox5.Items.Add(label40.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label40.Text) * numericUpDown4.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown5.Value != 0)
                    {
                        fn.listBox1.Items.Add(label49.Text);
                        fn.listBox3.Items.Add(label16.Text);
                        fn.listBox4.Items.Add(numericUpDown5.Value);
                        fn.listBox5.Items.Add(label41.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label41.Text) * numericUpDown5.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");
        }
                private void Button6_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown6.Value != 0)
                    {
                        fn.listBox1.Items.Add(label50.Text);
                        fn.listBox3.Items.Add(label19.Text);
                        fn.listBox4.Items.Add(numericUpDown6.Value);
                        fn.listBox5.Items.Add(label42.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label42.Text) * numericUpDown6.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown7.Value != 0)
                    {
                        fn.listBox1.Items.Add(label51.Text);
                        fn.listBox3.Items.Add(label22.Text);
                        fn.listBox4.Items.Add(numericUpDown7.Value);
                        fn.listBox5.Items.Add(label43.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label43.Text) * numericUpDown7.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (fn.listBox1.Items.Count < 15)
            {
                if (label3.Text == "")
                {
                    Form_Login fln = new Form_Login();
                    fln.ShowDialog();
                    this.Hide();
                }
                else
                {
                    if (numericUpDown8.Value != 0)
                    {
                        fn.listBox1.Items.Add(label52.Text);
                        fn.listBox3.Items.Add(label25.Text);
                        fn.listBox4.Items.Add(numericUpDown8.Value);
                        fn.listBox5.Items.Add(label44.Text);
                        fn.listBox6.Items.Add(fn.listBox1.Items.Count);
                        fn.listBox2.Items.Add(Convert.ToInt32(label44.Text) * numericUpDown8.Value);
                        MessageBox.Show("เพิ่มในรายกาซื้อเรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("กรุณาใส่จำนวนหนังสือที่ต้องการซื้อ");
                    }
                }
            }
            else
                MessageBox.Show("รายการสินค้าเกินจำนวน กรุณาชำระเงินก่อนการซื้อเพิ่ม", "Book Shop");

        }
        private void PictureBox18_Click(object sender, EventArgs e)
        {
            fn.Show();
            fn.label18.Text = label3.Text;
        }

        private void Form_Main_Activated(object sender, EventArgs e)
        {
            if (fn.listBox6.Items.Count == 0)
                label53.Hide();
            else
            {
                label53.Show();
                label53.Text = Convert.ToString(fn.listBox1.Items.Count);
            } 
            
        }
    }
}
