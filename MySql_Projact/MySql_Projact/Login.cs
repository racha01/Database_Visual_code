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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int r = 244;
        int g = 65;
        int b = 65;
       
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string u = guna2TextBox1.Text;
            string p = guna2TextBox2.Text;

            if(guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {
                if (u == "kingmoney")
                {
                    if (p == "root1234")
                    {
                        this.Hide();
                        var a = new customerstype();
                        a.ShowDialog();
                        this.Show();
                    }
                    else
                        label1.Text = "password ไม่ถูกต้อง";
                }
                else if (u == "Username")
                {

                }
                else
                    label1.Text = "usernsme ไม่ถูกต้อง";
            }
        }

        private void timerR_Tick_1(object sender, EventArgs e)
        {
            if (b >= 244)
            {
                r -= 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (r <= 65)
                {
                    timerR.Stop();
                    timerG.Start();

                    //textBox1.Text = "hola";
                }
            }

            if (b <= 65)
            {
                r += 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (r >= 244)
                {
                    timerR.Stop();
                    timerG.Start();

                    // textBox1.Text = "kamusta";
                }
            }
        }

        private void timerG_Tick_1(object sender, EventArgs e)
        {
            if (r <= 65)
            {
                g += 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (g >= 244)
                {
                    timerG.Stop();
                    timerB.Start();

                    //textBox1.Text = "??????";
                }
            }

            if (r >= 244)
            {
                g -= 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (g <= 65)
                {
                    timerG.Stop();
                    timerB.Start();

                    //textBox1.Text = "??????";
                }
            }
        }

        private void timerB_Tick_1(object sender, EventArgs e)
        {
            if (g <= 65)
            {
                b += 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (b >= 244)
                {
                    timerB.Stop();
                    timerR.Start();

                    //textBox1.Text = "hello";
                }
            }

            if (g >= 244)
            {
                b -= 1;
                this.BackColor = Color.FromArgb(r, g, b);
                //textBox1.BackColor = Color.FromArgb(r, g, b);
                if (b <= 65)
                {
                    timerB.Stop();
                    timerR.Start();

                    //textBox1.Text = "Merhaba";
                }
            }
        }

        private void Longin_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(244, 66, 66);
        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "Username")
            {
                guna2TextBox1.Text = "";

                guna2TextBox1.ForeColor = Color.Black;
            }
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                guna2TextBox1.Text = "Username";

                guna2TextBox1.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "Password")
            {
                
                guna2TextBox2.ForeColor = Color.Black;

                if (guna2TextBox2.Text != "")
                {
                    guna2TextBox2.UseSystemPasswordChar = true;
                    guna2TextBox2.Text = "";
                }
            }
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
            {
                guna2TextBox2.UseSystemPasswordChar = false;
                guna2TextBox2.Text = "Password";

                guna2TextBox2.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void guna2Button1_DragEnter(object sender, DragEventArgs e)
        {
            string u = guna2TextBox1.Text;
            string p = guna2TextBox2.Text;

            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {
                if (u == "kingmoney")
                {
                    if (p == "root1234")
                    {
                        this.Hide();
                        var a = new customerstype();
                        a.ShowDialog();
                        this.Show();
                    }
                    else
                        label1.Text = "password ไม่ถูกต้อง";
                }
                else if (u == "Username")
                {

                }
                else
                    label1.Text = "usernsme ไม่ถูกต้อง";
            }
        }
    }
}
