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
            this.BT_Stop = new System.Windows.Forms.Button();
            this.TB_Count = new System.Windows.Forms.TrackBar();
            this.LB_Count = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_GetChatID = new System.Windows.Forms.Button();
            this.TB_ChatID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_vkLogin = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_Count)).BeginInit();
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
            this.BT_Post.Location = new System.Drawing.Point(506, 419);
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
            this.TB_ApiToken.Location = new System.Drawing.Point(11, 33);
            this.TB_ApiToken.Name = "TB_ApiToken";
            this.TB_ApiToken.Size = new System.Drawing.Size(243, 20);
            this.TB_ApiToken.TabIndex = 3;
            this.TB_ApiToken.TextChanged += new System.EventHandler(this.TB_ApiToken_TextChanged);
            // 
            // LB1_number
            // 
            this.LB1_number.AutoSize = true;
            this.LB1_number.Location = new System.Drawing.Point(9, 11);
            this.LB1_number.Name = "LB1_number";
            this.LB1_number.Size = new System.Drawing.Size(163, 13);
            this.LB1_number.TabIndex = 4;
            this.LB1_number.Text = "Enter Bot Father / Bot Api Token";
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
            this.TB_Pass.Location = new System.Drawing.Point(694, 85);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.Size = new System.Drawing.Size(100, 20);
            this.TB_Pass.TabIndex = 6;
            this.TB_Pass.TextChanged += new System.EventHandler(this.TB_Pass_TextChanged);
            // 
            // LB_Pass
            // 
            this.LB_Pass.AutoSize = true;
            this.LB_Pass.Location = new System.Drawing.Point(691, 66);
            this.LB_Pass.Name = "LB_Pass";
            this.LB_Pass.Size = new System.Drawing.Size(73, 13);
            this.LB_Pass.TabIndex = 7;
            this.LB_Pass.Text = "VK Password:";
            // 
            // BT_Authorizer
            // 
            this.BT_Authorizer.Cursor = System.Windows.Forms.Cursors.Default;
            this.BT_Authorizer.Location = new System.Drawing.Point(713, 419);
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
            this.textBox1.Location = new System.Drawing.Point(12, 216);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 175);
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
            this.LB_Messages.Location = new System.Drawing.Point(411, 11);
            this.LB_Messages.Name = "LB_Messages";
            this.LB_Messages.Size = new System.Drawing.Size(274, 95);
            this.LB_Messages.TabIndex = 9;
            // 
            // BT_Stop
            // 
            this.BT_Stop.Location = new System.Drawing.Point(114, 419);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(75, 23);
            this.BT_Stop.TabIndex = 12;
            this.BT_Stop.Text = "Stop";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Visible = false;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // TB_Count
            // 
            this.TB_Count.LargeChange = 50;
            this.TB_Count.Location = new System.Drawing.Point(11, 128);
            this.TB_Count.Name = "TB_Count";
            this.TB_Count.Size = new System.Drawing.Size(734, 45);
            this.TB_Count.SmallChange = 10;
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
            this.label1.Location = new System.Drawing.Point(11, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Log:";
            // 
            // BT_GetChatID
            // 
            this.BT_GetChatID.Location = new System.Drawing.Point(260, 30);
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
            this.label2.Location = new System.Drawing.Point(8, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter Chat ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(691, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "VK Login:";
            // 
            // TB_vkLogin
            // 
            this.TB_vkLogin.Location = new System.Drawing.Point(694, 32);
            this.TB_vkLogin.Name = "TB_vkLogin";
            this.TB_vkLogin.Size = new System.Drawing.Size(100, 20);
            this.TB_vkLogin.TabIndex = 19;
            this.TB_vkLogin.TextChanged += new System.EventHandler(this.TB_vkLogin_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_vkLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_ChatID);
            this.Controls.Add(this.BT_GetChatID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_Count);
            this.Controls.Add(this.TB_Count);
            this.Controls.Add(this.BT_Stop);
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
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.TrackBar TB_Count;
        private System.Windows.Forms.Label LB_Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_GetChatID;
        private System.Windows.Forms.TextBox TB_ChatID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_vkLogin;
    }
}

