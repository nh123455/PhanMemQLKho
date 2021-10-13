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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;Persist Security Info=True;User ID=sa;Password=sa2012");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from TaiKhoan where Tk='" + textBox1.Text + "'and Mk='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "admin")
            {
                
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh chính";
                
            }
            else if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "CN1")
            {
                Menu menu = new Menu();
                Form2 fr2 = new Form2();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh 1"; ;
                

            }
            else if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "CN2")
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh 2";
            }
            else
            {
                MessageBox.Show("Sai tài khoản mật khẩu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E9MJJFD8;Initial Catalog=QL_KHOHANG;Persist Security Info=True;User ID=sa;Password=sa2012");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from TaiKhoan where Tk='" + textBox1.Text + "'and Mk='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "admin")
            {

                Menu menu = new Menu();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh chính";

            }
            else if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "CN1")
            {
                Menu menu = new Menu();
                Form2 fr2 = new Form2();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh 1"; ;


            }
            else if (dt.Rows[0][0].ToString() == "1" & textBox1.Text == "CN2")
            {
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
                menu.label3.Text = "Chi nhánh 2";
            }
            else
            {
                MessageBox.Show("Sai tài khoản mật khẩu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification);
            }
        }
    }
}
