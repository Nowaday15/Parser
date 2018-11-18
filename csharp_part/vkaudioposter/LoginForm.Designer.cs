namespace vkaudioposter
{
    partial class LoginForm
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
            this.TB_ownerID = new System.Windows.Forms.TextBox();
            this.TB_TokenApp = new System.Windows.Forms.TextBox();
            this.TB_PublicId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.TB_Token = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_ftpLogin = new System.Windows.Forms.TextBox();
            this.TB_ftpPass = new System.Windows.Forms.TextBox();
            this.TB_ftpAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_Login = new System.Windows.Forms.TextBox();
            this.BT_GetToken = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_AppId = new System.Windows.Forms.TextBox();
            this.BT_Reset = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_vkdev = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_ownerID
            // 
            this.TB_ownerID.Location = new System.Drawing.Point(211, 32);
            this.TB_ownerID.Name = "TB_ownerID";
            this.TB_ownerID.Size = new System.Drawing.Size(100, 20);
            this.TB_ownerID.TabIndex = 0;
            this.TB_ownerID.TextChanged += new System.EventHandler(this.TB_ownerID_TextChanged);
            this.TB_ownerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_ownerID_KeyPress);
            // 
            // TB_TokenApp
            // 
            this.TB_TokenApp.Location = new System.Drawing.Point(12, 240);
            this.TB_TokenApp.Name = "TB_TokenApp";
            this.TB_TokenApp.Size = new System.Drawing.Size(100, 20);
            this.TB_TokenApp.TabIndex = 1;
            this.TB_TokenApp.TextChanged += new System.EventHandler(this.TB_TokenApp_TextChanged);
            // 
            // TB_PublicId
            // 
            this.TB_PublicId.Location = new System.Drawing.Point(211, 71);
            this.TB_PublicId.Name = "TB_PublicId";
            this.TB_PublicId.Size = new System.Drawing.Size(100, 20);
            this.TB_PublicId.TabIndex = 2;
            this.TB_PublicId.TextChanged += new System.EventHandler(this.TB_PublicId_TextChanged);
            this.TB_PublicId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_PublicId_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ваш ID ВК ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Защищённый ключ приложения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ID группы";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(290, 337);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // TB_Token
            // 
            this.TB_Token.Location = new System.Drawing.Point(12, 279);
            this.TB_Token.Name = "TB_Token";
            this.TB_Token.Size = new System.Drawing.Size(100, 20);
            this.TB_Token.TabIndex = 7;
            this.TB_Token.TextChanged += new System.EventHandler(this.TB_Token_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Token";
            // 
            // TB_ftpLogin
            // 
            this.TB_ftpLogin.Location = new System.Drawing.Point(211, 240);
            this.TB_ftpLogin.Name = "TB_ftpLogin";
            this.TB_ftpLogin.Size = new System.Drawing.Size(100, 20);
            this.TB_ftpLogin.TabIndex = 9;
            this.TB_ftpLogin.TextChanged += new System.EventHandler(this.TB_ftpLogin_TextChanged);
            // 
            // TB_ftpPass
            // 
            this.TB_ftpPass.Location = new System.Drawing.Point(211, 279);
            this.TB_ftpPass.Name = "TB_ftpPass";
            this.TB_ftpPass.Size = new System.Drawing.Size(100, 20);
            this.TB_ftpPass.TabIndex = 10;
            this.TB_ftpPass.TextChanged += new System.EventHandler(this.TB_ftpPass_TextChanged);
            // 
            // TB_ftpAddress
            // 
            this.TB_ftpAddress.Location = new System.Drawing.Point(211, 204);
            this.TB_ftpAddress.Name = "TB_ftpAddress";
            this.TB_ftpAddress.Size = new System.Drawing.Size(154, 20);
            this.TB_ftpAddress.TabIndex = 11;
            this.TB_ftpAddress.TextChanged += new System.EventHandler(this.TB_ftpAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "FTP адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "FTP логин";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "FTP пароль";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Пароль ВК";
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(12, 71);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.Size = new System.Drawing.Size(100, 20);
            this.TB_Pass.TabIndex = 17;
            this.TB_Pass.TextChanged += new System.EventHandler(this.TB_Pass_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Логин ВК";
            // 
            // TB_Login
            // 
            this.TB_Login.Location = new System.Drawing.Point(12, 30);
            this.TB_Login.Name = "TB_Login";
            this.TB_Login.Size = new System.Drawing.Size(100, 20);
            this.TB_Login.TabIndex = 15;
            this.TB_Login.TextChanged += new System.EventHandler(this.TB_Login_TextChanged);
            // 
            // BT_GetToken
            // 
            this.BT_GetToken.Location = new System.Drawing.Point(118, 277);
            this.BT_GetToken.Name = "BT_GetToken";
            this.BT_GetToken.Size = new System.Drawing.Size(75, 23);
            this.BT_GetToken.TabIndex = 19;
            this.BT_GetToken.Text = "Get Token";
            this.BT_GetToken.UseVisualStyleBackColor = true;
            this.BT_GetToken.Click += new System.EventHandler(this.BT_GetToken_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "ID приложения";
            // 
            // TB_AppId
            // 
            this.TB_AppId.Location = new System.Drawing.Point(12, 200);
            this.TB_AppId.Name = "TB_AppId";
            this.TB_AppId.Size = new System.Drawing.Size(100, 20);
            this.TB_AppId.TabIndex = 21;
            this.TB_AppId.TextChanged += new System.EventHandler(this.TB_AppId_TextChanged);
            this.TB_AppId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_AppId_KeyPress);
            // 
            // BT_Reset
            // 
            this.BT_Reset.Location = new System.Drawing.Point(12, 337);
            this.BT_Reset.Name = "BT_Reset";
            this.BT_Reset.Size = new System.Drawing.Size(75, 23);
            this.BT_Reset.TabIndex = 22;
            this.BT_Reset.Text = "Сбросить";
            this.BT_Reset.UseVisualStyleBackColor = true;
            this.BT_Reset.Click += new System.EventHandler(this.BT_Reset_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "База опубликованных треков";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_vkdev
            // 
            this.bt_vkdev.Location = new System.Drawing.Point(12, 158);
            this.bt_vkdev.Name = "bt_vkdev";
            this.bt_vkdev.Size = new System.Drawing.Size(146, 23);
            this.bt_vkdev.TabIndex = 25;
            this.bt_vkdev.Text = "Создать ВК приложение";
            this.bt_vkdev.UseVisualStyleBackColor = true;
            this.bt_vkdev.Click += new System.EventHandler(this.bt_vkdev_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(191, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Платформа: Standalone-приложение\t";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 372);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bt_vkdev);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BT_Reset);
            this.Controls.Add(this.TB_AppId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.BT_GetToken);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TB_Login);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_ftpAddress);
            this.Controls.Add(this.TB_ftpPass);
            this.Controls.Add(this.TB_ftpLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Token);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_PublicId);
            this.Controls.Add(this.TB_TokenApp);
            this.Controls.Add(this.TB_ownerID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LoginForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_ownerID;
        private System.Windows.Forms.TextBox TB_TokenApp;
        private System.Windows.Forms.TextBox TB_PublicId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox TB_Token;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_ftpLogin;
        private System.Windows.Forms.TextBox TB_ftpPass;
        private System.Windows.Forms.TextBox TB_ftpAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_Login;
        private System.Windows.Forms.Button BT_GetToken;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_AppId;
        private System.Windows.Forms.Button BT_Reset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_vkdev;
        private System.Windows.Forms.Label label12;
    }
}