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
    public partial class frmDanhMuc : Form
    {
        public frmDanhMuc()
        {
            InitializeComponent();
        }
        DanhMucDLL dmBLL=new DanhMucDLL();
        SanPhamBLL spBLL= new SanPhamBLL();
        private void txtMaDanhMuc_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Text=string.Empty;
        }

        private void txtTenDanhMuc_Click(object sender, EventArgs e)
        {
            txtTenDanhMuc.Text = string.Empty;
        }
        public void load_cboDanhMuc()
        {
            DanhMucDLL dmBLL = new DanhMucDLL();
            cboDanhMuc.DataSource = dmBLL.getData();
            cboDanhMuc.DisplayMember = "TenDM";
            cboDanhMuc.ValueMember = "MaDM";
        }
        public void Load_SP_TheoDanhMuc(string ma)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPhamDTO> ds= new List<SanPhamDTO>();
            ds = spBLL.get_data_theoDM(ma);
            foreach (SanPhamDTO d in ds)
            {
                string[] itm = { d.MaSP, d.TenSP, d.MoTa };
                ListViewItem item = new ListViewItem(itm);
                listView_SanPham.Items.Add(item);
            }    
        }
        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            load_cboDanhMuc();
            cboDanhMuc.Text = "";
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
            txtSoLuongSP.Text = "";
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            listView_SanPham.Items.Clear();
            Load_SP_TheoDanhMuc(cboDanhMuc.SelectedValue.ToString());
            txtMaDanhMuc.Text = cboDanhMuc.SelectedValue.ToString();
            txtTenDanhMuc.Text = cboDanhMuc.Text;
            int dem = spBLL.DemSLSP_theoDM(txtMaDanhMuc.Text);
            txtSoLuongSP.Text = dem.ToString();
        }

        private void listView_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //cboDanhMuc.DataSource = null;
            //cboDanhMuc.Items.Clear();
            DanhMucDTO dm = new DanhMucDTO(txtMaDanhMuc.Text, txtTenDanhMuc.Text);
            if(dmBLL.insert_DM(dm))
            {
                MessageBox.Show("Thêm Thành Công Danh Mục");
            }
            else
            {
                MessageBox.Show("Thêm thất bại, kiểm tra ma danh mục");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            //txtMaDanhMuc.Clear();
            //txtTenDanhMuc.Clear();
            //txtSoLuongSP.Clear();
            frmDanhMuc_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DanhMucDTO dm = new DanhMucDTO(txtMaDanhMuc.Text, txtTenDanhMuc.Text);
            if (dmBLL.sua_DM(dm.MaDM,dm.TenDM))
            {
                MessageBox.Show("Sửa Thành Công Danh Mục");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dmBLL.xoa_DanhMuc(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Xóa Thành Công Danh Mục");
            }
            else
            {
                MessageBox.Show("Xóa thất bại, Đảm bảo không có sản phẩm nào thuộc danh mục này :"+txtMaDanhMuc.Text);
            }
        }
    }
}
