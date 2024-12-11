using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmManageAnime
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvAnime;
        private System.Windows.Forms.Button btnAddAnime;
        private System.Windows.Forms.Button btnEditAnime;
        private System.Windows.Forms.Button btnDeleteAnime;
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
            this.dgvAnime = new System.Windows.Forms.DataGridView();
            this.btnAddAnime = new System.Windows.Forms.Button();
            this.btnEditAnime = new System.Windows.Forms.Button();
            this.btnDeleteAnime = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.btnManageEpisodes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnime
            // 
            this.dgvAnime.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAnime.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvAnime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnime.Location = new System.Drawing.Point(28, 187);
            this.dgvAnime.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnime.Name = "dgvAnime";
            this.dgvAnime.RowHeadersWidth = 51;
            this.dgvAnime.Size = new System.Drawing.Size(1116, 492);
            this.dgvAnime.TabIndex = 0;
            // 
            // btnAddAnime
            // 
            this.btnAddAnime.BackColor = System.Drawing.Color.MintCream;
            this.btnAddAnime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddAnime.Location = new System.Drawing.Point(1190, 186);
            this.btnAddAnime.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAnime.Name = "btnAddAnime";
            this.btnAddAnime.Size = new System.Drawing.Size(160, 37);
            this.btnAddAnime.TabIndex = 1;
            this.btnAddAnime.Text = "Add Anime";
            this.btnAddAnime.UseVisualStyleBackColor = false;
            this.btnAddAnime.Click += new System.EventHandler(this.btnAddAnime_Click);
            // 
            // btnEditAnime
            // 
            this.btnEditAnime.BackColor = System.Drawing.Color.MintCream;
            this.btnEditAnime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnEditAnime.Location = new System.Drawing.Point(1190, 235);
            this.btnEditAnime.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditAnime.Name = "btnEditAnime";
            this.btnEditAnime.Size = new System.Drawing.Size(160, 37);
            this.btnEditAnime.TabIndex = 2;
            this.btnEditAnime.Text = "Edit Anime";
            this.btnEditAnime.UseVisualStyleBackColor = false;
            this.btnEditAnime.Click += new System.EventHandler(this.btnEditAnime_Click);
            // 
            // btnDeleteAnime
            // 
            this.btnDeleteAnime.BackColor = System.Drawing.Color.MintCream;
            this.btnDeleteAnime.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAnime.Location = new System.Drawing.Point(1190, 284);
            this.btnDeleteAnime.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteAnime.Name = "btnDeleteAnime";
            this.btnDeleteAnime.Size = new System.Drawing.Size(160, 37);
            this.btnDeleteAnime.TabIndex = 3;
            this.btnDeleteAnime.Text = "Delete Anime";
            this.btnDeleteAnime.UseVisualStyleBackColor = false;
            this.btnDeleteAnime.Click += new System.EventHandler(this.btnDeleteAnime_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.MintCream;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
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
            this.txtSearch.BackColor = System.Drawing.Color.MintCream;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
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
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(24, 135);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 23);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search:";
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
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(568, 46);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(255, 45);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Manage Anime";
            // 
            // btnManageEpisodes
            // 
            this.btnManageEpisodes.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnManageEpisodes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnManageEpisodes.Location = new System.Drawing.Point(1190, 383);
            this.btnManageEpisodes.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageEpisodes.Name = "btnManageEpisodes";
            this.btnManageEpisodes.Size = new System.Drawing.Size(160, 37);
            this.btnManageEpisodes.TabIndex = 11;
            this.btnManageEpisodes.Text = "Manage Episodes";
            this.btnManageEpisodes.UseVisualStyleBackColor = false;
            this.btnManageEpisodes.Click += new System.EventHandler(this.btnManageEpisodes_Click);
            // 
            // frmManageAnime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1402, 706);
            this.ControlBox = false;
            this.Controls.Add(this.btnManageEpisodes);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteAnime);
            this.Controls.Add(this.btnEditAnime);
            this.Controls.Add(this.btnAddAnime);
            this.Controls.Add(this.dgvAnime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageAnime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Anime";
            this.Load += new System.EventHandler(this.frmManageAnime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picHeader;
        private Label labelTitle;
        private Button btnManageEpisodes;
    }
}
