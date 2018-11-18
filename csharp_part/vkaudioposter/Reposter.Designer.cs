namespace vkaudioposter
{
    partial class Reposter
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
            this.BT_Repost = new System.Windows.Forms.Button();
            this.dUD_PostCount = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Phone = new System.Windows.Forms.TextBox();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pB_reposting = new System.Windows.Forms.ProgressBar();
            this.TB_count = new System.Windows.Forms.TrackBar();
            this.lb_Count = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TB_count)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Repost
            // 
            this.BT_Repost.Location = new System.Drawing.Point(242, 148);
            this.BT_Repost.Name = "BT_Repost";
            this.BT_Repost.Size = new System.Drawing.Size(64, 23);
            this.BT_Repost.TabIndex = 0;
            this.BT_Repost.Text = "Репост";
            this.BT_Repost.UseVisualStyleBackColor = true;
            this.BT_Repost.Click += new System.EventHandler(this.button1_Click);
            // 
            // dUD_PostCount
            // 
            this.dUD_PostCount.Location = new System.Drawing.Point(262, 122);
            this.dUD_PostCount.Name = "dUD_PostCount";
            this.dUD_PostCount.ReadOnly = true;
            this.dUD_PostCount.Size = new System.Drawing.Size(50, 20);
            this.dUD_PostCount.TabIndex = 1;
            this.dUD_PostCount.Visible = false;
            this.dUD_PostCount.SelectedItemChanged += new System.EventHandler(this.dUD_PostCount_SelectedItemChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество постов";
            // 
            // TB_Id
            // 
            this.TB_Id.Location = new System.Drawing.Point(15, 34);
            this.TB_Id.MaxLength = 10;
            this.TB_Id.Name = "TB_Id";
            this.TB_Id.Size = new System.Drawing.Size(114, 20);
            this.TB_Id.TabIndex = 3;
            this.TB_Id.TextChanged += new System.EventHandler(this.TB_Id_TextChanged);
            this.TB_Id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Id_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Откуда? ID страницы/группы:";
            // 
            // TB_Phone
            // 
            this.TB_Phone.Location = new System.Drawing.Point(205, 34);
            this.TB_Phone.Name = "TB_Phone";
            this.TB_Phone.Size = new System.Drawing.Size(102, 20);
            this.TB_Phone.TabIndex = 5;
            this.TB_Phone.TextChanged += new System.EventHandler(this.TB_Phone_TextChanged);
            // 
            // TB_Pass
            // 
            this.TB_Pass.Location = new System.Drawing.Point(205, 60);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.Size = new System.Drawing.Size(102, 20);
            this.TB_Pass.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Логин ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пароль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Куда репост?";
            // 
            // pB_reposting
            // 
            this.pB_reposting.Location = new System.Drawing.Point(18, 148);
            this.pB_reposting.Name = "pB_reposting";
            this.pB_reposting.Size = new System.Drawing.Size(218, 23);
            this.pB_reposting.TabIndex = 10;
            // 
            // TB_count
            // 
            this.TB_count.Location = new System.Drawing.Point(15, 97);
            this.TB_count.Name = "TB_count";
            this.TB_count.Size = new System.Drawing.Size(221, 45);
            this.TB_count.TabIndex = 11;
            this.TB_count.Scroll += new System.EventHandler(this.TB_count_Scroll);
            // 
            // lb_Count
            // 
            this.lb_Count.AutoSize = true;
            this.lb_Count.Location = new System.Drawing.Point(242, 97);
            this.lb_Count.Name = "lb_Count";
            this.lb_Count.Size = new System.Drawing.Size(13, 13);
            this.lb_Count.TabIndex = 12;
            this.lb_Count.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Reposter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(324, 184);
            this.Controls.Add(this.lb_Count);
            this.Controls.Add(this.TB_count);
            this.Controls.Add(this.pB_reposting);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Pass);
            this.Controls.Add(this.TB_Phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_Id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dUD_PostCount);
            this.Controls.Add(this.BT_Repost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reposter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Reposter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Reposter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TB_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Repost;
        private System.Windows.Forms.DomainUpDown dUD_PostCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Phone;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pB_reposting;
        private System.Windows.Forms.TrackBar TB_count;
        private System.Windows.Forms.Label lb_Count;
        private System.Windows.Forms.Timer timer1;
    }
}