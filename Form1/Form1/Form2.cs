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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC from HANGHOA ", con);
            //cmd.Parameters.AddWithValue("MAHANG", textBox1.Text);
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
            adapt = new SqlDataAdapter("select * from dbo.HANGHOA", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
               // SqlCommand cmd = new SqlCommand("insert into dbo.HANGHOA values (@MAHANG,@TENHANG,@NGAYSX,@NGAYHH,@MANCC)", con);
                //cmd.Parameters.AddWithValue("@MAHANG", textBox1.Text);
                //cmd.Parameters.AddWithValue("@TENHANG", textBox2.Text);
                //cmd.Parameters.AddWithValue("@NGAYSX", dateTimePicker1.Value.ToString());
                //cmd.Parameters.AddWithValue("@NGAYHH", dateTimePicker2.Value.ToString());
                //cmd.Parameters.AddWithValue("@MAHANG", textBox3.Text);
                //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                //dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                //dateTimePicker2.Format = DateTimePickerFormat.Custom;
                //dateTimePicker2.CustomFormat = "yyyy/MM/dd";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.HANGHOA(MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "','" + textBox3.Text + "')";

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                dataGridView1.Refresh();
                DisplayData();
                ClearData();
            }catch(Exception)
            {
                MessageBox.Show("Thêm không thành công!");
            }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete dbo.HANGHOA where MAHANG=@MAHANG", con);
                cmd.Parameters.AddWithValue("@MAHANG", textBox1.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update dbo.HANGHOA set  TENHANG=@TENHHANG,NGAYSX=@NGAYSX,NGAYHH=@NGAYHH,MANCC=@MANCC where MAHANG=@MAHANG", con);
                cmd.Parameters.AddWithValue("@MAHANG", textBox1.Text);
                cmd.Parameters.AddWithValue("@TENHANG", textBox2.Text);
                cmd.Parameters.AddWithValue("@NGAYSX", dateTimePicker1.Value.ToString());
                cmd.Parameters.AddWithValue("@NGAYSX", dateTimePicker2.Value.ToString());
                cmd.Parameters.AddWithValue("@MANCC", textBox3.Text);
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
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 fr = new Form1();
            //fr.ShowDialog();
            //this.Close();
        }

        private void connect_CN1(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KH;Persist Security Info=True;User ID=sa;Password=***********");
                con1.Open();
                
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "yyyy/MM/dd";
                SqlCommand cmd = con1.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.HANGHOA(MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString() + "','" + dateTimePicker2.Value.ToString() + "','" + textBox3.Text + "')";

                cmd.ExecuteNonQuery();

                con1.Close();
                MessageBox.Show("Thành công !");
                dataGridView1.Refresh();
                DisplayData();
                ClearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công!");
            }
        }
        private void connect_CN2(object sender, EventArgs e)
        {

        }
        private void connect_ALL(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC from dbo.HANGHOA where TENHANG like'%" +textBox4.Text + "%' ", con);
            cmd.Parameters.AddWithValue("MAHANG", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
