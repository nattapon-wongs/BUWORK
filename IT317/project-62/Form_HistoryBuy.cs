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
    public partial class Form_HistoryBuy : Form
    {
        public Form_HistoryBuy(string iduser,string idinv)
        {
            InitializeComponent();
            label10.Text = idinv;
            label18.Text = iduser;
        }

        private void Form_HistoryBuy_Activated(object sender, EventArgs e)
        {
            int a = 1;
            string sql = "SELECT Invno,Invdate,DiscountInv,Subtotal,TotalPrice,Itemno,Quantity,Priceitem,PRO_NAME,PRO_PRICE FROM Invoice INNER JOIN Invoiceitem ON Invno = Invnoitem INNER JOIN Table_Product ON Itemno = PRO_ID WHERE  Custid = '"+label18.Text+"' AND Invno = '"+ label10.Text+"'";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            
            while(rd.Read())
            {
                listBox1.Items.Add(rd["Itemno"]);
                listBox2.Items.Add(rd["Priceitem"]);
                listBox3.Items.Add(rd["PRO_NAME"]);
                listBox4.Items.Add(rd["Quantity"]);
                listBox5.Items.Add(rd["PRO_PRICE"]);
                listBox6.Items.Add(a++);
                label20.Text = rd["Invdate"].ToString();
                label6.Text = rd["Subtotal"].ToString();
                label5.Text = rd["DiscountInv"].ToString();
                label4.Text = rd["TotalPrice"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
