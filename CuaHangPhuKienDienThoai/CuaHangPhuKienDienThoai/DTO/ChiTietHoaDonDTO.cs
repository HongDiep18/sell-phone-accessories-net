using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SL { get; set; }
        public float Gia { get; set; }
        public ChiTietHoaDonDTO() { }
        public ChiTietHoaDonDTO(string maHD, string maSP, int sL, float gia)
        {
            MaHD = maHD;
            MaSP = maSP;
            SL = sL;
            Gia = gia;
        }
    }
}
