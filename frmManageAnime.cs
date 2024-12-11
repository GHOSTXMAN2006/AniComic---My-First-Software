using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmManageAnime : Form
    {
        // Database connection string
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // DLL imports for dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmManageAnime()
        {
            InitializeComponent();
            LoadAnime();

            // Set up the dragging event for picHeader
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
        }

        // Method to allow dragging the form
        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Close button event
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Minimize button event
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Load all anime into the DataGridView with image scaling and text wrapping
        private void LoadAnime()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AnimeID, Title, Genre, Episodes, Status, Price, Description, CoverImage, AddedDate FROM tblAnime";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAnime.DataSource = dt;

                    // Format DataGridView columns
                    dgvAnime.Columns["CoverImage"].DefaultCellStyle.NullValue = null;
                    dgvAnime.Columns["CoverImage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAnime.Columns["CoverImage"].Width = 100;
                    dgvAnime.Columns["CoverImage"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    // Set the image scaling mode for the CoverImage column
                    foreach (DataGridViewRow row in dgvAnime.Rows)
                    {
                        if (row.Cells["CoverImage"].Value is byte[] imageBytes)
                        {
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                Image img = Image.FromStream(ms);
                                row.Cells["CoverImage"].Value = new Bitmap(img, new Size(80, 80)); // Resize image for better display
                            }
                        }
                    }

                    // Enable text wrapping for Description column
                    dgvAnime.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvAnime.AutoResizeRows(); // Adjust row height to fit wrapped text
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading anime: " + ex.Message);
            }
        }

        // Add a new anime
        private void btnAddAnime_Click(object sender, EventArgs e)
        {
            frmAddEditAnime addAnimeForm = new frmAddEditAnime(); // Assume this form handles adding new anime
            if (addAnimeForm.ShowDialog() == DialogResult.OK)
            {
                LoadAnime(); // Refresh the list after adding
            }
        }

        // Edit selected anime
        private void btnEditAnime_Click(object sender, EventArgs e)
        {
            if (dgvAnime.SelectedRows.Count > 0)
            {
                int animeID = Convert.ToInt32(dgvAnime.SelectedRows[0].Cells["AnimeID"].Value);
                frmAddEditAnime editAnimeForm = new frmAddEditAnime(animeID); // Pass animeID to edit form
                if (editAnimeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAnime(); // Refresh after editing
                }
            }
            else
            {
                MessageBox.Show("Please select an anime to edit.");
            }
        }

        // Delete selected anime
        private void btnDeleteAnime_Click(object sender, EventArgs e)
        {
            if (dgvAnime.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show(
                    "Are you sure you want to delete the selected records?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            foreach (DataGridViewRow selectedRow in dgvAnime.SelectedRows)
                            {
                                if (selectedRow.Cells["AnimeID"].Value != null)
                                {
                                    int animeID = Convert.ToInt32(selectedRow.Cells["AnimeID"].Value);

                                    string query = "DELETE FROM tblAnime WHERE AnimeID = @AnimeID";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        cmd.Parameters.AddWithValue("@AnimeID", animeID);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Selected records deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAnime(); // Refresh the list after deletion
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one or more records to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // Refresh the anime list
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnime();
        }

        // Search anime by title, genre, or status
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT AnimeID, Title, Genre, Episodes, Status, Price, Description, CoverImage, AddedDate
                FROM tblAnime 
                WHERE Title LIKE @Search 
                   OR Genre LIKE @Search 
                   OR Status LIKE @Search";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAnime.DataSource = dt;

                    // Ensure image and description format is retained after search
                    FormatDataGridViewColumns();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error searching anime: " + ex.Message);
            }
        }

        // Format DataGridView columns for images and wrapped text
        private void FormatDataGridViewColumns()
        {
            foreach (DataGridViewRow row in dgvAnime.Rows)
            {
                if (row.Cells["CoverImage"].Value is byte[] imageBytes)
                {
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        Image img = Image.FromStream(ms);
                        row.Cells["CoverImage"].Value = new Bitmap(img, new Size(80, 80)); // Resize image for better display
                    }
                }
            }
            dgvAnime.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAnime.AutoResizeRows(); // Adjust row height to fit wrapped text
        }

        private void frmManageAnime_Load(object sender, EventArgs e)
        {
            // Optionally handle form load event if needed
        }

        private void dgvAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optionally handle DataGridView cell click events if needed
        }

        private void btnManageEpisodes_Click(object sender, EventArgs e)
        {
            // Instantiate the frmManageAnimeEpisodes form
            frmManageAnimeEpisodes manageAnimeEpisodesForm = new frmManageAnimeEpisodes();

            // Show the new form without closing the current one
            manageAnimeEpisodesForm.Show();
        }


    }
}
