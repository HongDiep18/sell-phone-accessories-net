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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private Form CurrentFormChild;
        public string MaNV;
        public string MatKhau;
        private void OpenChildForm(Form childForm)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childForm);
            panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        NhanVienBLL nvBLL = new NhanVienBLL();
     
        public void loadMaNV(string ma)
        {
            MaNV = ma;
            label2.Text += ma;
            string PhanQuyen = nvBLL.get_Chuc_Vu(MaNV);
            if(PhanQuyen.Trim() == "QL")
            {
                bánSảnPhẩmToolStripMenuItem.Enabled = true;
                nhậpSảnPhẩmToolStripMenuItem.Enabled = true;
                danhMụcSảnPhẩmToolStripMenuItem.Enabled = true;
                chiTiếtSảnPhẩmToolStripMenuItem.Enabled = true;
                kháchHàngToolStripMenuItem.Enabled = true;
                thốngKêToolStripMenuItem.Enabled = true;
                nhânViênToolStripMenuItem.Enabled = true;
                nhàCungCấpToolStripMenuItem.Enabled = true;
            }    
            else if(PhanQuyen.Trim()=="NVBH")
            {
                bánSảnPhẩmToolStripMenuItem.Enabled = true;
              //  nhậpSảnPhẩmToolStripMenuItem.Enabled = true;
                danhMụcSảnPhẩmToolStripMenuItem.Enabled = true;
                chiTiếtSảnPhẩmToolStripMenuItem.Enabled = true;
                kháchHàngToolStripMenuItem.Enabled = true;
                //thốngKêToolStripMenuItem.Enabled = true;
                //nhânViênToolStripMenuItem.Enabled = true;
                //nhàCungCấpToolStripMenuItem.Enabled = true;
            }
            else
            {
             //   bánSảnPhẩmToolStripMenuItem.Enabled = true;
                nhậpSảnPhẩmToolStripMenuItem.Enabled = true;
                danhMụcSảnPhẩmToolStripMenuItem.Enabled = true;
                chiTiếtSảnPhẩmToolStripMenuItem.Enabled = true;
             //   kháchHàngToolStripMenuItem.Enabled = true;
               // thốngKêToolStripMenuItem.Enabled = true;
               // nhânViênToolStripMenuItem.Enabled = true;
                nhàCungCấpToolStripMenuItem.Enabled = true;

            }
        }
        public void loadTenNV(string ten)
        {
            label3.Text += ten;
        }
        public void loadMatKhau(string ten)
        {
            MatKhau = ten;

        }
        public string Lay_Chuc_Vu(string ma)
        {
            NhanVienBLL nvBLL=new NhanVienBLL();
            return nvBLL.get_Chuc_Vu(ma);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            bánSảnPhẩmToolStripMenuItem.Enabled = false;
            nhậpSảnPhẩmToolStripMenuItem.Enabled = false;
            danhMụcSảnPhẩmToolStripMenuItem.Enabled = false;
            chiTiếtSảnPhẩmToolStripMenuItem.Enabled = false;
            kháchHàngToolStripMenuItem.Enabled = false;
            thốngKêToolStripMenuItem.Enabled = false;
            nhânViênToolStripMenuItem.Enabled = false;
            nhàCungCấpToolStripMenuItem.Enabled = false;


            MatKhau =string.Empty;
            MaNV=string.Empty;
            label3.Text= "Tên Nhân Viên :";
            label2.Text= "Mã Nhân Viên :";


            frmDangNhap DangNhap = new frmDangNhap();
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = DangNhap;
            DangNhap.TopLevel = false;
            DangNhap.FormBorderStyle = FormBorderStyle.None;
            DangNhap.Dock = DockStyle.Fill;
            panel_body.Controls.Add(DangNhap);
            panel_body.Tag = DangNhap;
            DangNhap.BringToFront();
            DangNhap.truyenMANV = new frmDangNhap.MANV(loadMaNV);
            DangNhap.truyenTENNV = new frmDangNhap.TENNV(loadTenNV);
            DangNhap.truyenMATKHAU = new frmDangNhap.MATKHAU(loadMatKhau);
            DangNhap.Show();
        }

       
       

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDoiMatKhau(MatKhau,MaNV));

        }
        private void bánSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham(MaNV));
            label1.Text = "Bán Sản Phẩm";
        }

        private void nhậpSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhapKho(MaNV));
            label1.Text = "Nhập Sản Phẩm";
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDanhMuc());
            label1.Text = "Danh Mục Sản Phẩm";
        }

        private void chiTiếtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietSanPham(""));
            label1.Text = "Chi Tiết Sản Phẩm";
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            label1.Text = "Khách Hàng";
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            label1.Text = "Nhân Viên";
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
            label1.Text = "Thống Kê";
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
            label1.Text = "Nhà Cung Cấp";
        }
    }
}
