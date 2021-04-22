using Guna.UI2.WinForms;
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
    public partial class customerstype : Form
    {

        public customerstype(){
            InitializeComponent();
            //

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            moveImageBox(sender);
            //this.Hide();
            var a = new openaccount();
            a.Show();
            //this.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            moveImageBox(sender);
            //this.Hide();
            var reg = new register();
            reg.Show();
            //this.Show();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            moveImageBox(sender);
            //this.Hide();
            var dewit = new deorwit();
            dewit.Show();
            //this.Show();
            //this.Dispose();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            moveImageBox(sender);
            //this.Hide();
            var a = new transfermoney();
            a.Show();
            //this.Show();
        }
        private void guna2Button4_Click(object sender, EventArgs e){
            moveImageBox(sender);
            this.Hide();
            var choose = new chooselist();
            choose.ShowDialog();
            this.Show();}

        private void guna2Button5_Click(object sender, EventArgs e){ 
            this.Dispose();}
        private void moveImageBox(object sender){
            Guna2Button b = (Guna2Button)sender;
            pictureBox1.Location = new Point(b.Location.X + 142, b.Location.Y -0);
            pictureBox1.SendToBack();}

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 190, pictureBox1.Location.Y - 0);
        }
    }
}
