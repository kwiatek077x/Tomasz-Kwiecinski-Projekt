namespace Mp3Player
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
            this.listaPlikow = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.vsb_Volume = new System.Windows.Forms.VScrollBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lb_SongCur = new System.Windows.Forms.Label();
            this.lb_SongEnd = new System.Windows.Forms.Label();
            this.vsb_Bass = new System.Windows.Forms.VScrollBar();
            this.vsb_Treble = new System.Windows.Forms.VScrollBar();
            this.lb_Volume = new System.Windows.Forms.Label();
            this.lb_Bass = new System.Windows.Forms.Label();
            this.lb_Treble = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_curSongName = new System.Windows.Forms.Label();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.pb_Delete = new System.Windows.Forms.PictureBox();
            this.pb_Repeat = new System.Windows.Forms.PictureBox();
            this.pb_LoadPlaylist = new System.Windows.Forms.PictureBox();
            this.pb_SavePlaylist = new System.Windows.Forms.PictureBox();
            this.pb_OpenFile = new System.Windows.Forms.PictureBox();
            this.pb_Hide = new System.Windows.Forms.PictureBox();
            this.pb_STEnd = new System.Windows.Forms.PictureBox();
            this.pb_STStart = new System.Windows.Forms.PictureBox();
            this.pb_PlayBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Repeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LoadPlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_SavePlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_OpenFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_STEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_STStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PlayBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // listaPlikow
            // 
            this.listaPlikow.FormattingEnabled = true;
            this.listaPlikow.Location = new System.Drawing.Point(13, 130);
            this.listaPlikow.Name = "listaPlikow";
            this.listaPlikow.Size = new System.Drawing.Size(150, 160);
            this.listaPlikow.TabIndex = 0;
            this.listaPlikow.SelectedIndexChanged += new System.EventHandler(this.listaPlikow_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Pliki MP3|*.mp3|Pliki WAV|*.wav";
            this.openFileDialog1.Multiselect = true;
            // 
            // vsb_Volume
            // 
            this.vsb_Volume.Location = new System.Drawing.Point(191, 170);
            this.vsb_Volume.Maximum = 109;
            this.vsb_Volume.Name = "vsb_Volume";
            this.vsb_Volume.Size = new System.Drawing.Size(17, 120);
            this.vsb_Volume.TabIndex = 5;
            this.vsb_Volume.ValueChanged += new System.EventHandler(this.vsb_Volume_ValueChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 32);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(309, 17);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.MouseCaptureChanged += new System.EventHandler(this.trackBar1_MouseCaptureChanged);
            // 
            // lb_SongCur
            // 
            this.lb_SongCur.AutoSize = true;
            this.lb_SongCur.Location = new System.Drawing.Point(9, 52);
            this.lb_SongCur.Name = "lb_SongCur";
            this.lb_SongCur.Size = new System.Drawing.Size(28, 13);
            this.lb_SongCur.TabIndex = 8;
            this.lb_SongCur.Text = "0:00";
            this.lb_SongCur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_SongEnd
            // 
            this.lb_SongEnd.AutoSize = true;
            this.lb_SongEnd.Location = new System.Drawing.Point(293, 52);
            this.lb_SongEnd.Name = "lb_SongEnd";
            this.lb_SongEnd.Size = new System.Drawing.Size(28, 13);
            this.lb_SongEnd.TabIndex = 9;
            this.lb_SongEnd.Text = "0:00";
            // 
            // vsb_Bass
            // 
            this.vsb_Bass.Location = new System.Drawing.Point(236, 170);
            this.vsb_Bass.Maximum = 109;
            this.vsb_Bass.Name = "vsb_Bass";
            this.vsb_Bass.Size = new System.Drawing.Size(17, 120);
            this.vsb_Bass.TabIndex = 5;
            this.vsb_Bass.Value = 100;
            this.vsb_Bass.ValueChanged += new System.EventHandler(this.vsb_Bass_ValueChanged);
            // 
            // vsb_Treble
            // 
            this.vsb_Treble.Location = new System.Drawing.Point(280, 170);
            this.vsb_Treble.Name = "vsb_Treble";
            this.vsb_Treble.Size = new System.Drawing.Size(17, 120);
            this.vsb_Treble.TabIndex = 11;
            this.vsb_Treble.Value = 100;
            this.vsb_Treble.ValueChanged += new System.EventHandler(this.vsb_T_ValueChanged);
            // 
            // lb_Volume
            // 
            this.lb_Volume.AutoSize = true;
            this.lb_Volume.Location = new System.Drawing.Point(179, 297);
            this.lb_Volume.Name = "lb_Volume";
            this.lb_Volume.Size = new System.Drawing.Size(42, 13);
            this.lb_Volume.TabIndex = 12;
            this.lb_Volume.Text = "Volume";
            this.lb_Volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Bass
            // 
            this.lb_Bass.AutoSize = true;
            this.lb_Bass.Location = new System.Drawing.Point(233, 297);
            this.lb_Bass.Name = "lb_Bass";
            this.lb_Bass.Size = new System.Drawing.Size(30, 13);
            this.lb_Bass.TabIndex = 13;
            this.lb_Bass.Text = "Bass";
            this.lb_Bass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Treble
            // 
            this.lb_Treble.AutoSize = true;
            this.lb_Treble.Location = new System.Drawing.Point(277, 297);
            this.lb_Treble.Name = "lb_Treble";
            this.lb_Treble.Size = new System.Drawing.Size(37, 13);
            this.lb_Treble.TabIndex = 14;
            this.lb_Treble.Text = "Treble";
            this.lb_Treble.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_curSongName
            // 
            this.lb_curSongName.Location = new System.Drawing.Point(9, 10);
            this.lb_curSongName.Name = "lb_curSongName";
            this.lb_curSongName.Size = new System.Drawing.Size(312, 19);
            this.lb_curSongName.TabIndex = 15;
            this.lb_curSongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerScroll
            // 
            this.timerScroll.Interval = 400;
            this.timerScroll.Tick += new System.EventHandler(this.timerScroll_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Playlists|*.txt";
            this.saveFileDialog1.InitialDirectory = "\\Playlists";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "Playlist";
            this.openFileDialog2.Filter = "Playlists|*.txt";
            // 
            // pb_Delete
            // 
            this.pb_Delete.Image = global::Mp3Player.Properties.Resources.Delete;
            this.pb_Delete.Location = new System.Drawing.Point(12, 94);
            this.pb_Delete.Name = "pb_Delete";
            this.pb_Delete.Size = new System.Drawing.Size(30, 30);
            this.pb_Delete.TabIndex = 24;
            this.pb_Delete.TabStop = false;
            this.pb_Delete.Visible = false;
            this.pb_Delete.Click += new System.EventHandler(this.pb_Delete_Click);
            // 
            // pb_Repeat
            // 
            this.pb_Repeat.Location = new System.Drawing.Point(182, 130);
            this.pb_Repeat.Name = "pb_Repeat";
            this.pb_Repeat.Size = new System.Drawing.Size(34, 28);
            this.pb_Repeat.TabIndex = 23;
            this.pb_Repeat.TabStop = false;
            this.pb_Repeat.Click += new System.EventHandler(this.pb_Repeat_Click);
            // 
            // pb_LoadPlaylist
            // 
            this.pb_LoadPlaylist.Image = global::Mp3Player.Properties.Resources.Load;
            this.pb_LoadPlaylist.Location = new System.Drawing.Point(133, 312);
            this.pb_LoadPlaylist.Name = "pb_LoadPlaylist";
            this.pb_LoadPlaylist.Size = new System.Drawing.Size(30, 30);
            this.pb_LoadPlaylist.TabIndex = 22;
            this.pb_LoadPlaylist.TabStop = false;
            this.pb_LoadPlaylist.Click += new System.EventHandler(this.pb_LoadPlaylist_Click);
            // 
            // pb_SavePlaylist
            // 
            this.pb_SavePlaylist.Image = global::Mp3Player.Properties.Resources.Save;
            this.pb_SavePlaylist.Location = new System.Drawing.Point(72, 312);
            this.pb_SavePlaylist.Name = "pb_SavePlaylist";
            this.pb_SavePlaylist.Size = new System.Drawing.Size(30, 30);
            this.pb_SavePlaylist.TabIndex = 21;
            this.pb_SavePlaylist.TabStop = false;
            this.pb_SavePlaylist.Click += new System.EventHandler(this.pb_SavePlaylist_Click);
            // 
            // pb_OpenFile
            // 
            this.pb_OpenFile.Image = global::Mp3Player.Properties.Resources.AddFile;
            this.pb_OpenFile.Location = new System.Drawing.Point(13, 312);
            this.pb_OpenFile.Name = "pb_OpenFile";
            this.pb_OpenFile.Size = new System.Drawing.Size(30, 30);
            this.pb_OpenFile.TabIndex = 20;
            this.pb_OpenFile.TabStop = false;
            this.pb_OpenFile.Click += new System.EventHandler(this.btn_listaPlikow_Click);
            // 
            // pb_Hide
            // 
            this.pb_Hide.Location = new System.Drawing.Point(151, 88);
            this.pb_Hide.Name = "pb_Hide";
            this.pb_Hide.Size = new System.Drawing.Size(30, 30);
            this.pb_Hide.TabIndex = 19;
            this.pb_Hide.TabStop = false;
            this.pb_Hide.Click += new System.EventHandler(this.pb_Hide_Click);
            // 
            // pb_STEnd
            // 
            this.pb_STEnd.Image = global::Mp3Player.Properties.Resources.SkipToEnd;
            this.pb_STEnd.Location = new System.Drawing.Point(257, 55);
            this.pb_STEnd.Name = "pb_STEnd";
            this.pb_STEnd.Size = new System.Drawing.Size(30, 30);
            this.pb_STEnd.TabIndex = 18;
            this.pb_STEnd.TabStop = false;
            this.pb_STEnd.Click += new System.EventHandler(this.pb_STEnd_Click);
            // 
            // pb_STStart
            // 
            this.pb_STStart.Image = global::Mp3Player.Properties.Resources.SkipToStart;
            this.pb_STStart.Location = new System.Drawing.Point(43, 52);
            this.pb_STStart.Name = "pb_STStart";
            this.pb_STStart.Size = new System.Drawing.Size(30, 30);
            this.pb_STStart.TabIndex = 17;
            this.pb_STStart.TabStop = false;
            this.pb_STStart.Click += new System.EventHandler(this.pb_STStart_Click);
            // 
            // pb_PlayBtn
            // 
            this.pb_PlayBtn.Image = ((System.Drawing.Image)(resources.GetObject("pb_PlayBtn.Image")));
            this.pb_PlayBtn.Location = new System.Drawing.Point(151, 55);
            this.pb_PlayBtn.Name = "pb_PlayBtn";
            this.pb_PlayBtn.Size = new System.Drawing.Size(30, 30);
            this.pb_PlayBtn.TabIndex = 16;
            this.pb_PlayBtn.TabStop = false;
            this.pb_PlayBtn.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(334, 120);
            this.Controls.Add(this.pb_Delete);
            this.Controls.Add(this.pb_Repeat);
            this.Controls.Add(this.pb_LoadPlaylist);
            this.Controls.Add(this.pb_SavePlaylist);
            this.Controls.Add(this.pb_OpenFile);
            this.Controls.Add(this.pb_Hide);
            this.Controls.Add(this.pb_STEnd);
            this.Controls.Add(this.pb_STStart);
            this.Controls.Add(this.pb_PlayBtn);
            this.Controls.Add(this.lb_curSongName);
            this.Controls.Add(this.lb_Treble);
            this.Controls.Add(this.lb_Bass);
            this.Controls.Add(this.lb_Volume);
            this.Controls.Add(this.vsb_Treble);
            this.Controls.Add(this.vsb_Bass);
            this.Controls.Add(this.lb_SongEnd);
            this.Controls.Add(this.lb_SongCur);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.vsb_Volume);
            this.Controls.Add(this.listaPlikow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mp3Player";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Repeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_LoadPlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_SavePlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_OpenFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_STEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_STStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PlayBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listaPlikow;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.VScrollBar vsb_Volume;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lb_SongCur;
        private System.Windows.Forms.Label lb_SongEnd;
        private System.Windows.Forms.VScrollBar vsb_Bass;
        private System.Windows.Forms.VScrollBar vsb_Treble;
        private System.Windows.Forms.Label lb_Volume;
        private System.Windows.Forms.Label lb_Bass;
        private System.Windows.Forms.Label lb_Treble;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_curSongName;
        private System.Windows.Forms.PictureBox pb_PlayBtn;
        private System.Windows.Forms.PictureBox pb_STStart;
        private System.Windows.Forms.PictureBox pb_STEnd;
        private System.Windows.Forms.Timer timerScroll;
        private System.Windows.Forms.PictureBox pb_Hide;
        private System.Windows.Forms.PictureBox pb_OpenFile;
        private System.Windows.Forms.PictureBox pb_SavePlaylist;
        private System.Windows.Forms.PictureBox pb_LoadPlaylist;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.PictureBox pb_Repeat;
        private System.Windows.Forms.PictureBox pb_Delete;
    }
}

