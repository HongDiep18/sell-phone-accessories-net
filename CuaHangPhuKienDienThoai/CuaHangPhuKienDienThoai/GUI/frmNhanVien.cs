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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        NhanVienBLL nvBLL = new NhanVienBLL();
        public void load_NV()
        {
            listView_NhanVien.Items.Clear();
            List<NhanVienDTO> ds = nvBLL.get_ds_nv();
            foreach (NhanVienDTO kh in ds)
            {
                string[] itm = { kh.MaNV, kh.TenNV, kh.ChucVu, kh.SDT, kh.Email,kh.Password,kh.Luong.ToString() };
                ListViewItem item = new ListViewItem(itm);
                listView_NhanVien.Items.Add(item);
            }
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load_NV();
        }

        private void listView_NhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_NhanVien.SelectedItems)
            {
                txtManv.Text = item.SubItems[0].Text;
                txtTennv.Text = item.SubItems[1].Text;
                txtCV.Text = item.SubItems[2].Text;
                txtSDt.Text = item.SubItems[3].Text;
                txtEM.Text = item.SubItems[4].Text;
                txtMatKhau.Text = item.SubItems[5].Text;
                txtLuong.Text = item.SubItems[6].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO tmp = new NhanVienDTO(txtManv.Text, txtTennv.Text, txtCV.Text, txtSDt.Text, txtEM.Text,float.Parse(txtLuong.Text), txtMatKhau.Text);
            if (nvBLL.Them_NV(tmp))
            {
                
                    MessageBox.Show("Thêm thành coong");
              
                   
            }
            else
            {
                MessageBox.Show("Thêm Thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO tmp = new NhanVienDTO(txtManv.Text, txtTennv.Text, txtCV.Text, txtSDt.Text, txtEM.Text, float.Parse(txtLuong.Text), txtMatKhau.Text);
            if (nvBLL.Xoa_NV(tmp))
            {

                MessageBox.Show("Xóa thành Công");


            }
            else
            {
                MessageBox.Show("Xóa Thất bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO tmp = new NhanVienDTO(txtManv.Text,txtTennv.Text,txtCV.Text,txtSDt.Text,txtEM.Text,float.Parse(txtLuong.Text),txtMatKhau.Text);
            if (nvBLL.Sua_NV(tmp))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }
    }
}
