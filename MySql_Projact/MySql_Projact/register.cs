using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();

            comboBox_prefix.Items.Add("เด็กชาย");
            comboBox_prefix.Items.Add("เด็กหญิง");
            comboBox_prefix.Items.Add("นาย");
            comboBox_prefix.Items.Add("นางสาว");
            comboBox_prefix.Items.Add("นาง");
        }
        private void button1_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button5_Click(object sender, EventArgs e){
            this.Dispose();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TB_nationalid.Text.Length == 13 && TB_firstname.Text != "" && comboBox_prefix.Text != "" && TB_lastname.Text != "" && dateTime_dateofbirth.Text != "" && TB_address.Text != "" && TB_email.Text != "" && TB_phone.Text.Length == 10)
                {
                    string sql = "SELECT * FROM nationalid";
                    sql = "INSERT INTO nationalid(National_ID, Prefix, Firstname, Lastname,Date_of_birth, Address, Email, Phonenumber) VALUES('" + TB_nationalid.Text + "', '" + comboBox_prefix.Text + "', '" + TB_firstname.Text + "', '" + TB_lastname.Text + "', '" + dateTime_dateofbirth.Text + "', '" + TB_address.Text + "', '" + TB_email.Text + "', '" + TB_phone.Text + "')";

                    MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

                    cmd.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล

                    con.Close();

                    this.Dispose();
                    MessageBox.Show("ทำรายการเสร็จเรียบร้อย");
                }
                else if (TB_nationalid.Text.Length != 13)
                    MessageBox.Show("โปรดใส่เลขบัตประชาชนให้ครบ 13 หลัก"); 
                else if (TB_phone.Text.Length != 10)
                    MessageBox.Show("โปรดใส่หมายเลขโทรศัพท์ให้ครบ 10 หลัก");
                else
                    MessageBox.Show("โปรดใส่ข้อมูลให้ครบ");
            }
            catch
            {
                MessageBox.Show("มีเลขประจำตัวประชาชนนี้อยู่ในระบบแล้ว");
            }
        }
        private void guna2Button4_Click(object sender, EventArgs e){
            this.Dispose();}
    }
}
