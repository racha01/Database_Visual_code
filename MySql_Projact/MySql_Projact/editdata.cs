using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class editdata : Form
    {
        public editdata()
        {
            InitializeComponent();

            CB_chooseedit.Items.Add("Prefix");
            CB_chooseedit.Items.Add("Firstname");
            CB_chooseedit.Items.Add("Lastname");
            CB_chooseedit.Items.Add("Phonenumber");
            CB_chooseedit.Items.Add("Email");
            CB_chooseedit.Items.Add("Address");
            CB_chooseedit.Items.Add("Checkcustomer");
        }
        private void guna2Button3_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CB_chooseedit.Text == "Prefix" || CB_chooseedit.Text == "Firstname" || CB_chooseedit.Text == "Lastname" || CB_chooseedit.Text == "Phonenumber" || CB_chooseedit.Text == "Email" || CB_chooseedit.Text == "Address")
            {
                try
                {
                    string sql_up = "UPDATE nationalid SET " + CB_chooseedit.Text + " = '" + TB_newdata.Text + "' WHERE National_ID = '" + TB_nationalid.Text + "' ";
                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_up = new MySqlCommand(sql_up, con);

                    con.Open();
                    cmd_up.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("ทำรายการเสร็จสิ้น");

                    this.Hide();
                    var a = new customerstype();
                    a.ShowDialog();
                    this.Show();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
            else if (CB_chooseedit.Text == "Checkcustomer")
            {
                try
                {
                    string sql_up = "UPDATE account_id SET " + CB_chooseedit.Text + " = '" + TB_newdata.Text + "' WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
                    MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);

                    con_up.Open();
                    cmd_up.ExecuteNonQuery();
                    con_up.Close();

                    MessageBox.Show("ทำรายการเสร็จสิ้น");
                    this.Hide();
                    var a = new customerstype();
                    a.ShowDialog();
                    this.Show();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e){
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void editdata_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("A");
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ถ้าต้องการ ปลดล็อกบัญชี ให้กรอกขอมูลเลขบัญชีและสาขา\nแต่ถ้าต้องการแก้ไขข้อมูลทัวไปให้ใส่เฉพาะเชลประตัวประชาชน","คำแนะนำ");
        }
    }
}
