using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Software
{
    public partial class frmRptMyComics : Form
    {
        public frmRptMyComics()
        {
            InitializeComponent();
        }

        private void frmRptMyComics_Load(object sender, EventArgs e)
        {
            // Load the report file directly into the viewer
            this.crystalReportViewer1.ReportSource = @"D:\=------NIBM WORK-----=\DSE - Niviru - Acer\GAD\GAD Coursework\Software\CrystalReport1.rpt";

            // Adjust the zoom level to fit the report to the viewer's width
            this.crystalReportViewer1.Zoom(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Connection string to the database
            string cs = @"Data Source=DESKTOP-O0Q3714\SQLEXPRESS;
                        Initial Catalog=NiviruGADCourseworkDB;Integrated Security=True";

            // Establish connection to the database
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Create the SQL query dynamically
                    string sql = "SELECT * FROM tblComics WHERE 1=1";
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        sql += " AND (Title LIKE @Search OR Type LIKE @Search)";
                    }

                    SqlCommand com = new SqlCommand(sql, con);

                    // Add parameter to the query
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        com.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");
                    }

                    // Execute the query and fetch the results into a dataset
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    // Load the Crystal Report and set the data source dynamically
                    ReportDocument rpt = new ReportDocument();
                    rpt.Load(@"D:\=------NIBM WORK-----=\DSE - Niviru - Acer\GAD\GAD Coursework\Software\CrystalReport1.rpt");
                    rpt.SetDataSource(ds.Tables[0]);

                    // Assign the report to the viewer
                    this.crystalReportViewer1.ReportSource = rpt;

                    // Adjust the zoom level to fit the report to the viewer's width
                    this.crystalReportViewer1.Zoom(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
