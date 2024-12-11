using System.Drawing;
using System.Windows.Forms;
using System;

namespace Software
{
    partial class frmAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox picClose;
        private PictureBox picMinimize;
        private PictureBox picHeader;
        private PictureBox picHome;
        private Panel pnlNavigation;
        private Panel panel1;
        private CurvedPanel pnlManageComics;
        private PictureBox picManageComics;
        private Label lblManageComics;

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

            using (Pen pen = new Pen(borderColor, borderThickness))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlManageAnime = new CurvedPanel();
            this.lblManageAnime = new System.Windows.Forms.Label();
            this.picManageAnime = new System.Windows.Forms.PictureBox();
            this.pnlManageComics = new CurvedPanel();
            this.lblManageComics = new System.Windows.Forms.Label();
            this.picManageComics = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.tileReports = new Guna.UI2.WinForms.Guna2TileButton();
            this.pnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlManageAnime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageAnime)).BeginInit();
            this.pnlManageComics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageComics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNavigation.Controls.Add(this.picLogout);
            this.pnlNavigation.Controls.Add(this.picHome);
            this.pnlNavigation.Location = new System.Drawing.Point(3, 32);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(52, 386);
            this.pnlNavigation.TabIndex = 23;
            // 
            // picLogout
            // 
            this.picLogout.Image = global::Software.Properties.Resources._17367;
            this.picLogout.Location = new System.Drawing.Point(6, 339);
            this.picLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(37, 39);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogout.TabIndex = 25;
            this.picLogout.TabStop = false;
            // 
            // picHome
            // 
            this.picHome.Image = global::Software.Properties.Resources.home_icon_illustration_design_vector;
            this.picHome.Location = new System.Drawing.Point(-6, 15);
            this.picHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(62, 55);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 22;
            this.picHome.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.tileReports);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnlManageAnime);
            this.panel1.Controls.Add(this.pnlManageComics);
            this.panel1.Location = new System.Drawing.Point(71, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 336);
            this.panel1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Welcome back";
            // 
            // pnlManageAnime
            // 
            this.pnlManageAnime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlManageAnime.Controls.Add(this.lblManageAnime);
            this.pnlManageAnime.Controls.Add(this.picManageAnime);
            this.pnlManageAnime.CornerRadius = 40;
            this.pnlManageAnime.Location = new System.Drawing.Point(215, 43);
            this.pnlManageAnime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlManageAnime.Name = "pnlManageAnime";
            this.pnlManageAnime.Size = new System.Drawing.Size(162, 153);
            this.pnlManageAnime.TabIndex = 3;
            // 
            // lblManageAnime
            // 
            this.lblManageAnime.AutoSize = true;
            this.lblManageAnime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageAnime.ForeColor = System.Drawing.Color.White;
            this.lblManageAnime.Location = new System.Drawing.Point(75, 58);
            this.lblManageAnime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManageAnime.Name = "lblManageAnime";
            this.lblManageAnime.Size = new System.Drawing.Size(72, 84);
            this.lblManageAnime.TabIndex = 2;
            this.lblManageAnime.Text = "Manage\r\nAnime\r\n\r\n\r\n";
            // 
            // picManageAnime
            // 
            this.picManageAnime.Image = global::Software.Properties.Resources.defa5b9817265f6c251650be59b13fa9;
            this.picManageAnime.Location = new System.Drawing.Point(12, 13);
            this.picManageAnime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picManageAnime.Name = "picManageAnime";
            this.picManageAnime.Size = new System.Drawing.Size(62, 127);
            this.picManageAnime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picManageAnime.TabIndex = 1;
            this.picManageAnime.TabStop = false;
            // 
            // pnlManageComics
            // 
            this.pnlManageComics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlManageComics.Controls.Add(this.lblManageComics);
            this.pnlManageComics.Controls.Add(this.picManageComics);
            this.pnlManageComics.CornerRadius = 40;
            this.pnlManageComics.Location = new System.Drawing.Point(22, 43);
            this.pnlManageComics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlManageComics.Name = "pnlManageComics";
            this.pnlManageComics.Size = new System.Drawing.Size(162, 153);
            this.pnlManageComics.TabIndex = 0;
            // 
            // lblManageComics
            // 
            this.lblManageComics.AutoSize = true;
            this.lblManageComics.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageComics.ForeColor = System.Drawing.Color.White;
            this.lblManageComics.Location = new System.Drawing.Point(75, 58);
            this.lblManageComics.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblManageComics.Name = "lblManageComics";
            this.lblManageComics.Size = new System.Drawing.Size(72, 84);
            this.lblManageComics.TabIndex = 2;
            this.lblManageComics.Text = "Manage\r\nComics\r\n\r\n\r\n";
            // 
            // picManageComics
            // 
            this.picManageComics.Image = global::Software.Properties.Resources.solo_leveling_sung_jin_woo_blue_wallpaper;
            this.picManageComics.Location = new System.Drawing.Point(12, 13);
            this.picManageComics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picManageComics.Name = "picManageComics";
            this.picManageComics.Size = new System.Drawing.Size(62, 127);
            this.picManageComics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picManageComics.TabIndex = 1;
            this.picManageComics.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dashboard";
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(11, 11);
            this.picClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(14, 13);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 18;
            this.picClose.TabStop = false;
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(30, 11);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(14, 13);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 19;
            this.picMinimize.TabStop = false;
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(3, 3);
            this.picHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(741, 29);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 20;
            this.picHeader.TabStop = false;
            // 
            // tileReports
            // 
            this.tileReports.Animated = true;
            this.tileReports.BackColor = System.Drawing.Color.Transparent;
            this.tileReports.BorderRadius = 6;
            this.tileReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tileReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tileReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tileReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tileReports.FillColor = System.Drawing.Color.Gray;
            this.tileReports.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileReports.ForeColor = System.Drawing.Color.White;
            this.tileReports.Location = new System.Drawing.Point(22, 216);
            this.tileReports.Name = "tileReports";
            this.tileReports.Size = new System.Drawing.Size(100, 99);
            this.tileReports.TabIndex = 275;
            this.tileReports.Text = "Reports";
            this.tileReports.UseTransparentBackground = true;
            this.tileReports.Click += new System.EventHandler(this.tileReports_Click);
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(747, 422);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminDashboard";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.pnlNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlManageAnime.ResumeLayout(false);
            this.pnlManageAnime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageAnime)).EndInit();
            this.pnlManageComics.ResumeLayout(false);
            this.pnlManageComics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageComics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CurvedPanel pnlManageAnime;
        private Label lblManageAnime;
        private PictureBox picManageAnime;
        private Label label3;
        private Label label2;
        private PictureBox picLogout;
        private Guna.UI2.WinForms.Guna2TileButton tileReports;
    }
}
