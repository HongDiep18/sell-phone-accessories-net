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
    public partial class frmBao_Cao5 : Form
    {
        public frmBao_Cao5()
        {
            InitializeComponent();
        }

        private void frmBao_Cao5_Load(object sender, EventArgs e)
        {
            Bao_Cao_SanPham f= new Bao_Cao_SanPham();
            f.SetDatabaseLogon("sa", "123");
            crystalReportViewer1.ReportSource = f;
        }
    }
}
