using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmAdminDashboard : Form
    {

        // DLL imports to allow dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private Timer fadeTimer;
        private bool isClosing;
        private bool isMinimizing;

        public frmAdminDashboard()
        {
            InitializeComponent();
            picHeader.MouseDown += new MouseEventHandler(picHeader_MouseDown);


            // Initialize click events for navigation
            picClose.Click += PicClose_Click;
            picMinimize.Click += PicMinimize_Click;
            picLogout.Click += PicLogout_Click;

            // Manage Comics Panel Components
            lblManageComics.Click += (sender, e) => OpenForm(new frmManageComics());
            picManageComics.Click += (sender, e) => OpenForm(new frmManageComics());
            pnlManageComics.Click += (sender, e) => OpenForm(new frmManageComics());

            // Manage Anime Panel Components
            lblManageAnime.Click += (sender, e) => OpenForm(new frmManageAnime());
            picManageAnime.Click += (sender, e) => OpenForm(new frmManageAnime());
            pnlManageAnime.Click += (sender, e) => OpenForm(new frmManageAnime());


            // Set up fade timer for smooth transitions
            fadeTimer = new Timer();
            fadeTimer.Interval = 10; // Adjust speed of fade effect
            fadeTimer.Tick += FadeTimer_Tick;
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


        private void PicClose_Click(object sender, EventArgs e)
        {
            isClosing = true;
            isMinimizing = false;
            fadeTimer.Start();
        }

        private void PicMinimize_Click(object sender, EventArgs e)
        {
            isClosing = false;
            isMinimizing = true;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.05; // Adjust fade-out speed (smaller values = slower fade)
            }
            else
            {
                fadeTimer.Stop();
                if (isClosing)
                {
                    Close(); // Close the application after fading out
                }
                else if (isMinimizing)
                {
                    Opacity = 1; // Restore opacity for when the form is shown again
                    WindowState = FormWindowState.Minimized;
                }
            }
        }

        private void PicLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new frmLogin();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }

        // Method to handle smooth transitions between forms
        private void OpenForm(Form newForm)
        {
            this.Hide(); // Hide the dashboard
            newForm.FormClosed += (s, args) => this.Show(); // Show dashboard when new form is closed
            newForm.StartPosition = FormStartPosition.CenterScreen;
            newForm.ShowDialog(); // Open the new form as a modal dialog for smoother transition
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void tileReports_Click(object sender, EventArgs e)
        {
            frmReports reportsFrm = new frmReports();
            reportsFrm.Show();
            reportsFrm.Focus();
        }
    }
}
