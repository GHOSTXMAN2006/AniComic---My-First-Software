using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmManageComics : Form
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

        public frmManageComics()
        {
            InitializeComponent();
            LoadComics();

            // Set up the dragging event for picHeader
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);

            // Enable multiple row selection
            dgvComics.MultiSelect = true;
            dgvComics.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        // Load all comics into the DataGridView
        private void LoadComics()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM tblComics";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvComics.DataSource = dt;

                    // Ensure the CoverImage column is set as an image column
                    if (dgvComics.Columns["CoverImage"] is DataGridViewImageColumn imageColumn)
                    {
                        imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; // Set the layout to stretch
                    }

                    // Convert each image to be displayed properly
                    foreach (DataGridViewRow row in dgvComics.Rows)
                    {
                        if (row.Cells["CoverImage"].Value is byte[] imageBytes)
                        {
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                row.Cells["CoverImage"].Value = Image.FromStream(ms);
                            }
                        }
                    }

                    // Adjust the row height and column width to provide better visibility
                    dgvComics.Columns["CoverImage"].Width = 150; // Set a larger width for the CoverImage column
                    dgvComics.RowTemplate.Height = 150; // Set a larger row height
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading comics: " + ex.Message);
            }
        }



        // Add a new comic
        private void btnAddComic_Click(object sender, EventArgs e)
        {
            frmAddEditComic addComicForm = new frmAddEditComic(); // Assume this form handles adding new comics
            if (addComicForm.ShowDialog() == DialogResult.OK)
            {
                LoadComics(); // Refresh the list after adding
            }
        }

        // Edit selected comic
        private void btnEditComic_Click(object sender, EventArgs e)
        {
            if (dgvComics.SelectedRows.Count > 0)
            {
                int comicID = Convert.ToInt32(dgvComics.SelectedRows[0].Cells["ComicID"].Value);
                frmAddEditComic editComicForm = new frmAddEditComic(comicID); // Pass comicID to edit form
                if (editComicForm.ShowDialog() == DialogResult.OK)
                {
                    LoadComics(); // Refresh after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a comic to edit.");
            }
        }

        // Delete selected comics
        private void btnDeleteComic_Click(object sender, EventArgs e)
        {
            if (dgvComics.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete the selected comics?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            foreach (DataGridViewRow row in dgvComics.SelectedRows)
                            {
                                int comicID = Convert.ToInt32(row.Cells["ComicID"].Value);
                                string query = "DELETE FROM tblComics WHERE ComicID = @ComicID";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@ComicID", comicID);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        LoadComics(); // Refresh list after deletion
                        MessageBox.Show("Selected comics deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting comics: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select one or more comics to delete.");
            }
        }

        // Refresh the comics list
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadComics();
        }

        // Search comics by title, genre, author, or type
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT * 
                    FROM tblComics 
                    WHERE Title LIKE @Search 
                       OR Genre LIKE @Search 
                       OR Author LIKE @Search
                       OR Type LIKE @Search";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvComics.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error searching comics: " + ex.Message);
            }
        }

        private void frmManageComics_Load(object sender, EventArgs e)
        {
            // Optionally handle form load event if needed
        }

        private void dgvComics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optionally handle DataGridView cell click events if needed
        }

        private void btnAddChapters_Click(object sender, EventArgs e)
        {
            // Instantiate the frmManageChapterContent form
            frmManageComicChapters manageComicChapters = new frmManageComicChapters();

            // Show the new form without closing the current one
            manageComicChapters.Show();
        }
    }
}
