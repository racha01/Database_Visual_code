using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class transfermoney : Form
    {
        public transfermoney()
        {
            InitializeComponent();

            //กำหนดเวลาเมื่อเปฺดหน้าโปรแกรมนี้ขึ้นมา
            timer1.Start(); //เริ่มนับเวลา
            TB_timer.Text = "" + DateTime.Now + ""; //ค่าของเวลาเป็นค่าปัจจุบัน
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //บังคับให้ใส่ค่าที่มีค่าไม่ว่างเข้ามา(ต้องใส่ให้ครบและเลขบัญชีต้องมี10หลัก)
            if (TB_accountnum.Text.Length == 10 && CB_branch.Text != "" && textBox1.Text.Length == 10 && comboBox1.Text != "" && TB_balance.Text != "") 
            {
                //ทำการเช็คในฐานข้อมูล ว่าเลขบัญชีที่ใส่เข้ามา มีค่าเท่ากับ เลขบัญชีที่อยู่ในฐานข้อมูลหรือไม่ โดยการวนลูปไปเรื่อยๆ (เลขบัญชีที่จะถูกโอนไป)
                string sql_a = "SELECT ID FROM `account_id` WHERE 1";
                MySqlConnection con_a = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd_a = new MySqlCommand(sql_a, con_a);

                con_a.Open();
                MySqlDataReader reader_a = cmd_a.ExecuteReader();

                while (reader_a.Read()) //ทำการวนloopเพื่อเช็คว่ามีเลขบัญชีอญู่ในระบบหรือไม่(ID)
                {
                    if (TB_accountnum.Text == reader_a.GetString("ID") ) //เมื่อมีIDอยู่ในฐานข้อมูล โปรแกรมจะทำงาน
                    {
                        //ทำการเช็คในฐานข้อมูล ว่าสาขาของเลขบัญชีที่ใส่เข้ามา มีค่าเท่ากับ สาขาของเลขบัญชีที่อยู่ในฐานข้อมูลหรือไม่ โดยการวนลูปไปเรื่อยๆ (สาขาของเลขบัญชีที่จะโอนไป)
                        string sql_b = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + TB_accountnum.Text + "' GROUP BY A.Branch";
                        MySqlConnection con_b = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                        MySqlCommand cmd_b = new MySqlCommand(sql_b, con_b);

                        con_b.Open();

                        MySqlDataReader reader = cmd_b.ExecuteReader();

                        while (reader.Read())
                        {
                            if (CB_branch.Text == reader.GetString("Branch")) //เมื่อมีสาขาอยู่ในฐานข้อมูล โปรแกรมจะทำงาน
                            {
                                //ดึงข้อมูลจาก table deorwit จะได้ค่า sum ของ balance มา
                                string sql1 = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                                MySqlConnection con1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                MySqlCommand cmd1 = new MySqlCommand(sql1, con1);

                                con1.Open();
                                MySqlDataReader reader1 = cmd1.ExecuteReader();
                                reader1.Read();

                                Int64 balance = Int64.Parse(reader1.GetString("Balance"));//แปลงค่า  balance จาก string เป็น int
                                Int64 TB_bal = Int64.Parse("" + TB_balance.Text + ""); //แปลงค่าจาก จำนวนเงินที่ใส่เข้ามา string เป็น int

                                if (TB_bal <= balance) //เมื่อจำนวนเงินที่ใส่เข้ามามีค่าน้อยกว่าค่า balance โปรแกรมจะทำงาน
                                {
                                    try//เช็คError ถ้าไม่ Error ทำงานในนี้
                                    {
                                        //ทำการเช็คในฐานข้อมูล ว่าเลขบัญชีที่ใส่เข้ามา มีค่าเท่ากับ เลขบัญชีที่อยู่ในฐานข้อมูลหรือไม่ โดยการวนลูปไปเรื่อยๆ (เลขบัญชีที่จะถูกโอนไป)
                                        string sql_F2 = "SELECT ID FROM `account_id` WHERE 1";
                                        MySqlConnection con_F2 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                        MySqlCommand cmd_F2 = new MySqlCommand(sql_F2, con_F2);

                                        con_F2.Open();
                                        MySqlDataReader reader_F2 = cmd_F2.ExecuteReader();

                                        while (reader_F2.Read()) //ทำการวนloopเพื่อเช็คว่ามีเลขบัญชีอญู่ในระบบหรือไม่(ID)
                                        {

                                            if (textBox1.Text == reader_F2.GetString("ID")) //เมื่อมีIDอยู่ในฐานข้อมูล โปรแกรมจะทำงาน
                                            {
                                                //ทำการเช็คในฐานข้อมูล ว่าสาขาของเลขบัญชีที่ใส่เข้ามา มีค่าเท่ากับ สาขาของเลขบัญชีที่อยู่ในฐานข้อมูลหรือไม่ โดยการวนลูปไปเรื่อยๆ (สาขาของเลขบัญชีที่จะถูกโอนไป)
                                                string sql_bf2 = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + textBox1.Text + "' GROUP BY A.Branch";
                                                MySqlConnection con_bf2 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                MySqlCommand cmd_bf2 = new MySqlCommand(sql_bf2, con_bf2);

                                                con_bf2.Open();
                                                MySqlDataReader reader_bf2 = cmd_bf2.ExecuteReader();

                                                while (reader_bf2.Read())
                                                {
                                                    if (comboBox1.Text == reader_bf2.GetString("Branch"))
                                                    {
                                                        //โดยการโอนเงินจะใช้หลักการ ถอนจากอีกบัญชี และไปฝากอีกบัญชี

                                                        //เพิ่มข้อมูลลงในตาราง deorwit ในส่วนของการถอน
                                                        string sql = "SELECT * FROM deorwit";
                                                        sql = "INSERT INTO deorwit(ID, Branch, Date_time, Withdraw, Balance) VALUES('" + TB_accountnum.Text + "', '" + CB_branch.Text + "','" + TB_timer.Text + "', '" + TB_balance.Text + "', '" + -Int64.Parse(TB_balance.Text) + "')";
                                                        MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd = new MySqlCommand(sql, con);

                                                        con.Open(); cmd.ExecuteNonQuery(); /*คำสั่งเพิ่ม/ลบข้อมูล*/ con.Close();

                                                        //ดึงข้อมูลมาจา table deorwit จะได้ค่ายอดรวมของ balance เพื่อนำไป update ใน table account_id
                                                        string sql_ba = "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "') GROUP BY D.ID, D.Branch";
                                                        MySqlConnection con_ba = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_ba = new MySqlCommand(sql_ba, con_ba);

                                                        con_ba.Open();
                                                        MySqlDataReader reader_ba = cmd_ba.ExecuteReader();
                                                        reader_ba.Read();

                                                        //update ยอด balance จากการถอน ลงใน table account_id เพื่อแสดงยอดเงินปัจจุบัน
                                                        string sql_up = "UPDATE account_id SET Balances = '" + reader_ba.GetString("Balance") + "' WHERE(ID, Branch) = ('" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
                                                        MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);

                                                        con_up.Open();
                                                        cmd_up.ExecuteNonQuery();
                                                        con_up.Close();

                                                        string sql_upt = "UPDATE deorwit SET Statusacc = 'transfer' WHERE ID = '"+TB_accountnum.Text+"' And Branch = '"+CB_branch.Text+"' And Date_time = '"+TB_timer.Text+"'";
                                                        MySqlConnection cont = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_upt = new MySqlCommand(sql_upt, cont);

                                                        cont.Open();
                                                        cmd_upt.ExecuteNonQuery();
                                                        cont.Close();

                                                        //เพิ่มข้อมูลลงในตาราง deorwit ในส่วนของการฝาก
                                                        string sql11 = "SELECT * FROM deorwit";
                                                        sql11 = "INSERT INTO deorwit(ID, Branch, Date_time, Deposit, Balance) VALUES('" + textBox1.Text + "', '" + comboBox1.Text + "','" + TB_timer.Text + "','" + TB_balance.Text + "', '" + Int64.Parse(TB_balance.Text) + "')";
                                                        MySqlConnection con11 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd11 = new MySqlCommand(sql11, con11);

                                                        con11.Open(); cmd11.ExecuteNonQuery(); /*คำสั่งเพิ่ม/ลบข้อมูล*/ con11.Close();

                                                        
                                                        //ดึงข้อมูลมาจา table deorwit จะได้ค่ายอดรวมของ balance เพื่อนำไป update ใน table account_id
                                                        string sql_ba1= "SELECT SUM(D.Balance) Balance FROM deorwit D WHERE(D.ID, D.Branch) = ('" + textBox1.Text + "', '" + comboBox1.Text + "') GROUP BY D.ID, D.Branch";
                                                        MySqlConnection con_ba1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_ba1 = new MySqlCommand(sql_ba1, con_ba1);

                                                        con_ba1.Open();
                                                        MySqlDataReader reader_ba1 = cmd_ba1.ExecuteReader();
                                                        reader_ba1.Read();

                                                        //update ยอด balance จากการฝาก ลงใน table account_id เพื่อแสดงยอดเงินปัจจุบัน
                                                        string sql_up1 = "UPDATE account_id SET Balances = '" + reader_ba1.GetString("Balance") + "' WHERE(ID, Branch) = ('" + textBox1.Text + "', '" + comboBox1.Text + "')";
                                                        MySqlConnection con_up1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_up1 = new MySqlCommand(sql_up1, con_up1);

                                                        con_up1.Open();
                                                        cmd_up1.ExecuteNonQuery();
                                                        con_up1.Close();

                                                        string sql_upt1 = "UPDATE deorwit SET Statusacc = 'transfer' WHERE ID = '" + textBox1.Text + "' And Branch = '" + comboBox1.Text + "' And Date_time = '" + TB_timer.Text + "'";
                                                        MySqlConnection cont1 = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                                                        MySqlCommand cmd_upt1 = new MySqlCommand(sql_upt1, cont1);

                                                        cont1.Open();
                                                        cmd_upt1.ExecuteNonQuery();
                                                        cont1.Close();

                                                        MessageBox.Show("ทำรายการเสร็จสิ้น");

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
                                            else
                                            {
                                                label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                                              
                                            }
                                        }
                                        
                                    }
                                    catch
                                    {
                                        MessageBox.Show("ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่");
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
                    else
                        label10.Text = "ไม่มีบัญชีนี้ในระบบ โปรดลองใหม่";
                } 
            }
            else
                MessageBox.Show("ใส่ข้อมูลให้ถูกต้อง"); 
        }
        private void TB_accountnum_TextChanged(object sender, EventArgs e)
        {
            //หาสาขาของเลขบัญชีจากการ input ค่าเข้ามา จากบัญชีที่จะโอน

            string sql = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + TB_accountnum.Text + "' GROUP BY A.Branch";
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CB_branch.Items.Add(reader.GetString("Branch"));
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //หาสาขาของเลขบัญชีจากการ input ค่าเข้ามา จากบัญชีที่ถูกโอนเข้ามา

            string sql = "SELECT A.Branch FROM account_id A INNER JOIN account_id ON A.Branch = A.Branch WHERE A.Checkcustomer = 'normal' AND A.ID = '" + textBox1.Text + "' GROUP BY A.Branch";
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            MySqlCommand cmd = new MySqlCommand(sql, con);

            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("Branch"));
            }
        }
    }
}
