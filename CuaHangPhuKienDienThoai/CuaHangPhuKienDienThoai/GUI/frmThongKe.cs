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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        ThongKeBLL tkBLL= new ThongKeBLL();
        PhieuNhapBLL pnBLL= new PhieuNhapBLL();
        HoaDonBLL hdBLL= new HoaDonBLL();
        public void load_Thang()
        {
            List<string> ds = tkBLL.get_Month();
            foreach (string s in ds)
            {
                cbo_Thang.Items.Add(s);
            }
            List<string> ds1 = tkBLL.get_Month_CP();
            foreach (string s in ds1)
            {
                cbo_Thang1.Items.Add(s);
            }
        }
        public void load_Nam()
        {
            List<string> ds = tkBLL.get_Year();
            foreach (string s in ds)
            {
                cbo_Nam.Items.Add(s);
            }
            List<string> ds1 = tkBLL.get_Year_CP();
            foreach (string s in ds)
            {
                cbo_Nam1.Items.Add(s);
            }
        }
        public void load_HOADON()
        {

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            load_Thang();
            load_Nam();
        }

        

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(rdoThang.Checked && cbo_Nam.SelectedItem !=null && cbo_Thang.SelectedItem!=null)
            {
                listView_HOADON.Items.Clear();
                List<HoaDonDTO> ds = hdBLL.get_ds_Thang(cbo_Thang.Text, cbo_Nam.Text);
                foreach (HoaDonDTO tmp in ds)
                {
                    string[] itm = { tmp.MaHD, tmp.MaKH, tmp.NgayMUA, tmp.PhaiTra.ToString(), tmp.MaNV };
                    ListViewItem item= new ListViewItem(itm);
                    listView_HOADON.Items.Add(item);
                    
                }

                txtChiPhi.Text = tkBLL.get_ChiPhi_Thang(cbo_Thang.Text, cbo_Nam.Text).ToString();
            }    
            else if (rdoNam.Checked && cbo_Nam.SelectedItem != null)
            {
                listView_HOADON.Items.Clear();
                List<HoaDonDTO> ds = hdBLL.get_ds_Nam( cbo_Nam.Text);
                foreach (HoaDonDTO tmp in ds)
                {
                    string[] itm = { tmp.MaHD, tmp.MaKH, tmp.NgayMUA, tmp.PhaiTra.ToString(), tmp.MaNV };
                    ListViewItem item = new ListViewItem(itm);
                    listView_HOADON.Items.Add(item);

                }

                txtChiPhi.Text = tkBLL.get_ChiPhi_Nam(cbo_Nam.Text).ToString();
            }
            else
            {
                MessageBox.Show("Chọn Tháng Chọn Năm");
            }
        }

        private void btnThongKe1_Click(object sender, EventArgs e)
        {
            if (rdo_Thang1.Checked && cbo_Nam1.SelectedItem != null && cbo_Thang1.SelectedItem != null)
            {
                listView_PHIEUNHAP.Items.Clear();
                List<PhieuNhapDTO> ds = pnBLL.get_ds_PN_Thang(cbo_Thang1.Text, cbo_Nam1.Text);
                foreach (PhieuNhapDTO p in ds)
                {
                    string[] itm = { p.MaPN, p.MaNCC, p.NgayNhap, double.Parse(p.TongTien.ToString()).ToString(), p.MaNV };
                    ListViewItem item = new ListViewItem(itm);
                    listView_PHIEUNHAP.Items.Add(item);
                }


                txtChiPhiNhap.Text = tkBLL.get_CP_Thang(cbo_Thang1.Text, cbo_Nam1.Text);
            }
            else if (rdo_Nam1.Checked && cbo_Nam1.SelectedItem != null)
            {

                listView_PHIEUNHAP.Items.Clear();
                List<PhieuNhapDTO> ds = pnBLL.get_ds_PN_Nam( cbo_Nam1.Text);
                foreach (PhieuNhapDTO p in ds)
                {
                    string[] itm = { p.MaPN, p.MaNCC, p.NgayNhap, double.Parse(p.TongTien.ToString()).ToString(), p.MaNV };
                    ListViewItem item = new ListViewItem(itm);
                    listView_PHIEUNHAP.Items.Add(item);
                }

                txtChiPhiNhap.Text = tkBLL.get_CP_Nam( cbo_Nam1.Text);
            }
            else
            {
                MessageBox.Show("Chọn Tháng Chọn Năm");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            frmBao_Cao1 f = new frmBao_Cao1();
            f.ShowDialog();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            frmBao_Cao2 f = new frmBao_Cao2();
            f.ShowDialog();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            frmBao_Cao3 f = new frmBao_Cao3();
            f.ShowDialog();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            frmBao_Cao4 f = new frmBao_Cao4();
            f.ShowDialog();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            frmBao_Cao5 f = new frmBao_Cao5();
            f.ShowDialog();
        }
    }
}
