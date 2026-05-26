namespace GUI
{
    partial class frmNhapKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_SanPham = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_MaSp = new System.Windows.Forms.TextBox();
            this.comboBox_NhaCungCap = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TenSp = new System.Windows.Forms.TextBox();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.txt_NgayNhap = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listView_GioHang = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_DonGia = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btn_LoaiSP = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThemSPMoi = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnInPN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_SanPham
            // 
            this.listView_SanPham.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_SanPham.FullRowSelect = true;
            this.listView_SanPham.HideSelection = false;
            this.listView_SanPham.Location = new System.Drawing.Point(15, 326);
            this.listView_SanPham.MultiSelect = false;
            this.listView_SanPham.Name = "listView_SanPham";
            this.listView_SanPham.Size = new System.Drawing.Size(433, 239);
            this.listView_SanPham.TabIndex = 0;
            this.listView_SanPham.UseCompatibleStateImageBehavior = false;
            this.listView_SanPham.View = System.Windows.Forms.View.Details;
            this.listView_SanPham.SelectedIndexChanged += new System.EventHandler(this.listView_SanPham_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Sản Phẩm";
            this.columnHeader1.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Sản Phẩm";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SL";
            this.columnHeader3.Width = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kho";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Số lượng ";
            // 
            // txt_MaSp
            // 
            this.txt_MaSp.Location = new System.Drawing.Point(127, 35);
            this.txt_MaSp.Name = "txt_MaSp";
            this.txt_MaSp.Size = new System.Drawing.Size(249, 22);
            this.txt_MaSp.TabIndex = 5;
            // 
            // comboBox_NhaCungCap
            // 
            this.comboBox_NhaCungCap.FormattingEnabled = true;
            this.comboBox_NhaCungCap.Location = new System.Drawing.Point(523, 22);
            this.comboBox_NhaCungCap.Name = "comboBox_NhaCungCap";
            this.comboBox_NhaCungCap.Size = new System.Drawing.Size(277, 24);
            this.comboBox_NhaCungCap.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhà cung cấp";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ngày Nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Thành Tiền";
            // 
            // txt_TenSp
            // 
            this.txt_TenSp.Location = new System.Drawing.Point(127, 76);
            this.txt_TenSp.Name = "txt_TenSp";
            this.txt_TenSp.Size = new System.Drawing.Size(249, 22);
            this.txt_TenSp.TabIndex = 10;
            // 
            // txt_SL
            // 
            this.txt_SL.Location = new System.Drawing.Point(513, 35);
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(249, 22);
            this.txt_SL.TabIndex = 11;
            // 
            // txt_NgayNhap
            // 
            this.txt_NgayNhap.Enabled = false;
            this.txt_NgayNhap.Location = new System.Drawing.Point(126, 65);
            this.txt_NgayNhap.Name = "txt_NgayNhap";
            this.txt_NgayNhap.Size = new System.Drawing.Size(249, 22);
            this.txt_NgayNhap.TabIndex = 12;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Enabled = false;
            this.txtThanhTien.Location = new System.Drawing.Point(523, 65);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(277, 22);
            this.txtThanhTien.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(863, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Danh sách sản phẩm sẽ nhập";
            // 
            // listView_GioHang
            // 
            this.listView_GioHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView_GioHang.FullRowSelect = true;
            this.listView_GioHang.HideSelection = false;
            this.listView_GioHang.Location = new System.Drawing.Point(866, 84);
            this.listView_GioHang.Name = "listView_GioHang";
            this.listView_GioHang.Size = new System.Drawing.Size(525, 481);
            this.listView_GioHang.TabIndex = 14;
            this.listView_GioHang.UseCompatibleStateImageBehavior = false;
            this.listView_GioHang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã SP";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên SP";
            this.columnHeader5.Width = 130;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Đơn Giá";
            this.columnHeader6.Width = 70;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "SL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_DonGia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_MaSp);
            this.groupBox1.Controls.Add(this.txt_TenSp);
            this.groupBox1.Controls.Add(this.txt_SL);
            this.groupBox1.Location = new System.Drawing.Point(15, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 115);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết phiếu nhập";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(405, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Đơn giá";
            // 
            // txt_DonGia
            // 
            this.txt_DonGia.Location = new System.Drawing.Point(513, 76);
            this.txt_DonGia.Name = "txt_DonGia";
            this.txt_DonGia.Size = new System.Drawing.Size(249, 22);
            this.txt_DonGia.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMaPN);
            this.groupBox2.Controls.Add(this.txt_NgayNhap);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtThanhTien);
            this.groupBox2.Controls.Add(this.comboBox_NhaCungCap);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(15, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(809, 114);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phiếu nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Mã Phiếu Nhập";
            // 
            // txtMaPN
            // 
            this.txtMaPN.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtMaPN.Location = new System.Drawing.Point(126, 23);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(249, 22);
            this.txtMaPN.TabIndex = 15;
            this.txtMaPN.Text = "Điền Mã Phiếu Nhập";
            this.txtMaPN.Click += new System.EventHandler(this.txtMaPN_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(482, 386);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(196, 44);
            this.btnThem.TabIndex = 18;
            this.btnThem.Text = "Thêm Sản Phẩm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btn_LoaiSP
            // 
            this.btn_LoaiSP.Location = new System.Drawing.Point(482, 446);
            this.btn_LoaiSP.Name = "btn_LoaiSP";
            this.btn_LoaiSP.Size = new System.Drawing.Size(196, 44);
            this.btn_LoaiSP.TabIndex = 19;
            this.btn_LoaiSP.Text = "Loại Sản Phẩm";
            this.btn_LoaiSP.UseVisualStyleBackColor = true;
            this.btn_LoaiSP.Click += new System.EventHandler(this.btn_LoaiSP_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(482, 506);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(196, 44);
            this.btnThanhToan.TabIndex = 20;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnThemSPMoi
            // 
            this.btnThemSPMoi.Location = new System.Drawing.Point(483, 326);
            this.btnThemSPMoi.Name = "btnThemSPMoi";
            this.btnThemSPMoi.Size = new System.Drawing.Size(196, 44);
            this.btnThemSPMoi.TabIndex = 21;
            this.btnThemSPMoi.Text = "Thêm Sản Phẩm Mới";
            this.btnThemSPMoi.UseVisualStyleBackColor = true;
            this.btnThemSPMoi.Click += new System.EventHandler(this.btnThemSPMoi_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(713, 326);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(112, 66);
            this.btnLamMoi.TabIndex = 22;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnInPN
            // 
            this.btnInPN.Location = new System.Drawing.Point(713, 424);
            this.btnInPN.Name = "btnInPN";
            this.btnInPN.Size = new System.Drawing.Size(112, 66);
            this.btnInPN.TabIndex = 23;
            this.btnInPN.Text = "In Phiếu Nhập";
            this.btnInPN.UseVisualStyleBackColor = true;
            this.btnInPN.Click += new System.EventHandler(this.btnInPN_Click);
            // 
            // frmNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 596);
            this.Controls.Add(this.btnInPN);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnThemSPMoi);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btn_LoaiSP);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listView_GioHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_SanPham);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmNhapKho";
            this.Text = "frmNhapKho";
            this.Load += new System.EventHandler(this.frmNhapKho_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_SanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_MaSp;
        private System.Windows.Forms.ComboBox comboBox_NhaCungCap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TenSp;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.TextBox txt_NgayNhap;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listView_GioHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btn_LoaiSP;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnThemSPMoi;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnInPN;
    }
}