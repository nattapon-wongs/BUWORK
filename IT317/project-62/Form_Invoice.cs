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
    public partial class Form_Invoice : Form
    {
        public Form_Invoice()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection connection;
        SqlCommand command;
        int sum =0;
        Form_Main fm = new Form_Main("");
        private void Form_Invoice_Load(object sender, EventArgs e)
        {
            int a;
            string sql = "SELECT MAX(Invno) FROM Invoice";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if(rd.Read())
            {
                string val = rd[0].ToString();
                if(val == "")
                {
                    label10.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(rd[0].ToString());
                    a = a + 1;
                    label10.Text = a.ToString() ;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                DateTime today = DateTime.Now.Date;
                
                string sql = "SELECT * FROM Promotion  WHERE PCode = '" + textBox1.Text + "'";
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    if(today < Convert.ToDateTime(rd["Deadline"].ToString()))
                    {
                        if (Convert.ToInt32(label6.Text) >= Convert.ToInt32(rd["Min"].ToString()))
                        {
                            label5.Text = rd["Discount"].ToString();
                            MessageBox.Show(" สามารถใช้ส่วนลดได้ ");
                            label4.Text = Convert.ToString(Convert.ToInt32(label6.Text) - Convert.ToInt32(label5.Text));
                        }
                        else
                        {
                            MessageBox.Show(" ไม่สามารถใช้ส่วนลดได้ ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" โค้ดส่วนลดหมดอายุแล้ว ");
                    }
                }
            }
            else
            {
                MessageBox.Show(" กรุณากรอกโค้ดส่วนลด ");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            textBox1.Text = "";
        }
        int a ;
        private void Button1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            connection.Open();
            command = new SqlCommand("INSERT INTO Invoice (Invno,Custid,Invdate,DiscountInv,Subtotal,TotalPrice,AmountBook)VALUES(@Invno,@Custid,@Invdate,@DiscountInv,@Subtotal,@TotalPrice,@AmountBook)", connection);
            command.Parameters.Add(new SqlParameter("@Invno", label10.Text));
            command.Parameters.Add(new SqlParameter("@Custid", label18.Text));
            command.Parameters.Add(new SqlParameter("@Invdate", label20.Text));
            command.Parameters.Add(new SqlParameter("@DiscountInv", label5.Text));
            command.Parameters.Add(new SqlParameter("@Subtotal", label6.Text));
            command.Parameters.Add(new SqlParameter("@TotalPrice", label4.Text));
            command.Parameters.Add(new SqlParameter("@AmountBook", listBox1.Items.Count));
            command.ExecuteNonQuery();
            command.Parameters.Clear();

            command = new SqlCommand("SELECT MAX(no) FROM Invoiceitem", connection);
            SqlDataReader rd;
            rd = command.ExecuteReader();
            if(rd.Read())
            {
                
                string val = rd[0].ToString();
                if (val == "")
                {
                    a = 1;
                }
                else
                {
                    a = Convert.ToInt32(rd[0].ToString());
                    a = a + 1;
                }
            }
            
            
            for(int i=0;i< listBox1.Items.Count;i++)
            {
                connection.Close();
                connection.Open();
                command.Parameters.Clear();
                command = new SqlCommand("INSERT INTO Invoiceitem (no,Invnoitem,Itemno,Quantity,Priceitem)VALUES(@no,@Invnoitem,@Itemno,@Quantity,@Priceitem)", connection);
                command.Parameters.Add(new SqlParameter("no", a++));
                command.Parameters.Add(new SqlParameter("Invnoitem", label10.Text));
                command.Parameters.Add(new SqlParameter("Itemno", listBox1.Items[i].ToString()));
                command.Parameters.Add(new SqlParameter("Quantity",Convert.ToInt32(listBox4.Items[i].ToString())));
                command.Parameters.Add(new SqlParameter("Priceitem", listBox2.Items[i].ToString()));
                
                command.ExecuteNonQuery();
            }

            //command.Parameters.Clear();
            MessageBox.Show("ชำระเงินเรียบร้อย","Book shop");
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            label4.Text = "0";
            label5.Text = "0";
            label6.Text = "0";
            textBox1.Text = "";
            this.Hide();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void Form_Invoice_Activated(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
            label20.Text = Convert.ToString(today.ToString("dd-MM-yyyy"));
            sum = 0;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                sum = sum + Convert.ToInt32(listBox2.Items[i].ToString());
            }
            label6.Text = Convert.ToString(sum);
            label4.Text = Convert.ToString(Convert.ToInt32(label6.Text) - Convert.ToInt32(label5.Text));
        }

        private void Form_Invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
