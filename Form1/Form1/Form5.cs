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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAKHO,TENKHO,DCHI,MACN from dbo.KHO ", con);
            cmd.Parameters.AddWithValue("MAKHO", textBox1.Text);
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
            adapt = new SqlDataAdapter("select * from dbo.KHO", con);
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
                cmd.CommandText = "insert into dbo.KHO(MAKHO,TENKHO,DCHI,MACN) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                dataGridView1.Refresh();
                DisplayData();
                ClearData();
            }
            catch(Exception)
            {
                MessageBox.Show("Thêm không thành công!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete dbo.KHO where MAKHO=@MAKHO", con);
                cmd.Parameters.AddWithValue("@MAKHO", textBox1.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thành công !");
                DisplayData();
                ClearData();
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update dbo.KHO set  TENKHO=@TENKHO,DCHI=@DCHI,MACN=@MACN where MAKHO=@MAKHO", con);
                cmd.Parameters.AddWithValue("@MAKHO", textBox1.Text);
                cmd.Parameters.AddWithValue("@TENKHO", textBox2.Text);
                cmd.Parameters.AddWithValue("@DCHI", textBox3.Text);
                cmd.Parameters.AddWithValue("@MACN", textBox3.Text);

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
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form1 fr = new Form1();
            //fr.ShowDialog();
            //this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;User ID=sa;Password=sa2012");
            con.Open();
            SqlCommand cmd = new SqlCommand("select MAKHO,TENKHO,DCHI,MACN from dbo.KHO where TENKHO like'%" + textBox5.Text + "%' ", con);
            cmd.Parameters.AddWithValue("MAKHO", textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

    }
}
