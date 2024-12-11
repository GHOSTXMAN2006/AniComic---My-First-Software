using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmManageComicChapters
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
            this.lblComic = new System.Windows.Forms.Label();
            this.cmbComic = new System.Windows.Forms.ComboBox();
            this.dgvChapters = new System.Windows.Forms.DataGridView();
            this.btnAddChapter = new System.Windows.Forms.Button();
            this.btnEditChapter = new System.Windows.Forms.Button();
            this.btnDeleteChapter = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnAddContent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComic
            // 
            this.lblComic.AutoSize = true;
            this.lblComic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblComic.Location = new System.Drawing.Point(24, 129);
            this.lblComic.Name = "lblComic";
            this.lblComic.Size = new System.Drawing.Size(65, 23);
            this.lblComic.TabIndex = 0;
            this.lblComic.Text = "Comic:";
            // 
            // cmbComic
            // 
            this.cmbComic.BackColor = System.Drawing.Color.DimGray;
            this.cmbComic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComic.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbComic.FormattingEnabled = true;
            this.cmbComic.Location = new System.Drawing.Point(100, 125);
            this.cmbComic.Name = "cmbComic";
            this.cmbComic.Size = new System.Drawing.Size(300, 31);
            this.cmbComic.TabIndex = 1;
            this.cmbComic.SelectedIndexChanged += new System.EventHandler(this.cmbComic_SelectedIndexChanged);
            // 
            // dgvChapters
            // 
            this.dgvChapters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChapters.Location = new System.Drawing.Point(28, 179);
            this.dgvChapters.Name = "dgvChapters";
            this.dgvChapters.RowHeadersWidth = 51;
            this.dgvChapters.Size = new System.Drawing.Size(800, 400);
            this.dgvChapters.TabIndex = 2;
            // 
            // btnAddChapter
            // 
            this.btnAddChapter.BackColor = System.Drawing.Color.DimGray;
            this.btnAddChapter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddChapter.Location = new System.Drawing.Point(850, 179);
            this.btnAddChapter.Name = "btnAddChapter";
            this.btnAddChapter.Size = new System.Drawing.Size(150, 40);
            this.btnAddChapter.TabIndex = 3;
            this.btnAddChapter.Text = "Add Chapter";
            this.btnAddChapter.UseVisualStyleBackColor = false;
            this.btnAddChapter.Click += new System.EventHandler(this.btnAddChapter_Click);
            // 
            // btnEditChapter
            // 
            this.btnEditChapter.BackColor = System.Drawing.Color.DimGray;
            this.btnEditChapter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnEditChapter.Location = new System.Drawing.Point(850, 229);
            this.btnEditChapter.Name = "btnEditChapter";
            this.btnEditChapter.Size = new System.Drawing.Size(150, 40);
            this.btnEditChapter.TabIndex = 4;
            this.btnEditChapter.Text = "Edit Chapter";
            this.btnEditChapter.UseVisualStyleBackColor = false;
            this.btnEditChapter.Click += new System.EventHandler(this.btnEditChapter_Click);
            // 
            // btnDeleteChapter
            // 
            this.btnDeleteChapter.BackColor = System.Drawing.Color.DimGray;
            this.btnDeleteChapter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteChapter.Location = new System.Drawing.Point(850, 279);
            this.btnDeleteChapter.Name = "btnDeleteChapter";
            this.btnDeleteChapter.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteChapter.TabIndex = 5;
            this.btnDeleteChapter.Text = "Delete Chapter";
            this.btnDeleteChapter.UseVisualStyleBackColor = false;
            this.btnDeleteChapter.Click += new System.EventHandler(this.btnDeleteChapter_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(10, 10);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 6;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(34, 10);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 7;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(1040, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 8;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(312, 39);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(398, 45);
            this.labelTitle.TabIndex = 9;
            this.labelTitle.Text = "Manage Comic Chapters";
            // 
            // btnAddContent
            // 
            this.btnAddContent.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAddContent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddContent.Location = new System.Drawing.Point(850, 329);
            this.btnAddContent.Name = "btnAddContent";
            this.btnAddContent.Size = new System.Drawing.Size(150, 40);
            this.btnAddContent.TabIndex = 10;
            this.btnAddContent.Text = "Add content";
            this.btnAddContent.UseVisualStyleBackColor = false;
            this.btnAddContent.Click += new System.EventHandler(this.btnAddContent_Click);
            // 
            // frmManageComicChapters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1040, 628);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddContent);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblComic);
            this.Controls.Add(this.cmbComic);
            this.Controls.Add(this.dgvChapters);
            this.Controls.Add(this.btnAddChapter);
            this.Controls.Add(this.btnEditChapter);
            this.Controls.Add(this.btnDeleteChapter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageComicChapters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Comic Chapters";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChapters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblComic;
        private System.Windows.Forms.ComboBox cmbComic;
        private System.Windows.Forms.DataGridView dgvChapters;
        private System.Windows.Forms.Button btnAddChapter;
        private System.Windows.Forms.Button btnEditChapter;
        private System.Windows.Forms.Button btnDeleteChapter;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.Label labelTitle;
        private Button btnAddContent;
    }
}
