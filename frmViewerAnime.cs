using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Software
{
    public partial class frmViewerAnime : Form
    {
        private readonly string connectionString = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

        // DLL imports to enable dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmViewerAnime()
        {
            InitializeComponent();
            pnlHeader.MouseDown += new MouseEventHandler(pnlHeader_MouseDown);
            picClose.Click += new EventHandler(picClose_Click);
            picMinimize.Click += new EventHandler(picMinimize_Click);
        }

        private void frmViewerAnime_Load(object sender, EventArgs e)
        {
            LoadAnime();
        }

        private void LoadAnime()
        {
            flowAnime.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AnimeID, Title, CoverImage FROM tblAnime";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int animeId = reader.GetInt32(0);
                        string title = reader.GetString(1);
                        byte[] coverImageBytes = reader["CoverImage"] as byte[];

                        Panel animePanel = new Panel
                        {
                            Width = 180,
                            Height = 250,
                            Margin = new Padding(10),
                            BackColor = Color.White,
                            BorderStyle = BorderStyle.FixedSingle,
                            Tag = animeId
                        };

                        PictureBox animePictureBox = new PictureBox
                        {
                            Width = 160,
                            Height = 180,
                            Top = 10,
                            Left = 10,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Tag = animeId
                        };

                        // Load image or fallback to default image
                        try
                        {
                            if (coverImageBytes != null)
                            {
                                animePictureBox.Image = ByteArrayToImage(coverImageBytes);
                            }
                            else
                            {
                                animePictureBox.Image = Image.FromFile(@"D:\=------NIBM WORK-----=\DSE - Niviru - Acer\GAD\GAD Coursework\Software\Resources\defaultImage.jpg");
                            }
                        }
                        catch
                        {
                            animePictureBox.Image = Image.FromFile(@"D:\=------NIBM WORK-----=\DSE - Niviru - Acer\GAD\GAD Coursework\Software\Resources\defaultImage.jpg");
                        }

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
                            Tag = animeId
                        };

                        animePictureBox.Click += Anime_Click;
                        titleLabel.Click += Anime_Click;
                        animePanel.Click += Anime_Click;

                        animePanel.Controls.Add(animePictureBox);
                        animePanel.Controls.Add(titleLabel);

                        flowAnime.Controls.Add(animePanel);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Loading Anime: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Anime_Click(object sender, EventArgs e)
        {
            int animeId;
            if (sender is Control control && int.TryParse(control.Tag.ToString(), out animeId))
            {
                frmAnimeDetails animeDetailsForm = new frmAnimeDetails(animeId);
                this.Hide();
                animeDetailsForm.FormClosed += (s, args) => this.Show();
                animeDetailsForm.ShowDialog();
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
