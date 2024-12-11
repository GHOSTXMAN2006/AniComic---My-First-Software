using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmComicDetails : Form
    {

        // DLL Imports for enabling dragging functionality
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private readonly int comicId;
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";
        private bool isPurchased = false;

        public frmComicDetails(int comicId)
        {
            InitializeComponent();
            this.comicId = comicId;

            picHeader.MouseDown += picHeader_MouseDown;
            picClose.Click += picClose_Click;
            picMinimize.Click += picMinimize_Click;
            btnPurchase.Click += btnPurchase_Click;
            btnViewChapters.Click += btnViewChapters_Click;

            btnViewChapters.Enabled = false; // Disable initially
        }

        private void frmComicDetails_Load(object sender, EventArgs e)
        {
            LoadComicDetails();
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

        private void LoadComicDetails()
        {
            try
            {
                // Establish a connection to the database using the provided connection string.
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the database connection.

                    // Define the SQL query to retrieve details of the comic based on the ComicID.
                    string query = "SELECT Title, Author, Genre, Status, Description, CoverImage FROM tblComics WHERE ComicID = @ComicID";

                    // Create a SqlCommand object to execute the SQL query.
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add the ComicID parameter to the SQL query to filter results for the specific comic.
                        cmd.Parameters.AddWithValue("@ComicID", comicId);

                        // Execute the query and retrieve the results using a SqlDataReader.
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if the query returned a row.
                            if (reader.Read())
                            {
                                // Populate the title label with the comic's title from the database.
                                lblTitle.Text = reader["Title"].ToString();

                                // Populate the author label with the comic's author.
                                lblAuthor.Text = $"Author: {reader["Author"]}";

                                // Populate the genre label with the comic's genre.
                                lblGenre.Text = $"Genre: {reader["Genre"]}";

                                // Populate the status label with the comic's status (e.g., ongoing, completed).
                                lblStatus.Text = $"Status: {reader["Status"]}";

                                // Populate the description label with the comic's description.
                                lblDescription.Text = $"Description: {reader["Description"]}";

                                // Check if a cover image is available in the database.
                                if (reader["CoverImage"] != DBNull.Value)
                                {
                                    // Retrieve the image bytes from the database.
                                    byte[] imageBytes = (byte[])reader["CoverImage"];

                                    // Create a MemoryStream from the image bytes to load the image.
                                    using (var ms = new System.IO.MemoryStream(imageBytes))
                                    {
                                        // Display the image in the PictureBox.
                                        picCover.Image = Image.FromStream(ms);
                                    }
                                }
                                else
                                {
                                    // If no cover image exists, set the PictureBox to null or use a placeholder.
                                    picCover.Image = null;
                                }
                            }
                            else
                            {
                                // If no comic is found with the given ComicID, display an error message.
                                MessageBox.Show("Comic not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                // Close the form since the comic cannot be displayed.
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs during the process, display the error message to the user.
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (isPurchased)
            {
                MessageBox.Show("You have already purchased this comic.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to purchase this comic?", "Purchase Comic", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO tblComicPurchases (UserID, ComicID, PurchaseDate, Price) VALUES (@UserID, @ComicID, GETDATE(), (SELECT Price FROM tblComics WHERE ComicID = @ComicID))";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            int userId = 1; // Replace with actual UserID
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@ComicID", comicId);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Comic purchased successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            isPurchased = true;
                            btnViewChapters.Enabled = true; // Enable after purchase
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during purchase: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnViewChapters_Click(object sender, EventArgs e)
        {
            if (!isPurchased)
            {
                MessageBox.Show("You must purchase this comic to view its chapters.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create an instance of the frmComicChapters form and pass the selected comic ID to it.
            frmComicChapters chaptersForm = new frmComicChapters(comicId);

            // Hide the current form (frmComicDetails) while the chapters form is open.
            this.Hide();

            // Attach an event handler to the FormClosed event of the frmComicChapters.
            // When the chapters form is closed, this handler will show the current form (frmComicDetails) again.
            chaptersForm.FormClosed += (s, args) => this.Show();

            // Show the frmComicChapters form as a modal dialog.
            // This ensures that the user must interact with the chapters form before returning to this form.
            chaptersForm.ShowDialog();

        }
    }
}
