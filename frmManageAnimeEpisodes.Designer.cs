using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmManageAnimeEpisodes
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvAnimeEpisodes;
        private Button btnAddEpisode;
        private Button btnEditEpisode;
        private Button btnDeleteEpisode;
        private Button btnRefresh;
        private TextBox txtSearch;
        private Label lblSearch;
        private PictureBox picClose;
        private PictureBox picMinimize;
        private PictureBox picHeader;
        private Label labelTitle;

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
            this.dgvAnimeEpisodes = new System.Windows.Forms.DataGridView();
            this.btnAddEpisode = new System.Windows.Forms.Button();
            this.btnEditEpisode = new System.Windows.Forms.Button();
            this.btnDeleteEpisode = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimeEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnimeEpisodes
            // 
            this.dgvAnimeEpisodes.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvAnimeEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimeEpisodes.Location = new System.Drawing.Point(28, 187);
            this.dgvAnimeEpisodes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvAnimeEpisodes.Name = "dgvAnimeEpisodes";
            this.dgvAnimeEpisodes.RowHeadersWidth = 51;
            this.dgvAnimeEpisodes.Size = new System.Drawing.Size(1116, 492);
            this.dgvAnimeEpisodes.TabIndex = 0;
            // 
            // btnAddEpisode
            // 
            this.btnAddEpisode.BackColor = System.Drawing.Color.MintCream;
            this.btnAddEpisode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddEpisode.Location = new System.Drawing.Point(1190, 186);
            this.btnAddEpisode.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEpisode.Name = "btnAddEpisode";
            this.btnAddEpisode.Size = new System.Drawing.Size(160, 37);
            this.btnAddEpisode.TabIndex = 1;
            this.btnAddEpisode.Text = "Add Episode";
            this.btnAddEpisode.UseVisualStyleBackColor = false;
            this.btnAddEpisode.Click += new System.EventHandler(this.btnAddEpisode_Click);
            // 
            // btnEditEpisode
            // 
            this.btnEditEpisode.BackColor = System.Drawing.Color.MintCream;
            this.btnEditEpisode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnEditEpisode.Location = new System.Drawing.Point(1190, 235);
            this.btnEditEpisode.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditEpisode.Name = "btnEditEpisode";
            this.btnEditEpisode.Size = new System.Drawing.Size(160, 37);
            this.btnEditEpisode.TabIndex = 2;
            this.btnEditEpisode.Text = "Edit Episode";
            this.btnEditEpisode.UseVisualStyleBackColor = false;
            this.btnEditEpisode.Click += new System.EventHandler(this.btnEditEpisode_Click);
            // 
            // btnDeleteEpisode
            // 
            this.btnDeleteEpisode.BackColor = System.Drawing.Color.MintCream;
            this.btnDeleteEpisode.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteEpisode.Location = new System.Drawing.Point(1190, 284);
            this.btnDeleteEpisode.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteEpisode.Name = "btnDeleteEpisode";
            this.btnDeleteEpisode.Size = new System.Drawing.Size(160, 37);
            this.btnDeleteEpisode.TabIndex = 3;
            this.btnDeleteEpisode.Text = "Delete Episode";
            this.btnDeleteEpisode.UseVisualStyleBackColor = false;
            this.btnDeleteEpisode.Click += new System.EventHandler(this.btnDeleteEpisode_Click);
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
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(490, 47);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(399, 45);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Manage Anime Episodes";
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
            // frmManageAnimeEpisodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1402, 706);
            this.ControlBox = false;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteEpisode);
            this.Controls.Add(this.btnEditEpisode);
            this.Controls.Add(this.btnAddEpisode);
            this.Controls.Add(this.dgvAnimeEpisodes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageAnimeEpisodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Anime Episodes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimeEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
