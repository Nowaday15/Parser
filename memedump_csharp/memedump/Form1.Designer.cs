namespace memedump
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
            this.BT_GetPosts = new System.Windows.Forms.Button();
            this.BT_Post = new System.Windows.Forms.Button();
            this.TB_ApiToken = new System.Windows.Forms.TextBox();
            this.LB1_number = new System.Windows.Forms.Label();
            this.LB_Code = new System.Windows.Forms.Label();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.LB_Pass = new System.Windows.Forms.Label();
            this.BT_Authorizer = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LB_Messages = new System.Windows.Forms.ListBox();
            this.BT_Save = new System.Windows.Forms.Button();
            this.TB_Count = new System.Windows.Forms.TrackBar();
            this.LB_Count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_GetChatID = new System.Windows.Forms.Button();
            this.TB_ChatID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_vkLogin = new System.Windows.Forms.TextBox();
            this.ChB_AddMessage = new System.Windows.Forms.CheckBox();
            this.CHB_AddWOPhoto = new System.Windows.Forms.CheckBox();
            this.lb_Delay = new System.Windows.Forms.Label();
            this.numericUpDown1Min = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2Max = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BT_BotFather = new System.Windows.Forms.Button();
            this.LB_Source = new System.Windows.Forms.Label();
            this.chb_addsource = new System.Windows.Forms.CheckBox();
            this.chb_auto = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_GetPosts
            // 
            this.BT_GetPosts.Location = new System.Drawing.Point(11, 419);
            this.BT_GetPosts.Name = "BT_GetPosts";
            this.BT_GetPosts.Size = new System.Drawing.Size(65, 23);
            this.BT_GetPosts.TabIndex = 0;
            this.BT_GetPosts.Text = "Start";
            this.BT_GetPosts.UseVisualStyleBackColor = true;
            this.BT_GetPosts.Click += new System.EventHandler(this.BT_GetPosts_Click);
            // 
            // BT_Post
            // 
            this.BT_Post.Location = new System.Drawing.Point(701, 18);
            this.BT_Post.Name = "BT_Post";
            this.BT_Post.Size = new System.Drawing.Size(75, 23);
            this.BT_Post.TabIndex = 1;
            this.BT_Post.Text = "Post";
            this.BT_Post.UseVisualStyleBackColor = true;
            this.BT_Post.Visible = false;
            this.BT_Post.Click += new System.EventHandler(this.BT_Post_Click);
            // 
            // TB_ApiToken
            // 
            this.TB_ApiToken.Location = new System.Drawing.Point(11, 44);
            this.TB_ApiToken.Name = "TB_ApiToken";
            this.TB_ApiToken.Size = new System.Drawing.Size(243, 20);
            this.TB_ApiToken.TabIndex = 3;
            this.TB_ApiToken.TextChanged += new System.EventHandler(this.TB_ApiToken_TextChanged);
            // 
            // LB1_number
            // 
            this.LB1_number.AutoSize = true;
            this.LB1_number.Location = new System.Drawing.Point(8, 28);
            this.LB1_number.Name = "LB1_number";
            this.LB1_number.Size = new System.Drawing.Size(181, 13);
            this.LB1_number.TabIndex = 4;
            this.LB1_number.Text = "Enter Bot Api Token from Bot Father:";
            // 
            // LB_Code
            // 
            this.LB_Code.AutoSize = true;
            this.LB_Code.Location = new System.Drawing.Point(8, 112);
            this.LB_Code.Name = "LB_Code";
            this.LB_Code.Size = new System.Drawing.Size(82, 13);
            this.LB_Code.TabIndex = 5;
            this.LB_Code.Text = "VK Post Count: ";
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(415, 86);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.Size = new System.Drawing.Size(100, 20);
            this.TB_Pass.TabIndex = 6;
            this.TB_Pass.TextChanged += new System.EventHandler(this.TB_Pass_TextChanged);
            // 
            // LB_Pass
            // 
            this.LB_Pass.AutoSize = true;
            this.LB_Pass.Location = new System.Drawing.Point(412, 67);
            this.LB_Pass.Name = "LB_Pass";
            this.LB_Pass.Size = new System.Drawing.Size(73, 13);
            this.LB_Pass.TabIndex = 7;
            this.LB_Pass.Text = "VK Password:";
            // 
            // BT_Authorizer
            // 
            this.BT_Authorizer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_Authorizer.Location = new System.Drawing.Point(701, 40);
            this.BT_Authorizer.Name = "BT_Authorizer";
            this.BT_Authorizer.Size = new System.Drawing.Size(75, 23);
            this.BT_Authorizer.TabIndex = 8;
            this.BT_Authorizer.Text = "Authorize";
            this.BT_Authorizer.UseVisualStyleBackColor = true;
            this.BT_Authorizer.Visible = false;
            this.BT_Authorizer.Click += new System.EventHandler(this.BT_Authorizer_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 179);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 73);
            this.textBox1.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(379, 179);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LB_Messages
            // 
            this.LB_Messages.FormattingEnabled = true;
            this.LB_Messages.HorizontalScrollbar = true;
            this.LB_Messages.Location = new System.Drawing.Point(11, 258);
            this.LB_Messages.Name = "LB_Messages";
            this.LB_Messages.Size = new System.Drawing.Size(361, 134);
            this.LB_Messages.TabIndex = 9;
            // 
            // BT_Save
            // 
            this.BT_Save.Location = new System.Drawing.Point(260, 86);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(75, 23);
            this.BT_Save.TabIndex = 12;
            this.BT_Save.Text = "Save";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // TB_Count
            // 
            this.TB_Count.LargeChange = 10;
            this.TB_Count.Location = new System.Drawing.Point(11, 128);
            this.TB_Count.Name = "TB_Count";
            this.TB_Count.Size = new System.Drawing.Size(734, 45);
            this.TB_Count.SmallChange = 5;
            this.TB_Count.TabIndex = 13;
            this.TB_Count.Scroll += new System.EventHandler(this.TB_Count_Scroll);
            // 
            // LB_Count
            // 
            this.LB_Count.AutoSize = true;
            this.LB_Count.Location = new System.Drawing.Point(740, 128);
            this.LB_Count.Name = "LB_Count";
            this.LB_Count.Size = new System.Drawing.Size(54, 13);
            this.LB_Count.TabIndex = 14;
            this.LB_Count.Text = "LB_Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Log:";
            // 
            // BT_GetChatID
            // 
            this.BT_GetChatID.Location = new System.Drawing.Point(260, 41);
            this.BT_GetChatID.Name = "BT_GetChatID";
            this.BT_GetChatID.Size = new System.Drawing.Size(136, 23);
            this.BT_GetChatID.TabIndex = 16;
            this.BT_GetChatID.Text = "Get Chat Id from Token";
            this.BT_GetChatID.UseVisualStyleBackColor = true;
            this.BT_GetChatID.Click += new System.EventHandler(this.BT_GetChatID_Click);
            // 
            // TB_ChatID
            // 
            this.TB_ChatID.Location = new System.Drawing.Point(11, 86);
            this.TB_ChatID.Name = "TB_ChatID";
            this.TB_ChatID.Size = new System.Drawing.Size(133, 20);
            this.TB_ChatID.TabIndex = 17;
            this.TB_ChatID.TextChanged += new System.EventHandler(this.TB_ChatID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter Chat ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "VK Login:";
            // 
            // TB_vkLogin
            // 
            this.TB_vkLogin.Location = new System.Drawing.Point(415, 43);
            this.TB_vkLogin.Name = "TB_vkLogin";
            this.TB_vkLogin.Size = new System.Drawing.Size(100, 20);
            this.TB_vkLogin.TabIndex = 19;
            this.TB_vkLogin.TextChanged += new System.EventHandler(this.TB_vkLogin_TextChanged);
            // 
            // ChB_AddMessage
            // 
            this.ChB_AddMessage.AutoSize = true;
            this.ChB_AddMessage.Location = new System.Drawing.Point(11, 397);
            this.ChB_AddMessage.Name = "ChB_AddMessage";
            this.ChB_AddMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChB_AddMessage.Size = new System.Drawing.Size(117, 17);
            this.ChB_AddMessage.TabIndex = 21;
            this.ChB_AddMessage.Text = "Add Text to Photos";
            this.ChB_AddMessage.UseVisualStyleBackColor = true;
            // 
            // CHB_AddWOPhoto
            // 
            this.CHB_AddWOPhoto.AutoSize = true;
            this.CHB_AddWOPhoto.Location = new System.Drawing.Point(211, 397);
            this.CHB_AddWOPhoto.Name = "CHB_AddWOPhoto";
            this.CHB_AddWOPhoto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CHB_AddWOPhoto.Size = new System.Drawing.Size(161, 17);
            this.CHB_AddWOPhoto.TabIndex = 22;
            this.CHB_AddWOPhoto.Text = "Add Text Posts W/O Photos";
            this.CHB_AddWOPhoto.UseVisualStyleBackColor = true;
            // 
            // lb_Delay
            // 
            this.lb_Delay.AutoSize = true;
            this.lb_Delay.Location = new System.Drawing.Point(667, 400);
            this.lb_Delay.Name = "lb_Delay";
            this.lb_Delay.Size = new System.Drawing.Size(37, 13);
            this.lb_Delay.TabIndex = 23;
            this.lb_Delay.Text = "Delay:";
            // 
            // numericUpDown1Min
            // 
            this.numericUpDown1Min.Location = new System.Drawing.Point(670, 419);
            this.numericUpDown1Min.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown1Min.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1Min.Name = "numericUpDown1Min";
            this.numericUpDown1Min.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown1Min.TabIndex = 24;
            this.numericUpDown1Min.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1Min.ValueChanged += new System.EventHandler(this.numericUpDown1Min_ValueChanged);
            // 
            // numericUpDown2Max
            // 
            this.numericUpDown2Max.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2Max.Location = new System.Drawing.Point(717, 419);
            this.numericUpDown2Max.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown2Max.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2Max.Name = "numericUpDown2Max";
            this.numericUpDown2Max.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown2Max.TabIndex = 25;
            this.numericUpDown2Max.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2Max.ValueChanged += new System.EventHandler(this.numericUpDown2Max_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(767, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "sec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(704, 421);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "-";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Text files (*.txt)|*.txt\"";
            // 
            // BT_BotFather
            // 
            this.BT_BotFather.Location = new System.Drawing.Point(11, 2);
            this.BT_BotFather.Name = "BT_BotFather";
            this.BT_BotFather.Size = new System.Drawing.Size(75, 23);
            this.BT_BotFather.TabIndex = 28;
            this.BT_BotFather.Text = "BotFather";
            this.BT_BotFather.UseVisualStyleBackColor = true;
            this.BT_BotFather.Click += new System.EventHandler(this.BT_BotFather_Click);
            // 
            // LB_Source
            // 
            this.LB_Source.AutoSize = true;
            this.LB_Source.Location = new System.Drawing.Point(379, 162);
            this.LB_Source.Name = "LB_Source";
            this.LB_Source.Size = new System.Drawing.Size(44, 13);
            this.LB_Source.TabIndex = 29;
            this.LB_Source.Text = "Source:";
            // 
            // chb_addsource
            // 
            this.chb_addsource.AutoSize = true;
            this.chb_addsource.Location = new System.Drawing.Point(290, 423);
            this.chb_addsource.Name = "chb_addsource";
            this.chb_addsource.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chb_addsource.Size = new System.Drawing.Size(82, 17);
            this.chb_addsource.TabIndex = 30;
            this.chb_addsource.Text = "Add Source";
            this.chb_addsource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_addsource.UseVisualStyleBackColor = true;
            // 
            // chb_auto
            // 
            this.chb_auto.AutoSize = true;
            this.chb_auto.Location = new System.Drawing.Point(586, 422);
            this.chb_auto.Name = "chb_auto";
            this.chb_auto.Size = new System.Drawing.Size(54, 17);
            this.chb_auto.TabIndex = 31;
            this.chb_auto.Text = "Auto?";
            this.chb_auto.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(521, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "min";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(471, 419);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 33;
            this.numericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(424, 419);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown2.TabIndex = 32;
            this.numericUpDown2.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Posting time every hour:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.chb_auto);
            this.Controls.Add(this.chb_addsource);
            this.Controls.Add(this.LB_Source);
            this.Controls.Add(this.BT_BotFather);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown2Max);
            this.Controls.Add(this.numericUpDown1Min);
            this.Controls.Add(this.lb_Delay);
            this.Controls.Add(this.CHB_AddWOPhoto);
            this.Controls.Add(this.ChB_AddMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_vkLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_ChatID);
            this.Controls.Add(this.BT_GetChatID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_Count);
            this.Controls.Add(this.TB_Count);
            this.Controls.Add(this.BT_Save);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LB_Messages);
            this.Controls.Add(this.BT_Authorizer);
            this.Controls.Add(this.LB_Pass);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.LB_Code);
            this.Controls.Add(this.LB1_number);
            this.Controls.Add(this.TB_ApiToken);
            this.Controls.Add(this.BT_Post);
            this.Controls.Add(this.BT_GetPosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Meme Dump [Мем помойка]";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_GetPosts;
        private System.Windows.Forms.Button BT_Post;
        private System.Windows.Forms.TextBox TB_ApiToken;
        private System.Windows.Forms.Label LB1_number;
        private System.Windows.Forms.Label LB_Code;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.Label LB_Pass;
        private System.Windows.Forms.Button BT_Authorizer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox LB_Messages;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.TrackBar TB_Count;
        private System.Windows.Forms.Label LB_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_GetChatID;
        private System.Windows.Forms.TextBox TB_ChatID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_vkLogin;
        private System.Windows.Forms.CheckBox ChB_AddMessage;
        private System.Windows.Forms.CheckBox CHB_AddWOPhoto;
        private System.Windows.Forms.Label lb_Delay;
        private System.Windows.Forms.NumericUpDown numericUpDown1Min;
        private System.Windows.Forms.NumericUpDown numericUpDown2Max;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BT_BotFather;
        private System.Windows.Forms.Label LB_Source;
        private System.Windows.Forms.CheckBox chb_addsource;
        private System.Windows.Forms.CheckBox chb_auto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label8;
    }
}

