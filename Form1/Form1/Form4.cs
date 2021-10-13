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
namespace Form1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        
        private void Form4_Load(object sender, EventArgs e)
        {


            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select *from dbo.NHANVIEN  ", con);
            //cmd.Parameters.AddWithValue("MANV", textBox1.Text);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
              
        }
        SqlCommand cmd;
        SqlDataAdapter adapt;
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.NHANVIEN", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        SqlDataAdapter adapt2;
        private void DisplayData2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            DataTable dt = new DataTable();
            adapt2 = new SqlDataAdapter("select * from dbo.NHANVIEN", con);
            adapt2.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        SqlDataAdapter adapt3;
        private void DisplayData3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER2;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            DataTable dt = new DataTable();
            adapt3 = new SqlDataAdapter("select * from dbo.NHANVIEN", con);
            adapt3.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.NHANVIEN(MANV,TENNV,GIOITINH,DCHI,SDT,MACN) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                dataGridView1.Refresh();
                if (label3.Text == "Chi nhánh chính")
                {
                    DisplayData();
                }
                else if (label3.Text == "Chi nhánh 1")
                {
                    DisplayData2();
                }
                else
                {
                    DisplayData3();
                }
                
                ClearData();
               
            
            

            
        }

        
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete dbo.NHANVIEN where MANV=@MANV", con);
            cmd.Parameters.AddWithValue("@MANV", textBox1.Text);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Thành công !");


            if (label3.Text == "Chi nhánh chính")
            {
                DisplayData();
            }
            else if (label3.Text == "Chi nhánh 1")
            {
                DisplayData2();
            }
            else
            {
                DisplayData3();
            }

            ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update dbo.NHANVIEN set  TENNV=@TENNV,GIOITINH=@GIOITINH,DCHI=@DCHI,SDT=@SDT,MACN=@MACN where MANV=@MANV", con);
                cmd.Parameters.AddWithValue("@MANV", textBox1.Text);
                cmd.Parameters.AddWithValue("@TENNV", textBox2.Text);
                cmd.Parameters.AddWithValue("@GIOITINH", textBox3.Text);
                cmd.Parameters.AddWithValue("@DCHI", textBox4.Text);
                cmd.Parameters.AddWithValue("@SDT", textBox5.Text);
                cmd.Parameters.AddWithValue("@MACN", textBox6.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                DisplayData();
                ClearData();
            }catch(Exception)
            {
                MessageBox.Show("Thất bại!");
            }
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 fr = new Form1();
            //fr.ShowDialog();
            //this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MANV,TENNV,GIOITINH ,DCHI,SDT,MACN from dbo.NHANVIEN where TENNV like'%"+textBox7.Text+"%' ", con);
            cmd.Parameters.AddWithValue("MANV", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        

        

    }
}
