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
    public partial class frmNhapKho : Form
    {
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        SanPhamBLL spBLL= new SanPhamBLL();
        private string MANV { get; set; }
        public frmNhapKho(string mANV)
        {
            InitializeComponent();
            MANV = mANV;
        }
        public void load_NhaCungCap()
        {
            List<NhaCungCapDTO> ds=nccBLL.GetAll();
            comboBox_NhaCungCap.DataSource = ds;
            comboBox_NhaCungCap.DisplayMember = "TenNCC";
            comboBox_NhaCungCap.ValueMember = "MaNCC";

        }
        public void load_Kho()
        {
            listView_SanPham.Items.Clear();
            List<SanPhamDTO> ds =spBLL.get_data();
            foreach (SanPhamDTO s in ds)
            {
                string[] tmp = { s.MaSP, s.TenSP, s.SLTonKo.ToString() };
                ListViewItem item = new ListViewItem(tmp);
                listView_SanPham.Items.Add(item);
            }    
        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            PhieuNhapBLL pnBLL = new PhieuNhapBLL();
            string ma = "PN" + DateTime.Today.ToString("yyMMdd") + string.Format("{0:00}",pnBLL.Dem_SL_PN()+ 1);
            txtMaPN.Text = ma;
            listView_SanPham.Items.Clear();
            load_NhaCungCap();
            load_Kho();
            txt_NgayNhap.Text = DateTime.Now.ToString();
            comboBox_NhaCungCap.SelectedItem = null;
        }

        private void listView_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView_SanPham.SelectedItems)
            {
                txt_MaSp.Text = item.SubItems[0].Text;
                txt_TenSp.Text = item.SubItems[1].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string[]tmp = { txt_MaSp.Text, txt_TenSp.Text, txt_DonGia.Text, txt_SL.Text };
            ListViewItem listView = new ListViewItem(tmp);
            listView_GioHang.Items.Add(listView);
        }

        private void btn_LoaiSP_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem tmp in listView_GioHang.SelectedItems)
            {
                listView_GioHang.Items.Remove(tmp);
            }    
        }

    

        private void txtMaPN_Click(object sender, EventArgs e)
        {
            txtMaPN.Clear();
        }
        public float ThanhTien()
        {
            float TT = 0;
            foreach(ListViewItem tmp in listView_GioHang.Items)
            {
                TT += float.Parse(tmp.SubItems[2].Text) * int.Parse(tmp.SubItems[3].Text);
            }
            return TT;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhieuNhapBLL pnBLL = new PhieuNhapBLL();
            CHITIETPN_BLL CTpnBLL= new CHITIETPN_BLL();
            if (listView_GioHang.Items.Count > 0)
            {
                if (txtMaPN.Text != "Điền Mã Phiếu Nhập")
                {
                    if (comboBox_NhaCungCap.SelectedItem != null)
                    {
                        txtThanhTien.Text = ThanhTien().ToString();
                        PhieuNhapDTO pn = new PhieuNhapDTO(txtMaPN.Text, comboBox_NhaCungCap.SelectedValue.ToString(), DateTime.Now.ToString(), float.Parse(txtThanhTien.Text),MANV);
                        if (pnBLL.insert(pn))
                        {
                            foreach (ListViewItem item in listView_GioHang.Items)
                            {
                                float tt = float.Parse(item.SubItems[2].Text) * int.Parse(item.SubItems[3].Text);
                                ChiTietPN_DTO ctpnDTO = new ChiTietPN_DTO(txtMaPN.Text, item.SubItems[0].Text, int.Parse(item.SubItems[3].Text), float.Parse(item.SubItems[2].Text), tt);
                                if (CTpnBLL.insert_ChiTietPN(ctpnDTO) == false)
                                {
                                    MessageBox.Show("THêm Thất Bại");
                                }
                            }
                        }
                        MessageBox.Show("THêm Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Chọn Nhà Cung Cấp");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập mã phiếu nhập");
                }
            }
            else
            {
                MessageBox.Show("Chọn Mặt Hàng Cần Nhập");
            }    
        }

        private void btnThemSPMoi_Click(object sender, EventArgs e)
        {
            frmChiTietSanPham them = new frmChiTietSanPham("ThemMoi");
            them.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            listView_GioHang.Items.Clear();
            frmNhapKho_Load(sender, e);
        }

        private void btnInPN_Click(object sender, EventArgs e)
        {
            frm_Report_PhieuNhap now = new frm_Report_PhieuNhap(txtMaPN.Text.Trim());
            now.ShowDialog();
        }
    }
}
