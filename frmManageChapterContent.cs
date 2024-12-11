using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmManageChapterContent : Form
    {
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmManageChapterContent()
        {
            InitializeComponent();
            LoadComics(); // Populate the Comic ComboBox
            cmbComic.SelectedIndexChanged += cmbComic_SelectedIndexChanged;
            cmbChapter.SelectedIndexChanged += cmbChapter_SelectedIndexChanged;
            picHeader.MouseDown += picHeader_MouseDown;
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

        // Load all comics into the ComboBox
        private void LoadComics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ComicID, Title FROM tblComics";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbComic.DisplayMember = "Title";
                    cmbComic.ValueMember = "ComicID";
                    cmbComic.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading comics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load chapters for the selected comic
        private void LoadChapters(int comicId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ChapterID, Title 
                        FROM tblComicChapters 
                        WHERE ComicID = @ComicID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ComicID", comicId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbChapter.DisplayMember = "Title";
                    cmbChapter.ValueMember = "ChapterID";
                    cmbChapter.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading chapters: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load content for the selected chapter
        private void LoadContent(int chapterId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CI.ImageID, CI.ChapterID, CI.ImageData 
                        FROM tblChapterImages CI
                        WHERE CI.ChapterID = @ChapterID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@ChapterID", chapterId);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvContent.DataSource = dt;

                    dgvContent.Columns["ImageData"].Visible = false; // Hide the image data
                    dgvContent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event: Comic selection changed
        private void cmbComic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComic.SelectedValue != null && int.TryParse(cmbComic.SelectedValue.ToString(), out int comicId))
            {
                LoadChapters(comicId);
                dgvContent.DataSource = null; // Clear content grid
            }
        }

        // Event: Chapter selection changed
        private void cmbChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedValue != null && int.TryParse(cmbChapter.SelectedValue.ToString(), out int chapterId))
            {
                LoadContent(chapterId);
            }
        }

        // Add content
        private void btnAddContent_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedValue != null && int.TryParse(cmbChapter.SelectedValue.ToString(), out int chapterId))
            {
                frmAddEditChapterContent addContentForm = new frmAddEditChapterContent(chapterId);
                if (addContentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadContent(chapterId); // Reload content
                }
            }
            else
            {
                MessageBox.Show("Please select a chapter to add content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditContent_Click(object sender, EventArgs e)
        {
            if (dgvContent.SelectedRows.Count > 0 &&
                cmbChapter.SelectedValue != null && int.TryParse(cmbChapter.SelectedValue.ToString(), out int chapterId))
            {
                int contentId = Convert.ToInt32(dgvContent.SelectedRows[0].Cells["ImageID"].Value);

                frmAddEditChapterContent editContentForm = new frmAddEditChapterContent(chapterId, contentId);
                if (editContentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadContent(chapterId);
                }
            }
            else
            {
                MessageBox.Show("Please select content to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteContent_Click(object sender, EventArgs e)
        {
            if (dgvContent.SelectedRows.Count > 0 &&
                cmbChapter.SelectedValue != null && int.TryParse(cmbChapter.SelectedValue.ToString(), out int chapterId))
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the selected content?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            foreach (DataGridViewRow row in dgvContent.SelectedRows)
                            {
                                int contentId = Convert.ToInt32(row.Cells["ImageID"].Value);
                                string query = "DELETE FROM tblChapterImages WHERE ImageID = @ImageID";
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@ImageID", contentId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Selected content deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContent(chapterId); // Reload content
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select content to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Refresh content
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cmbChapter.SelectedValue != null && int.TryParse(cmbChapter.SelectedValue.ToString(), out int chapterId))
            {
                LoadContent(chapterId); // Reload content
            }
        }

        private void dgvContent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
