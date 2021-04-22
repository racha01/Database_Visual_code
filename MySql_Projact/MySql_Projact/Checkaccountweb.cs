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
    public partial class Checkaccountweb : Form
    {
        public Checkaccountweb()
        {
            InitializeComponent();

           
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Checkaccountweb_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");

            string sql = "SELECT National_ID, ID, Branch, Users, Accstatus FROM userpassacc WHERE 1";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView_data.DataSource = ds.Tables[0].DefaultView;
            con.Close();
        }

        private void BT_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                string sql_up = "UPDATE userpassacc SET Accstatus = 'active' WHERE Users = '"+TB_user.Text+"'";
                MySqlConnection con_up = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
                MySqlCommand cmd_up = new MySqlCommand(sql_up, con_up);

                con_up.Open();
                cmd_up.ExecuteNonQuery();
                con_up.Close();

                MessageBox.Show("ทำรายการเสร็จสิ้น");

                this.Hide();
                var a = new chooselist();
                a.ShowDialog();
                this.Show();
            }
            catch
            {
                MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
            }
        }

        private void BT_cancern_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
