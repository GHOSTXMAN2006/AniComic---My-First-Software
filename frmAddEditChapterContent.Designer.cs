using System;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    partial class frmAddEditChapterContent
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUploadImages;
        private PictureBox picImagePreview;
        private Button btnUploadCBZ;
        private Button btnUploadImages;
        private Button btnSave;
        private Button btnCancel;
        private PictureBox picClose;
        private PictureBox picHeader;

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
            this.lblUploadImages = new System.Windows.Forms.Label();
            this.picImagePreview = new System.Windows.Forms.PictureBox();
            this.btnUploadCBZ = new System.Windows.Forms.Button();
            this.btnUploadImages = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUploadImages
            // 
            this.lblUploadImages.AutoSize = true;
            this.lblUploadImages.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadImages.Location = new System.Drawing.Point(158, 50);
            this.lblUploadImages.Name = "lblUploadImages";
            this.lblUploadImages.Size = new System.Drawing.Size(180, 31);
            this.lblUploadImages.TabIndex = 4;
            this.lblUploadImages.Text = "Upload Images:";
            // 
            // picImagePreview
            // 
            this.picImagePreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImagePreview.Location = new System.Drawing.Point(118, 129);
            this.picImagePreview.Name = "picImagePreview";
            this.picImagePreview.Size = new System.Drawing.Size(150, 150);
            this.picImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagePreview.TabIndex = 5;
            this.picImagePreview.TabStop = false;
            // 
            // btnUploadCBZ
            // 
            this.btnUploadCBZ.BackColor = System.Drawing.Color.MintCream;
            this.btnUploadCBZ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadCBZ.Location = new System.Drawing.Point(292, 129);
            this.btnUploadCBZ.Name = "btnUploadCBZ";
            this.btnUploadCBZ.Size = new System.Drawing.Size(120, 30);
            this.btnUploadCBZ.TabIndex = 6;
            this.btnUploadCBZ.Text = "Upload CBZ";
            this.btnUploadCBZ.UseVisualStyleBackColor = false;
            this.btnUploadCBZ.Click += new System.EventHandler(this.btnUploadCBZ_Click);
            // 
            // btnUploadImages
            // 
            this.btnUploadImages.BackColor = System.Drawing.Color.MintCream;
            this.btnUploadImages.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUploadImages.Location = new System.Drawing.Point(292, 169);
            this.btnUploadImages.Name = "btnUploadImages";
            this.btnUploadImages.Size = new System.Drawing.Size(120, 30);
            this.btnUploadImages.TabIndex = 7;
            this.btnUploadImages.Text = "Upload Images";
            this.btnUploadImages.UseVisualStyleBackColor = false;
            this.btnUploadImages.Click += new System.EventHandler(this.btnUploadImages_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MintCream;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(93, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MintCream;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(203, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picClose
            // 
            this.picClose.Image = global::Software.Properties.Resources.red_circle_emoji_512x512_8xv6a7vo;
            this.picClose.Location = new System.Drawing.Point(12, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(18, 16);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picClose.TabIndex = 10;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picHeader
            // 
            this.picHeader.Image = global::Software.Properties.Resources.plain_grey_background_ydlwqztavi78gl24;
            this.picHeader.Location = new System.Drawing.Point(0, 0);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(500, 36);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeader.TabIndex = 11;
            this.picHeader.TabStop = false;
            this.picHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHeader_MouseDown);
            // 
            // frmAddEditChapterContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 353);
            this.ControlBox = false;
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.picHeader);
            this.Controls.Add(this.lblUploadImages);
            this.Controls.Add(this.picImagePreview);
            this.Controls.Add(this.btnUploadCBZ);
            this.Controls.Add(this.btnUploadImages);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditChapterContent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Chapter Content";

            ((System.ComponentModel.ISupportInitialize)(this.picImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
