using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL pnDAL { get; set; }
        PhieuNhapDTO pnDTO { get; set; }
        public PhieuNhapBLL() 
        {
            pnDAL = new PhieuNhapDAL();
            pnDTO = new PhieuNhapDTO();
        }
        public bool insert(PhieuNhapDTO tmp)
        {
            return pnDAL.insert_PhieuNhap(tmp);
        }
        public List<PhieuNhapDTO> get_ds_PN_Thang(string thang, string nam)
        {
            return pnDAL.get_DS_PN_Thang(thang, nam);
        }
        public List<PhieuNhapDTO> get_ds_PN_Nam( string nam)
        {
            return pnDAL.get_DS_PN_Nam(nam);
        }
        public int Dem_SL_PN()
        {
            return pnDAL.Dem_SL_PN();
        }
    }
}
