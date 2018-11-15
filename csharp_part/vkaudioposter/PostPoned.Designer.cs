namespace vkaudioposter
{
    partial class PostPoned
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.lstV_Posts = new System.Windows.Forms.ListView();
            this.colH_1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstV_Posts
            // 
            this.lstV_Posts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colH_1});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "lstV_Tracks";
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "lstV_Images";
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "lstV_Text";
            this.lstV_Posts.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lstV_Posts.Location = new System.Drawing.Point(12, 12);
            this.lstV_Posts.Name = "lstV_Posts";
            this.lstV_Posts.Size = new System.Drawing.Size(398, 426);
            this.lstV_Posts.TabIndex = 0;
            this.lstV_Posts.UseCompatibleStateImageBehavior = false;
            // 
            // PostPoned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstV_Posts);
            this.Name = "PostPoned";
            this.Text = "PostPoned";
            this.Load += new System.EventHandler(this.PostPoned_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstV_Posts;
        private System.Windows.Forms.ColumnHeader colH_1;
    }
}