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
    public partial class frmBao_Cao2 : Form
    {
        public frmBao_Cao2()
        {
            InitializeComponent();
        }

        private void frmBao_Cao2_Load(object sender, EventArgs e)
        {
            Bao_Cao_DoanhThu_Time f= new Bao_Cao_DoanhThu_Time();
            f.SetDatabaseLogon("sa", "123");
            crystalReportViewer1.ReportSource = f;
        }
    }
}
