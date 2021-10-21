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
    public partial class Form_Person : Form
    {
        SqlConnection connection;
        public Form_Person(string textname)
        {
            InitializeComponent();
            label16.Text = "สวัสดี";
            label15.Text = textname;
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
           OpenFileDialog o = new OpenFileDialog();
           o.Filter = "jpg files(.jpg)|*.jpg|PNG files(.png)|*.png|All files(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox9.Text = o.FileName;
                pictureBox1.Image = new Bitmap(o.FileName);
            } 
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {
            
            if(textBox7.Text != "")
            {
                label11.Text = "";
            }
            if(textBox7.Text == textBox6.Text) 
            {
               
                label11.Text = "รหัสผ่านซ้ำ";
                label11.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label11.Text = "";
                if (textBox7.Text == textBox8.Text && textBox8.Text != "")
                {
                    label12.Text = "รหัสผ่านตรงกัน";
                    label12.ForeColor = System.Drawing.Color.Green;
                }
                else if (textBox7.Text != textBox8.Text && textBox8.Text != "")
                {
                    label12.Text = "รหัสผ่านไม่ตรงกัน";
                    label12.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label12.Text = "";
                }
            }
            
        }

        private void checkemp()
        {
            if (textBox6.Text == "")
            {
                label13.Text = "*";
                label13.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if(label13.Text == "รหัสผ่านถูกต้อง")
                {
                    label13.Text = "รหัสผ่านถูกต้อง";
                }
                else
                {
                    label13.Text = "";
                }
                
            }
            if (textBox7.Text == "")
            {
                label11.Text = "*";
                label11.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label11.Text = "";
            }
            if (textBox8.Text == "")
            {
                label12.Text = "*";
                label12.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (label12.Text == "รหัสผ่านตรงกัน")
                {
                    label12.Text = "รหัสผ่านตรงกัน";
                }
                else
                {
                    label12.Text = "";
                }
            }
            
        }
        

        private void Button4_Click(object sender, EventArgs e)
        {
            checkemp();
            if(textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                
                if (label13.Text == "รหัสผ่านถูกต้อง" && label12.Text == "รหัสผ่านตรงกัน")
                {
                    //update data
                    string sql2 = @"UPDATE TBInformations SET IFpass = @NIFpass WHERE IFuser = @OIFuser";
                    connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                    SqlCommand command = new SqlCommand(sql2, connection);
                    connection.Open();
                    command.Parameters.AddWithValue("@OIFuser", textBox3.Text);
                    command.Parameters.AddWithValue("@NIFpass", textBox7.Text);

                    command.ExecuteNonQuery();
                    
                    DialogResult result = MessageBox.Show("เปลี่ยนรหัสผ่านเสร็จสมบูรณ์", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        label13.Text = "";
                        label11.Text = "";
                        label12.Text = "";
                    }
                }
                else if(label13.Text != "รหัสผ่านถูกต้อง" && label12.Text == "รหัสผ่านตรงกัน")
                {
                    MessageBox.Show("รหัสผ่านเก่าไม่ถูกต้อง");
                    label13.Text = "รหัสผ่านไม่ถูกต้อง";
                    label13.ForeColor = System.Drawing.Color.Red;
                }
                else if (label13.Text == "รหัสผ่านถูกต้อง" && label12.Text != "รหัสผ่านตรงกัน")
                {
                    MessageBox.Show("รหัสผ่านไม่ตรงกัน");
                    label12.Text = "รหัสผ่านไม่ตรงกัน";
                    label12.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    MessageBox.Show("ข้อมูลไม่ถูกต้อง");
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    label13.Text = "";
                    label11.Text = "";
                    label12.Text = "";
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน");
            }
           
        }
        private DataSet dataSt;

        private void selectData()
        {
            String sql = "SELECT *FROM TBInformations";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Regis");

        }
        private void TextBox6_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox6.Text != "")
            {
                label13.Text = "";
            }
            //เช็ค password
            string sql = "SELECT *FROM TBInformations WHERE IFuser ='" + textBox3.Text + "' AND IFpass ='" + textBox6.Text + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                label13.Text = "รหัสผ่านถูกต้อง";
                label13.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label13.Text = "รหัสผ่านไม่ถูกต้อง";
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox6.UseSystemPasswordChar = false;
                textBox7.UseSystemPasswordChar = false;
                textBox8.UseSystemPasswordChar = false;
            }
            else
            {
                textBox6.UseSystemPasswordChar = true;
                textBox7.UseSystemPasswordChar = true;
                textBox8.UseSystemPasswordChar = true;
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        { 
            this.Hide();
        }

       
        private void Form_Personal_Information_Load_1(object sender, EventArgs e)
        {
            
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();
            //dataGridView1.DataSource = dataSt.Tables["Regis"];

            string sql = "SELECT *FROM TBInformations WHERE IFuser ='" + label15.Text +"'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                textBox1.Text = rd["IFfname"].ToString();
                textBox2.Text = rd["IFlname"].ToString();
                textBox3.Text = rd["IFuser"].ToString();
                textBox4.Text = rd["IFphone"].ToString();
                textBox5.Text = rd["IFmail"].ToString();
                if(rd["IFbirthday"].ToString() != "")
                {
                    dateTimePicker1.Value = Convert.ToDateTime(rd["IFbirthday"].ToString());
                }
                else
                {
                    MessageBox.Show("2");
                }
                if(rd["IFsex"].ToString() == "ชาย")
                {
                    radioButton1.Checked = true;
                }
                else if (rd["IFsex"].ToString() == "หญิง")
                {
                    radioButton2.Checked = true;
                }
                else if (rd["IFsex"].ToString() == "อื่นๆ")
                {
                    radioButton3.Checked = true;
                }
                if (!DBNull.Value.Equals(rd["IFpath"]))
                {
                    byte[] img = (byte[])rd["IFprofile"];
                    MemoryStream ms = new MemoryStream(img);
                    ms.Seek(0, SeekOrigin.Begin);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            
        }
        string SEX;
        private void radiocheck()
        {

            if (radioButton1.Checked)
            {
                SEX = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                SEX = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                SEX = radioButton3.Text;
            }
            else
            {
                SEX = "NULL";
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            radiocheck();
            string sql2 = @"UPDATE TBInformations SET IFfname = @NewFN, IFlname = @NewLN ,IFphone = @Newphone,IFsex = @Newsex,IFbirthday = @Newbirthday WHERE IFuser = '" + textBox3.Text + "'";
            
            SqlCommand command = new SqlCommand(sql2, connection);
           
            command.Parameters.Clear();
            command.Parameters.AddWithValue("NewFN", textBox1.Text);
            command.Parameters.AddWithValue("NewLN", textBox2.Text);
            command.Parameters.AddWithValue("Newphone", textBox4.Text);
            command.Parameters.AddWithValue("Newsex", SEX);
            command.Parameters.AddWithValue("Newbirthday", dateTimePicker1.Value.Date);
            //command.Parameters.AddWithValue("@Nbirthday", dateTimePicker1.Value.Date);
            command.ExecuteNonQuery();
            
            selectData();
            //dataGridView1.DataSource = dataSt.Tables["Regis"];
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            string imgpath = textBox9.Text;
            FileStream fs;
            fs = new FileStream(@imgpath, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            con.Open();
            string qry = "UPDATE TBInformations SET IFpath = '"+textBox9.Text+"' , IFprofile = @pic WHERE IFuser = '"+textBox3.Text+"'";
            SqlParameter picpara = new SqlParameter();
            picpara.SqlDbType = SqlDbType.Image;
            picpara.ParameterName = "pic";
            picpara.Value = picbyte;
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.Add(picpara);
            cmd.ExecuteNonQuery();
            MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }

        private void Label17_Click(object sender, EventArgs e)
        {

        }

        private void Label15_MouseMove(object sender, MouseEventArgs e)
        {
            label15.ForeColor = System.Drawing.Color.Yellow;
            label16.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Label15_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = System.Drawing.Color.White;
            label16.ForeColor = System.Drawing.Color.White;
        }

        

        private void Form_Person_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(""+listBox1.SelectedIndex.ToString());
        }

        private void Form_Person_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string sql2 = "SELECT *FROM Invoice WHERE Custid ='" + textBox3.Text + "'";
            SqlConnection con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd2 = new SqlCommand(sql2, con2);
            con2.Open();
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                listBox1.Items.Add("       " +rd2["Invno"].ToString()+"                   "+rd2["Invdate"].ToString() +"                      " + rd2["AmountBook"].ToString() +"                          " + rd2["TotalPrice"].ToString() + "             ");
             
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Invoice  WHERE Invno = '" + textBox10.Text + "' AND Custid = '" + textBox3.Text + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                Form_HistoryBuy fh = new Form_HistoryBuy(textBox3.Text,textBox10.Text);
                fh.ShowDialog();
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
           
        }
    }
}
