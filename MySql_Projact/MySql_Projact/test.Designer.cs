
namespace MySql_Projact
{
    partial class test
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.TB_timer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_accountnum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CB_branch = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.D_confirm = new System.Windows.Forms.Button();
            this.CB_dewit = new System.Windows.Forms.ComboBox();
            this.TB_balance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(550, 468);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 40;
            this.button2.Text = "กลับสู่หน้าหลัก";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TB_timer
            // 
            this.TB_timer.Location = new System.Drawing.Point(427, 260);
            this.TB_timer.Name = "TB_timer";
            this.TB_timer.Size = new System.Drawing.Size(121, 22);
            this.TB_timer.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 38;
            this.label1.Text = "วันที่-เวลา";
            // 
            // TB_accountnum
            // 
            this.TB_accountnum.Location = new System.Drawing.Point(427, 153);
            this.TB_accountnum.Name = "TB_accountnum";
            this.TB_accountnum.Size = new System.Drawing.Size(121, 22);
            this.TB_accountnum.TabIndex = 37;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(609, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "ยกเลิก";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CB_branch
            // 
            this.CB_branch.FormattingEnabled = true;
            this.CB_branch.Location = new System.Drawing.Point(427, 198);
            this.CB_branch.Name = "CB_branch";
            this.CB_branch.Size = new System.Drawing.Size(121, 24);
            this.CB_branch.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "สาขา";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 33;
            this.label6.Text = "เลขบัญชี";
            // 
            // D_confirm
            // 
            this.D_confirm.Location = new System.Drawing.Point(427, 377);
            this.D_confirm.Name = "D_confirm";
            this.D_confirm.Size = new System.Drawing.Size(75, 23);
            this.D_confirm.TabIndex = 32;
            this.D_confirm.Text = "ยืนยัน";
            this.D_confirm.UseVisualStyleBackColor = true;
            this.D_confirm.Click += new System.EventHandler(this.D_confirm_Click);
            // 
            // CB_dewit
            // 
            this.CB_dewit.FormattingEnabled = true;
            this.CB_dewit.Location = new System.Drawing.Point(618, 318);
            this.CB_dewit.Name = "CB_dewit";
            this.CB_dewit.Size = new System.Drawing.Size(121, 24);
            this.CB_dewit.TabIndex = 31;
            // 
            // TB_balance
            // 
            this.TB_balance.Location = new System.Drawing.Point(427, 320);
            this.TB_balance.Name = "TB_balance";
            this.TB_balance.Size = new System.Drawing.Size(100, 22);
            this.TB_balance.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "บาท";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "จำนวน";
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TB_timer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_accountnum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_branch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.D_confirm);
            this.Controls.Add(this.CB_dewit);
            this.Controls.Add(this.TB_balance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "test";
            this.Size = new System.Drawing.Size(1072, 651);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TB_timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_accountnum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CB_branch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button D_confirm;
        private System.Windows.Forms.ComboBox CB_dewit;
        private System.Windows.Forms.TextBox TB_balance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}
