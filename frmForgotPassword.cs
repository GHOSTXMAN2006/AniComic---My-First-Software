using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Software
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        // Add your connection string to match your setup
        private string connectionString = @"Server=DESKTOP-O0Q3714\SQLEXPRESS;Database=NiviruGADCourseworkDB;Trusted_Connection=True;";

        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message message = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref message);
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

        private void lblLogin_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check if the new password and confirm password match
            if (newPassword == confirmPassword)
            {
                // Attempt to update the password in the database
                if (UpdateUserPassword(username, newPassword))
                {
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Redirect to the login form
                    frmLogin loginForm = new frmLogin();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool UpdateUserPassword(string username, string newPassword)
        {
            // Update statement to set the new password
            string query = "UPDATE tblUsers SET Password = @Password WHERE Username = @Username";

            // Using a connection with the specified connection string
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    // Open the database connection
                    conn.Open();

                    // Execute the update query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Return true if at least one row was updated
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Show error message in case of database failure
                    MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
