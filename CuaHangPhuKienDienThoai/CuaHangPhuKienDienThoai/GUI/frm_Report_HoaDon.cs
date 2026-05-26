using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_Report_HoaDon : Form
    {
        public string MaHD;
        public frm_Report_HoaDon()
        {
            InitializeComponent();
        }
        public frm_Report_HoaDon(string mahd)
        {
            MaHD = mahd;
            InitializeComponent();
        }

        private void frm_Report_HoaDon_Load(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon();
            f.SetDatabaseLogon("sa", "123");
            f.SetParameterValue("MAHD",MaHD);
            crystalReportViewer1.ReportSource = f;
        }
    }
}
