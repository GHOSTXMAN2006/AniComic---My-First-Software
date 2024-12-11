using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAddEditAnimeEpisode : Form
    {
        // DLL imports for dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int? episodeId; // Nullable int for editing an existing episode
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // Constructor for adding a new episode
        public frmAddEditAnimeEpisode()
        {
            InitializeComponent();
            episodeId = null; // Set to null for adding a new episode
            LoadAnimeDropdown();
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
        }

        // Constructor for editing an existing episode
        public frmAddEditAnimeEpisode(int episodeId, int episodeID)
        {
            InitializeComponent();
            this.episodeId = episodeId;
            LoadAnimeDropdown();
            LoadEpisodeData(episodeId);
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
        }

        // Load anime into dropdown
        private void LoadAnimeDropdown()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT AnimeID, Title FROM tblAnime";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(reader);

                            cmbAnime.DisplayMember = "Title";
                            cmbAnime.ValueMember = "AnimeID";
                            cmbAnime.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading anime list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load episode data
        private void LoadEpisodeData(int episodeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AnimeID, EpisodeNumber, Title, ReleaseDate, VideoPath 
                        FROM tblAnimeEpisodes 
                        WHERE EpisodeID = @EpisodeID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EpisodeID", episodeId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbAnime.SelectedValue = reader["AnimeID"];
                                txtEpisodeNumber.Text = reader["EpisodeNumber"].ToString();
                                txtTitle.Text = reader["Title"].ToString();
                                dtpReleaseDate.Value = Convert.ToDateTime(reader["ReleaseDate"]);
                                txtVideoPath.Text = reader["VideoPath"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading episode data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enable dragging the form
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

        // Browse video
        private void btnBrowseVideo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.mkv;*.avi;*.mov";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtVideoPath.Text = openFileDialog.FileName;
                }
            }
        }

        // Save button event
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEpisodeNumber.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtVideoPath.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEpisodeNumber.Text, out int episodeNumber))
            {
                MessageBox.Show("Episode number must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected AnimeID from the combo box
            if (cmbAnime.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid anime.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedAnimeId = (int)cmbAnime.SelectedValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (episodeId.HasValue)
                    {
                        // Update existing episode
                        string updateQuery = @"
                            UPDATE tblAnimeEpisodes 
                            SET AnimeID = @AnimeID, EpisodeNumber = @EpisodeNumber, Title = @Title, ReleaseDate = @ReleaseDate, VideoPath = @VideoPath 
                            WHERE EpisodeID = @EpisodeID";
                        cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@EpisodeID", episodeId.Value);
                    }
                    else
                    {
                        // Insert new episode
                        string insertQuery = @"
                            INSERT INTO tblAnimeEpisodes (AnimeID, EpisodeNumber, Title, ReleaseDate, VideoPath) 
                            VALUES (@AnimeID, @EpisodeNumber, @Title, @ReleaseDate, @VideoPath)";
                        cmd = new SqlCommand(insertQuery, conn);
                    }

                    cmd.Parameters.AddWithValue("@AnimeID", selectedAnimeId);
                    cmd.Parameters.AddWithValue("@EpisodeNumber", episodeNumber);
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@ReleaseDate", dtpReleaseDate.Value);
                    cmd.Parameters.AddWithValue("@VideoPath", txtVideoPath.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(episodeId.HasValue ? "Episode updated successfully!" : "Episode added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancel button event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmAddEditAnimeEpisode_Load(object sender, EventArgs e)
        {

        }
    }
}
