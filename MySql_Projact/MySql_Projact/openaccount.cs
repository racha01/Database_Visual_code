using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class openaccount : Form
    {
        public openaccount()
        {
            InitializeComponent();

            string sql = "SELECT National_ID FROM nationalid WHERE 1";
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CB_nationalid.Items.Add(reader.GetString("National_ID"));
            }
        }
        private void button3_Click(object sender, EventArgs e){
            //คำสั่งไปยัง form customerstype และปิดหน้าปัจจุบันลง
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button5_Click(object sender, EventArgs e){
            this.Dispose();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (TB_accountnum.Text.Length == 10 && TB_branch.Text != "" && CB_nationalid.Text.Length == 13)
            {
                string sql = "SELECT National_ID FROM nationalid WHERE 1";
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (CB_nationalid.Text == reader.GetString("National_ID"))
                    {
                        try
                        {
                            string sql_acc = "SELECT * FROM account_id";
                            sql_acc = "INSERT INTO account_id(National_ID, ID, Branch, Checkcustomer) VALUES('" + CB_nationalid.Text + "','" + TB_accountnum.Text + "','" + TB_branch.Text + "','normal')";

                            MySqlConnection con_acc = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                            MySqlCommand cmd_acc = new MySqlCommand(sql_acc, con_acc);

                            con_acc.Open();

                            cmd_acc.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล

                            con_acc.Close();

                            MessageBox.Show("ทำรายการเสร็จเรียบร้อย");

                            this.Dispose();
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("มีบัญชีนี้อยู่ในระบบแล้ว");
                        }
                    }
                    else if (CB_nationalid.Text != reader.GetString("National_ID"))
                    {
                        label4.Text = "ไม่มีเลขประจำตัวประชาชนนี้อยู่ในระบบ";
                        //MessageBox.Show("ไม่มีเลขประจำตัวประชาชนนี้อยู่ในระบบ");
                    }
                }
            }
            else
                MessageBox.Show("ข้อมูลไม่ถูกต้อง โปรดใส่ข้อมูลให้ถูกต้อง");
        }
        private void guna2Button2_Click(object sender, EventArgs e){
            this.Dispose();}
    }
}
