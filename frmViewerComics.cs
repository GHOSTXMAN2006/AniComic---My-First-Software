using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmViewerComics : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // DLL imports to enable dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmViewerComics()
        {
            InitializeComponent();
            pnlHeader.MouseDown += new MouseEventHandler(pnlHeader_MouseDown);
            picClose.Click += new EventHandler(picClose_Click);
            picMinimize.Click += new EventHandler(picMinimize_Click);
        }

        private void frmViewerComics_Load(object sender, EventArgs e)
        {
            LoadComics();
        }

        private void LoadComics()
        {
            flowComics.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ComicID, Title, CoverImage FROM tblComics";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int comicId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        byte[] coverImageBytes = reader["CoverImage"] as byte[];

                        Panel comicPanel = new Panel
                        {
                            Width = 180,
                            Height = 250,
                            Margin = new Padding(10),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = comicId
                        };

                        PictureBox comicPictureBox = new PictureBox
                        {
                            Width = 160,
                            Height = 180,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Image = coverImageBytes != null ? ByteArrayToImage(coverImageBytes) : Properties.Resources.red_circle_emoji_512x512_8xv6a7vo, // Use a default placeholder image
                            Tag = comicId
                        };

                        Label titleLabel = new Label
                        {
                            AutoSize = false,
                            Width = 160,
                            Height = 40,
                            Top = 200,
                            Left = 10,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Text = title,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Tag = comicId
                        };

                        comicPictureBox.Click += Comic_Click;
                        titleLabel.Click += Comic_Click;
                        comicPanel.Click += Comic_Click;

                        comicPanel.Controls.Add(comicPictureBox);
                        comicPanel.Controls.Add(titleLabel);

                        flowComics.Controls.Add(comicPanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading comics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void Comic_Click(object sender, EventArgs e)
        {
            int comicId;

            if (sender is Control control && int.TryParse(control.Tag.ToString(), out comicId))
            {
                frmComicDetails comicDetailsForm = new frmComicDetails(comicId);
                this.Hide();
                comicDetailsForm.FormClosed += (s, args) => this.Show();
                comicDetailsForm.ShowDialog();
            }
        }


        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
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
    }
}
