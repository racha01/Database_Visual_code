using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class total : Form
    {
        public total(){
            InitializeComponent();}
        private void T_cancel_Click(object sender, EventArgs e){
            this.Dispose();}
        private void T_search_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                TB_balance.Text = reader.GetString("Balance");
                con.Close();
            }
            catch
            {
                MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");}
        }
        private void T_ID_TextChanged(object sender, EventArgs e)
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
        private void button1_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd = new MySqlCommand(sql, con);

                con.Open();
                MySqlDataReader reader_ba = cmd.ExecuteReader();
                reader_ba.Read();
                //TB_balance.Text = reader.GetString("Balance");
                //con.Close();

                string sql_up = "UPDATE account_id SET Balances = '" + reader_ba.GetString("Balance") + "' WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
                MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);


                con_up.Open();
                cmd_up.ExecuteNonQuery();
                con_up.Close();
                //#########################################################
                string sql_r = "SELECT Balances FROM `account_id` WHERE(ID, Branch) = ('"+TB_accountnum.Text+"', '"+CB_branch.Text+"')";
                MySqlConnection con_r = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd_r = new MySqlCommand(sql_r, con_r);

                con_r.Open();
                MySqlDataReader reader_r = cmd_r.ExecuteReader();
                reader_r.Read();
                TB_balance.Text = reader_r.GetString("Balances");
                con_r.Close();

                //#########################################################
            }
            catch
            {
                label5.Text = "ไม่มีเลขบัญชีนี้ในระบบ";
            }
        }
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
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Dispose();}
        private void guna2Button3_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
