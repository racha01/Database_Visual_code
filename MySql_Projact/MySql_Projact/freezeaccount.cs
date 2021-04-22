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
    public partial class freezeaccount : Form
    {
        public freezeaccount()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_up = "UPDATE account_id SET Checkcustomer = 'freeze' WHERE(Checkcustomer, ID, Branch) = ('normal', '" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
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
        private void button2_Click(object sender, EventArgs e){
            this.Dispose();}
        private void guna2Button3_Click(object sender, EventArgs e){
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_up = "UPDATE account_id SET Checkcustomer = 'freeze' WHERE(Checkcustomer, ID, Branch) = ('normal', '" + TB_accountnum.Text + "', '" + CB_branch.Text + "')";
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
        private void guna2Button4_Click(object sender, EventArgs e){
            this.Dispose();}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
