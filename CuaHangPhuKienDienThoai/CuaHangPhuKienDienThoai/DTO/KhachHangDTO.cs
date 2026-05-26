using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string DChi { get; set; }
        public KhachHangDTO() { }
        public KhachHangDTO(string maKH, string tenKH, string email, string sDT, string dChi)
        {
            MaKH = maKH;
            TenKH = tenKH;
            Email = email;
            SDT = sDT;
            DChi = dChi;
        }
    }
}
