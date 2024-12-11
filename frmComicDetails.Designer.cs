using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmComicDetails
    {
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnViewChapters = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // picHeader
            // 
            this.picHeader.BackColor = System.Drawing.Color.Teal;
            this.picHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(800, 40);
            this.picHeader.TabIndex = 3;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(12, 10);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.Image = global::Software.Properties.Resources.images__1_;
            this.picMinimize.Location = new System.Drawing.Point(38, 10);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(20, 20);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMinimize.TabIndex = 1;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(235, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(545, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Comic Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblAuthor.ForeColor = System.Drawing.Color.White;
            this.lblAuthor.Location = new System.Drawing.Point(240, 100);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(540, 40);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author: ";
            // 
            // lblGenre
            // 
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGenre.ForeColor = System.Drawing.Color.White;
            this.lblGenre.Location = new System.Drawing.Point(240, 140);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(540, 50);
            this.lblGenre.TabIndex = 3;
            this.lblGenre.Text = "Genre: ";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(240, 190);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(540, 47);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: ";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(240, 237);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(540, 73);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description: ";
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(20, 42);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(200, 258);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            // 
            // btnPurchase
            // 
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPurchase.ForeColor = System.Drawing.Color.White;
            this.btnPurchase.Location = new System.Drawing.Point(20, 320);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(200, 40);
            this.btnPurchase.TabIndex = 6;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnViewChapters
            // 
            this.btnViewChapters.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewChapters.ForeColor = System.Drawing.Color.White;
            this.btnViewChapters.Location = new System.Drawing.Point(240, 320);
            this.btnViewChapters.Name = "btnViewChapters";
            this.btnViewChapters.Size = new System.Drawing.Size(200, 40);
            this.btnViewChapters.TabIndex = 7;
            this.btnViewChapters.Text = "View Chapters";
            this.btnViewChapters.Click += new System.EventHandler(this.btnViewChapters_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Black;
            this.panelContent.Controls.Add(this.picCover);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Controls.Add(this.lblAuthor);
            this.panelContent.Controls.Add(this.lblGenre);
            this.panelContent.Controls.Add(this.lblStatus);
            this.panelContent.Controls.Add(this.lblDescription);
            this.panelContent.Controls.Add(this.btnPurchase);
            this.panelContent.Controls.Add(this.btnViewChapters);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 40);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 385);
            this.panelContent.TabIndex = 0;
            // 
            // frmComicDetails
            // 
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmComicDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comic Details";
            this.Load += new System.EventHandler(this.frmComicDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private PictureBox picHeader;
        private PictureBox picClose;
        private PictureBox picMinimize;
        private Label lblTitle;
        private Label lblAuthor;
        private Label lblGenre;
        private Label lblStatus;
        private Label lblDescription;
        private PictureBox picCover;
        private Button btnPurchase;
        private Button btnViewChapters;
        private Panel panelContent;
    }
}
