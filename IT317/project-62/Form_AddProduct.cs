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
    public partial class Form_AddProduct : Form
    {
        public Form_AddProduct()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        SqlCommand cmd;
        DataSet dataSt;

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "jpg files(.jpg)|*.jpg| PNG files(.png)|*.png|All files(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                textBox15.Text = o.FileName;
                pictureBox1.Image = new Bitmap(o.FileName);
            }
        }

      
        private void Button2_Click(object sender, EventArgs e)
        {

            string GP = comboBox1.SelectedItem.ToString();
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\IT-62\Project1\projectit-62\projectit-62\Database1.mdf;Integrated Security=True";
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
            MessageBox.Show("Image stored");
        }

       


        private void Button5_Click_1(object sender, EventArgs e)
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
            comboBox3.Text = "เลือกรหัสหนังสือ";
        }

        private void selectData()
        {
            string sql = "SELECT  * FROM  Table_Product ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "book");

            comboBox3.Items.Clear();
            comboBox1.Text = "เลือกหมวดหนังสือ";
            comboBox3.Text = "เลือกรหัสหนังสือ";
            
            for (int i = 0; i < dataSt.Tables["book"].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSt.Tables["book"].Rows[i]["PRO_ID"].ToString());
            }
        }

        private void Form_AddProduct_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\PJ\project-62\project-62\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\PJ\project-62\project-62\Database1.mdf;Integrated Security=True");
            connection.Open();
            cmd = new SqlCommand("INSERT INTO Promotion (PCode)VALUES(@PCode)", connection);
            cmd.Parameters.Add(new SqlParameter("@PCode",textBox16.Text));
            cmd.Parameters.Add(new SqlParameter("@Deadline", textBox17.Text));
            cmd.Parameters.Add(new SqlParameter("@Values", Convert.ToInt32(textBox18.Text)));
           
            cmd.ExecuteNonQuery();
            MessageBox.Show("เพิ่มโปรโมชั่นเรียบร้อย");
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "0";
        }

        private void TextBox16_TextChanged(object sender, EventArgs e)
        {
            textBox16.CharacterCasing = CharacterCasing.Upper;
            textBox16.MaxLength = 12;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox4.MaxLength = 10;
        }

        private void TextBox18_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox18.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox18.Text = textBox18.Text.Remove(textBox18.Text.Length - 1);
            }
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            string imgpath = textBox15.Text;
            FileStream fs;
            fs = new FileStream(@imgpath, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            string str1 = @"UPDATE Table_Product SET PRO_NAME = @NName,PRO_AMOUNT = @NAmount,PRO_PRICE = @NPrice,PRO_DETAIL = @NDetail,PRO_WRITER = @NWriter,PRO_H = @NH,PRO_L = @NL,PRO_W = @NW,PRO_GROUP = @NGroup,PUBLISHER = @NPublisher,PAGE = @NPage,WEIGHT = @NWeight,MP = @NMP,YP = @NYP ,IMG_PATH = @NPath,PRO_IMG = @NImg WHERE PRO_ID = @OID";
            SqlCommand command = new SqlCommand(str1, connection);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@OID", comboBox3.SelectedItem.ToString());
            command.Parameters.AddWithValue("@NName", textBox2.Text);
            command.Parameters.AddWithValue("@NAmount", textBox3.Text);
            command.Parameters.AddWithValue("@NPrice", textBox4.Text);
            command.Parameters.AddWithValue("@NDetail", textBox5.Text);
            command.Parameters.AddWithValue("@NWriter", textBox6.Text);
            command.Parameters.AddWithValue("@NH", textBox7.Text);
            command.Parameters.AddWithValue("@NL", textBox8.Text);
            command.Parameters.AddWithValue("@NW", textBox9.Text);
            command.Parameters.AddWithValue("@NGroup", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@NPublisher", textBox10.Text);
            command.Parameters.AddWithValue("@NPage", textBox11.Text);
            command.Parameters.AddWithValue("@NWeight", textBox12.Text);
            command.Parameters.AddWithValue("@NMP", textBox13.Text);
            command.Parameters.AddWithValue("@NYP", textBox14.Text);
            command.Parameters.AddWithValue("@NPath", textBox15.Text);
            SqlParameter picpara = new SqlParameter();
            picpara.SqlDbType = SqlDbType.Image;
            picpara.ParameterName = "NImg";
            picpara.Value = picbyte;
            command.Parameters.Add(picpara);
            command.ExecuteNonQuery();
            MessageBox.Show("แก้ไขข้อมูลเรียบร้อย","Add Book");
            Button5_Click_1(null, null);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM Table_Product WHERE PRO_ID ='" + comboBox3.SelectedItem.ToString() + "'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\PJ\project-62\project-62\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                comboBox1.Text = rd["PRO_GROUP"].ToString();
                textBox1.Text = rd["PRO_ID"].ToString();
                textBox2.Text = rd["PRO_NAME"].ToString();
                textBox3.Text = rd["PRO_AMOUNT"].ToString();
                textBox4.Text = rd["PRO_PRICE"].ToString();
                textBox5.Text = rd["PRO_DETAIL"].ToString();
                textBox6.Text = rd["PRO_WRITER"].ToString();
                textBox7.Text = rd["PRO_H"].ToString();
                textBox8.Text = rd["PRO_L"].ToString();
                textBox9.Text = rd["PRO_W"].ToString();
                textBox10.Text = rd["PUBLISHER"].ToString();
                textBox11.Text = rd["PAGE"].ToString();
                textBox12.Text = rd["WEIGHT"].ToString();
                textBox13.Text = rd["MP"].ToString();
                textBox14.Text = rd["YP"].ToString();
                textBox15.Text = rd["IMG_PATH"].ToString();
                if (!DBNull.Value.Equals(rd["IMG_PATH"]))
                {
                    byte[] img = (byte[])rd["PRO_IMG"];
                    MemoryStream ms = new MemoryStream(img);
                    ms.Seek(0, SeekOrigin.Begin);
                    pictureBox1.Image = Image.FromStream(ms);
                }    
            }
        }

        
    }
}
