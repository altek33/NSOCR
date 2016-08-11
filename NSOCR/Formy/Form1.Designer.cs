namespace NSOCR
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxSellerNip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxBoughtNip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxBoughtDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxDateOfIssue = new System.Windows.Forms.TextBox();
            this.TextBoxCashIn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxFaktu = new System.Windows.Forms.TextBox();
            this.TextBoxToPay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.słowaKluczoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PanelWait = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LabelServerStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.PanelWait.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Kod Kreskowy";
            // 
            // TextBoxBarcode
            // 
            this.TextBoxBarcode.Location = new System.Drawing.Point(176, 87);
            this.TextBoxBarcode.Name = "TextBoxBarcode";
            this.TextBoxBarcode.Size = new System.Drawing.Size(100, 22);
            this.TextBoxBarcode.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Zakupu";
            // 
            // TextBoxSellerNip
            // 
            this.TextBoxSellerNip.Location = new System.Drawing.Point(146, 110);
            this.TextBoxSellerNip.Name = "TextBoxSellerNip";
            this.TextBoxSellerNip.Size = new System.Drawing.Size(100, 22);
            this.TextBoxSellerNip.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Wystawienia";
            // 
            // TextBoxBoughtNip
            // 
            this.TextBoxBoughtNip.Location = new System.Drawing.Point(146, 138);
            this.TextBoxBoughtNip.Name = "TextBoxBoughtNip";
            this.TextBoxBoughtNip.Size = new System.Drawing.Size(100, 22);
            this.TextBoxBoughtNip.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data sprzedaży";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nip Sprzedawcy";
            // 
            // TextBoxBoughtDate
            // 
            this.TextBoxBoughtDate.Location = new System.Drawing.Point(146, 82);
            this.TextBoxBoughtDate.Name = "TextBoxBoughtDate";
            this.TextBoxBoughtDate.Size = new System.Drawing.Size(100, 22);
            this.TextBoxBoughtDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nip Nabywcy";
            // 
            // TextBoxDateOfIssue
            // 
            this.TextBoxDateOfIssue.Location = new System.Drawing.Point(146, 26);
            this.TextBoxDateOfIssue.Name = "TextBoxDateOfIssue";
            this.TextBoxDateOfIssue.Size = new System.Drawing.Size(100, 22);
            this.TextBoxDateOfIssue.TabIndex = 3;
            // 
            // TextBoxCashIn
            // 
            this.TextBoxCashIn.Location = new System.Drawing.Point(146, 54);
            this.TextBoxCashIn.Name = "TextBoxCashIn";
            this.TextBoxCashIn.Size = new System.Drawing.Size(100, 22);
            this.TextBoxCashIn.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nr Faktury(obcy)";
            // 
            // TextBoxFaktu
            // 
            this.TextBoxFaktu.Location = new System.Drawing.Point(146, 166);
            this.TextBoxFaktu.Name = "TextBoxFaktu";
            this.TextBoxFaktu.Size = new System.Drawing.Size(100, 22);
            this.TextBoxFaktu.TabIndex = 12;
            // 
            // TextBoxToPay
            // 
            this.TextBoxToPay.Location = new System.Drawing.Point(146, 194);
            this.TextBoxToPay.Name = "TextBoxToPay";
            this.TextBoxToPay.Size = new System.Drawing.Size(100, 22);
            this.TextBoxToPay.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Do zapłaty";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TextBoxToPay);
            this.groupBox1.Controls.Add(this.TextBoxFaktu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.TextBoxCashIn);
            this.groupBox1.Controls.Add(this.TextBoxDateOfIssue);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TextBoxBoughtDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBoxBoughtNip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TextBoxSellerNip);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 243);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(314, 26);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.słowaKluczoweToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(56, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // słowaKluczoweToolStripMenuItem
            // 
            this.słowaKluczoweToolStripMenuItem.Name = "słowaKluczoweToolStripMenuItem";
            this.słowaKluczoweToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.słowaKluczoweToolStripMenuItem.Text = "Słowa Kluczowe";
            this.słowaKluczoweToolStripMenuItem.Click += new System.EventHandler(this.słowaKluczoweToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // PanelWait
            // 
            this.PanelWait.Controls.Add(this.label10);
            this.PanelWait.Controls.Add(this.label9);
            this.PanelWait.Location = new System.Drawing.Point(21, 29);
            this.PanelWait.Name = "PanelWait";
            this.PanelWait.Size = new System.Drawing.Size(270, 336);
            this.PanelWait.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(92, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "Wait";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(77, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Please";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 396);
            this.Controls.Add(this.LabelServerStatus);
            this.Controls.Add(this.PanelWait);
            this.Controls.Add(this.TextBoxBarcode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PanelWait.ResumeLayout(false);
            this.PanelWait.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxSellerNip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxBoughtNip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxBoughtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxDateOfIssue;
        private System.Windows.Forms.TextBox TextBoxCashIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxFaktu;
        private System.Windows.Forms.TextBox TextBoxToPay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem słowaKluczoweToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel PanelWait;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LabelServerStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

