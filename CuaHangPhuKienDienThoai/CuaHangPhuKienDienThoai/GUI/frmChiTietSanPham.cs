using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmChiTietSanPham : Form
    {
        public string loai;
        public frmChiTietSanPham(string loai)
        {
            InitializeComponent();
            this.loai = loai;
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            listView_SanPham.Items.Clear();
            if(loai !="")
            {
                btnEdit.Enabled = false;
                btnXoa.Enabled = false;
                txtSL.Enabled = false;
            }
            Loadsp();
            //loadDanhMuc();
            
        }
        public void Loadsp()
        {
            SanPhamBLL spBLL= new SanPhamBLL();
            List<SanPhamDTO> ds = spBLL.get_data();
            foreach(SanPhamDTO d in ds)
            {
                string[] itm = { d.MaSP, d.TenSP, d.SLTonKo.ToString(), d.Gia.ToString(),d.MoTa, d.MaDM };
                ListViewItem item = new ListViewItem(itm);
                listView_SanPham.Items.Add(item);
            }    
        }
        public void loadDanhMuc()
        {
            DanhMucDLL dmBLL = new DanhMucDLL();
            cboDM.DataSource = dmBLL.getData();
            cboDM.DisplayMember = "TenDM";
            cboDM.ValueMember = "MaDM";
        }


        // Đoạn mã để hiển thị thông tin sản phẩm khi chọn sản phẩm trong ListView
        private void listView_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_SanPham.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_SanPham.SelectedItems[0];
                txtMa.Text = item.SubItems[0].Text.Trim();
                txtTen.Text = item.SubItems[1].Text.Trim();
                txtSL.Text = item.SubItems[2].Text.Trim();
                txtGia.Text = item.SubItems[3].Text.Trim();
                txtMoTa.Text = item.SubItems[4].Text.Trim();
                cboDM.Text = item.SubItems[5].Text.Trim();

                // Hiển thị ảnh sản phẩm
                string imagePath = "C:\\Users\\vuxec\\OneDrive\\Máy tính\\QLDA_NET\\QLDA_CN.NET\\Nhom7_CuaHangPhuKienDienThoai\\CuaHangPhuKienDienThoai\\GUI\\Imgs\\" + txtMa.Text.Trim() + ".jpg";

                try
                {
                    Bitmap bm = new Bitmap(imagePath);
                    pictureBox_Anh.Image = bm;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                }


               
                
            }
        }

        


        public void Load_SP_TheoDanhMuc(string ma)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            List<SanPhamDTO> ds = new List<SanPhamDTO>();
            ds = spBLL.get_data_theoDM(ma);
            foreach (SanPhamDTO d in ds)
            {
                string[] itm = { d.MaSP, d.TenSP, d.SLTonKo.ToString(), d.Gia.ToString(), d.MoTa, d.MaDM };
                ListViewItem item = new ListViewItem(itm);
                listView_SanPham.Items.Add(item);
            }
        }
        private void cboDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView_SanPham.Items.Clear();
            Load_SP_TheoDanhMuc(cboDM.SelectedValue.ToString());
        }

        private void cboDM_Click(object sender, EventArgs e)
        {
            loadDanhMuc();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            frmChiTietSanPham_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboDM.SelectedValue == null)
            {
                SanPhamDTO sp = new SanPhamDTO(txtMa.Text, txtTen.Text, txtMoTa.Text, float.Parse(txtGia.Text), 0, cboDM.Text);
                SanPhamBLL spBLL = new SanPhamBLL();
                if (spBLL.insert_sanPham(sp))
                {
                    // Thêm phần xử lý ảnh ở đây
                    if (pictureBox_Anh.Image != null)
                    {
                        string destinationFolder = Path.Combine(Application.StartupPath, "ProductImages");
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }
                        string imagePath = Path.Combine(destinationFolder, txtMa.Text.Trim() + ".jpg");
                        pictureBox_Anh.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, Kiểm tra mã sản phẩm và nhập đầy đủ thông tin");
                }
            }
            else
            {
                SanPhamDTO sp = new SanPhamDTO(txtMa.Text, txtTen.Text, txtMoTa.Text, float.Parse(txtGia.Text), 0, cboDM.SelectedValue.ToString());
                SanPhamBLL spBLL = new SanPhamBLL();
                if (spBLL.insert_sanPham(sp))
                {
                    // Thêm phần xử lý ảnh ở đây (giống như trên)
                    if (pictureBox_Anh.Image != null)
                    {
                        string destinationFolder = Path.Combine(Application.StartupPath, "ProductImages");
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }
                        string imagePath = Path.Combine(destinationFolder, txtMa.Text.Trim() + ".jpg");
                        pictureBox_Anh.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, Kiểm tra mã sản phẩm và nhập đầy đủ thông tin");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SanPhamBLL spBLL= new SanPhamBLL();
            if(listView_SanPham.SelectedItems!=null)
            {
                if(spBLL.Xoa_SP(txtMa.Text))
                {
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại, do sản phẩm còn trong kho và liên quan đến Hóa Đơn, Phiếu Nhập");
                }
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm cần xóa");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SanPhamBLL spBLL = new SanPhamBLL();
            if (listView_SanPham.SelectedItems != null)
            {
                SanPhamDTO tmp = new SanPhamDTO(txtMa.Text,txtTen.Text,txtMoTa.Text,float.Parse(txtGia.Text),int.Parse(txtSL.Text),cboDM.Text);
                if (spBLL.Sua_SP(tmp))
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa Thất Bại");
                }
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm cần Sửa");
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\vuxec\OneDrive\Desktop";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Chọn hình ảnh sản phẩm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string sourceFilePath = openFileDialog.FileName;
                        string destinationFolder = @"D:\GITHUB\HocKy5\CongNgheNet\test_baocao1\QLDA_CN.NET\Nhom7_CuaHangPhuKienDienThoai\CuaHangPhuKienDienThoai\GUI\Imgs";

                        // Tạo thư mục nếu chưa tồn tại
                        if (!Directory.Exists(destinationFolder))
                        {
                            Directory.CreateDirectory(destinationFolder);
                        }

                        // Tạo tên file mới sử dụng mã sản phẩm
                        string newFileName = txtMa.Text.Trim() + Path.GetExtension(sourceFilePath);
                        string destinationFilePath = Path.Combine(destinationFolder, newFileName);

                        // Giải phóng ảnh cũ trong PictureBox nếu có
                        if (pictureBox_Anh.Image != null)
                        {
                            var oldImage = pictureBox_Anh.Image;
                            pictureBox_Anh.Image = null;
                            oldImage.Dispose();
                        }

                        // Đọc ảnh vào memory và tạo bản sao
                        using (var sourceImage = new Bitmap(sourceFilePath))
                        {
                            // Tạo bản sao của ảnh
                            using (Bitmap copy = new Bitmap(sourceImage))
                            {
                                // Lưu bản sao vào thư mục đích
                                copy.Save(destinationFilePath);
                                // Gán ảnh mới cho PictureBox
                                pictureBox_Anh.Image = new Bitmap(destinationFilePath);
                            }
                        }

                        MessageBox.Show("Đã chọn và lưu ảnh thành công vào thư mục " + destinationFolder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message + "\nVui lòng thử lại.");
                    }
                }
            }
        }
    }
}
