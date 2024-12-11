using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAnimeDetails : Form
    {
        // DLL Imports for enabling dragging functionality
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private readonly int animeId;
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";
        private bool isPurchased = false;

        public frmAnimeDetails(int animeId)
        {
            InitializeComponent();
            this.animeId = animeId;

            // Attach event handlers
            picHeader.MouseDown += picHeader_MouseDown;
            picClose.Click += picClose_Click;
            picMinimize.Click += picMinimize_Click;
            btnPurchase.Click += btnPurchase_Click;
            btnViewEpisodes.Click += btnViewEpisodes_Click;

            btnViewEpisodes.Enabled = false; // Disable initially
        }

        private void frmAnimeDetails_Load(object sender, EventArgs e)
        {
            LoadAnimeDetails();
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

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoadAnimeDetails()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Title, Genre, Episodes, Status, Description, CoverImage FROM tblAnime WHERE AnimeID = @AnimeID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AnimeID", animeId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTitle.Text = reader["Title"].ToString();
                            lblGenre.Text = $"Genre: {reader["Genre"]}";
                            lblStatus.Text = $"Status: {reader["Status"]}";
                            lblEpisodes.Text = $"Episodes: {reader["Episodes"]}";
                            lblDescription.Text = $"Description: {reader["Description"]}";

                            if (reader["CoverImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["CoverImage"];
                                using (var ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    picCover.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                picCover.Image = null; // Placeholder image can be added here
                            }
                        }
                        else
                        {
                            MessageBox.Show("Anime not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (isPurchased)
            {
                MessageBox.Show("You have already purchased this anime.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to purchase this anime?", "Purchase Anime", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        string query = "INSERT INTO tblAnimePurchases (UserID, AnimeID, PurchaseDate, Price) VALUES (@UserID, @AnimeID, GETDATE(), (SELECT Price FROM tblAnime WHERE AnimeID = @AnimeID))";
                        SqlCommand cmd = new SqlCommand(query, conn);

                        int userId = 1; // Replace with the actual UserID
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@AnimeID", animeId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Anime purchased successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        isPurchased = true;
                        btnViewEpisodes.Enabled = true; // Enable button after purchase
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewEpisodes_Click(object sender, EventArgs e)
        {
            if (!isPurchased)
            {
                MessageBox.Show("You must purchase this anime to view its episodes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmAnimeEpisodes episodesForm = new frmAnimeEpisodes(animeId);
            this.Hide();
            episodesForm.FormClosed += (s, args) => this.Show();
            episodesForm.ShowDialog();
        }
    }
}
