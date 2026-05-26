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
    public partial class frmBao_Cao1 : Form
    {
        public frmBao_Cao1()
        {
            InitializeComponent();
        }

        private void frmBao_Cao1_Load(object sender, EventArgs e)
        {
            BaoCao_DoanhThu_NV f = new BaoCao_DoanhThu_NV();
            f.SetDatabaseLogon("sa", "123");
            crystalReportViewer1.ReportSource = f;

        }
    }
}
