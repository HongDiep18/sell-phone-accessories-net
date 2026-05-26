using BLL;
using DTO;
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
    public partial class frmDangNhap : Form
    {
        
        public delegate void MANV(string manv);
        public MANV truyenMANV;
        public delegate void TENNV(string tennv);
        public TENNV truyenTENNV;

        public delegate void MATKHAU(string mk);
        public MATKHAU truyenMATKHAU;
        public frmDangNhap()
        {
            InitializeComponent();
           
        }
        NhanVienBLL nvBLL = new NhanVienBLL();
        List<NhanVienDTO>ds = new List<NhanVienDTO>();
        public void load_NV()
        {
           ds=nvBLL.get_ds_nv();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            foreach (NhanVienDTO d in ds)
            {
                if(d.MaNV.Trim()==txtManv.Text && d.Password.Trim()==txtMK.Text)
                {
                   if(truyenMANV != null)
                    {
                        truyenMANV(txtManv.Text);
                    }
                    if (truyenTENNV != null)
                    {
                        truyenTENNV(d.TenNV);
                    }
                    if (truyenMATKHAU != null)
                    {
                        truyenMATKHAU(txtMK.Text);
                    }
                    MessageBox.Show("Đăng Nhập Thành Công ");
                    this.Close(); // Đóng form con
                    return;
                }    
            }    
            MessageBox.Show("Đang Nhập Thất Bại ");
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            load_NV();
            txtMK.PasswordChar = '*';
      
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtMK.PasswordChar = '\0';
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }
    }
}
