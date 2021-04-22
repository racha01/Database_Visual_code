using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MySql_Projact
{
    public partial class chooselist : Form
    {
        public chooselist()
        {
            InitializeComponent();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var stat = new statmant();
            stat.Show();
            //this.Show();
        }
        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var total = new total();
            total.Show();
            //this.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var data = new Datacuto();
            data.Show();
            //this.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var a = new editdata();
            a.Show();
            //this.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var a = new freezeaccount();
            a.Show();
            //this.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            moveImage(sender);
            //this.Hide();
            var delete = new deleteaccount();
            delete.Show();
            //this.Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            var a = new customerstype();
            a.ShowDialog();
            this.Show();
        }

        private void moveImage(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
            picture.Location = new Point(b.Location.X + 85, b.Location.Y +0);
            picture.SendToBack();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            picture.Location = new Point(picture.Location.X + 121, picture.Location.Y + 0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var a = new Checkaccountweb();
            a.ShowDialog();
            this.Show();
        }
    }
}
