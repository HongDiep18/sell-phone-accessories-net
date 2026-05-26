using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public float Gia { get; set; }
        public int SLTonKo { get; set; }
        public string MaDM { get; set; }
        public SanPhamDTO() { }
        public SanPhamDTO(string maSP, string tenSP, string moTa, float gia, int sLTonKo, string maDM)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MoTa = moTa;
            Gia = gia;
            SLTonKo = sLTonKo;
            MaDM = maDM;
        }
    }
}
