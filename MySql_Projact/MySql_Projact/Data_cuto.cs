using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class Datacuto : Form
    {
        public Datacuto(){
            InitializeComponent();

            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=bank;Uid=root;Pwd=''");
            if (TB_nationalid.Text.Length == 13)
            {
                try
                {
                    
                    string sql = "SELECT N.National_ID, A.ID, A.Branch , SUM(D.Balance) Balance ,N.Prefix,N.FirstName,N.LastName,N.Date_of_birth,N.Address,N.Email,N.Phonenumber, A.Checkcustomer FROM nationalid N INNER JOIN account_id A ON N.National_ID = A.National_ID INNER JOIN deorwit D ON(A.ID, A.Branch) = (D.ID, D.Branch) WHERE N.National_ID = '" + TB_nationalid.Text + "' GROUP BY A.ID, A.Branch";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    con.Open();
                    
                    DataSet ds = new DataSet();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(ds);
                    dataGridView_data.DataSource = ds.Tables[0].DefaultView;
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("ทำรายการล้มเหลว โปรดลองใหม่");
                }
            }
            else
                MessageBox.Show("โปรดใส่เลขบัตรประชาชน13หลัก");
        }
        private void guna2Button2_Click(object sender, EventArgs e){
            this.Dispose();}
        private void guna2Button3_Click(object sender, EventArgs e){
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
