using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        ChiTietHoaDonDTO CTHDDTO {  get; set; }
        ChiTietHoaDonDAL CTHDDAL { get; set; }
        public ChiTietHoaDonBLL()
        { 
            CTHDDTO= new ChiTietHoaDonDTO();
            CTHDDAL = new ChiTietHoaDonDAL();
        }
        public bool Insert(ChiTietHoaDonDTO tmp)
        {
            if(CTHDDAL.insert_ChiTietHD(tmp)!=-1)
            {
                return true;
            }
            else
            {
                   return false;
            }
        }
    }
}
