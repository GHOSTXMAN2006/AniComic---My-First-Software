using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Software
{
    public partial class frmCreateAccount : Form
    {
        // DLL imports to allow dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Database connection string
        private string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        public frmCreateAccount()
        {
            InitializeComponent();
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);

            // Set form to open in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Enable dragging by handling MouseDown on picHeader
        private void picHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // Custom close button logic
        private void picClose_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Dispose(); // Closes frmCreateAccount completely instead of just hiding it
        }




        // Custom minimize button logic
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // When the 'Login' label is clicked, navigate back to frmLogin
        private void lblLogin_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Dispose(); // Disposes frmCreateAccount to free resources
        }


        // Helper method to check if the email format is valid
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to check if username already exists
        private bool IsUsernameExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblUsers WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // If count is greater than 0, the username exists
                }
            }
        }

        // When the form loads, initialize the UserType ComboBox
        private void frmCreateAccount_Load(object sender, EventArgs e)
        {
            // Populate User Type combobox with Admin and Viewer options
            cmbUserType.SelectedIndex = 1; // Default to Viewer
        }

        // When the save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Basic validations
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if password and confirm password match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if username already exists in the database
            if (IsUsernameExists(txtUsername.Text))
            {
                MessageBox.Show("Username already exists. Please choose a different one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Try to insert the new account into the database
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO tblUsers (Username, Password, Email, UserType, DateJoined) VALUES (@Username, @Password, @Email, @UserType, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Store password as plain text (you can hash later if needed)
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@UserType", cmbUserType.SelectedItem.ToString()); // Admin or Viewer

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate back to the login form
                            frmLogin loginForm = new frmLogin();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while creating the account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
    }
}
