using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPN_DTO
    {
        public string MaPN { get; set; }
        public string MaSP { get; set;}
        public int SL { get; set;}
        public float Gia { get; set;}
        public float ThnanhTien { get; set;}
        public ChiTietPN_DTO() { }
        public ChiTietPN_DTO(string maPN, string maSP, int sL, float gia, float thnanhTien)
        {
            MaPN = maPN;
            MaSP = maSP;
            SL = sL;
            Gia = gia;
            ThnanhTien = thnanhTien;
        }   
    }
}
