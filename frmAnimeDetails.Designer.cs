using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmAnimeDetails
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

        private void InitializeComponent()
        {
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEpisodes = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnViewEpisodes = new System.Windows.Forms.Button();
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
            this.picHeader.TabIndex = 0;
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
            this.picClose.TabIndex = 1;
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
            this.picMinimize.TabIndex = 2;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(235, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(545, 40);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Anime Title";
            // 
            // lblGenre
            // 
            this.lblGenre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGenre.ForeColor = System.Drawing.Color.White;
            this.lblGenre.Location = new System.Drawing.Point(240, 91);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(540, 40);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre: ";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(240, 141);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(540, 40);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: ";
            // 
            // lblEpisodes
            // 
            this.lblEpisodes.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEpisodes.ForeColor = System.Drawing.Color.White;
            this.lblEpisodes.Location = new System.Drawing.Point(240, 191);
            this.lblEpisodes.Name = "lblEpisodes";
            this.lblEpisodes.Size = new System.Drawing.Size(540, 40);
            this.lblEpisodes.TabIndex = 6;
            this.lblEpisodes.Text = "Episodes: ";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(240, 241);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(540, 80);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description: ";
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(20, 44);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(200, 260);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCover.TabIndex = 8;
            this.picCover.TabStop = false;
            // 
            // btnPurchase
            // 
            this.btnPurchase.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPurchase.ForeColor = System.Drawing.Color.White;
            this.btnPurchase.Location = new System.Drawing.Point(20, 330);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(200, 40);
            this.btnPurchase.TabIndex = 9;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnViewEpisodes
            // 
            this.btnViewEpisodes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnViewEpisodes.ForeColor = System.Drawing.Color.White;
            this.btnViewEpisodes.Location = new System.Drawing.Point(240, 330);
            this.btnViewEpisodes.Name = "btnViewEpisodes";
            this.btnViewEpisodes.Size = new System.Drawing.Size(200, 40);
            this.btnViewEpisodes.TabIndex = 10;
            this.btnViewEpisodes.Text = "View Episodes";
            this.btnViewEpisodes.Click += new System.EventHandler(this.btnViewEpisodes_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Black;
            this.panelContent.Controls.Add(this.picCover);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Controls.Add(this.lblGenre);
            this.panelContent.Controls.Add(this.lblStatus);
            this.panelContent.Controls.Add(this.lblEpisodes);
            this.panelContent.Controls.Add(this.lblDescription);
            this.panelContent.Controls.Add(this.btnPurchase);
            this.panelContent.Controls.Add(this.btnViewEpisodes);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 40);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 410);
            this.panelContent.TabIndex = 11;
            // 
            // frmAnimeDetails
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.picMinimize);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnimeDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anime Details";
            this.Load += new System.EventHandler(this.frmAnimeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEpisodes;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnViewEpisodes;
        private System.Windows.Forms.Panel panelContent;
    }
}
