namespace A2Coursework
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnLogin = new System.Windows.Forms.Button();
            this.LoginText = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.Label();
            this.CbxAdmin = new System.Windows.Forms.CheckBox();
            this.TBXname = new System.Windows.Forms.TextBox();
            this.TBXpassword = new System.Windows.Forms.TextBox();
            this.pbxBanner = new System.Windows.Forms.PictureBox();
            this.lblDohertyCars = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.Location = new System.Drawing.Point(648, 515);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(170, 59);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "Log In";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginText
            // 
            this.LoginText.AutoSize = true;
            this.LoginText.Font = new System.Drawing.Font("Mongolian Baiti", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginText.Location = new System.Drawing.Point(411, 143);
            this.LoginText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(154, 58);
            this.LoginText.TabIndex = 1;
            this.LoginText.Text = "Login";
            this.LoginText.Click += new System.EventHandler(this.label1_Click);
            // 
            // TxtPassword
            // 
            this.TxtPassword.AutoSize = true;
            this.TxtPassword.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.Location = new System.Drawing.Point(42, 335);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(145, 36);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.Text = "Password";
            // 
            // TxtUsername
            // 
            this.TxtUsername.AutoSize = true;
            this.TxtUsername.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.Location = new System.Drawing.Point(42, 215);
            this.TxtUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(96, 36);
            this.TxtUsername.TabIndex = 3;
            this.TxtUsername.Text = "Name";
            this.TxtUsername.Click += new System.EventHandler(this.TxtUsername_Click);
            // 
            // CbxAdmin
            // 
            this.CbxAdmin.AutoSize = true;
            this.CbxAdmin.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbxAdmin.Location = new System.Drawing.Point(48, 465);
            this.CbxAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CbxAdmin.Name = "CbxAdmin";
            this.CbxAdmin.Size = new System.Drawing.Size(125, 34);
            this.CbxAdmin.TabIndex = 4;
            this.CbxAdmin.Text = "Admin?";
            this.CbxAdmin.UseVisualStyleBackColor = true;
            // 
            // TBXname
            // 
            this.TBXname.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBXname.Location = new System.Drawing.Point(45, 266);
            this.TBXname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBXname.Name = "TBXname";
            this.TBXname.Size = new System.Drawing.Size(284, 46);
            this.TBXname.TabIndex = 5;
            // 
            // TBXpassword
            // 
            this.TBXpassword.Font = new System.Drawing.Font("Mongolian Baiti", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBXpassword.Location = new System.Drawing.Point(45, 383);
            this.TBXpassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBXpassword.Name = "TBXpassword";
            this.TBXpassword.Size = new System.Drawing.Size(284, 46);
            this.TBXpassword.TabIndex = 6;
            // 
            // pbxBanner
            // 
            this.pbxBanner.Image = ((System.Drawing.Image)(resources.GetObject("pbxBanner.Image")));
            this.pbxBanner.Location = new System.Drawing.Point(-4, 0);
            this.pbxBanner.Margin = new System.Windows.Forms.Padding(4);
            this.pbxBanner.Name = "pbxBanner";
            this.pbxBanner.Size = new System.Drawing.Size(1096, 129);
            this.pbxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBanner.TabIndex = 7;
            this.pbxBanner.TabStop = false;
            // 
            // lblDohertyCars
            // 
            this.lblDohertyCars.AutoSize = true;
            this.lblDohertyCars.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDohertyCars.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDohertyCars.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDohertyCars.Location = new System.Drawing.Point(324, 23);
            this.lblDohertyCars.Name = "lblDohertyCars";
            this.lblDohertyCars.Size = new System.Drawing.Size(349, 64);
            this.lblDohertyCars.TabIndex = 8;
            this.lblDohertyCars.Text = "Doherty Cars";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1068, 625);
            this.Controls.Add(this.lblDohertyCars);
            this.Controls.Add(this.pbxBanner);
            this.Controls.Add(this.TBXpassword);
            this.Controls.Add(this.TBXname);
            this.Controls.Add(this.CbxAdmin);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.BtnLogin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label LoginText;
        private System.Windows.Forms.Label TxtPassword;
        private System.Windows.Forms.Label TxtUsername;
        private System.Windows.Forms.CheckBox CbxAdmin;
        private System.Windows.Forms.TextBox TBXname;
        private System.Windows.Forms.TextBox TBXpassword;
        private System.Windows.Forms.PictureBox pbxBanner;
        private System.Windows.Forms.Label lblDohertyCars;
    }
}

