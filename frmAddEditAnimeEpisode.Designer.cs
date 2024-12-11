using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmAddEditAnimeEpisode
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderThickness = 10;
            Color borderColor = Color.DarkCyan;

            // Draw border
            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Forces the form to redraw the border on resize
        }

        private void InitializeComponent()
        {
            this.lblAnime = new System.Windows.Forms.Label();
            this.cmbAnime = new System.Windows.Forms.ComboBox();
            this.lblEpisodeNumber = new System.Windows.Forms.Label();
            this.txtEpisodeNumber = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.btnBrowseVideo = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnime
            // 
            this.lblAnime.AutoSize = true;
            this.lblAnime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnime.Location = new System.Drawing.Point(20, 90);
            this.lblAnime.Name = "lblAnime";
            this.lblAnime.Size = new System.Drawing.Size(63, 23);
            this.lblAnime.TabIndex = 0;
            this.lblAnime.Text = "Anime:";
            // 
            // cmbAnime
            // 
            this.cmbAnime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnime.FormattingEnabled = true;
            this.cmbAnime.Location = new System.Drawing.Point(175, 87);
            this.cmbAnime.Name = "cmbAnime";
            this.cmbAnime.Size = new System.Drawing.Size(250, 31);
            this.cmbAnime.TabIndex = 1;
            // 
            // lblEpisodeNumber
            // 
            this.lblEpisodeNumber.AutoSize = true;
            this.lblEpisodeNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEpisodeNumber.Location = new System.Drawing.Point(20, 140);
            this.lblEpisodeNumber.Name = "lblEpisodeNumber";
            this.lblEpisodeNumber.Size = new System.Drawing.Size(141, 23);
            this.lblEpisodeNumber.TabIndex = 2;
            this.lblEpisodeNumber.Text = "Episode Number:";
            // 
            // txtEpisodeNumber
            // 
            this.txtEpisodeNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpisodeNumber.Location = new System.Drawing.Point(175, 137);
            this.txtEpisodeNumber.Name = "txtEpisodeNumber";
            this.txtEpisodeNumber.Size = new System.Drawing.Size(250, 30);
            this.txtEpisodeNumber.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 190);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(46, 23);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(175, 187);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 30);
            this.txtTitle.TabIndex = 5;
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReleaseDate.Location = new System.Drawing.Point(20, 240);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(112, 23);
            this.lblReleaseDate.TabIndex = 6;
            this.lblReleaseDate.Text = "Release Date:";
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReleaseDate.Location = new System.Drawing.Point(175, 237);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(250, 30);
            this.dtpReleaseDate.TabIndex = 7;
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoPath.Location = new System.Drawing.Point(20, 290);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(97, 23);
            this.lblVideoPath.TabIndex = 8;
            this.lblVideoPath.Text = "Video Path:";
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoPath.Location = new System.Drawing.Point(175, 287);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(250, 30);
            this.txtVideoPath.TabIndex = 9;
            // 
            // btnBrowseVideo
            // 
            this.btnBrowseVideo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseVideo.Location = new System.Drawing.Point(435, 287);
            this.btnBrowseVideo.Name = "btnBrowseVideo";
            this.btnBrowseVideo.Size = new System.Drawing.Size(80, 30);
            this.btnBrowseVideo.TabIndex = 10;
            this.btnBrowseVideo.Text = "Browse";
            this.btnBrowseVideo.UseVisualStyleBackColor = true;
            this.btnBrowseVideo.Click += new System.EventHandler(this.btnBrowseVideo_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(175, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MintCream;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(325, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(17, 16);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 18);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 13;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(3, 4);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(515, 40);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 14;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // frmAddEditAnimeEpisode
            // 
            this.ClientSize = new System.Drawing.Size(522, 450);
            this.ControlBox = false;
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowseVideo);
            this.Controls.Add(this.txtVideoPath);
            this.Controls.Add(this.lblVideoPath);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtEpisodeNumber);
            this.Controls.Add(this.lblEpisodeNumber);
            this.Controls.Add(this.cmbAnime);
            this.Controls.Add(this.lblAnime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditAnimeEpisode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Episode";
            this.Load += new System.EventHandler(this.frmAddEditAnimeEpisode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblAnime;
        private System.Windows.Forms.ComboBox cmbAnime;
        private System.Windows.Forms.Label lblEpisodeNumber;
        private System.Windows.Forms.TextBox txtEpisodeNumber;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label lblVideoPath;
        private System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.Button btnBrowseVideo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picHeader;
    }
}
