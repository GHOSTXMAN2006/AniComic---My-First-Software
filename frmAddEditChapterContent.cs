using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAddEditChapterContent : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";
        private readonly int chapterId;
        private readonly int? contentId; // Nullable for adding or editing

        // Constants for enabling form drag
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Constructor for adding new content
        public frmAddEditChapterContent(int chapterId)
        {
            InitializeComponent();
            this.chapterId = chapterId;
            this.contentId = null; // Adding new content
            picHeader.MouseDown += picHeader_MouseDown;
            picClose.Click += picClose_Click;
            btnCancel.Click += btnCancel_Click;
        }

        // Constructor for editing existing content
        public frmAddEditChapterContent(int chapterId, int contentId)
        {
            InitializeComponent();
            this.chapterId = chapterId;
            this.contentId = contentId; // Editing existing content
            picHeader.MouseDown += picHeader_MouseDown;
            picClose.Click += picClose_Click;
            btnCancel.Click += btnCancel_Click;
            LoadContentData(contentId); // Load the existing content data
        }

        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imageBytes = null;
                if (picImagePreview.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        picImagePreview.Image.Save(ms, picImagePreview.Image.RawFormat);
                        imageBytes = ms.ToArray();
                    }
                }

                if (imageBytes == null)
                {
                    MessageBox.Show("Please upload an image before saving.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (contentId.HasValue)
                    {
                        // Update existing content
                        string updateQuery = "UPDATE tblChapterImages SET ImageData = @ImageData WHERE ImageID = @ContentID";
                        cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@ContentID", contentId.Value);
                    }
                    else
                    {
                        // Insert new content
                        string insertQuery = "INSERT INTO tblChapterImages (ChapterID, ImageData) VALUES (@ChapterID, @ImageData)";
                        cmd = new SqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@ChapterID", chapterId);
                    }

                    cmd.Parameters.AddWithValue("@ImageData", imageBytes);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(contentId.HasValue ? "Content updated successfully!" : "Content added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadContentData(int contentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ImageData FROM tblChapterImages WHERE ImageID = @ContentID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ContentID", contentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["ImageData"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])reader["ImageData"];
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                picImagePreview.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading content: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadImages_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picImagePreview.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void btnUploadCBZ_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CBZ Files|*.cbz";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExtractAndSaveCBZImages(openFileDialog.FileName);
                }
            }
        }

        private void ExtractAndSaveCBZImages(string cbzFilePath)
        {
            try
            {
                using (var archive = ZipFile.OpenRead(cbzFilePath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            using (var stream = entry.Open())
                            {
                                var image = Image.FromStream(stream);
                                using (var ms = new MemoryStream())
                                {
                                    image.Save(ms, image.RawFormat);
                                    byte[] imageBytes = ms.ToArray();

                                    using (SqlConnection conn = new SqlConnection(connectionString))
                                    {
                                        conn.Open();
                                        string query = "INSERT INTO tblChapterImages (ChapterID, ImageData) VALUES (@ChapterID, @ImageData)";
                                        SqlCommand cmd = new SqlCommand(query, conn);
                                        cmd.Parameters.AddWithValue("@ChapterID", chapterId);
                                        cmd.Parameters.AddWithValue("@ImageData", imageBytes);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("CBZ images added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting CBZ file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
