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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAPN,MAHANG,NGAYNHAP from dbo.PHIEUNHAP ", con);
            cmd.Parameters.AddWithValue("MAPN", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        SqlCommand cmd;
        SqlDataAdapter adapt;
        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from dbo.PHIEUNHAP", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                //SqlCommand cmd = new SqlCommand("insert into dbo.HANGHOA values (@MAHANG,@TENHANG,@NGAYSX,@NGAYHH,@MANCC)", con);
                //cmd.Parameters.AddWithValue("@MAHANG", textBox1.Text);
                //cmd.Parameters.AddWithValue("@TENHANG", textBox2.Text);
                //cmd.Parameters.AddWithValue("@NGAYSX", dateTimePicker1.Value.ToString());
                //cmd.Parameters.AddWithValue("@NGAYHH", dateTimePicker2.Value.ToString());
                //cmd.Parameters.AddWithValue("@MAHANG", textBox3.Text);
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy/MM/dd";

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.PHIEUNHAP(MAPN,MAHANG,NGAYNHAP) values('" + textBox1.Text + "','" + textBox2.Text + "')";

                cmd.ExecuteNonQuery();

                con.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete dbo.PHIEUNHAP where MAPN=@MAPN", con);
                cmd.Parameters.AddWithValue("@MAPN", textBox1.Text);
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
                SqlCommand cmd = new SqlCommand("Update dbo.PHIEUNHAP set  MAHANG=@MAHANG,NGAYNHAP=@NGAYNHAP where MAPN=@MAPN", con);
                cmd.Parameters.AddWithValue("@MAPN", textBox1.Text);
                cmd.Parameters.AddWithValue("@MAHANG", textBox2.Text);
                cmd.Parameters.AddWithValue("@NGAYNHAP", dateTimePicker1.Value.ToString());
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

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 fr = new Form1();
            //fr.ShowDialog();
            //this.Close();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAPN,MAHANG,NGAYNHAP from dbo.PHIEUNHAP where MAPN like'%" + textBox3.Text + "%' ", con);
            cmd.Parameters.AddWithValue("MAPN", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
