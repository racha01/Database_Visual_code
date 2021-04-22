using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class deorwit : Form
    {
        public deorwit(){
            InitializeComponent();

            timer1.Start();
            TB_timer.Text = "" + DateTime.Now + "";

            CB_dewit.Items.Add("ฝาก");
            CB_dewit.Items.Add("ถอน");

        }
        private void TB_accountnum_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '"+TB_accountnum.Text+"' GROUP BY A.Branch";
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CB_branch.Items.Add(reader.GetString("Branch"));
            }
        }
        private void button2_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button5_Click_1(object sender, EventArgs e){
            this.Dispose();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string sql_a = "SELECT ID FROM `account_id` WHERE 1";
            MySqlConnection con_a = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd_a = new MySqlCommand(sql_a, con_a);

            con_a.Open();
            MySqlDataReader reader_a = cmd_a.ExecuteReader();

            while (reader_a.Read())
            {
                if (TB_accountnum.Text == reader_a.GetString("ID"))
                {
                    if (CB_dewit.Text == "ฝาก")
                    {
                        try
                        {
                            string sql_b = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + TB_accountnum.Text + "' GROUP BY A.Branch";
                            MySqlConnection con_b = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                            MySqlCommand cmd_b = new MySqlCommand(sql_b, con_b);

                            con_b.Open();
                            MySqlDataReader reader = cmd_b.ExecuteReader();

                            while (reader.Read())
                            {
                                if (CB_branch.Text == reader.GetString("Branch"))
                                {
                                    //เพิ่มข้อมูลลงไปใน table deorwit
                                    string sql = "SELECT * FROM deorwit";
                                    sql = "INSERT INTO deorwit(ID, Branch, Date_time, Deposit, Balance) VALUES('" + TB_accountnum.Text + "', '" + CB_branch.Text + "','" + TB_timer.Text + "','" + TB_balance.Text + "', '" + Int64.Parse(TB_balance.Text) + "')";
                                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                    MySqlCommand cmd = new MySqlCommand(sql, con);

                                    con.Open(); cmd.ExecuteNonQuery(); /*คำสั่งเพิ่ม/ลบข้อมูล*/ con.Close();

                                    MessageBox.Show("ทำรายการเสร็จสิ้น");

                                    //ดึงข้อมูลยอดทั้งหมดของ บัญชีที่ทำการฝากเงินเข้ามา เพื่อนำไปใช้ในการ update ข้อมูลลงใน table account_id
                                    string sql_ba = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                                    MySqlConnection con_ba = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                    MySqlCommand cmd_ba = new MySqlCommand(sql_ba, con_ba);

                                    con_ba.Open();
                                    MySqlDataReader reader_ba = cmd_ba.ExecuteReader();
                                    reader_ba.Read();

                                    //update ยอด Balance ให้เป็นยอดปัจจุบันมื่อทำการฝากเงิน            /*ยอดเงินที่อ่านมาจากโค้ดด้านบน*/
                                    string sql_up = "UPDATE account_id SET Balances = '" + reader_ba.GetString("Balance") + "' WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
                                    MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                    MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);

                                    con_up.Open();
                                    cmd_up.ExecuteNonQuery();
                                    con_up.Close();

                                    //update Statusacc ให้เป็น deposit เมื่อทำการฝากเงิน
                                    string sql_upt1 = "UPDATE deorwit SET Statusacc = 'deposit' WHERE ID = '" + TB_accountnum.Text + "' And Branch = '" + CB_branch.Text + "' And Date_time = '" + TB_timer.Text + "'";
                                    MySqlConnection cont1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                    MySqlCommand cmd_upt1 = new MySqlCommand(sql_upt1, cont1);

                                    cont1.Open();
                                    cmd_upt1.ExecuteNonQuery();
                                    cont1.Close();

                                    this.Hide();
                                    var a = new customerstype();
                                    a.ShowDialog();
                                    this.Show();

                                    break;
                                }
                                else
                                {
                                    label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("ใส่จำนวนเงิน");
                        }
                    }
                    else if (CB_dewit.Text == "ถอน")
                    {
                        try
                        {
                            string sql_b = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + TB_accountnum.Text + "' GROUP BY A.Branch";
                            MySqlConnection con_b = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                            MySqlCommand cmd_b = new MySqlCommand(sql_b, con_b);

                            con_b.Open();
                            MySqlDataReader reader_b = cmd_b.ExecuteReader();

                            while (reader_b.Read())
                            {
                                if (CB_branch.Text == reader_b.GetString("Branch"))
                                {
                                    string sql1 = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                                    MySqlConnection con1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                    MySqlCommand cmd1 = new MySqlCommand(sql1, con1);

                                    con1.Open();
                                    MySqlDataReader reader = cmd1.ExecuteReader();
                                    reader.Read();

                                    Int64 balance = Int64.Parse(reader.GetString("Balance"));
                                    Int64 TB_bal = Int64.Parse("" + TB_balance.Text + "");

                                    if (TB_bal <= balance)
                                    {
                                        try
                                        {
                                            string sql = "SELECT * FROM deorwit";
                                            sql = "INSERT INTO deorwit(ID, Branch, Date_time, Withdraw, Balance) VALUES('" + TB_accountnum.Text + "', '" + CB_branch.Text + "','" + TB_timer.Text + "', '" + TB_balance.Text + "', '" + -Int64.Parse(TB_balance.Text) + "')";
                                            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                            MySqlCommand cmd = new MySqlCommand(sql, con);

                                            con.Open(); cmd.ExecuteNonQuery(); /*คำสั่งเพิ่ม/ลบข้อมูล*/ con.Close();

                                            MessageBox.Show("ทำรายการเสร็จสิ้น");
                                            /*this.Hide();
                                            var a = new customerstype();
                                            a.ShowDialog();
                                            this.Show();*/
                                            string sql_ba = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                                            MySqlConnection con_ba = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                            MySqlCommand cmd_ba = new MySqlCommand(sql_ba, con_ba);

                                            con_ba.Open();
                                            MySqlDataReader reader_ba = cmd_ba.ExecuteReader();
                                            reader_ba.Read();

                                            string sql_up = "UPDATE account_id SET Balances = '" + reader_ba.GetString("Balance") + "' WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
                                            MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                            MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);

                                            con_up.Open();
                                            cmd_up.ExecuteNonQuery();
                                            con_up.Close();

                                            string sql_upt1 = "UPDATE deorwit SET Statusacc = 'withdraw' WHERE ID = '" + TB_accountnum.Text + "' And Branch = '" + CB_branch.Text + "' And Date_time = '" + TB_timer.Text + "'";
                                            MySqlConnection cont1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                            MySqlCommand cmd_upt1 = new MySqlCommand(sql_upt1, cont1);

                                            cont1.Open();
                                            cmd_upt1.ExecuteNonQuery();
                                            cont1.Close();

                                            this.Hide();
                                            var a = new customerstype();
                                            a.ShowDialog();
                                            this.Show();

                                        }
                                        catch
                                        {
                                            label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("ยอดเงินไม่พอ");
                                    }
                                    con1.Close();
                                    break;
                                }
                                else
                                {
                                    label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("ใส่จำนวนเงิน");
                        }
                    }
                    else
                        MessageBox.Show("โปรดเลือกรายการฝกถอน");

                    break;
                }
                else
                {
                    label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                }
            }
        }
        private void guna2Button2_Click(object sender, EventArgs e){
            this.Dispose();}
    } 
}
