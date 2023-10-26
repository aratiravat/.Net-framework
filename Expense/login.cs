using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Expense
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();

        }

        /*SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");
        public static string User;
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter both Username and Password.");
            }
            else
            {

                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from UserTbl where UName= ' " + UNameTb.Text + " ' and UPass= ' " + PasswordTb.Text + " ' ", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UNameTb.Text;
                    Dashboard Obj = new Dashboard();
                    Obj.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password!!!");
                    UNameTb.Text = "";
                    PasswordTb.Text = "";
                }
                Con.Close();
            }
        }*/
        SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");
        public static string User;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter both Username and Password.");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM UserTbl WHERE UName = @Username AND UPass = @Password", Con);
                sda.SelectCommand.Parameters.AddWithValue("@Username", UNameTb.Text);
                sda.SelectCommand.Parameters.AddWithValue("@Password", PasswordTb.Text);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UNameTb.Text;
                    Dashboard Obj = new Dashboard();
                    Obj.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password!!!");
                    UNameTb.Text = "";
                    PasswordTb.Text = "";
                }

                Con.Close();
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
