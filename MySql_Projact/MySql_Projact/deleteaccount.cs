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
    public partial class deleteaccount : Form
    {
        public deleteaccount(){
            InitializeComponent();}
        private void DEl_account_TextChanged(object sender, EventArgs e)
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
            

            if (TB_accountnum.Text.Length == 10)
            {
                //ทำการเปลี่ยน Statusacc ของเลขบัญชีและสาขาที่ใส่เข้ามา เป็น delete เพื่อที่จะนำไปลบ
                string sql_up = "UPDATE deorwit SET Statusacc = 'delete' WHERE ID = '"+TB_accountnum.Text+"' And Branch = '"+CB_branch.Text+"'";
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd_up = new MySqlCommand(sql_up, con);

                con.Open();
                cmd_up.ExecuteNonQuery();
                con.Close();

                //ทำการลบข่อมูลที่มี Statusacc เป็น delete
                string sql = "DELETE FROM deorwit WHERE Statusacc = 'delete'";
                MySqlConnection con_d = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd = new MySqlCommand(sql, con_d);

                con_d.Open();
                cmd.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                con_d.Close();

                //เมื่อมีเลขบัญชีใน table account_id และ table deorwit จะทำงานใน try (โปรแกรมทำงานปกติ)
                try
                {
                    //ลบข้อมูลเลขบัญชี(ID)และสาขา(Branch)ที่ผู้ใช้ใส่เข้ามา
                    string sql_con = "SELECT * FROM account_id";
                    sql_con = "DELETE FROM account_id WHERE ID = '" + TB_accountnum.Text + "' AND Branch = '" + CB_branch.Text + "'";
                    MySqlConnection con_con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_con = new MySqlCommand(sql_con, con_con);

                    con_con.Open();
                    cmd_con.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_con.Close();

                    MessageBox.Show("ทำรายการเสร็จสิ้น");
                    this.Hide();
                    var coo = new chooselist();
                    coo.ShowDialog();
                    this.Show();
                }

                //เมื่อมีเลขบัญชี(ID)ใน table account_id และไม่มีเลขบัญชี(ID)ใน table deorwit จะทำงานใน catch (โปรแกรมเกิดการ Erorr)
                catch
                {
                    /*ทำการย้ายข้อมูลที่จะไม่ถูกลบออกไปไว้ในตาราง newdeorwit เนื่องจาก 
                    เมื่อมีเลขบัญชี(ID)ใน table account_id และไม่มีเลขบัญชี(ID)ใน table deorwit โปรแกรมเกิดการ Erorr
                    จึงทำการย้ายข้อมูลที่สาขา(Branch)ที่ไม่ตรงกับที่ผู้ใช้ใส่เข้ามาไปฝากไว้ก่อน*/

                    string sql_into = "SELECT * FROM account_id";
                    sql_into = "INSERT INTO newdeorwit SELECT* FROM deorwit WHERE ID = '"+TB_accountnum.Text+"'  AND Branch != '"+CB_branch.Text+"'; ";
                    MySqlConnection con_into = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_into = new MySqlCommand(sql_into, con_into);

                    con_into.Open();
                    cmd_into.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_into.Close();


                    /*string sql_into1 = "SELECT * FROM account_id";
                    sql_into = "INSERT INTO newuserpassacc SELECT* FROM userpassacc WHERE 1; ";
                    MySqlConnection con_into1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_into1 = new MySqlCommand(sql_into1, con_into1);

                    con_into1.Open();
                    cmd_into1.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_into1.Close();

                    string sql_dweb = "DELETE FROM newuserpassacc WHERE 1";
                    MySqlConnection con_dweb = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_dweb = new MySqlCommand(sql_dweb, con_dweb);

                    con_dweb.Open();
                    cmd_dweb.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_dweb.Close();*/

                    //เปลี่ยน Statusacc เป็น delete เพื่อนำไปลบออกทั้งหมด
                    string sql_up1 = "UPDATE deorwit SET Statusacc = 'delete' WHERE ID = '" + TB_accountnum.Text + "'";
                    MySqlConnection con1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_up1 = new MySqlCommand(sql_up1, con1);

                    con1.Open();
                    cmd_up1.ExecuteNonQuery();
                    con1.Close();

                    //ทำการลลบข้อมูลที่มี Statusacc เป็น delete
                    string sql1 = "DELETE FROM deorwit WHERE Statusacc = 'delete'";
                    MySqlConnection con_d1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con_d1);

                    con_d1.Open();
                    cmd1.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_d1.Close();

                    //ลบข้อมูลเลขบัญชี(ID)และสาขา(Branch)ที่ผู้ใช้ใส่เข้ามา
                    string sql_con = "DELETE FROM account_id WHERE Checkcustomer = 'delete'";
                    MySqlConnection con_con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_con = new MySqlCommand(sql_con, con_con);

                    con_con.Open();
                    cmd_con.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_con.Close();

                    //เพิ่มข้อมูลจากการที่เอาข้อมูลไปฝากไว้ในตอนแรกที่ทำการย้ายข้อมูลเข้ามายัง table deorwit เหมือนเดิม
                    string sql_into1 = "SELECT * FROM account_id";
                    sql_into1 = "INSERT INTO deorwit SELECT* FROM newdeorwit WHERE ID = '" + TB_accountnum.Text + "'  AND Branch != '" + CB_branch.Text + "'; ";
                    MySqlConnection con_into1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_into1 = new MySqlCommand(sql_into1, con_into1);

                    con_into1.Open();
                    cmd_into1.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_into1.Close();


                    //ทำการลบข้อมูลที่อยู่ใน table newdeorwit ออกหมด 
                    string sql_dinto = "SELECT * FROM account_id";
                    sql_dinto = "DELETE FROM `newdeorwit` WHERE 1";
                    MySqlConnection con_dinto = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                    MySqlCommand cmd_dinto = new MySqlCommand(sql_dinto, con_dinto);

                    con_dinto.Open();
                    cmd_dinto.ExecuteNonQuery(); //คำสั่งเพิ่ม/ลบข้อมูล
                    con_dinto.Close();

                    MessageBox.Show("ทำรายการเสร็จสิ้น");
                    this.Hide();
                    var coo = new chooselist();
                    coo.ShowDialog();
                    this.Show();
                }
               
            }
            else
                MessageBox.Show("ใส่เลขบัญชีให้ถูกต้อง");
        }
        private void guna2Button2_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

