using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class SanPhamBLL
    {
        public SanPhamDAL sanphamDAL { get; set; }
        public SanPhamDTO sanphamDTO { get; set; }
        public SanPhamBLL() 
        {
            sanphamDAL = new SanPhamDAL();
            sanphamDTO = new SanPhamDTO();
        }
        public List<SanPhamDTO>get_data()
        {
            return sanphamDAL.get_DanhSachSP();
        }
        public bool insert_sanPham(SanPhamDTO sanpham)
        {
            return sanphamDAL.insert_sanPham(sanpham);
        }
        public List <SanPhamDTO>get_data_theoDM(string ma)
        {
            return sanphamDAL.get_DanhSachSP_TheoDanhMuc(ma);
        }
        public int DemSLSP_theoDM(string ma)
        {
            return sanphamDAL.DemSLSP_TheoDanhMuc(ma);
        }
        public bool Xoa_SP(string ma)
        {
            return sanphamDAL.Xoa_SP(ma);
        }
        public bool Sua_SP(SanPhamDTO tmp)
        {
            return sanphamDAL.XuaSanPham(tmp);
        }
        public int Dem_SL_HD()
        {
            return sanphamDAL.Dem_SL_HD();
        }
    }
}
