using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        private void tileComics_Click(object sender, EventArgs e)
        {
            frmRptMyComics rptMyComics = new frmRptMyComics();
            rptMyComics.Show();
        }

        private void tileAnime_Click(object sender, EventArgs e)
        {
            frmRptMyAnime rptMyAnime = new frmRptMyAnime();
            rptMyAnime.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
