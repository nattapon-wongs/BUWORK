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
    public partial class Form_Register : Form
    {
        public Form_Register()
        {
            InitializeComponent();
        }

        Form_Main _fmain = null;
        SqlConnection connection;
        SqlCommand command;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void chechempty()
        {
            
            if (textBox1.Text == "")
            {
                label9.Text = "*";
                label9.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label9.Text = "";
            }
            if (textBox2.Text == "")
            {
                label10.Text = "*";
                label10.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label10.Text = "";
            }
            if (textBox3.Text == "")
            {
                label11.Text = "*";
                label11.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label11.Text = "";
            }
            if (textBox4.Text == "")
            {
                label12.Text = "*";
                label12.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label12.Text = "";
            }
            if (textBox5.Text == "")
            {
                label13.Text = "*";
                label13.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label13.Text = "";
            }
            if (textBox6.Text == "")
            {
                label14.Text = "*";
                label14.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label14.Text = "";
            }
            if (textBox7.Text == "")
            {
                label15.Text = "*";
                label15.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label15.Text = "";
            }
            if(radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                label19.Text = "*";
                label19.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label19.Text = "";
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
        }
        private void Button2_Click(object sender, EventArgs e)
        {
           
            chechempty();
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && label16.Text == "รหัสผ่านตรงกัน" && label17.Text == "สามารถใช้งานได้" && (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
            {
                radiocheck();
                MessageBox.Show("ลงทะเบียนเสร็จเรียบร้อย");
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                connection.Open(); 
                command = new SqlCommand ("INSERT INTO TBInformations (IFuser,IFpass,IFfname,IFlname,IFphone,IFmail,IFsex,IFbirthday)VALUES(@IFuser,@IFpass,@IFfname,@IFlname,@IFphone,@IFmail,@IFsex,@IFbirthday)",connection);
                
                command.Parameters.Add(new SqlParameter("@IFuser", textBox3.Text));
                command.Parameters.Add(new SqlParameter("@IFpass", textBox6.Text));
                command.Parameters.Add(new SqlParameter("@IFfname", textBox1.Text));
                command.Parameters.Add(new SqlParameter("@IFlname", textBox2.Text));
                command.Parameters.Add(new SqlParameter("@IFphone", textBox4.Text));
                command.Parameters.Add(new SqlParameter("@IFmail", textBox5.Text));
                command.Parameters.Add(new SqlParameter("@IFsex", SEX));
                command.Parameters.Add(new SqlParameter("@IFbirthday", dateTimePicker1.Value.Date));
                command.ExecuteNonQuery();

                selectData();
                //dataGridView1.DataSource = dataSt.Tables["Regis"];
                
                this.Hide();
                if (_fmain != null)
                {
                    Form_Main fm = new Form_Main("");
                    _fmain.Close();
                    _fmain = null;
                    fm.Show();
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้องและครบถ้วน","การสมัครสมาชิกใหม่",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private DataSet dataSt;

        private void selectData()
        {
            String sql = "SELECT *FROM TBInformations";
            SqlCommand command = new SqlCommand(sql,connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            dataSt = new DataSet();
            adapter.Fill(dataSt, "Regis");

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox6.UseSystemPasswordChar = false;
                textBox7.UseSystemPasswordChar = false;
            }
            else
            {
                textBox6.UseSystemPasswordChar = true;
                textBox7.UseSystemPasswordChar = true;
            }
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == textBox7.Text && textBox6.Text != "")
            {
                label16.Text = "รหัสผ่านตรงกัน";
                label16.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label16.Text = "รหัสผ่านไม่ตรงกัน";
                label16.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text.Length > 4)
            {
                string sql = "SELECT *FROM TBInformations WHERE IFuser ='" + textBox3.Text + "'";
                connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader rd = command.ExecuteReader();
                if (rd.Read())
                {
                    label17.Text = "ไม่สามารถใช้งานได้";
                    label17.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label17.Text = "สามารถใช้งานได้";
                    label17.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                label17.Text = "กรอกข้อมูลมากกว่า 4 ตัว";
                label17.ForeColor = System.Drawing.Color.Red;
            }
            
        }

        private void Form_Register_Load(object sender, EventArgs e)
        {
            string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";

            connection = new SqlConnection(conStr);
            connection.Open();
            selectData();

            //dataGridView1.DataSource = dataSt.Tables["Regis"];
        }
    }
}
