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
    public partial class frm_Report_PhieuNhap : Form
    {
        public string MaPN;
        public frm_Report_PhieuNhap()
        {
            InitializeComponent();
        }
        public frm_Report_PhieuNhap(string ma)
        {
            MaPN = ma;  
            InitializeComponent();
        }

        private void frm_Report_PhieuNhap_Load(object sender, EventArgs e)
        {
            PhieuNhap f = new PhieuNhap();
            f.SetDatabaseLogon("sa", "123");
            f.SetParameterValue("MAPN", MaPN);
            crystalReportViewer1.ReportSource = f;
        }
    }
}
