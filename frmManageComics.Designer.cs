using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmManageComics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvComics;
        private System.Windows.Forms.Button btnAddComic;
        private System.Windows.Forms.Button btnEditComic;
        private System.Windows.Forms.Button btnDeleteComic;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

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

            int borderThickness = 5;
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
            this.dgvComics = new System.Windows.Forms.DataGridView();
            this.btnAddComic = new System.Windows.Forms.Button();
            this.btnEditComic = new System.Windows.Forms.Button();
            this.btnDeleteComic = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.btnAddChapters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComics
            // 
            this.dgvComics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComics.Location = new System.Drawing.Point(28, 187);
            this.dgvComics.Margin = new System.Windows.Forms.Padding(4);
            this.dgvComics.Name = "dgvComics";
            this.dgvComics.RowHeadersWidth = 51;
            this.dgvComics.Size = new System.Drawing.Size(1116, 492);
            this.dgvComics.TabIndex = 0;
            this.dgvComics.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComics_CellContentClick);
            // 
            // btnAddComic
            // 
            this.btnAddComic.BackColor = System.Drawing.Color.DimGray;
            this.btnAddComic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddComic.Location = new System.Drawing.Point(1190, 186);
            this.btnAddComic.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddComic.Name = "btnAddComic";
            this.btnAddComic.Size = new System.Drawing.Size(160, 37);
            this.btnAddComic.TabIndex = 1;
            this.btnAddComic.Text = "Add Comic";
            this.btnAddComic.UseVisualStyleBackColor = false;
            this.btnAddComic.Click += new System.EventHandler(this.btnAddComic_Click);
            // 
            // btnEditComic
            // 
            this.btnEditComic.BackColor = System.Drawing.Color.DimGray;
            this.btnEditComic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditComic.Location = new System.Drawing.Point(1190, 235);
            this.btnEditComic.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditComic.Name = "btnEditComic";
            this.btnEditComic.Size = new System.Drawing.Size(160, 37);
            this.btnEditComic.TabIndex = 2;
            this.btnEditComic.Text = "Edit Comic";
            this.btnEditComic.UseVisualStyleBackColor = false;
            this.btnEditComic.Click += new System.EventHandler(this.btnEditComic_Click);
            // 
            // btnDeleteComic
            // 
            this.btnDeleteComic.BackColor = System.Drawing.Color.DimGray;
            this.btnDeleteComic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteComic.Location = new System.Drawing.Point(1190, 284);
            this.btnDeleteComic.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteComic.Name = "btnDeleteComic";
            this.btnDeleteComic.Size = new System.Drawing.Size(160, 37);
            this.btnDeleteComic.TabIndex = 3;
            this.btnDeleteComic.Text = "Delete Comic";
            this.btnDeleteComic.UseVisualStyleBackColor = false;
            this.btnDeleteComic.Click += new System.EventHandler(this.btnDeleteComic_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(1190, 334);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(160, 37);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.DimGray;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(107, 132);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(265, 30);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(24, 135);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 23);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 45);
            this.label1.TabIndex = 10;
            this.label1.Text = "Manage Comics";
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(11, 10);
            this.picClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 7;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(34, 10);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 8;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(1402, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 9;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // btnAddChapters
            // 
            this.btnAddChapters.BackColor = System.Drawing.Color.RosyBrown;
            this.btnAddChapters.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddChapters.Location = new System.Drawing.Point(1190, 382);
            this.btnAddChapters.Name = "btnAddChapters";
            this.btnAddChapters.Size = new System.Drawing.Size(160, 40);
            this.btnAddChapters.TabIndex = 11;
            this.btnAddChapters.Text = "Add Chapters";
            this.btnAddChapters.UseVisualStyleBackColor = false;
            this.btnAddChapters.Click += new System.EventHandler(this.btnAddChapters_Click);
            // 
            // frmManageComics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1402, 706);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddChapters);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteComic);
            this.Controls.Add(this.btnEditComic);
            this.Controls.Add(this.btnAddComic);
            this.Controls.Add(this.dgvComics);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageComics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Comics";
            this.Load += new System.EventHandler(this.frmManageComics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picHeader;
        private Label label1;
        private Button btnAddChapters;
    }
}
