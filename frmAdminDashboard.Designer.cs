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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.pnlManageAnime = new CurvedPanel();
            this.lblManageAnime = new System.Windows.Forms.Label();
            this.picManageAnime = new System.Windows.Forms.PictureBox();
            this.pnlManageComics = new CurvedPanel();
            this.lblManageComics = new System.Windows.Forms.Label();
            this.picManageComics = new System.Windows.Forms.PictureBox();
            this.pnlNavigation.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.pnlManageAnime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageAnime)).BeginInit();
            this.pnlManageComics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageComics)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNavigation.Controls.Add(this.picLogout);
            this.pnlNavigation.Controls.Add(this.picHome);
            this.pnlNavigation.Location = new System.Drawing.Point(4, 40);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(65, 483);
            this.pnlNavigation.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnlManageAnime);
            this.panel1.Controls.Add(this.pnlManageComics);
            this.panel1.Location = new System.Drawing.Point(89, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 420);
            this.panel1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 31);
            this.label2.TabIndex = 25;
            this.label2.Text = "Welcome back";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(79, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dashboard";
            // 
            // picLogout
            // 
            this.picLogout.Image = global::Software.Properties.Resources._17367;
            this.picLogout.Location = new System.Drawing.Point(8, 424);
            this.picLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(46, 49);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogout.TabIndex = 25;
            this.picLogout.TabStop = false;
            // 
            // picHome
            // 
            this.picHome.Image = global::Software.Properties.Resources.home_icon_illustration_design_vector;
            this.picHome.Location = new System.Drawing.Point(-7, 19);
            this.picHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(77, 69);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 22;
            this.picHome.TabStop = false;
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(14, 14);
            this.picClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 18;
            this.picClose.TabStop = false;
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(37, 14);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 19;
            this.picMinimize.TabStop = false;
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(4, 4);
            this.picHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(926, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 20;
            this.picHeader.TabStop = false;
            // 
            // pnlManageAnime
            // 
            this.pnlManageAnime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlManageAnime.Controls.Add(this.lblManageAnime);
            this.pnlManageAnime.Controls.Add(this.picManageAnime);
            this.pnlManageAnime.CornerRadius = 40;
            this.pnlManageAnime.Location = new System.Drawing.Point(269, 76);
            this.pnlManageAnime.Name = "pnlManageAnime";
            this.pnlManageAnime.Size = new System.Drawing.Size(203, 191);
            this.pnlManageAnime.TabIndex = 3;
            // 
            // lblManageAnime
            // 
            this.lblManageAnime.AutoSize = true;
            this.lblManageAnime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageAnime.ForeColor = System.Drawing.Color.White;
            this.lblManageAnime.Location = new System.Drawing.Point(94, 72);
            this.lblManageAnime.Name = "lblManageAnime";
            this.lblManageAnime.Size = new System.Drawing.Size(88, 112);
            this.lblManageAnime.TabIndex = 2;
            this.lblManageAnime.Text = "Manage\r\nAnime\r\n\r\n\r\n";
            // 
            // picManageAnime
            // 
            this.picManageAnime.Image = global::Software.Properties.Resources.defa5b9817265f6c251650be59b13fa9;
            this.picManageAnime.Location = new System.Drawing.Point(15, 16);
            this.picManageAnime.Name = "picManageAnime";
            this.picManageAnime.Size = new System.Drawing.Size(77, 159);
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
            this.pnlManageComics.Location = new System.Drawing.Point(28, 76);
            this.pnlManageComics.Name = "pnlManageComics";
            this.pnlManageComics.Size = new System.Drawing.Size(203, 191);
            this.pnlManageComics.TabIndex = 0;
            // 
            // lblManageComics
            // 
            this.lblManageComics.AutoSize = true;
            this.lblManageComics.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageComics.ForeColor = System.Drawing.Color.White;
            this.lblManageComics.Location = new System.Drawing.Point(94, 72);
            this.lblManageComics.Name = "lblManageComics";
            this.lblManageComics.Size = new System.Drawing.Size(88, 112);
            this.lblManageComics.TabIndex = 2;
            this.lblManageComics.Text = "Manage\r\nComics\r\n\r\n\r\n";
            // 
            // picManageComics
            // 
            this.picManageComics.Image = global::Software.Properties.Resources.solo_leveling_sung_jin_woo_blue_wallpaper;
            this.picManageComics.Location = new System.Drawing.Point(15, 16);
            this.picManageComics.Name = "picManageComics";
            this.picManageComics.Size = new System.Drawing.Size(77, 159);
            this.picManageComics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picManageComics.TabIndex = 1;
            this.picManageComics.TabStop = false;
            // 
            // frmAdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 527);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminDashboard";
            this.Load += new System.EventHandler(this.frmAdminDashboard_Load);
            this.pnlNavigation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.pnlManageAnime.ResumeLayout(false);
            this.pnlManageAnime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageAnime)).EndInit();
            this.pnlManageComics.ResumeLayout(false);
            this.pnlManageComics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picManageComics)).EndInit();
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
    }
}
