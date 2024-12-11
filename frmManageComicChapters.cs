using System;
using System.Data; // For working with DataTable
using System.Data.SqlClient; // For SQL Server database operations
using System.Drawing; // For working with UI elements like colors and images
using System.Runtime.InteropServices; // For enabling drag functionality
using System.Windows.Forms; // For Windows Forms

namespace Software
{
    public partial class frmManageComicChapters : Form
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

        // Constructor to initialize the form
        public frmManageComicChapters()
        {
            InitializeComponent(); // Initializes all components of the form
            LoadComics(); // Loads the list of comics into the dropdown menu
            cmbComic.SelectedIndexChanged += new EventHandler(cmbComic_SelectedIndexChanged); // Event triggered when a comic is selected
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown); // Enables drag functionality for the form header
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
        private void picClose_Click(object sender, EventArgs e) => this.Close();

        // Minimizes the form when the minimize button is clicked
        private void picMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        // Loads the list of comics into the dropdown menu
        private void LoadComics()
        {
            try
            {
                // Establish a connection to the SQL database
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Opens the database connection
                    string query = "SELECT ComicID, Title FROM tblComics"; // SQL query to fetch comic IDs and titles
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn); // Executes the query and fetches the data
                    DataTable dt = new DataTable(); // Creates a table to store the fetched data
                    adapter.Fill(dt); // Fills the DataTable with the fetched data

                    cmbComic.DisplayMember = "Title"; // Displays the comic titles in the dropdown
                    cmbComic.ValueMember = "ComicID"; // Sets the comic IDs as values for the dropdown
                    cmbComic.DataSource = dt; // Sets the data source for the dropdown
                }
            }
            catch (SqlException ex) // Catches any SQL-related errors
            {
                MessageBox.Show("Error loading comics: " + ex.Message); // Displays an error message
            }
        }

        // Triggered when a comic is selected from the dropdown
        private void cmbComic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComic.SelectedValue is int comicId) // Checks if a valid comic ID is selected
            {
                LoadChapters(comicId); // Loads the chapters for the selected comic
            }
        }

        // Loads the chapters for a specific comic into the DataGridView
        private void LoadChapters(int comicId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Establish a connection to the SQL database
                {
                    conn.Open(); // Opens the database connection
                    string query = @"
                        SELECT ChapterID, ChapterNumber, Title, ReleaseDate 
                        FROM tblComicChapters 
                        WHERE ComicID = @ComicID"; // SQL query to fetch chapters for the given comic ID
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn); // Executes the query
                    adapter.SelectCommand.Parameters.AddWithValue("@ComicID", comicId); // Adds the comic ID parameter
                    DataTable dt = new DataTable(); // Creates a table to store the fetched data
                    adapter.Fill(dt); // Fills the DataTable with the fetched data
                    dgvChapters.DataSource = dt; // Displays the data in the DataGridView

                    dgvChapters.Columns["ChapterID"].Visible = false; // Hides the ChapterID column as it's not needed
                    dgvChapters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Adjusts column widths automatically
                }
            }
            catch (SqlException ex) // Catches any SQL-related errors
            {
                MessageBox.Show("Error loading chapters: " + ex.Message); // Displays an error message
            }
        }

        // Opens a form to add a new chapter to the selected comic
        private void btnAddChapter_Click(object sender, EventArgs e)
        {
            if (cmbComic.SelectedValue is int comicId) // Checks if a valid comic is selected
            {
                frmAddEditComicChapter addChapterForm = new frmAddEditComicChapter(comicId); // Creates a new form for adding chapters
                if (addChapterForm.ShowDialog() == DialogResult.OK) // Checks if the form was submitted successfully
                {
                    LoadChapters(comicId); // Reloads the chapters after adding
                }
            }
            else
            {
                MessageBox.Show("Please select a comic to add chapters."); // Prompts the user to select a comic
            }
        }

        // Opens a form to edit the selected chapter
        private void btnEditChapter_Click(object sender, EventArgs e)
        {
            if (dgvChapters.SelectedRows.Count > 0 && cmbComic.SelectedValue is int comicId) // Checks if a chapter is selected
            {
                int chapterId = Convert.ToInt32(dgvChapters.SelectedRows[0].Cells["ChapterID"].Value); // Gets the selected chapter ID
                frmAddEditComicChapter editChapterForm = new frmAddEditComicChapter(comicId, chapterId); // Creates a new form for editing chapters
                if (editChapterForm.ShowDialog() == DialogResult.OK) // Checks if the form was submitted successfully
                {
                    LoadChapters(comicId); // Reloads the chapters after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a chapter to edit."); // Prompts the user to select a chapter
            }
        }

        // Deletes the selected chapters from the database
        private void btnDeleteChapter_Click(object sender, EventArgs e)
        {
            if (dgvChapters.SelectedRows.Count > 0) // Checks if chapters are selected
            {
                var confirmResult = MessageBox.Show("Are you sure to delete the selected chapter(s)?", "Confirm Delete", MessageBoxButtons.YesNo); // Asks for confirmation
                if (confirmResult == DialogResult.Yes) // If the user confirms
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString)) // Establish a connection to the SQL database
                        {
                            conn.Open(); // Opens the database connection
                            foreach (DataGridViewRow row in dgvChapters.SelectedRows) // Loops through the selected rows
                            {
                                int chapterId = Convert.ToInt32(row.Cells["ChapterID"].Value); // Gets the ChapterID
                                string query = "DELETE FROM tblComicChapters WHERE ChapterID = @ChapterID"; // SQL query to delete the chapter
                                SqlCommand cmd = new SqlCommand(query, conn); // Creates the SQL command
                                cmd.Parameters.AddWithValue("@ChapterID", chapterId); // Adds the ChapterID parameter
                                cmd.ExecuteNonQuery(); // Executes the query
                            }
                        }
                        MessageBox.Show("Selected chapter(s) deleted successfully."); // Displays a success message
                        if (cmbComic.SelectedValue is int comicId)
                        {
                            LoadChapters(comicId); // Reloads the chapters after deletion
                        }
                    }
                    catch (SqlException ex) // Catches any SQL-related errors
                    {
                        MessageBox.Show("Error deleting chapter(s): " + ex.Message); // Displays an error message
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select chapter(s) to delete."); // Prompts the user to select chapters
            }
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            // Instantiate the frmManageChapterContent form
            frmManageChapterContent manageChapterContentForm = new frmManageChapterContent();

            // Show the new form without closing the current one
            manageChapterContentForm.Show();
        }


    }
}
