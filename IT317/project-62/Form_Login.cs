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
    public partial class Form_Login : Form
    {

        public Form_Login()
        {
            InitializeComponent();
        }


        SqlConnection connection;
        DataSet dataSt;

        private void Label4_Click(object sender, EventArgs e)
        {          
            Form_Register regis = new Form_Register();
            //this.Close();
            regis.ShowDialog();
            this.Hide();
        }
       
        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form_Main fm = new Form_Main("");
            fm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT *FROM TBInformations WHERE IFuser ='" + textBox1.Text + "' AND IFpass ='" + textBox2.Text + "'";
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader rd = cmd.ExecuteReader(); 
            if (rd.Read())
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ","เข้าสู่ระบบ");
                string textuser = rd["IFuser"].ToString();
                this.Close();
                Form_Main f1 = new Form_Main(textuser); 
                f1.Show();
                
            }
            else
            {
                MessageBox.Show("ขออภัย... Username/Password ไม่ถูกต้อง กรุณาตรวจสอบ Username/Password แล้วลองใหม่อีกครั้ง", " ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Form_Forgetpass ff = new Form_Forgetpass();
            ff.Show();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            
            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();

            //dataGridView1.DataSource = dataSt.Tables["Regis"];
        }
       
        private void selectData()
        {
            String sql = "SELECT *FROM TBInformations";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Regis");

        }
    }
}
