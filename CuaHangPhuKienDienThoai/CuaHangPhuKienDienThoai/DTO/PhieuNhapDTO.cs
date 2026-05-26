using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        public string MaPN { get; set; }
        public string MaNCC { get; set; }
        public string NgayNhap { get; set;   }
        public float TongTien { get; set; }
        public string MaNV { get; set; }
        public PhieuNhapDTO() { }
        public PhieuNhapDTO(string maPN, string maNCC, string ngayNhap, float tongTien, string maNV)
        {
            MaPN = maPN;
            MaNCC = maNCC;
            NgayNhap = ngayNhap;
            TongTien = tongTien;
            MaNV = maNV;
        }
    }
}
