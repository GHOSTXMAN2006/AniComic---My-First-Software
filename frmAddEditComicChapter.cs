using System;
using System.Data.SqlClient; // Required for SQL Server database operations
using System.Drawing; // For working with UI elements like colors and images
using System.Runtime.InteropServices; // For enabling drag functionality
using System.Windows.Forms; // For Windows Forms

namespace Software
{
    public partial class frmAddEditComicChapter : Form
    {
        // Connection string to the SQL database
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // Constants for enabling drag functionality on the form header
        public const int WM_NCLBUTTONDOWN = 0xA1; // Message for left mouse button down on non-client area
        public const int HT_CAPTION = 0x2; // Code indicating the title bar area

        // Importing user32.dll functions for form drag functionality
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture(); // Releases mouse capture
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int? chapterId; // Nullable integer to store the ChapterID if editing an existing chapter
        private int comicId; // Stores the ComicID to link chapters

        public frmAddEditComicChapter()
        {
            InitializeComponent(); // Ensure the form initializes correctly
        }


        // Constructor for adding a new chapter
        public frmAddEditComicChapter(int comicId)
        {
            InitializeComponent(); // Initializes all components of the form
            this.comicId = comicId; // Stores the ComicID passed to the form
            chapterId = null; // Indicates a new chapter is being added
            LoadComicDropdown(); // Loads the comic list into the dropdown menu
            cmbComic.SelectedValue = comicId; // Preselects the associated comic
            cmbComic.Enabled = false; // Disables dropdown to prevent changes to the comic
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown); // Enables drag functionality for the form header
        }

        // Constructor for editing an existing chapter
        public frmAddEditComicChapter(int comicId, int chapterId)
        {
            InitializeComponent(); // Initializes all components of the form
            this.comicId = comicId; // Stores the ComicID passed to the form
            this.chapterId = chapterId; // Stores the ChapterID passed to the form
            LoadComicDropdown(); // Loads the comic list into the dropdown menu
            cmbComic.SelectedValue = comicId; // Preselects the associated comic
            cmbComic.Enabled = false; // Disables dropdown to prevent changes to the comic
            LoadChapterData(chapterId); // Loads the data of the chapter being edited
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown); // Enables drag functionality for the form header
        }

        // Loads the list of comics into the dropdown menu
        private void LoadComicDropdown()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Creates a connection to the database
                {
                    conn.Open(); // Opens the connection
                    string query = "SELECT ComicID, Title FROM tblComics"; // SQL query to fetch all comics
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepares the SQL command
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader()) // Executes the command and reads the data
                        {
                            var dataTable = new System.Data.DataTable(); // Creates a DataTable to store the data
                            dataTable.Load(reader); // Loads the data into the DataTable

                            cmbComic.DisplayMember = "Title"; // Sets the comic titles to display in the dropdown
                            cmbComic.ValueMember = "ComicID"; // Sets the ComicID as the value of the dropdown items
                            cmbComic.DataSource = dataTable; // Binds the DataTable to the dropdown
                        }
                    }
                }
            }
            catch (Exception ex) // Catches any errors
            {
                MessageBox.Show($"Error loading comic list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays an error message
            }
        }

        // Loads data for an existing chapter into the form fields
        private void LoadChapterData(int chapterId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Creates a connection to the database
                {
                    conn.Open(); // Opens the connection
                    string query = @"
                        SELECT ChapterNumber, Title, ReleaseDate 
                        FROM tblComicChapters 
                        WHERE ChapterID = @ChapterID"; // SQL query to fetch chapter details
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepares the SQL command
                    {
                        cmd.Parameters.AddWithValue("@ChapterID", chapterId); // Adds the ChapterID parameter
                        using (SqlDataReader reader = cmd.ExecuteReader()) // Executes the command and reads the data
                        {
                            if (reader.Read()) // Checks if a record was found
                            {
                                txtChapterNumber.Text = reader["ChapterNumber"].ToString(); // Sets the chapter number
                                txtTitle.Text = reader["Title"].ToString(); // Sets the chapter title
                                dtpReleaseDate.Value = Convert.ToDateTime(reader["ReleaseDate"]); // Sets the release date
                            }
                        }
                    }
                }
            }
            catch (Exception ex) // Catches any errors
            {
                MessageBox.Show($"Error loading chapter data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays an error message
            }
        }

        // Enables dragging the form by clicking and holding the header
        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Checks if the left mouse button is pressed
            {
                ReleaseCapture(); // Releases the mouse capture
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Sends a drag message to the form
            }
        }

        // Closes the form when the close button is clicked
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Saves the chapter when the Save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validates inputs
            if (string.IsNullOrWhiteSpace(txtChapterNumber.Text) || string.IsNullOrWhiteSpace(txtTitle.Text)) // Checks if any field is empty
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displays a validation error
                return;
            }

            if (!int.TryParse(txtChapterNumber.Text, out int chapterNumber)) // Checks if the chapter number is a valid integer
            {
                MessageBox.Show("Chapter number must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displays a validation error
                return;
            }

            // Checks for duplicate chapter numbers
            if (IsDuplicateChapterNumber(chapterNumber))
            {
                MessageBox.Show("A chapter with the same number already exists for this comic.", "Duplicate Chapter", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Displays a duplicate error
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Creates a connection to the database
                {
                    conn.Open(); // Opens the connection
                    SqlCommand cmd;

                    if (chapterId.HasValue) // Checks if editing an existing chapter
                    {
                        string updateQuery = @"
                            UPDATE tblComicChapters 
                            SET ChapterNumber = @ChapterNumber, Title = @Title, ReleaseDate = @ReleaseDate 
                            WHERE ChapterID = @ChapterID"; // SQL query to update the chapter
                        cmd = new SqlCommand(updateQuery, conn); // Prepares the SQL command
                        cmd.Parameters.AddWithValue("@ChapterID", chapterId.Value); // Adds the ChapterID parameter
                    }
                    else // Adds a new chapter
                    {
                        string insertQuery = @"
                            INSERT INTO tblComicChapters (ComicID, ChapterNumber, Title, ReleaseDate) 
                            VALUES (@ComicID, @ChapterNumber, @Title, @ReleaseDate)"; // SQL query to insert a new chapter
                        cmd = new SqlCommand(insertQuery, conn); // Prepares the SQL command
                        cmd.Parameters.AddWithValue("@ComicID", comicId); // Adds the ComicID parameter
                    }

                    cmd.Parameters.AddWithValue("@ChapterNumber", chapterNumber); // Adds the ChapterNumber parameter
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim()); // Adds the Title parameter
                    cmd.Parameters.AddWithValue("@ReleaseDate", dtpReleaseDate.Value); // Adds the ReleaseDate parameter

                    cmd.ExecuteNonQuery(); // Executes the SQL command

                    MessageBox.Show(chapterId.HasValue ? "Chapter updated successfully!" : "Chapter added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Displays a success message
                    this.DialogResult = DialogResult.OK; // Sets the dialog result to OK
                    this.Close(); // Closes the form
                }
            }
            catch (Exception ex) // Catches any errors
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays an error message
            }
        }

        // Cancels the operation and closes the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Sets the dialog result to Cancel
            this.Close(); // Closes the form
        }

        // Checks if the chapter number already exists for the selected comic
        private bool IsDuplicateChapterNumber(int chapterNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Creates a connection to the database
                {
                    conn.Open(); // Opens the connection
                    string query = @"
                        SELECT COUNT(*) 
                        FROM tblComicChapters 
                        WHERE ComicID = @ComicID AND ChapterNumber = @ChapterNumber AND ChapterID != @ChapterID"; // SQL query to check for duplicates
                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Prepares the SQL command
                    {
                        cmd.Parameters.AddWithValue("@ComicID", comicId); // Adds the ComicID parameter
                        cmd.Parameters.AddWithValue("@ChapterNumber", chapterNumber); // Adds the ChapterNumber parameter
                        cmd.Parameters.AddWithValue("@ChapterID", chapterId.HasValue ? chapterId.Value : -1); // Adds the ChapterID parameter

                        int count = (int)cmd.ExecuteScalar(); // Executes the query and gets the count
                        return count > 0; // Returns true if a duplicate is found
                    }
                }
            }
            catch (Exception ex) // Catches any errors
            {
                MessageBox.Show($"Error checking duplicate chapter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Displays an error message
                return false;
            }
        }
    }
}
