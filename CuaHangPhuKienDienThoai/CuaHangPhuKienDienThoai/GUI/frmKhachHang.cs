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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KhachHangBLL khBLL = new KhachHangBLL();
        public void load_KH()
        {
            listView_KhachHang.Items.Clear();
            List<KhachHangDTO> ds = khBLL.get_ds_KH();
            foreach(KhachHangDTO kh in ds)
            {
                string[] itm = { kh.MaKH, kh.TenKH, kh.SDT, kh.Email, kh.DChi };
                ListViewItem item = new ListViewItem(itm);
                listView_KhachHang.Items.Add(item);
            }    
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load_KH();
        }

        private void listView_KhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView_KhachHang.SelectedItems)
            {
                txtMakh.Text = item.SubItems[0].Text;
                txtTenkh.Text = item.SubItems[1].Text;
                txtSDT.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
                txtDC.Text = item.SubItems[4].Text;
            }    
        }

        private void txtMakh_Click(object sender, EventArgs e)
        {
            txtMakh.Clear();
        }

        private void txtTenkh_Click(object sender, EventArgs e)
        {
            txtTenkh.Clear();
        }

        private void txtSDT_Click(object sender, EventArgs e)
        {
            txtSDT.Clear();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtEmail.Clear();
        }

        private void txtDC_Click(object sender, EventArgs e)
        {
            txtDC.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMakh.Text.Length>0 && txtTenkh.Text.Length>0 && txtSDT.Text.Length > 0 && txtEmail.Text.Length > 0 && txtDC.Text.Length > 0)
            {
                KhachHangDTO tmp =new KhachHangDTO(txtMakh.Text,txtTenkh.Text,txtEmail.Text,txtSDT.Text,txtDC.Text);
                if (khBLL.kt_trung(tmp))
                {
                    if(khBLL.insertKH(tmp))
                    {
                        MessageBox.Show("Thêm thành coong");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }    
                }
                else
                {
                    MessageBox.Show("Trùng mã Khách Hàng");
                }
            }   
            else
            {
                MessageBox.Show("Nhập Thông Tin");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(listView_KhachHang.SelectedItems.Count>0)
            {
                KhachHangDTO tmp = new KhachHangDTO(txtMakh.Text, txtTenkh.Text, txtEmail.Text, txtSDT.Text, txtDC.Text);
                if (khBLL.kt_trung(tmp)==false)
                {
                    if(khBLL.xoa_KH(tmp))
                    {
                        MessageBox.Show("Xóa Thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Khách hàng không tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Chọn Khách hàng cần xóa");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMakh.Text.Length > 0 && txtTenkh.Text.Length > 0 && txtSDT.Text.Length > 0 && txtEmail.Text.Length > 0 && txtDC.Text.Length > 0)
            {
                KhachHangDTO tmp = new KhachHangDTO(txtMakh.Text, txtTenkh.Text, txtEmail.Text, txtSDT.Text, txtDC.Text);
                if (khBLL.kt_trung(tmp)==false)
                {
                    if (khBLL.sua_KH(tmp))
                    {
                        MessageBox.Show("Sửa thành coong");
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Không thấy Khách Hàng");
                }
            }
            else
            {
                MessageBox.Show("Nhập Thông Tin");
            }
        }
    }
}
