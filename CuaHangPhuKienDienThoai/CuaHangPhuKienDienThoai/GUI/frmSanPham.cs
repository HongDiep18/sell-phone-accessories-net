using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace GUI
{
    public partial class frmSanPham : Form
    {

        SanPhamBLL SP = new SanPhamBLL();
        KhachHangBLL KH = new KhachHangBLL();
        private string MANV { get; set; }
        public frmSanPham(string mANV)
        {
            InitializeComponent();
            MANV = mANV;
        }
        bool kiemtrasl(string tmp)
        {
            foreach (ListViewItem item in lst_GioHang.Items)
            {
                if (item.SubItems[0].Text == tmp)
                {
                    int sl = int.Parse(item.SubItems[3].Text) + 1;
                    item.SubItems[3].Text = sl.ToString();
                    return true;
                }
            }
            return false;
        }
        void Load_DS_KH()
        {
            List<KhachHangDTO> ds = KH.get_ds_KH();
            
            cbo_KH.DataSource = ds;
            cbo_KH.DisplayMember = "TenKH";
            cbo_KH.ValueMember = "MaKH";
           

        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {

            tab_Xem.SelectedIndex = 1;
            List<SanPhamDTO> ds = SP.get_data();
            foreach (SanPhamDTO d in ds)
            {
                ListViewItem subitem = new ListViewItem(new[] { d.MaSP, d.TenSP, d.Gia.ToString(), d.MoTa });
                lst_SanPham.Items.Add(subitem);
            }
            tab_Xem.TabPages[0].Enabled = false;

            cbo_KH.SelectedItem = null;//====================================
            Load_DS_KH();
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_SanPham.SelectedItems)
            {
                if (kiemtrasl(item.SubItems[0].Text) == false)
                {
                    ListViewItem item1 = new ListViewItem(new[] { item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, "1" });
                    lst_GioHang.Items.Add(item1);
                }

            }

        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            string ma = "HD" + DateTime.Today.ToString("yyMMdd") + string.Format("{0:00}",SP.Dem_SL_HD()+1);
            txtMaHD.Text = ma;
            txtMaKH2.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            cbo_KH.Text= string.Empty;
            
            if (lst_GioHang.Items.Count > 0)
            {
                tab_Xem.TabPages[0].Enabled = true;
                tab_Xem.SelectedTab = tab_thanhtoan;
                foreach (ListViewItem tmp in lst_GioHang.Items)
                {
                    ListViewItem item1 = new ListViewItem(new[] { tmp.SubItems[0].Text, tmp.SubItems[1].Text, tmp.SubItems[2].Text, tmp.SubItems[3].Text });
                    lstThanhToan.Items.Add(item1);
                }
                //lst_GioHang.Clear();
            }
            double tt = TongTien();
            txtTong2.Text = tt.ToString();
        }

        private void btn_Loai_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lst_GioHang.SelectedItems)
            {
                lst_GioHang.Items.Remove(item);
            }

        }

        private void cbo_KH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenKH.Text = cbo_KH.SelectedValue.ToString();
            KhachHangDTO tmp = KH.Tim_1KH(txtTenKH.Text);
            txtEmail.Text = tmp.Email;
            txtDiaChi.Text = tmp.DChi;
            txtSDT.Text = tmp.SDT;
            txtMaKH2.Text= cbo_KH.SelectedValue.ToString();
            txtNgay.Text=DateTime.Now.ToString();

        }
        public double TongTien()
        {
            float tongtien = 0;
            foreach (ListViewItem tmp in lstThanhToan.Items)
            {
                float temp, temp1;
                if (float.TryParse(tmp.SubItems[3].Text, out temp) && float.TryParse(tmp.SubItems[2].Text, out temp1))
                {
                    tongtien = tongtien + (temp * temp1);
                }
                else
                {
                    // Xử lý lỗi nếu cần thiết, ví dụ: thông báo cho người dùng
                    MessageBox.Show("Lỗi");
                }
            }
            return tongtien;
        }
        public double GiamGia(bool kt)
        {
            if (kt == true)
                return (TongTien() * 5 / 100);
            return 0;
        }
        private void btn_thanhtoan1_Click(object sender, EventArgs e)
        {

            if (txtTienNhan.Text.Length > 0 && (txtTenKH.Text.Length > 0 || checkBox_KhachHangMoi.Checked == true) && float.Parse(txtTienNhan.Text) > TongTien()) 
            {
                txtTongTien.Text = TongTien().ToString();
                txtGiamGia.Text = GiamGia(checkBox_KHThanThiet.Checked).ToString();
                double pt = TongTien() - GiamGia(checkBox_KHThanThiet.Checked);
                txtPhaiTra.Text = pt.ToString();
                double tt = float.Parse(txtTienNhan.Text) - pt;
                txtTienThua.Text = tt.ToString();
                string kq="Tên KH:"+cbo_KH.Text+"\n"+"Số tiền phải trả:"+txtPhaiTra.Text+"\n"+"Mã Hóa Đơn:"+txtMaHD.Text;
                MessageBox.Show(kq);
            }
            else
            {
                MessageBox.Show("Tiền Nhận Không Đủ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //tab_Xem.TabPages[2].Enabled = true;



            HoaDonBLL hoaDonBLL = new HoaDonBLL();
            ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();
            string tmp_MaKH=string.Empty;
            if (checkBox_KhachHangMoi.Checked==true)
            {
                tmp_MaKH = "null";
                if (txtMaHD.Text.Length > 0 && hoaDonBLL.insert_HoaDon(txtMaHD.Text, tmp_MaKH, txtTongTien.Text, txtGiamGia.Text, txtPhaiTra.Text, MANV))
                {
                    foreach (ListViewItem tmp in lstThanhToan.Items)
                    {
                        float temp1;
                        int temp;
                        if (int.TryParse(tmp.SubItems[3].Text, out temp) && float.TryParse(tmp.SubItems[2].Text, out temp1))
                        {
                            ChiTietHoaDonDTO dt = new ChiTietHoaDonDTO(txtMaHD.Text, tmp.SubItems[0].Text, temp, temp1);
                            chiTietHoaDonBLL.Insert(dt);
                        }
                    }
                    MessageBox.Show("Xuất hóa đơn thành công !");
                }
                else
                {
                    MessageBox.Show("Kiểm Tra Điền Mã Hóa Đơn");
                }
            }
            else
            {
                tmp_MaKH = "'"+txtTenKH.Text+"'";
                if (txtMaHD.Text.Length > 0 && hoaDonBLL.insert_HoaDon(txtMaHD.Text, tmp_MaKH, txtTongTien.Text, txtGiamGia.Text, txtPhaiTra.Text, MANV))
                {
                    foreach (ListViewItem tmp in lstThanhToan.Items)
                    {
                        float temp1;
                        int temp;
                        if (int.TryParse(tmp.SubItems[3].Text, out temp) && float.TryParse(tmp.SubItems[2].Text, out temp1))
                        {
                            ChiTietHoaDonDTO dt = new ChiTietHoaDonDTO(txtMaHD.Text, tmp.SubItems[0].Text, temp, temp1);
                            chiTietHoaDonBLL.Insert(dt);
                        }
                    }
                    MessageBox.Show("Xuất hóa đơn thành công !");
                }
                else
                {
                    MessageBox.Show("Kiểm Tra Điền Mã Hóa Đơn");
                }
            }
            frm_Report_HoaDon f = new frm_Report_HoaDon(txtMaHD.Text.Trim());
            f.ShowDialog();
           
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {

            if(txt_add_MaKH.Text.Length>0 && txt_add_tenKH.Text.Length>0 && txt_add_SDT.Text.Length>0 && txt_add_Email.Text.Length>0 && txt_add_Address.Text.Length>0)
            {
                KhachHangDTO tmp = new KhachHangDTO(txt_add_MaKH.Text,txt_add_tenKH.Text,txt_add_Email.Text,txt_add_SDT.Text,txt_add_Address.Text);
                if(KH.kt_trung(tmp))
                {
                    if(KH.insertKH(tmp))
                    {
                        MessageBox.Show("Thêm thành công");
                    }    
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }    
                }
                else
                {
                    MessageBox.Show("Trùng mã khách hàng");
                } 
            }
            else
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
            } 
        }

        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            txt_add_Address.Clear();
            txt_add_MaKH.Clear();
            txt_add_tenKH.Clear();  txt_add_SDT.Clear();
            txt_add_Email.Clear();
        }

        private void btnHuyKH_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }

        private void btnThemKHmoi_Click(object sender, EventArgs e)
        {
            tab_Xem.SelectedTab = tabPage_themKHmoi;
        }

       
    }
}
