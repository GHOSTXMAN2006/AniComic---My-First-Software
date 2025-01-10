using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAddEditAnime : Form
    {
        // DLL imports for dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int? animeId; // Nullable int to store the ID if editing an existing anime
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // Default constructor for adding a new anime
        public frmAddEditAnime()
        {
            InitializeComponent();
            // Set up the dragging event for picHeader
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
            animeId = null; // Set to null for adding a new anime
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

        // Constructor for editing an existing anime
        public frmAddEditAnime(int existingAnimeId)
        {
            InitializeComponent();
            animeId = existingAnimeId; // Set to the provided anime ID

            // Load existing anime data if editing
            LoadAnimeData(existingAnimeId);
        }

        // Method to load existing anime data
        private void LoadAnimeData(int existingAnimeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Title, Genre, Episodes, Price, Status, Description, CoverImage FROM tblAnime WHERE AnimeID = @AnimeID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AnimeID", existingAnimeId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["Title"].ToString();
                            txtGenre.Text = reader["Genre"].ToString();
                            txtEpisodes.Text = reader["Episodes"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            cmbStatus.SelectedItem = reader["Status"].ToString();
                            txtDescription.Text = reader["Description"].ToString();

                            // Load the image if available
                            if (reader["CoverImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["CoverImage"];
                                using (var ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    picCoverImage.Image = Image.FromStream(ms);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Event handler for the Upload Image button
        private void BtnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picCoverImage.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        // Event handler for the Save button
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text) ||
                string.IsNullOrWhiteSpace(txtEpisodes.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtEpisodes.Text, out int episodes) || episodes <= 0)
            {
                MessageBox.Show("Please enter a valid number of episodes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes = null;
            if (picCoverImage.Image != null)
            {
                try
                {
                    // Create a deep copy of the image to avoid GDI+ errors
                    using (Bitmap bitmapCopy = new Bitmap(picCoverImage.Image))
                    {
                        using (var ms = new System.IO.MemoryStream())
                        {
                            bitmapCopy.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Save as PNG
                            imageBytes = ms.ToArray();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Prevent further execution if image saving fails
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (animeId.HasValue)
                    {
                        // Update existing anime
                        string updateQuery = "UPDATE tblAnime SET Title = @Title, Genre = @Genre, Episodes = @Episodes, Price = @Price, Status = @Status, Description = @Description, CoverImage = @CoverImage WHERE AnimeID = @AnimeID";
                        cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@AnimeID", animeId.Value);
                    }
                    else
                    {
                        // Insert new anime
                        string insertQuery = "INSERT INTO tblAnime (Title, Genre, Episodes, Price, Status, Description, CoverImage) VALUES (@Title, @Genre, @Episodes, @Price, @Status, @Description, @CoverImage)";
                        cmd = new SqlCommand(insertQuery, conn);
                    }

                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
                    cmd.Parameters.AddWithValue("@Episodes", episodes);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@CoverImage", (object)imageBytes ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(animeId.HasValue ? "Anime updated successfully!" : "Anime added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the Cancel button
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
