using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Expense
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetToInc();
            GetToExp();
            GetNumExp();
            GetNumInc();
            GetIncLDate();
            GetExpLDate();
            GetMaxInc();
            GetMaxExp();
            GetMinInc();
            GetMinExp();
            GetToBalance();
            GetMaxExpCat();
            GetMaxIncCat();

        }


        private void IncLbl_Click(object sender, EventArgs e)
        {
            Incomes obj = new Incomes();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expense obj = new Expense();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }
        /*
        SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");
        private void GetToInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'",Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               // Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotIncLbl.Text = "Rs " + dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
            }
        }*/
        SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");
        int Inc, Exp;
        private void GetToInc()
        {
          
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SUM(IncAmt) FROM IncomeTbl WHERE IncUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    Inc = Convert.ToInt32(result.ToString());
                    TotIncLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    TotIncLbl.Text = "Rs 0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
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
                    Exp = Convert.ToInt32(result.ToString());
                    TotExpLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    TotExpLbl.Text = "Rs 0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetNumExp()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM ExpenseTbl WHERE ExpUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    NumExpLbl.Text =  result.ToString();
                }
                else
                {
                    NumExpLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetNumInc()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM IncomeTbl WHERE IncUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    NumIncLbl.Text = result.ToString();
                }
                else
                {
                    NumIncLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetIncLDate()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Max(IncDate) FROM IncomeTbl WHERE IncUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();
                DateIncLbl.Text = result.ToString();
                DateIncLbl1.Text = result.ToString();

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetExpLDate()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Max(ExpDate) FROM ExpenseTbl WHERE ExpUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();
                DateExpLbl.Text = result.ToString();
                DateExpLbl1.Text = result.ToString();

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetMaxInc()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Max(IncAmt) FROM IncomeTbl WHERE IncUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    MaxIncLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    MaxIncLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetMaxExp()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Max(ExpAmt) FROM ExpenseTbl WHERE ExpUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    MaxExpLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    MaxExpLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetMinInc()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Min(IncAmt) FROM IncomeTbl WHERE IncUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    MinIncLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    MinIncLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }
        private void GetMinExp()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Min(ExpAmt) FROM ExpenseTbl WHERE ExpUser = @User", Con);
                cmd.Parameters.AddWithValue("@User", login.User);

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    MinExpLbl.Text = "Rs " + result.ToString();
                }
                else
                {
                    MinExpLbl.Text = "0";
                }

                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }

        private void GetToBalance()
        {

            double Bal = Inc - Exp;
            BalanceLbl.Text = "Rs " + Bal;
        }

        private void GetMaxExpCat()
        {
            try
            {
                Con.Open();
                string InnerQuery = "select MAX(ExpAmt) from ExpenseTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                string Query = "select ExpCat from ExpenseTbl where ExpAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt); 
                BestExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
                // Handle the exception, e.g., log it or show an error message.
            }
        }

        private void GetMaxIncCat()
        {
            try
            {
                Con.Open();
                string InnerQuery = "select MAX(IncAmt) from IncomeTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                string Query = "select IncCat from IncomeTbl where IncAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt); 
                BestIncLbl.Text = dt.Rows[0][0].ToString();
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

     
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
