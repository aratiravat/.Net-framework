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
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
            GetToExp();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");

        private void Clear()
        {
            ExpNameTb.Text = "";
            ExpAmtTb.Text = "";
            ExpDescTb.Text = "";
            CatCb.SelectedIndex = 0;


        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if (ExpNameTb.Text == "" || ExpAmtTb.Text == "" || ExpDescTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpenseTbl(ExpName,ExpAmt,ExpCat, ExpDate,ExpDesc,ExpUser) values (@EN, @EA,@EC, @ED, @EDe,@EU)", Con);
                    cmd.Parameters.AddWithValue("@EN", ExpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", ExpAmtTb.Text);
                    cmd.Parameters.AddWithValue("@EC", CatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", ExpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EDe", ExpDescTb.Text);
                    cmd.Parameters.AddWithValue("@EU", login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expense added...");
                    Con.Close();
                    GetToExp();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Incomes obj = new Incomes();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           ViewIncomes obj = new ViewIncomes();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses obj = new ViewExpenses();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expense obj = new Expense();
            obj.Show();
            this.Hide();
        }
        private void GetToExp()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(ExpAmt) FROM ExpenseTbl WHERE ExpUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                   // Exp = Convert.ToInt32(result.ToString());
                    TotExp.Text = "Rs " + result.ToString();
                }
                else
                {
                    TotExp.Text = "Rs 0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
