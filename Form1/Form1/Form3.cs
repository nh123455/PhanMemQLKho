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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MANCC,TENNCC,SDT  from dbo.NHACC ", con);
            cmd.Parameters.AddWithValue("MANCC", textBox1.Text);
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
            adapt = new SqlDataAdapter("select * from dbo.NHACC ", con);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.NHACC(MANCC,TENNCC,SDT) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete dbo.NHACC where MANCC=@MANCC", con);
                cmd.Parameters.AddWithValue("@MANCC", textBox1.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                DisplayData();
                ClearData();
            }catch(Exception)
            { MessageBox.Show("Thất bại!"); }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update dbo.NHACC set  TENNCC=@TENNCC,SDT=@SDT where MANCC=@MANCC", con);
                cmd.Parameters.AddWithValue("@MANCC", textBox1.Text);
                cmd.Parameters.AddWithValue("@TENNCC", textBox2.Text);
                cmd.Parameters.AddWithValue("@SDT", textBox3.Text);
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
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 fr = new Form1();
            //fr.ShowDialog();
            //this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MANCC,TENNCC,SDT from dbo.NHACC where TENNCC like'%" + textBox4.Text + "%' ", con);
            cmd.Parameters.AddWithValue("MANCC", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
