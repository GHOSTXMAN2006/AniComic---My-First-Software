using System.Drawing;
using System.Windows.Forms;
using System;

namespace Software
{
    partial class frmReports
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

            int borderThickness = 7;
            Color borderColor = Color.DarkGray;

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



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tileComics = new Guna.UI2.WinForms.Guna2TileButton();
            this.tileAnime = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tileComics
            // 
            this.tileComics.Animated = true;
            this.tileComics.BackColor = System.Drawing.Color.Transparent;
            this.tileComics.BorderRadius = 6;
            this.tileComics.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tileComics.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tileComics.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tileComics.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tileComics.FillColor = System.Drawing.Color.Gray;
            this.tileComics.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileComics.ForeColor = System.Drawing.Color.White;
            this.tileComics.Location = new System.Drawing.Point(75, 76);
            this.tileComics.Name = "tileComics";
            this.tileComics.Size = new System.Drawing.Size(100, 99);
            this.tileComics.TabIndex = 274;
            this.tileComics.Text = "Comic Report";
            this.tileComics.UseTransparentBackground = true;
            this.tileComics.Click += new System.EventHandler(this.tileComics_Click);
            // 
            // tileAnime
            // 
            this.tileAnime.Animated = true;
            this.tileAnime.BackColor = System.Drawing.Color.Transparent;
            this.tileAnime.BorderRadius = 6;
            this.tileAnime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.tileAnime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.tileAnime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.tileAnime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.tileAnime.FillColor = System.Drawing.Color.Gray;
            this.tileAnime.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileAnime.ForeColor = System.Drawing.Color.White;
            this.tileAnime.Location = new System.Drawing.Point(231, 76);
            this.tileAnime.Name = "tileAnime";
            this.tileAnime.Size = new System.Drawing.Size(100, 99);
            this.tileAnime.TabIndex = 275;
            this.tileAnime.Text = "Anime Report";
            this.tileAnime.UseTransparentBackground = true;
            this.tileAnime.Click += new System.EventHandler(this.tileAnime_Click);
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BorderRadius = 7;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = global::Software.Properties.Resources.Arrow_Left_512_ezgif_com_webp_to_png_converter;
            this.btnBack.ImageSize = new System.Drawing.Size(40, 32);
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(45, 45);
            this.btnBack.TabIndex = 273;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(405, 220);
            this.ControlBox = false;
            this.Controls.Add(this.tileAnime);
            this.Controls.Add(this.tileComics);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReports";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2TileButton tileComics;
        private Guna.UI2.WinForms.Guna2TileButton tileAnime;
    }
}