using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmManageChapterContent
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblComic;
        private ComboBox cmbComic;
        private Label lblChapter;
        private ComboBox cmbChapter;
        private DataGridView dgvContent;
        private Button btnAddContent;
        private Button btnEditContent;
        private Button btnDeleteContent;
        private Button btnRefresh;
        private PictureBox picClose;
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
            this.lblChapter = new System.Windows.Forms.Label();
            this.cmbChapter = new System.Windows.Forms.ComboBox();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.btnAddContent = new System.Windows.Forms.Button();
            this.btnEditContent = new System.Windows.Forms.Button();
            this.btnDeleteContent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComic
            // 
            this.lblComic.AutoSize = true;
            this.lblComic.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblComic.Location = new System.Drawing.Point(25, 130);
            this.lblComic.Name = "lblComic";
            this.lblComic.Size = new System.Drawing.Size(65, 23);
            this.lblComic.TabIndex = 0;
            this.lblComic.Text = "Comic:";
            // 
            // cmbComic
            // 
            this.cmbComic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComic.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbComic.FormattingEnabled = true;
            this.cmbComic.Location = new System.Drawing.Point(100, 127);
            this.cmbComic.Name = "cmbComic";
            this.cmbComic.Size = new System.Drawing.Size(280, 31);
            this.cmbComic.TabIndex = 1;
            this.cmbComic.SelectedIndexChanged += new System.EventHandler(this.cmbComic_SelectedIndexChanged);
            // 
            // lblChapter
            // 
            this.lblChapter.AutoSize = true;
            this.lblChapter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblChapter.Location = new System.Drawing.Point(10, 182);
            this.lblChapter.Name = "lblChapter";
            this.lblChapter.Size = new System.Drawing.Size(80, 23);
            this.lblChapter.TabIndex = 2;
            this.lblChapter.Text = "Chapter:";
            // 
            // cmbChapter
            // 
            this.cmbChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChapter.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbChapter.FormattingEnabled = true;
            this.cmbChapter.Location = new System.Drawing.Point(100, 179);
            this.cmbChapter.Name = "cmbChapter";
            this.cmbChapter.Size = new System.Drawing.Size(280, 31);
            this.cmbChapter.TabIndex = 3;
            this.cmbChapter.SelectedIndexChanged += new System.EventHandler(this.cmbChapter_SelectedIndexChanged);
            // 
            // dgvContent
            // 
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(100, 247);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.RowHeadersWidth = 51;
            this.dgvContent.Size = new System.Drawing.Size(280, 400);
            this.dgvContent.TabIndex = 4;
            this.dgvContent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContent_CellContentClick);
            // 
            // btnAddContent
            // 
            this.btnAddContent.BackColor = System.Drawing.Color.DimGray;
            this.btnAddContent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAddContent.Location = new System.Drawing.Point(444, 325);
            this.btnAddContent.Name = "btnAddContent";
            this.btnAddContent.Size = new System.Drawing.Size(150, 40);
            this.btnAddContent.TabIndex = 5;
            this.btnAddContent.Text = "Add Content";
            this.btnAddContent.UseVisualStyleBackColor = false;
            this.btnAddContent.Click += new System.EventHandler(this.btnAddContent_Click);
            // 
            // btnEditContent
            // 
            this.btnEditContent.BackColor = System.Drawing.Color.DimGray;
            this.btnEditContent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnEditContent.Location = new System.Drawing.Point(444, 385);
            this.btnEditContent.Name = "btnEditContent";
            this.btnEditContent.Size = new System.Drawing.Size(150, 40);
            this.btnEditContent.TabIndex = 6;
            this.btnEditContent.Text = "Edit Content";
            this.btnEditContent.UseVisualStyleBackColor = false;
            this.btnEditContent.Click += new System.EventHandler(this.btnEditContent_Click);
            // 
            // btnDeleteContent
            // 
            this.btnDeleteContent.BackColor = System.Drawing.Color.DimGray;
            this.btnDeleteContent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDeleteContent.Location = new System.Drawing.Point(444, 445);
            this.btnDeleteContent.Name = "btnDeleteContent";
            this.btnDeleteContent.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteContent.TabIndex = 7;
            this.btnDeleteContent.Text = "Delete Content";
            this.btnDeleteContent.UseVisualStyleBackColor = false;
            this.btnDeleteContent.Click += new System.EventHandler(this.btnDeleteContent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(444, 505);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 40);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(10, 10);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 9;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(1040, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 10;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(135, 41);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(412, 45);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Manage Chapter Content";
            // 
            // frmManageChapterContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(664, 682);
            this.ControlBox = false;
            this.Controls.Add(this.lblComic);
            this.Controls.Add(this.cmbComic);
            this.Controls.Add(this.lblChapter);
            this.Controls.Add(this.cmbChapter);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.btnAddContent);
            this.Controls.Add(this.btnEditContent);
            this.Controls.Add(this.btnDeleteContent);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManageChapterContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Chapter Content";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
