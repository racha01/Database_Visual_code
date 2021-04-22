using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class statmant : Form
    {
        public statmant(){
            InitializeComponent();

            CB_type.Items.Add("ทั้งหมด");
            CB_type.Items.Add("รายการฝากถอน");
            CB_type.Items.Add("รายการโอนเงิน");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT ID, Branch, Date_time,Deposit,Withdraw FROM deorwit WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY ID, Branch, Date_time,Deposit,Withdraw, Balance";
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView_stat.DataSource = ds.Tables[0].DefaultView;
                con.Close();
            }
            catch{
                MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");}  
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();}
        private void TB_accountnum_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.ID = '" + TB_accountnum.Text + "' GROUP BY A.Branch";
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CB_branch.Items.Add(reader.GetString("Branch"));
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {                                     
            if(CB_type.Text == "ทั้งหมด")
            {
                try
                {
                    string sql = "SELECT ID, Branch, Date_time,Deposit,Withdraw FROM deorwit WHERE (ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY ID, Branch, Date_time,Deposit,Withdraw, Balance";
                    //sql = "DELETE FROM instructor WHERE name = '"+textBox2.Text+"'";
                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();

                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    dataGridView_stat.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
            else if (CB_type.Text == "รายการฝากถอน")
            {
                try
                {
                    string sql = "SELECT ID, Branch, Date_time,Deposit,Withdraw FROM deorwit WHERE Statusacc != 'transfer'  AND(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY ID, Branch, Date_time,Deposit,Withdraw, Balance";
                    //sql = "DELETE FROM instructor WHERE name = '"+textBox2.Text+"'";
                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();

                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    dataGridView_stat.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
            else if (CB_type.Text == "รายการโอนเงิน")
            {
                try
                {
                    string sql = "SELECT ID, Branch, Date_time,Deposit,Withdraw FROM deorwit WHERE Statusacc = 'transfer'  AND(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY ID, Branch, Date_time,Deposit,Withdraw, Balance";
                    //sql = "DELETE FROM instructor WHERE name = '"+textBox2.Text+"'";
                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();

                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    dataGridView_stat.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
            
        }
        private void guna2Button4_Click(object sender, EventArgs e){
            this.Dispose();}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
