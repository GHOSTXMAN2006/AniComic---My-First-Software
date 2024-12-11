using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmManageAnimeEpisodes : Form
    {
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmManageAnimeEpisodes()
        {
            InitializeComponent();
            LoadEpisodes();
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
        }

        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void picClose_Click(object sender, EventArgs e) => this.Close();

        private void picMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void LoadEpisodes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AE.EpisodeID, AE.EpisodeNumber, AE.Title, AE.ReleaseDate, AE.VideoPath, A.AnimeID, A.Title AS AnimeTitle
                        FROM tblAnimeEpisodes AE
                        INNER JOIN tblAnime A ON AE.AnimeID = A.AnimeID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAnimeEpisodes.DataSource = dt;

                    dgvAnimeEpisodes.Columns["AnimeID"].Visible = false;
                    dgvAnimeEpisodes.Columns["EpisodeID"].Visible = false;
                    dgvAnimeEpisodes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error loading anime episodes: " + ex.Message);
            }
        }

        private void btnAddEpisode_Click(object sender, EventArgs e)
        {
            // Open the add episode form and pass the AnimeID if available.
            frmAddEditAnimeEpisode addEpisodeForm = new frmAddEditAnimeEpisode();
            if (addEpisodeForm.ShowDialog() == DialogResult.OK)
            {
                LoadEpisodes();
            }
        }

        private void btnEditEpisode_Click(object sender, EventArgs e)
        {
            if (dgvAnimeEpisodes.SelectedRows.Count > 0)
            {
                int episodeID = Convert.ToInt32(dgvAnimeEpisodes.SelectedRows[0].Cells["EpisodeID"].Value);
                int animeID = Convert.ToInt32(dgvAnimeEpisodes.SelectedRows[0].Cells["AnimeID"].Value);
                frmAddEditAnimeEpisode editEpisodeForm = new frmAddEditAnimeEpisode(animeID, episodeID);
                if (editEpisodeForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEpisodes();
                }
            }
            else
            {
                MessageBox.Show("Please select an episode to edit.");
            }
        }

        private void btnDeleteEpisode_Click(object sender, EventArgs e)
        {
            if (dgvAnimeEpisodes.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the selected episode(s)?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            foreach (DataGridViewRow row in dgvAnimeEpisodes.SelectedRows)
                            {
                                int episodeID = Convert.ToInt32(row.Cells["EpisodeID"].Value);
                                string query = "DELETE FROM tblAnimeEpisodes WHERE EpisodeID = @EpisodeID";
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@EpisodeID", episodeID);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        LoadEpisodes();
                        MessageBox.Show("Selected episode(s) deleted successfully.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error deleting episode(s): " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select episode(s) to delete.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadEpisodes();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT AE.EpisodeID, AE.EpisodeNumber, AE.Title, AE.ReleaseDate, AE.VideoPath, A.AnimeID, A.Title AS AnimeTitle
                        FROM tblAnimeEpisodes AE
                        INNER JOIN tblAnime A ON AE.AnimeID = A.AnimeID
                        WHERE AE.Title LIKE @Search 
                           OR A.Title LIKE @Search 
                           OR AE.EpisodeNumber LIKE @Search";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvAnimeEpisodes.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error searching anime episodes: " + ex.Message);
            }
        }
    }
}
