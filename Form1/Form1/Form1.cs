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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //using(SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012"))
            //{
            //    con.Open();
            //    using (IDbCommand spCommand = con.CreateCommand())
            //    {
            //        spCommand.CommandText = "sp_KiemTraMaNhanVienTonTai";
            //        spCommand.CommandText = System.Data.CommandType.StoredProcedure.ToString();

            //        IDbDataParameter manvIdParameter = spCommand.CreateParameter();
            //        //textBox1.Text = "@MANV";
            //        manvIdParameter.ParameterName = "@MANV";
            //        manvIdParameter.Value = textBox1.ToString();
            //        spCommand.Parameters.Add(manvIdParameter);
            //        spCommand.ExecuteNonQuery();
            //        if (manvIdParameter.Value.ToString() == "1")
            //        {
            //            MessageBox.Show("Đã có nhân viên này!");
            //        }
            //        else
            //        { MessageBox.Show("Thanh cong"); }
            //    }
            //}

            //SqlConnection conn = null;
            //SqlDataReader rdr = null;

            //conn = new SqlConnection("Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            //conn.Open();
            //SqlCommand cmd = new SqlCommand("sp_KiemTraMaNhanVienTonTai", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //IDbCommand spCommand = conn.CreateCommand();



            //IDbDataParameter manvIdParameter = spCommand.CreateParameter();
            
            //manvIdParameter.ParameterName = "@MANV";
            //manvIdParameter.Value = textBox1.ToString();
            //spCommand.Parameters.Add(manvIdParameter);
            //rdr = cmd.ExecuteReader();

            
            //spCommand.ExecuteNonQuery();
            
            //using(SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012"))
            //{
            //    con.Open();
            //    using(IDbCommand spCommand=con.CreateCommand())
            //    {
            //        spCommand.CommandText = "sp_KiemTraMaNhanVienTonTai";
            //        spCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //        IDbDataParameter manvParameter = spCommand.CreateParameter();
            //        manvParameter.ParameterName = "@MANV";
            //        manvParameter.Value = "NV1";
            //        spCommand.Parameters.Add(manvParameter);

            //    }
            //}
            
            
            
            
        }

        SqlCommand cmd;
        SqlDataAdapter adapt;
        
        private void button1_Click(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012"))
            //{
            //    con.Open();
            //    using (IDbCommand spCommand = con.CreateCommand())
            //    {
            //        spCommand.CommandText = "sp_KiemTraMaNhanVienTonTai";
            //        spCommand.CommandType = System.Data.CommandType.StoredProcedure;

            //        IDbDataParameter manvParameter = spCommand.CreateParameter();
            //        manvParameter.ParameterName = "@MANV";
            //        manvParameter.Value = "NV1";
            //        spCommand.Parameters.Add(manvParameter);
                    
            //        spCommand.ExecuteNonQuery();


                    //if(manvParameter.Value=="1")
                    //{
                    //    MessageBox.Show("Ma nhan vien ton tai!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Mã nhân viên không tồn tại!");
                    //}

            if(comboBox1.Text=="CN1" && textBox1.Text=="admin")
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER1;Initial Catalog=QL_KHOHANG;Persist Security Info=True;User ID=sa;Password=sa2012");
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select MANV, TENNV from NHANVIEN", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                
                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("select * from dbo.KHO", con);
                adapt.Fill(dt2);
                dataGridView2.DataSource = dt2;
                con.Close();
                label1.Text = "Nhân viên theo chi nhánh 1";
                label2.Text = "Kho theo chi nhánh 1";
                
            }
            else if (comboBox1.Text == "CN2" && textBox1.Text == "admin")
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8\MSSQLSERVER2;Initial Catalog=QL_KHOHANG;Persist Security Info=True;User ID=sa;Password=sa2012");
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select MANV, TENNV from NHANVIEN", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;

                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("select * from dbo.KHO", con);
                adapt.Fill(dt2);
                dataGridView2.DataSource = dt2;
                con.Close();
                label1.Text = "Nhân viên theo chi nhánh 2";
                label2.Text = "Kho theo chi nhánh 2";
            }
            else if (comboBox1.Text == "ALL" && textBox1.Text == "admin")
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select MANV, TENNV from NHANVIEN", con);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;

                DataTable dt2 = new DataTable();
                adapt = new SqlDataAdapter("select * from dbo.KHO", con);
                adapt.Fill(dt2);
                dataGridView2.DataSource = dt2;
                con.Close();
                label1.Text = "Nhân viên ";
                label2.Text = "Kho ";
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Nhập mật khhẩu!");
            }
            else { MessageBox.Show("Sai mật khẩu!"); }

                }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fr = new Form4();
            fr.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fr = new Form5();
            fr.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr = new Form3();
            fr.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fr = new Form2();
            fr.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 fr = new Form7();
            fr.ShowDialog();
            this.Close();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fr = new Form6();
            fr.ShowDialog();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(comboBox2.Text=="CN1")
            {
                foreach (Form1 fr in Application.OpenForms.OfType<Form1>())
                {
                    fr.label7.Text = "CN1";
                }
            }
        }
            }
        }
    

