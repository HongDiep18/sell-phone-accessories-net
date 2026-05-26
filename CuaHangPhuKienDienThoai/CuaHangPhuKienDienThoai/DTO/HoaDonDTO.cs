using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string NgayMUA { get; set; }
        public float TongTien { get; set; }
        public float GiamGia { get; set; }
        public float PhaiTra { get;set; }
        public string MaNV { get; set; }
        public HoaDonDTO() { }
        public HoaDonDTO(string maHD, string maKH, string ngayMUA, float tongTien, float giamGia, float phaiTra, string maNV)
        {
            MaHD = maHD;
            MaKH = maKH;
            NgayMUA = ngayMUA;
            TongTien = tongTien;
            GiamGia = giamGia;
            PhaiTra = phaiTra;
            MaNV = maNV;
        }
    }
}
