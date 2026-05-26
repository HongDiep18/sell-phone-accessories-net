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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        NhaCungCapBLL nccBLL = new NhaCungCapBLL();
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            load_NCC();
        }
        public void load_NCC()
        {
            listView_NCC.Items.Clear();
            List<NhaCungCapDTO> ncc = nccBLL.GetAll();
            foreach (NhaCungCapDTO nha in ncc)
            {
                string[] item = { nha.MaNCC, nha.TenNCC, nha.DChiNCC, nha.SDTNCC, nha.EmailNCC };
                ListViewItem lst = new ListViewItem(item);
                listView_NCC.Items.Add(lst);
            }
        }
       
        private void addItemToListView(NhaCungCapDTO ncc)
        {
            string[] itm={ ncc.MaNCC,ncc.TenNCC,ncc.DChiNCC,ncc.SDTNCC,ncc.EmailNCC};
            ListViewItem item = new ListViewItem(itm);
            //item.SubItems.Add(ncc.MaNCC);
            //item.SubItems.Add(ncc.TenNCC);
            //item.SubItems.Add(ncc.DChiNCC);
            //item.SubItems.Add(ncc.SDTNCC);
            //item.SubItems.Add(ncc.EmailNCC);

            listView_NCC.Items.Add(item);

            listView_NCC.Refresh();
        }

        private void listView_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView_NCC.SelectedItems)
            {
                txtMaNCC.Text = item.SubItems[0].Text;
                txtTenNCC.Text = item.SubItems[1].Text;
                txtDiaChi.Text = item.SubItems[2].Text;
                txtSDT.Text = item.SubItems[3].Text;
                txtEM.Text = item.SubItems[4].Text;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nccDTO = new NhaCungCapDTO(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEM.Text);
            if (string.IsNullOrEmpty(txtMaNCC.Text) || string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtEM.Text))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin");
                return;
            }
            if (nccBLL.ktTrung(nccDTO.MaNCC) == false)
            {
                MessageBox.Show("Mã nhà cung cấp bị trùng, vui lòng thêm mã nhà cung cấp khác nhé");
                return;
            }
            else
            {
                if (nccBLL.addValue(nccDTO))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công");
                    addItemToListView(nccDTO);
                }
                else
                    MessageBox.Show("Thêm nhà cung cấp không thành công");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nccDTO = new NhaCungCapDTO(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEM.Text);
            if (nccBLL.deleteValue(nccDTO.MaNCC))
            {
                MessageBox.Show("Xóa nhà cung cấp thành công");
                load_NCC();
            }
            else
                MessageBox.Show("Xóa nhà cung cấp không thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaCungCapDTO nccDTO = new NhaCungCapDTO(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtSDT.Text, txtEM.Text);
            if (nccBLL.editValue(nccDTO))
            {
                MessageBox.Show("Sửa nhà cung cấp thành công");
                load_NCC();

            }
            else
                MessageBox.Show("Sửa nhà cung cấp không thành công");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtEM.Clear();
        }
    }
}
