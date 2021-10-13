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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Chi nhánh chính")
            {
                Form4 fr = new Form4() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MANV,TENNV,GIOITINH,DCHI,SDT,MACN from dbo.NHANVIEN", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }
            else if (label3.Text == "Chi nhánh 1")
            {
                Form4 fr = new Form4() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KH;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MANV,TENNV,GIOITINH,DCHI,SDT,MACN from dbo.NHANVIEN", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }
            else
            {
                Form4 fr = new Form4() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER2;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MANV,TENNV,GIOITINH,DCHI,SDT,MACN from dbo.NHANVIEN", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }
            
            
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            if (label3.Text == "Chi nhánh chính")
            {
                Form2 fr = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC from HANGHOA", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }
            else if (label3.Text == "Chi nhánh 1")
            {
                Form2 fr = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KH;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC from HANGHOA", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }
            if (label3.Text == "Chi nhánh 2")
            {
                Form2 fr = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER2;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("select MAHANG,TENHANG,NGAYSX,NGAYHH,MANCC from HANGHOA", con);
                cmd.Parameters.AddWithValue("MANV", fr.textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                fr.dataGridView1.DataSource = dt;
                this.panel2.Controls.Clear();
                this.panel2.Controls.Add(fr);
                fr.Show();
            }

            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Form3 fr = new Form3() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Form7 fr = new Form7() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Form6 fr = new Form6() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            this.Close();
            Login lg = new Login();
            lg.Show();
        }

        
    }
}
