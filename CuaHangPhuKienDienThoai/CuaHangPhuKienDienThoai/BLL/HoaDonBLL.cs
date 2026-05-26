using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDTO hoaDonDTO { get; set; }
        HoaDonDAL hoaDonDAL { get; set;}
        public HoaDonBLL() { 
            hoaDonDAL= new HoaDonDAL();
            hoaDonDTO= new HoaDonDTO(); 
        }
        public bool insert_HoaDon(string mahd, string makh,string tong, string giam, string phaitra,string manv)
        {
            try
            {
                if (hoaDonDAL.insertHoaDonDAL(mahd, makh, tong, giam, phaitra,manv))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<HoaDonDTO> get_ds_Thang(string thang,string nam)
        {
            return hoaDonDAL.get_ds_HOADON_Thang(thang,nam);
        }
        public List<HoaDonDTO> get_ds_Nam( string nam)
        {
            return hoaDonDAL.get_ds_HOADON_Nam( nam);
        }
    }
}
