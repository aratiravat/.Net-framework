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
    public partial class Incomes : Form
    {
        public Incomes()
        {
            InitializeComponent();
            GetToInc();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MRSILENT\SQLEXPRESS;Initial Catalog=FinanceDb;Integrated Security=True");

        private void Clear()
        {
            IncNameTb.Text = "";
            IncAmtTb.Text = "";
            IncDescTb.Text = "";
            CatCb.SelectedIndex = 0;


        }
        private void Savebtn_Click(object sender, EventArgs e)
        {


            if (IncNameTb.Text == "" || IncAmtTb.Text == "" || IncDescTb.Text == "" || CatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Info.");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName,IncAmt,IncCat, IncDate,IncDesc,IncUser) values (@IN, @IA,@IC, @ID, @IDe,@IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", IncNameTb.Text);
                    cmd.Parameters.AddWithValue("@IA", IncAmtTb.Text);
                    cmd.Parameters.AddWithValue("@IC", CatCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", IncDate.Value.Date);
                    cmd.Parameters.AddWithValue("@IDe", IncDescTb.Text);
                    cmd.Parameters.AddWithValue("@IU", login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income added...");
                    Con.Close();
                    GetToInc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

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
                   // Inc = Convert.ToInt32(result.ToString());
                    TotInc.Text = "Rs " + result.ToString();
                }
                else
                {
                    TotInc.Text = "Rs 0";
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
