using System.Drawing;
using System.Windows.Forms;
using System;

namespace Software
{
    partial class frmViewerDashboard
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAnime = new CurvedPanel();
            this.lblAnime = new System.Windows.Forms.Label();
            this.picAnime = new System.Windows.Forms.PictureBox();
            this.pnlComics = new CurvedPanel();
            this.lblComics = new System.Windows.Forms.Label();
            this.picComics = new System.Windows.Forms.PictureBox();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnlAnime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime)).BeginInit();
            this.pnlComics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picComics)).BeginInit();
            this.pnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pnlAnime);
            this.panel1.Controls.Add(this.pnlComics);
            this.panel1.Location = new System.Drawing.Point(67, 70);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 341);
            this.panel1.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Welcome back ";
            // 
            // pnlAnime
            // 
            this.pnlAnime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlAnime.Controls.Add(this.lblAnime);
            this.pnlAnime.Controls.Add(this.picAnime);
            this.pnlAnime.CornerRadius = 40;
            this.pnlAnime.Location = new System.Drawing.Point(205, 64);
            this.pnlAnime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlAnime.Name = "pnlAnime";
            this.pnlAnime.Size = new System.Drawing.Size(152, 155);
            this.pnlAnime.TabIndex = 3;
            // 
            // lblAnime
            // 
            this.lblAnime.AutoSize = true;
            this.lblAnime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnime.ForeColor = System.Drawing.Color.White;
            this.lblAnime.Location = new System.Drawing.Point(76, 69);
            this.lblAnime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnime.Name = "lblAnime";
            this.lblAnime.Size = new System.Drawing.Size(60, 21);
            this.lblAnime.TabIndex = 2;
            this.lblAnime.Text = "Anime";
            // 
            // picAnime
            // 
            this.picAnime.Image = global::Software.Properties.Resources._7580bcd58108f60135aa0942229c2ddd;
            this.picAnime.Location = new System.Drawing.Point(14, 15);
            this.picAnime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picAnime.Name = "picAnime";
            this.picAnime.Size = new System.Drawing.Size(58, 129);
            this.picAnime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnime.TabIndex = 1;
            this.picAnime.TabStop = false;
            // 
            // pnlComics
            // 
            this.pnlComics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlComics.Controls.Add(this.lblComics);
            this.pnlComics.Controls.Add(this.picComics);
            this.pnlComics.CornerRadius = 40;
            this.pnlComics.Location = new System.Drawing.Point(24, 64);
            this.pnlComics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlComics.Name = "pnlComics";
            this.pnlComics.Size = new System.Drawing.Size(152, 155);
            this.pnlComics.TabIndex = 0;
            // 
            // lblComics
            // 
            this.lblComics.AutoSize = true;
            this.lblComics.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComics.ForeColor = System.Drawing.Color.White;
            this.lblComics.Location = new System.Drawing.Point(75, 69);
            this.lblComics.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComics.Name = "lblComics";
            this.lblComics.Size = new System.Drawing.Size(65, 21);
            this.lblComics.TabIndex = 2;
            this.lblComics.Text = "Comics";
            // 
            // picComics
            // 
            this.picComics.Image = global::Software.Properties.Resources._373cdcd30d127d07be2bdcc002936945;
            this.picComics.Location = new System.Drawing.Point(14, 15);
            this.picComics.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picComics.Name = "picComics";
            this.picComics.Size = new System.Drawing.Size(58, 129);
            this.picComics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picComics.TabIndex = 1;
            this.picComics.TabStop = false;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlNavigation.Controls.Add(this.picLogout);
            this.pnlNavigation.Controls.Add(this.picHome);
            this.pnlNavigation.Location = new System.Drawing.Point(3, 32);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(49, 392);
            this.pnlNavigation.TabIndex = 29;
            // 
            // picLogout
            // 
            this.picLogout.Image = global::Software.Properties.Resources._17367;
            this.picLogout.Location = new System.Drawing.Point(7, 347);
            this.picLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(34, 40);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogout.TabIndex = 25;
            this.picLogout.TabStop = false;
            // 
            // picHome
            // 
            this.picHome.Image = global::Software.Properties.Resources.home_icon_illustration_design_vector;
            this.picHome.Location = new System.Drawing.Point(-4, 18);
            this.picHome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(58, 56);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 22;
            this.picHome.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 30);
            this.label3.TabIndex = 25;
            this.label3.Text = "Dashboard";
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(10, 11);
            this.picClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(14, 13);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 26;
            this.picClose.TabStop = false;
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(28, 11);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(14, 13);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 27;
            this.picMinimize.TabStop = false;
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(3, 2);
            this.picHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(694, 29);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 28;
            this.picHeader.TabStop = false;
            // 
            // frmViewerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 427);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmViewerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmViewerDashboard";
            this.Load += new System.EventHandler(this.frmViewerDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAnime.ResumeLayout(false);
            this.pnlAnime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnime)).EndInit();
            this.pnlComics.ResumeLayout(false);
            this.pnlComics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picComics)).EndInit();
            this.pnlNavigation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private CurvedPanel pnlAnime;
        private System.Windows.Forms.Label lblAnime;
        private System.Windows.Forms.PictureBox picAnime;
        private CurvedPanel pnlComics;
        private System.Windows.Forms.Label lblComics;
        private System.Windows.Forms.PictureBox picComics;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.PictureBox picHeader;
    }
}