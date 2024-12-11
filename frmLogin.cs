using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmLogin : Form
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

        public frmLogin()
        {
            InitializeComponent();
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);

            // Set form to open in the center of the screen
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add Click event handler for lblCreateAccount
            lblCreateAccount.Click += new EventHandler(lblCreateAccount_Click);

            // Add Click event handler for lblForgotPassword
            lblForgotPassword.Click += new EventHandler(lblForgotPassword_Click); // <-- New event handler
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
            Application.Exit();
        }

        // Custom minimize button logic
        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Event handler for lblCreateAccount click to open frmCreateAccount
        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            frmCreateAccount createAccountForm = new frmCreateAccount();
            createAccountForm.Show();
            this.Hide();
        }

        // Event handler for lblForgotPassword click to open frmForgotPassword
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword();
            forgotPasswordForm.Show();
            this.Hide(); // Optional: Hide frmLogin if you don't want both forms open simultaneously
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both Username and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Plain password check query
                    string query = "SELECT UserType FROM tblUsers WHERE Username = @Username AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string userType = result.ToString();

                            // Show success message box
                            MessageBox.Show("Login successful! Welcome!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Determine the form to open based on user type
                            if (userType == "Admin")
                            {
                                frmAdminDashboard adminDashboard = new frmAdminDashboard();
                                adminDashboard.Show();
                            }
                            else if (userType == "Viewer")
                            {
                                frmViewerDashboard viewerDashboard = new frmViewerDashboard();
                                viewerDashboard.Show();
                            }

                            // Close the login form after successful login
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
