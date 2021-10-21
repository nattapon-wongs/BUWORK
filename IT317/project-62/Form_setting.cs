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
    public partial class Form_setting : Form
    {
        SqlConnection connection;
        
        DataSet dataSt;
        public Form_setting()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "jpg files(.jpg)|*.jpg| PNG files(.png)|*.png|All files(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = o.FileName;
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            pictureBox1.Image = null;
            comboBox1.Text = "เลือกหมวดหนังสือ";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "เลือกหมวดหนังสือ" && pictureBox1.Image != null)
            {
                string GP = comboBox1.SelectedItem.ToString();
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                connection = new SqlConnection(str);
                string imgpath = textBox15.Text;
                FileStream fs;
                fs = new FileStream(@imgpath, FileMode.Open, FileAccess.Read);
                byte[] picbyte = new byte[fs.Length];
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                connection.Open();
                string str1 = "INSERT INTO Table_Product (PRO_ID,PRO_NAME,PRO_AMOUNT,PRO_PRICE,PRO_DETAIL,PRO_WRITER,PRO_H,PRO_L,PRO_W,PRO_GROUP,PUBLISHER,PAGE,WEIGHT,MP,YP,IMG_PATH,PRO_IMG)VALUES(@PRO_ID,@PRO_NAME,@PRO_AMOUNT,@PRO_PRICE,@PRO_DETAIL,@PRO_WRITER,@PRO_H,@PRO_L,@PRO_W,@PRO_GROUP,@PUBLISHER,@PAGE,@WEIGHT,@MP,@YP,@IMG_PATH,@pic)";
                SqlCommand command = new SqlCommand(str1, connection);

                command.Parameters.AddWithValue("@PRO_ID", textBox1.Text);
                command.Parameters.AddWithValue("@PRO_NAME", textBox2.Text);
                command.Parameters.AddWithValue("@PRO_AMOUNT", textBox3.Text);
                command.Parameters.AddWithValue("@PRO_PRICE", textBox4.Text);
                command.Parameters.AddWithValue("@PRO_DETAIL", textBox5.Text);
                command.Parameters.AddWithValue("@PRO_WRITER", textBox6.Text);
                command.Parameters.AddWithValue("@PRO_H", textBox7.Text);
                command.Parameters.AddWithValue("@PRO_L", textBox8.Text);
                command.Parameters.AddWithValue("@PRO_W", textBox9.Text);
                command.Parameters.AddWithValue("@PRO_GROUP", GP);
                command.Parameters.AddWithValue("@PUBLISHER", textBox10.Text);
                command.Parameters.AddWithValue("@PAGE", textBox11.Text);
                command.Parameters.AddWithValue("@WEIGHT", textBox12.Text);
                command.Parameters.AddWithValue("@MP", textBox13.Text);
                command.Parameters.AddWithValue("@YP", textBox14.Text);
                command.Parameters.AddWithValue("@IMG_PATH", textBox15.Text);
                SqlParameter picpara = new SqlParameter();
                picpara.SqlDbType = SqlDbType.Image;
                picpara.ParameterName = "pic";
                picpara.Value = picbyte;
                command.Parameters.Add(picpara);
                command.ExecuteNonQuery();
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Setting");
                selectData();
                Button1_Click(null, null);
            }
            else if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "เลือกหมวดหนังสือ" && pictureBox1.Image == null)
            {
                MessageBox.Show("กรุณาเพิ่มรูปสินค้า", "Setting");
            }
            else if(textBox1.Text == "" && textBox2.Text != "" && comboBox1.Text != "เลือกหมวดหนังสือ" && pictureBox1.Image != null)
            {
                MessageBox.Show("กรุณาเพิ่มรหัสสินค้า", "Setting");
            }
            else if(textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text == "เลือกหมวดหนังสือ" && pictureBox1.Image != null)
            {
                MessageBox.Show("กรุณาเเลือกหมวดสินค้า", "Setting");
            }
            else if(textBox1.Text != "" && textBox2.Text == "" && comboBox1.Text != "เลือกหมวดหนังสือ" && pictureBox1.Image != null)
            {
                MessageBox.Show("กรุณากรอกชื่อสินค้า", "Setting");
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลสินค้าให้ถูกต้อง", "Setting");
            }
        }

        private void selectData()
        {
            string sql = "SELECT  * FROM  Table_Product ";
            string sql2 = "SELECT  * FROM  Promotion ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlCommand command2 = new SqlCommand(sql2, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "book");
            adapter2.Fill(dataSt, "Promo");

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox1.Text = "เลือกหมวดหนังสือ";
            comboBox3.Text = "เลือกรหัสหนังสือ";
            comboBox4.Text = "เลือกรหัสโปรโมชั่น";
            for (int i = 0; i < dataSt.Tables["book"].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSt.Tables["book"].Rows[i]["PRO_ID"].ToString());
            }
            for (int i = 0; i < dataSt.Tables["Promo"].Rows.Count; i++)
            {
                comboBox4.Items.Add(dataSt.Tables["Promo"].Rows[i]["PCode"].ToString());
            }
        }

        private void Form_setting_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();
            comboBox1.Text = "เลือกหมวดหนังสือ";
            comboBox3.Text = "เลือกรหัสหนังสือ";
            comboBox4.Text = "เลือกรหัสโปรโมชั่น";
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM Table_Product WHERE PRO_ID ='" + comboBox3.SelectedItem.ToString() + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                comboBox2.Text = rd["PRO_GROUP"].ToString();
                
                textBox19.Text = rd["PRO_NAME"].ToString();
                textBox20.Text = rd["PRO_AMOUNT"].ToString();
                textBox16.Text = rd["PRO_PRICE"].ToString();
                textBox21.Text = rd["PRO_DETAIL"].ToString();
                textBox22.Text = rd["PRO_WRITER"].ToString();
                textBox24.Text = rd["PRO_H"].ToString();
                textBox26.Text = rd["PRO_L"].ToString();
                textBox28.Text = rd["PRO_W"].ToString();
                textBox30.Text = rd["PUBLISHER"].ToString();
                textBox29.Text = rd["PAGE"].ToString();
                textBox27.Text = rd["WEIGHT"].ToString();
                textBox23.Text = rd["MP"].ToString();
                textBox17.Text = rd["YP"].ToString();
                textBox25.Text = rd["IMG_PATH"].ToString();
                if (!DBNull.Value.Equals(rd["IMG_PATH"]))
                {
                    byte[] img = (byte[])rd["PRO_IMG"];
                    MemoryStream ms = new MemoryStream(img);
                    ms.Seek(0, SeekOrigin.Begin);
                    pictureBox2.Image = Image.FromStream(ms);
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex > -1)
            {
                string imgpath = textBox25.Text;
                FileStream fs;
                fs = new FileStream(@imgpath, FileMode.Open, FileAccess.Read);
                byte[] picbyte = new byte[fs.Length];
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                string str1 = @"UPDATE Table_Product SET PRO_NAME = @NName,PRO_AMOUNT = @NAmount,PRO_PRICE = @NPrice,PRO_DETAIL = @NDetail,PRO_WRITER = @NWriter,PRO_H = @NH,PRO_L = @NL,PRO_W = @NW,PRO_GROUP = @NGroup,PUBLISHER = @NPublisher,PAGE = @NPage,WEIGHT = @NWeight,MP = @NMP,YP = @NYP ,IMG_PATH = @NPath,PRO_IMG = @NImg WHERE PRO_ID = @OID";
                SqlCommand command = new SqlCommand(str1, connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@OID", comboBox3.SelectedItem.ToString());
                command.Parameters.AddWithValue("@NName", textBox19.Text);
                command.Parameters.AddWithValue("@NAmount", textBox20.Text);
                command.Parameters.AddWithValue("@NPrice", textBox16.Text);
                command.Parameters.AddWithValue("@NDetail", textBox21.Text);
                command.Parameters.AddWithValue("@NWriter", textBox22.Text);
                command.Parameters.AddWithValue("@NH", textBox24.Text);
                command.Parameters.AddWithValue("@NL", textBox26.Text);
                command.Parameters.AddWithValue("@NW", textBox28.Text);
                command.Parameters.AddWithValue("@NGroup", comboBox2.SelectedItem.ToString());
                command.Parameters.AddWithValue("@NPublisher", textBox30.Text);
                command.Parameters.AddWithValue("@NPage", textBox29.Text);
                command.Parameters.AddWithValue("@NWeight", textBox27.Text);
                command.Parameters.AddWithValue("@NMP", textBox23.Text);
                command.Parameters.AddWithValue("@NYP", textBox17.Text);
                command.Parameters.AddWithValue("@NPath", textBox25.Text);
                SqlParameter picpara = new SqlParameter();
                picpara.SqlDbType = SqlDbType.Image;
                picpara.ParameterName = "NImg";
                picpara.Value = picbyte;
                command.Parameters.Add(picpara);
                command.ExecuteNonQuery();
                MessageBox.Show("แก้ไขข้อมูลเรียบร้อย", "Setting");
                clear();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรหัสสินค้าที่ต้องการจะแก้ไขข้อมูล", "Setting");
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex > -1 )
            {
                string fn = comboBox3.SelectedItem.ToString();

                string sql = "DELETE FROM Table_Product WHERE (PRO_ID = @PRO_ID)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("PRO_ID", fn);

                command.ExecuteNonQuery();
                MessageBox.Show("ลบข้อมูลเรียบร้อย", "Setting");
                selectData();
                clear();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรหัสหนังสือที่ต้องการจะลบข้อมูล","Setting");
            }
            
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            comboBox3.Items.Clear();
            selectData();
            comboBox1.Text = "เลือกหมวดหนังสือ";
            comboBox3.Text = "เลือกรหัสหนังสือ";
        }
        private void clear()
        {
            textBox19.Text = "";
            textBox20.Text = "";
            textBox16.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox24.Text = "";
            textBox26.Text = "";
            textBox28.Text = "";
            textBox30.Text = "";
            textBox29.Text = "";
            textBox27.Text = "";
            textBox23.Text = "";
            textBox17.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox25.Text = "";
            comboBox1.Text = "เลือกหมวดหนังสือ";
            comboBox2.Text = "เลือกหมวดหนังสือ";
            comboBox3.Text = "เลือกรหัสหนังสือ";
            pictureBox2.Image = null;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "jpg files(.jpg)|*.jpg| PNG files(.png)|*.png|All files(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox25.Text = o.FileName;
                pictureBox2.Image = new Bitmap(o.FileName);
            }
        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            textBox18.CharacterCasing = CharacterCasing.Upper;
            string sql = "SELECT *FROM  Promotion WHERE PCode ='" + textBox18.Text + "'";
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader rd = command.ExecuteReader();
            if (rd.Read())
            {
                label32.Text = "✘";
                label32.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label32.Text = "✓";
                label32.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (textBox18.Text != "" && textBox31.Text != "" && textBox32.Text != ""   && label32.Text == "✓")
            {
                
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                connection.Open();
                string sql = "INSERT INTO Promotion (PCode,Deadline,Discount,Min,DEtail)VALUES(@PCode,@Deadline,@Discount,@Min,@Detail)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Add(new SqlParameter("@PCode", textBox18.Text));
                command.Parameters.Add(new SqlParameter("@Deadline", dateTimePicker1.Value.Date));
                command.Parameters.Add(new SqlParameter("@Discount", textBox31.Text ));
                command.Parameters.Add(new SqlParameter("@Min",textBox32.Text ));
                command.Parameters.Add(new SqlParameter("@Detail", textBox36.Text));


                command.ExecuteNonQuery();
                MessageBox.Show("เพิ่มโปรโมชั่นรียบร้อย");
                selectData();
                //dataGridView1.DataSource = dataSt.Tables["Regis"];
                textBox1.Text = "";
                textBox1.Text = "";
                textBox1.Text = "";
                textBox1.Text = "";
                //dateTimePicker1.Value = null;
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้องและครบถ้วน", "การสมัครสมาชิกใหม่", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM Promotion WHERE PCode ='" + comboBox4.SelectedItem.ToString() + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                textBox34.Text = rd["Discount"].ToString();
                textBox35.Text = rd["Min"].ToString();
                textBox37.Text = rd["Detail"].ToString();
                dateTimePicker2.Value = Convert.ToDateTime(rd["Deadline"].ToString());
                
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex > -1)
            {
                string str1 = @"UPDATE Promotion SET Deadline = @NDeadline,Discount = @NDiscount,Min = @NMin,Detail = @NDesc WHERE PCode = @OID";
                SqlCommand command = new SqlCommand(str1, connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("@OID", comboBox4.SelectedItem.ToString());
                command.Parameters.AddWithValue("@NDeadline", dateTimePicker2.Value.Date);
                command.Parameters.AddWithValue("@NDiscount", textBox34.Text);
                command.Parameters.AddWithValue("@NMin", textBox35.Text);
                command.Parameters.AddWithValue("@NDesc", textBox37.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("แก้ไขโปรโมชั่นรียบร้อย");
            } 
            else
            {
                MessageBox.Show("กรุณาเลือกรหัสโปรโมชั่น");
            }
           
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex > -1)
            {
                string fn = comboBox4.SelectedItem.ToString();

                string sql = "DELETE FROM Promotion WHERE (PCode = @PCode)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.Clear();
                command.Parameters.AddWithValue("PCode", fn);

                command.ExecuteNonQuery();
                MessageBox.Show("ลบข้อมูลเรียบร้อย", "Setting");
                selectData();
                MessageBox.Show("ลบโปรโมชั่นรียบร้อย");
                clear();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรหัสโปรโมชั่น");
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
