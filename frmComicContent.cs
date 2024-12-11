using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmComicContent : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";
        private readonly int chapterId;
        private int currentIndex = 0;
        private byte[][] images;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmComicContent(int chapterId)
        {
            InitializeComponent();
            this.chapterId = chapterId;

            LoadImages();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadImages()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ImageData FROM tblChapterImages WHERE ChapterID = @ChapterID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ChapterID", chapterId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var imageList = new System.Collections.Generic.List<byte[]>();
                        while (reader.Read())
                        {
                            if (reader["ImageData"] != DBNull.Value)
                            {
                                imageList.Add((byte[])reader["ImageData"]);
                            }
                        }
                        images = imageList.ToArray();
                    }
                }

                if (images.Length > 0)
                {
                    DisplayImage(0);
                    lstImages.Items.Clear();
                    for (int i = 0; i < images.Length; i++)
                    {
                        lstImages.Items.Add($"Page {i + 1}");
                    }
                }
                else
                {
                    MessageBox.Show("No images found for this chapter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayImage(int index)
        {
            if (images == null || index < 0 || index >= images.Length)
                return;

            currentIndex = index;

            using (var ms = new MemoryStream(images[index]))
            {
                picViewer.Image = Image.FromStream(ms);
            }

            // Ensure there are items in the list before setting SelectedIndex
            if (lstImages.Items.Count > 0 && index < lstImages.Items.Count)
            {
                lstImages.SelectedIndex = index;
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                DisplayImage(currentIndex - 1);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < images.Length - 1)
            {
                DisplayImage(currentIndex + 1);
            }
        }

        private void lstImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImages.SelectedIndex >= 0)
            {
                DisplayImage(lstImages.SelectedIndex);
            }
        }
    }
}
