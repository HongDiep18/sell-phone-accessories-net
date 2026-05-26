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
    public partial class frmBao_Cao3 : Form
    {
        public frmBao_Cao3()
        {
            InitializeComponent();
        }

        private void frmBao_Cao3_Load(object sender, EventArgs e)
        {
            Bao_Ca0_NhapHang_SP f= new Bao_Ca0_NhapHang_SP();
            f.SetDatabaseLogon("sa", "123");
            crystalReportViewer1.ReportSource = f;
        }
    }
}
