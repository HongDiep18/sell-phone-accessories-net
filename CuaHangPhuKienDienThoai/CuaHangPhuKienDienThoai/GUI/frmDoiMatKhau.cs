using BLL;
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
    public partial class frmDoiMatKhau : Form
    {
        public string MKC { get; set; }
        public string MaNV { get; set; }
        public frmDoiMatKhau(string MatKhauCu, string maNV)
        {
            MKC = MatKhauCu;
            MaNV = maNV;
            InitializeComponent();
           
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            NhanVienBLL nvBLL = new NhanVienBLL();
            if(txtMKC.Text==MKC && txtMKM1.Text==txtMKM2.Text)
            {
                if(nvBLL.Doi_MK(txtMKM1.Text,MaNV))
                {
                    MessageBox.Show("Đổi MẬt Khẩu Thành Công");
                }
                else
                {
                    MessageBox.Show("Đổi MẬt Khẩu Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Sai Mật Khẩu");
            } 
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
