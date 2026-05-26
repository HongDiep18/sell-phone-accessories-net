using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CHITIETPN_BLL
    {
        ChiTietPN_DAL ctPN_DAL {  get; set; }
        ChiTietPN_DTO ctPN_DTO { get; set; }
        public CHITIETPN_BLL() 
        {
            ctPN_DAL=new ChiTietPN_DAL();
            ctPN_DTO=new ChiTietPN_DTO();
        }
        public bool insert_ChiTietPN(ChiTietPN_DTO chiTietPN)
        {
            return ctPN_DAL.insert_ChiTietPN(chiTietPN);
        }
    }
}
