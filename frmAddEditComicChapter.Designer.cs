using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmAddEditComicChapter
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblComic;
        private ComboBox cmbComic;
        private Label lblChapterNumber;
        private TextBox txtChapterNumber;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblReleaseDate;
        private DateTimePicker dtpReleaseDate;
        private Button btnSave;
        private Button btnCancel;
        private PictureBox picClose;
        private PictureBox picHeader;

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
            this.lblComic = new System.Windows.Forms.Label();
            this.cmbComic = new System.Windows.Forms.ComboBox();
            this.lblChapterNumber = new System.Windows.Forms.Label();
            this.txtChapterNumber = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComic
            // 
            this.lblComic.AutoSize = true;
            this.lblComic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblComic.Location = new System.Drawing.Point(30, 79);
            this.lblComic.Name = "lblComic";
            this.lblComic.Size = new System.Drawing.Size(65, 23);
            this.lblComic.TabIndex = 0;
            this.lblComic.Text = "Comic:";
            // 
            // cmbComic
            // 
            this.cmbComic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComic.FormattingEnabled = true;
            this.cmbComic.Location = new System.Drawing.Point(200, 79);
            this.cmbComic.Name = "cmbComic";
            this.cmbComic.Size = new System.Drawing.Size(200, 31);
            this.cmbComic.TabIndex = 1;
            // 
            // lblChapterNumber
            // 
            this.lblChapterNumber.AutoSize = true;
            this.lblChapterNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChapterNumber.Location = new System.Drawing.Point(30, 119);
            this.lblChapterNumber.Name = "lblChapterNumber";
            this.lblChapterNumber.Size = new System.Drawing.Size(151, 23);
            this.lblChapterNumber.TabIndex = 2;
            this.lblChapterNumber.Text = "Chapter Number:";
            // 
            // txtChapterNumber
            // 
            this.txtChapterNumber.Location = new System.Drawing.Point(200, 119);
            this.txtChapterNumber.Name = "txtChapterNumber";
            this.txtChapterNumber.Size = new System.Drawing.Size(200, 30);
            this.txtChapterNumber.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 159);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(51, 23);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(200, 159);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(200, 30);
            this.txtTitle.TabIndex = 5;
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReleaseDate.Location = new System.Drawing.Point(30, 199);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(117, 23);
            this.lblReleaseDate.TabIndex = 6;
            this.lblReleaseDate.Text = "Release Date:";
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(200, 199);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(200, 30);
            this.dtpReleaseDate.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(200, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MintCream;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(310, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(12, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 10;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(442, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 11;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // frmAddEditComicChapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(442, 321);
            this.ControlBox = false;
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtChapterNumber);
            this.Controls.Add(this.lblChapterNumber);
            this.Controls.Add(this.cmbComic);
            this.Controls.Add(this.lblComic);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditComicChapter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
