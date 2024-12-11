using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmComicChapters : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";
        private readonly int comicId;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmComicChapters(int comicId)
        {
            InitializeComponent();
            this.comicId = comicId;

            LoadChapters();
        }

        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PicClose_Click(object sender, EventArgs e)
        {
            // Close the form properly
            this.Dispose();
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadChapters()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ChapterID, Title, ChapterNumber FROM tblComicChapters WHERE ComicID = @ComicID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ComicID", comicId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        lstChapters.Items.Clear();
                        while (reader.Read())
                        {
                            int chapterId = (int)reader["ChapterID"];
                            string title = reader["Title"].ToString();
                            int chapterNumber = (int)reader["ChapterNumber"];
                            lstChapters.Items.Add(new ChapterItem(chapterId, $"Chapter {chapterNumber}: {title}"));
                        }
                    }

                    // Ensure the first item is selected, if any items exist
                    if (lstChapters.Items.Count > 0)
                    {
                        lstChapters.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chapters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnViewContent_Click(object sender, EventArgs e)
        {
            if (lstChapters.SelectedItem is ChapterItem selectedChapter)
            {
                frmComicContent comicContentForm = new frmComicContent(selectedChapter.ChapterId);
                comicContentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a chapter to view its content.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private class ChapterItem
        {
            public int ChapterId { get; }
            public string DisplayText { get; }

            public ChapterItem(int chapterId, string displayText)
            {
                ChapterId = chapterId;
                DisplayText = displayText;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}
