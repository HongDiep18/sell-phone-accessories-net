using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string SDT{ get; set; }
        public string Email { get; set; }
        public float Luong { get; set; }
        public string Password { get; set; }    
        public NhanVienDTO() { }
        public NhanVienDTO(string maNV, string tenNV, string chucVu, string sDT, string email, float luong, string password)
        {
            MaNV = maNV;
            TenNV = tenNV;
            ChucVu = chucVu;
            SDT = sDT;
            Email = email;
            Luong = luong;
            Password = password;
        }
    }
}
