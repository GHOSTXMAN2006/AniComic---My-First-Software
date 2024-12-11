using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace Software
{
    public partial class frmAnimeEpisodes : Form
    {
        private readonly int animeId;
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // DLL Imports for enabling dragging functionality
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmAnimeEpisodes(int animeId)
        {
            InitializeComponent();
            this.animeId = animeId;

            pnlHeader.MouseDown += pnlHeader_MouseDown;
            picClose.Click += picClose_Click;
            picMinimize.Click += picMinimize_Click;
            btnFullscreen.Click += btnFullscreen_Click;
        }

        private void frmAnimeEpisodes_Load(object sender, EventArgs e)
        {
            LoadEpisodes();
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
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

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadEpisodes()
        {
            lstEpisodes.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT EpisodeID, Title FROM tblAnimeEpisodes WHERE AnimeID = @AnimeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AnimeID", animeId);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int episodeId = reader.GetInt32(0);
                        string title = reader.GetString(1);

                        // Add the episode to the list with its ID as Tag
                        lstEpisodes.Items.Add(new ListBoxItem { Text = title, Tag = episodeId });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading episodes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstEpisodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEpisodes.SelectedItem is ListBoxItem selectedItem && selectedItem.Tag is int episodeId)
            {
                LoadEpisodeVideo(episodeId);
            }
        }

        private void LoadEpisodeVideo(int episodeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT VideoPath FROM tblAnimeEpisodes WHERE EpisodeID = @EpisodeID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EpisodeID", episodeId);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string videoPath = result.ToString();
                        videoPlayer.URL = videoPath; // Load video in the player
                    }
                    else
                    {
                        MessageBox.Show("Video not found for the selected episode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            videoPlayer.fullScreen = true; // Enable fullscreen mode
        }

        // Custom ListBox item to store text and tag
        private class ListBoxItem
        {
            public string Text { get; set; }
            public object Tag { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
