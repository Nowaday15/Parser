namespace vkaudioposter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.RB_Manual = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.LstBox_AddedTracks = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.PB_Download = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.BT_Repost = new System.Windows.Forms.Button();
            this.BT_PlayPause = new System.Windows.Forms.Button();
            this.RB_Auto = new System.Windows.Forms.RadioButton();
            this.BT_ManualParser = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTN_DelImageFrom = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LB_version = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMENU_File = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMENU_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMENU_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.парсерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMENU_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSettToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetSettToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMENU_About = new System.Windows.Forms.ToolStripMenuItem();
            this.repostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.измененияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CHB_ToAudio = new System.Windows.Forms.CheckBox();
            this.chk_repost = new System.Windows.Forms.CheckBox();
            this.chk_openbrowser = new System.Windows.Forms.CheckBox();
            this.CB_Styles = new System.Windows.Forms.ComboBox();
            this.tb_counter = new System.Windows.Forms.TrackBar();
            this.lb_counttracks = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.RB_top100 = new System.Windows.Forms.RadioButton();
            this.RB_Tracks = new System.Windows.Forms.RadioButton();
            this.Btn_DeleteTrackFromSelectedList = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_counter)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список треков из файла:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Сообщение к посту:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(359, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(314, 64);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Жанр:\nRelease:";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "chart";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.Title = "Выберите файл чарта с треками";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 51);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(326, 156);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Нажмите \"Парсер\"";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "Image";
            this.openFileDialog2.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            this.openFileDialog2.Title = "Выберите фотографию";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Превью картинки:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 505);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(126, 18);
            this.progressBar1.TabIndex = 23;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(359, 527);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(167, 20);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 550);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "label6 - LOG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Результаты поиска:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(326, 121);
            this.listBox1.TabIndex = 30;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(0, 175);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(153, 17);
            this.radioButton1.TabIndex = 34;
            this.radioButton1.Text = "Загрузить картинку с ПК";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(0, 198);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(234, 17);
            this.radioButton2.TabIndex = 35;
            this.radioButton2.Text = "Добавить картинку по ПРЯМОЙ ссылке:";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1, 221);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 20);
            this.textBox3.TabIndex = 37;
            // 
            // RB_Manual
            // 
            this.RB_Manual.AutoSize = true;
            this.RB_Manual.Location = new System.Drawing.Point(3, 153);
            this.RB_Manual.Name = "RB_Manual";
            this.RB_Manual.Size = new System.Drawing.Size(67, 17);
            this.RB_Manual.TabIndex = 39;
            this.RB_Manual.Text = "Вручную";
            this.RB_Manual.UseVisualStyleBackColor = true;
            // 
            // LstBox_AddedTracks
            // 
            this.LstBox_AddedTracks.FormattingEnabled = true;
            this.LstBox_AddedTracks.Location = new System.Drawing.Point(359, 382);
            this.LstBox_AddedTracks.Name = "LstBox_AddedTracks";
            this.LstBox_AddedTracks.Size = new System.Drawing.Size(314, 121);
            this.LstBox_AddedTracks.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(356, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Вложка треков ";
            // 
            // PB_Download
            // 
            this.PB_Download.Location = new System.Drawing.Point(12, 527);
            this.PB_Download.Name = "PB_Download";
            this.PB_Download.Size = new System.Drawing.Size(326, 23);
            this.PB_Download.TabIndex = 46;
            this.PB_Download.Click += new System.EventHandler(this.PB_Download_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.BT_Repost);
            this.panel1.Controls.Add(this.BT_PlayPause);
            this.panel1.Controls.Add(this.RB_Manual);
            this.panel1.Controls.Add(this.RB_Auto);
            this.panel1.Controls.Add(this.BT_ManualParser);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(15, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 201);
            this.panel1.TabIndex = 49;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(245, 177);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 60;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // BT_Repost
            // 
            this.BT_Repost.Location = new System.Drawing.Point(58, 130);
            this.BT_Repost.Name = "BT_Repost";
            this.BT_Repost.Size = new System.Drawing.Size(75, 23);
            this.BT_Repost.TabIndex = 58;
            this.BT_Repost.Text = "Download";
            this.BT_Repost.UseVisualStyleBackColor = true;
            this.BT_Repost.Visible = false;
            this.BT_Repost.Click += new System.EventHandler(this.BT_Repost_Click);
            // 
            // BT_PlayPause
            // 
            this.BT_PlayPause.Image = ((System.Drawing.Image)(resources.GetObject("BT_PlayPause.Image")));
            this.BT_PlayPause.Location = new System.Drawing.Point(143, 130);
            this.BT_PlayPause.Name = "BT_PlayPause";
            this.BT_PlayPause.Size = new System.Drawing.Size(24, 23);
            this.BT_PlayPause.TabIndex = 59;
            this.BT_PlayPause.UseVisualStyleBackColor = true;
            this.BT_PlayPause.Visible = false;
            this.BT_PlayPause.Click += new System.EventHandler(this.BT_PlayPause_Click);
            // 
            // RB_Auto
            // 
            this.RB_Auto.AutoSize = true;
            this.RB_Auto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RB_Auto.Location = new System.Drawing.Point(3, 130);
            this.RB_Auto.Name = "RB_Auto";
            this.RB_Auto.Size = new System.Drawing.Size(49, 17);
            this.RB_Auto.TabIndex = 38;
            this.RB_Auto.Text = "Авто";
            this.RB_Auto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.RB_Auto.UseVisualStyleBackColor = true;
            // 
            // BT_ManualParser
            // 
            this.BT_ManualParser.Location = new System.Drawing.Point(0, 173);
            this.BT_ManualParser.Name = "BT_ManualParser";
            this.BT_ManualParser.Size = new System.Drawing.Size(67, 23);
            this.BT_ManualParser.TabIndex = 52;
            this.BT_ManualParser.Text = "GetAudio";
            this.BT_ManualParser.UseVisualStyleBackColor = true;
            this.BT_ManualParser.Visible = false;
            this.BT_ManualParser.Click += new System.EventHandler(this.BT_ManualParser_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(191, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 23);
            this.button3.TabIndex = 40;
            this.button3.Text = "Добавить во вложку";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.BTN_DelImageFrom);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(359, 122);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 241);
            this.panel2.TabIndex = 50;
            // 
            // BTN_DelImageFrom
            // 
            this.BTN_DelImageFrom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_DelImageFrom.Image = ((System.Drawing.Image)(resources.GetObject("BTN_DelImageFrom.Image")));
            this.BTN_DelImageFrom.Location = new System.Drawing.Point(293, 0);
            this.BTN_DelImageFrom.Name = "BTN_DelImageFrom";
            this.BTN_DelImageFrom.Size = new System.Drawing.Size(22, 23);
            this.BTN_DelImageFrom.TabIndex = 48;
            this.BTN_DelImageFrom.UseVisualStyleBackColor = false;
            this.BTN_DelImageFrom.Click += new System.EventHandler(this.BTN_DelImageFrom_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(189, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Открыть картинку";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(314, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(359, 509);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Отложить?";
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LB_version
            // 
            this.LB_version.AutoSize = true;
            this.LB_version.BackColor = System.Drawing.SystemColors.MenuBar;
            this.LB_version.Location = new System.Drawing.Point(9, 553);
            this.LB_version.Name = "LB_version";
            this.LB_version.Size = new System.Drawing.Size(42, 13);
            this.LB_version.TabIndex = 51;
            this.LB_version.Text = "Version";
            this.LB_version.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMENU_File,
            this.парсерToolStripMenuItem,
            this.TSMENU_Settings,
            this.TSMENU_About,
            this.repostToolStripMenuItem,
            this.измененияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(683, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMENU_File
            // 
            this.TSMENU_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMENU_Save,
            this.TSMENU_Reset});
            this.TSMENU_File.Image = ((System.Drawing.Image)(resources.GetObject("TSMENU_File.Image")));
            this.TSMENU_File.Name = "TSMENU_File";
            this.TSMENU_File.Size = new System.Drawing.Size(64, 20);
            this.TSMENU_File.Text = "Файл";
            this.TSMENU_File.Visible = false;
            this.TSMENU_File.Click += new System.EventHandler(this.TSMENU_File_Click);
            // 
            // TSMENU_Save
            // 
            this.TSMENU_Save.Name = "TSMENU_Save";
            this.TSMENU_Save.Size = new System.Drawing.Size(160, 22);
            this.TSMENU_Save.Text = "Отложенные";
            this.TSMENU_Save.Visible = false;
            this.TSMENU_Save.Click += new System.EventHandler(this.TSMENU_Save_Click);
            // 
            // TSMENU_Reset
            // 
            this.TSMENU_Reset.Name = "TSMENU_Reset";
            this.TSMENU_Reset.Size = new System.Drawing.Size(160, 22);
            this.TSMENU_Reset.Text = "Предложенные";
            this.TSMENU_Reset.Click += new System.EventHandler(this.TSMENU_Reset_Click);
            // 
            // парсерToolStripMenuItem
            // 
            this.парсерToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("парсерToolStripMenuItem.Image")));
            this.парсерToolStripMenuItem.Name = "парсерToolStripMenuItem";
            this.парсерToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.парсерToolStripMenuItem.Text = "Парсер";
            this.парсерToolStripMenuItem.Click += new System.EventHandler(this.парсерToolStripMenuItem_Click);
            // 
            // TSMENU_Settings
            // 
            this.TSMENU_Settings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSettToolStripMenuItem,
            this.ResetSettToolStripMenuItem});
            this.TSMENU_Settings.Image = ((System.Drawing.Image)(resources.GetObject("TSMENU_Settings.Image")));
            this.TSMENU_Settings.Name = "TSMENU_Settings";
            this.TSMENU_Settings.Size = new System.Drawing.Size(95, 20);
            this.TSMENU_Settings.Text = "Настройки";
            this.TSMENU_Settings.Click += new System.EventHandler(this.TSMENU_Settings_Click);
            // 
            // SaveSettToolStripMenuItem
            // 
            this.SaveSettToolStripMenuItem.Name = "SaveSettToolStripMenuItem";
            this.SaveSettToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.SaveSettToolStripMenuItem.Text = "Задать";
            this.SaveSettToolStripMenuItem.Click += new System.EventHandler(this.SaveSettToolStripMenuItem_Click);
            // 
            // ResetSettToolStripMenuItem
            // 
            this.ResetSettToolStripMenuItem.Name = "ResetSettToolStripMenuItem";
            this.ResetSettToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ResetSettToolStripMenuItem.Text = "Сбросить";
            this.ResetSettToolStripMenuItem.Click += new System.EventHandler(this.ResetSettToolStripMenuItem_Click);
            // 
            // TSMENU_About
            // 
            this.TSMENU_About.Image = ((System.Drawing.Image)(resources.GetObject("TSMENU_About.Image")));
            this.TSMENU_About.Name = "TSMENU_About";
            this.TSMENU_About.Size = new System.Drawing.Size(110, 20);
            this.TSMENU_About.Text = "О программе";
            this.TSMENU_About.Click += new System.EventHandler(this.TSMENU_About_Click);
            // 
            // repostToolStripMenuItem
            // 
            this.repostToolStripMenuItem.Image = global::vkaudioposter.Properties.Resources.listen;
            this.repostToolStripMenuItem.Name = "repostToolStripMenuItem";
            this.repostToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.repostToolStripMenuItem.Text = "AutoRepost";
            this.repostToolStripMenuItem.Click += new System.EventHandler(this.repostToolStripMenuItem_Click);
            // 
            // измененияToolStripMenuItem
            // 
            this.измененияToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("измененияToolStripMenuItem.Image")));
            this.измененияToolStripMenuItem.Name = "измененияToolStripMenuItem";
            this.измененияToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.измененияToolStripMenuItem.Text = "Изменения";
            this.измененияToolStripMenuItem.Visible = false;
            this.измененияToolStripMenuItem.Click += new System.EventHandler(this.измененияToolStripMenuItem_Click);
            // 
            // CHB_ToAudio
            // 
            this.CHB_ToAudio.AutoSize = true;
            this.CHB_ToAudio.Location = new System.Drawing.Point(436, 509);
            this.CHB_ToAudio.Name = "CHB_ToAudio";
            this.CHB_ToAudio.Size = new System.Drawing.Size(107, 17);
            this.CHB_ToAudio.TabIndex = 54;
            this.CHB_ToAudio.Text = "Аудио в группу?";
            this.CHB_ToAudio.UseVisualStyleBackColor = true;
            // 
            // chk_repost
            // 
            this.chk_repost.AutoSize = true;
            this.chk_repost.Location = new System.Drawing.Point(270, 504);
            this.chk_repost.Name = "chk_repost";
            this.chk_repost.Size = new System.Drawing.Size(68, 17);
            this.chk_repost.TabIndex = 55;
            this.chk_repost.Text = "Репост?";
            this.chk_repost.UseVisualStyleBackColor = true;
            this.chk_repost.CheckedChanged += new System.EventHandler(this.chk_repost_CheckedChanged);
            // 
            // chk_openbrowser
            // 
            this.chk_openbrowser.AutoSize = true;
            this.chk_openbrowser.Location = new System.Drawing.Point(144, 504);
            this.chk_openbrowser.Name = "chk_openbrowser";
            this.chk_openbrowser.Size = new System.Drawing.Size(120, 17);
            this.chk_openbrowser.TabIndex = 56;
            this.chk_openbrowser.Text = "Открыть браузер?";
            this.chk_openbrowser.UseVisualStyleBackColor = true;
            // 
            // CB_Styles
            // 
            this.CB_Styles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Styles.FormattingEnabled = true;
            this.CB_Styles.Location = new System.Drawing.Point(178, 27);
            this.CB_Styles.Name = "CB_Styles";
            this.CB_Styles.Size = new System.Drawing.Size(163, 21);
            this.CB_Styles.Sorted = true;
            this.CB_Styles.TabIndex = 57;
            this.CB_Styles.Visible = false;
            this.CB_Styles.SelectedIndexChanged += new System.EventHandler(this.CB_Styles_SelectedIndexChanged);
            // 
            // tb_counter
            // 
            this.tb_counter.LargeChange = 20;
            this.tb_counter.Location = new System.Drawing.Point(18, 213);
            this.tb_counter.Maximum = 100;
            this.tb_counter.Minimum = 10;
            this.tb_counter.Name = "tb_counter";
            this.tb_counter.Size = new System.Drawing.Size(184, 45);
            this.tb_counter.SmallChange = 10;
            this.tb_counter.TabIndex = 58;
            this.tb_counter.Value = 10;
            this.tb_counter.Visible = false;
            this.tb_counter.Scroll += new System.EventHandler(this.tb_counter_Scroll);
            // 
            // lb_counttracks
            // 
            this.lb_counttracks.AutoSize = true;
            this.lb_counttracks.Location = new System.Drawing.Point(198, 218);
            this.lb_counttracks.Name = "lb_counttracks";
            this.lb_counttracks.Size = new System.Drawing.Size(0, 13);
            this.lb_counttracks.TabIndex = 59;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.RB_top100);
            this.panel3.Controls.Add(this.RB_Tracks);
            this.panel3.Location = new System.Drawing.Point(15, 244);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 34);
            this.panel3.TabIndex = 60;
            // 
            // RB_top100
            // 
            this.RB_top100.AutoSize = true;
            this.RB_top100.Location = new System.Drawing.Point(82, 14);
            this.RB_top100.Name = "RB_top100";
            this.RB_top100.Size = new System.Drawing.Size(65, 17);
            this.RB_top100.TabIndex = 1;
            this.RB_top100.TabStop = true;
            this.RB_top100.Text = "TOP100";
            this.RB_top100.UseVisualStyleBackColor = true;
            this.RB_top100.Visible = false;
            this.RB_top100.CheckedChanged += new System.EventHandler(this.RB_top100_CheckedChanged);
            // 
            // RB_Tracks
            // 
            this.RB_Tracks.AutoSize = true;
            this.RB_Tracks.Location = new System.Drawing.Point(13, 14);
            this.RB_Tracks.Name = "RB_Tracks";
            this.RB_Tracks.Size = new System.Drawing.Size(58, 17);
            this.RB_Tracks.TabIndex = 0;
            this.RB_Tracks.TabStop = true;
            this.RB_Tracks.Text = "Tracks";
            this.RB_Tracks.UseVisualStyleBackColor = true;
            this.RB_Tracks.Visible = false;
            this.RB_Tracks.CheckedChanged += new System.EventHandler(this.RB_Tracks_CheckedChanged);
            // 
            // Btn_DeleteTrackFromSelectedList
            // 
            this.Btn_DeleteTrackFromSelectedList.Image = ((System.Drawing.Image)(resources.GetObject("Btn_DeleteTrackFromSelectedList.Image")));
            this.Btn_DeleteTrackFromSelectedList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_DeleteTrackFromSelectedList.Location = new System.Drawing.Point(548, 505);
            this.Btn_DeleteTrackFromSelectedList.Name = "Btn_DeleteTrackFromSelectedList";
            this.Btn_DeleteTrackFromSelectedList.Size = new System.Drawing.Size(126, 23);
            this.Btn_DeleteTrackFromSelectedList.TabIndex = 42;
            this.Btn_DeleteTrackFromSelectedList.Text = "Удалить из вложки";
            this.Btn_DeleteTrackFromSelectedList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_DeleteTrackFromSelectedList.UseVisualStyleBackColor = true;
            this.Btn_DeleteTrackFromSelectedList.Click += new System.EventHandler(this.Btn_DeleteTrackFromSelectedList_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Control;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(571, 534);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(102, 30);
            this.button6.TabIndex = 20;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.btPublish_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(609, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(62, 23);
            this.button5.TabIndex = 19;
            this.button5.Text = "Parser";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(239, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Поиск треков";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(683, 566);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lb_counttracks);
            this.Controls.Add(this.tb_counter);
            this.Controls.Add(this.CB_Styles);
            this.Controls.Add(this.chk_openbrowser);
            this.Controls.Add(this.chk_repost);
            this.Controls.Add(this.CHB_ToAudio);
            this.Controls.Add(this.LB_version);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PB_Download);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Btn_DeleteTrackFromSelectedList);
            this.Controls.Add(this.LstBox_AddedTracks);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Volume Music Parser";
            this.TransparencyKey = System.Drawing.SystemColors.WindowFrame;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_counter)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton RB_Auto;
        private System.Windows.Forms.RadioButton RB_Manual;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox LstBox_AddedTracks;
        private System.Windows.Forms.Button Btn_DeleteTrackFromSelectedList;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ProgressBar PB_Download;
        private System.Windows.Forms.Button BTN_DelImageFrom;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label LB_version;
        private System.Windows.Forms.Button BT_ManualParser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMENU_File;
        private System.Windows.Forms.ToolStripMenuItem TSMENU_About;
        private System.Windows.Forms.ToolStripMenuItem TSMENU_Save;
        private System.Windows.Forms.ToolStripMenuItem TSMENU_Reset;
        private System.Windows.Forms.ToolStripMenuItem TSMENU_Settings;
        private System.Windows.Forms.ToolStripMenuItem парсерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem измененияToolStripMenuItem;
        private System.Windows.Forms.CheckBox CHB_ToAudio;
        private System.Windows.Forms.CheckBox chk_repost;
        private System.Windows.Forms.CheckBox chk_openbrowser;
        private System.Windows.Forms.ComboBox CB_Styles;
        private System.Windows.Forms.Button BT_Repost;
        private System.Windows.Forms.Button BT_PlayPause;
        private System.Windows.Forms.ToolStripMenuItem repostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveSettToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetSettToolStripMenuItem;
        private System.Windows.Forms.TrackBar tb_counter;
        private System.Windows.Forms.Label lb_counttracks;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton RB_top100;
        protected System.Windows.Forms.RadioButton RB_Tracks;
    }
}

