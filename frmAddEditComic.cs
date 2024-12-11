using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAddEditComic : Form
    {
        // DLL imports for dragging the form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int? comicId; // Nullable int to store the ID if editing an existing comic
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // Default constructor for adding a new comic
        public frmAddEditComic()
        {
            InitializeComponent();

            // Set up the dragging event for picHeader
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);
            comicId = null; // Set to null for adding a new comic

            // Initialize cmbType with predefined values
            InitializeComicTypes();
        }

        // Constructor for editing an existing comic
        public frmAddEditComic(int existingComicId)
        {
            InitializeComponent();

            comicId = existingComicId; // Set to the provided comic ID
            InitializeComicTypes(); // Initialize cmbType with predefined values

            // Load existing comic data if editing
            LoadComicData(existingComicId);
        }

        // Initialize cmbType with predefined values
        private void InitializeComicTypes()
        {
            cmbType.Items.Clear();
            cmbType.Items.AddRange(new string[] { "Manhua", "Manhwa", "Manga" });
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList; // Ensure the user can only select predefined options
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

        // Method to load existing comic data
        private void LoadComicData(int existingComicId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Title, Genre, Author, Price, Status, Description, CoverImage, Type FROM tblComics WHERE ComicID = @ComicID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ComicID", existingComicId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["Title"].ToString();
                            txtGenre.Text = reader["Genre"].ToString();
                            txtAuthor.Text = reader["Author"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            cmbStatus.SelectedItem = reader["Status"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            cmbType.SelectedItem = reader["Type"].ToString(); // Set the selected type

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
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtGenre.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedIndex == -1 ||
                cmbType.SelectedIndex == -1 || // Ensure a type is selected
                string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate price input
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            byte[] imageBytes = null;
            if (picCoverImage.Image != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    picCoverImage.Image.Save(ms, picCoverImage.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd;

                    if (comicId.HasValue)
                    {
                        // Update existing comic
                        string updateQuery = "UPDATE tblComics SET Title = @Title, Genre = @Genre, Author = @Author, Price = @Price, Status = @Status, Type = @Type, Description = @Description, CoverImage = @CoverImage WHERE ComicID = @ComicID";
                        cmd = new SqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@ComicID", comicId.Value);
                    }
                    else
                    {
                        // Insert new comic
                        string insertQuery = "INSERT INTO tblComics (Title, Genre, Author, Price, Status, Type, Description, CoverImage) VALUES (@Title, @Genre, @Author, @Price, @Status, @Type, @Description, @CoverImage)";
                        cmd = new SqlCommand(insertQuery, conn);
                    }

                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
                    cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Type", cmbType.SelectedItem.ToString()); // Add Type value
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@CoverImage", (object)imageBytes ?? DBNull.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(comicId.HasValue ? "Comic updated successfully!" : "Comic added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
