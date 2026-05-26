using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    
    public class KhachHangBLL
    {
        KhachHangDAL KhachHangDAL { get; set; }
        KhachHangDTO KhachHangDTO { get; set; }
        
        public KhachHangBLL()
        {
            KhachHangDAL = new KhachHangDAL();
            KhachHangDTO = new KhachHangDTO();
        }
        public List<KhachHangDTO> get_ds_KH()
        {
            return KhachHangDAL.get_DanhSach_KhachHang();
        }
        public KhachHangDTO Tim_1KH(string ma)
        {
            KhachHangDTO tmp = new KhachHangDTO();
            List<KhachHangDTO> tmp_ = get_ds_KH();
            foreach(KhachHangDTO k in tmp_)
            {
                if(ma==k.MaKH)
                {
                    tmp = k;
                    return k;
                }    
            }
            return tmp;
        }
        public bool insertKH(KhachHangDTO k)
        {
            if(KhachHangDAL.InsertKH(k.MaKH,k.TenKH,k.Email,k.SDT,k.DChi))
                return true;
            return false;
        }
        public bool kt_trung(KhachHangDTO k)
        {
            if(KhachHangDAL.KT_TrungMaKH(k.MaKH))
                return true;
            return false;
        }
        public bool xoa_KH(KhachHangDTO tmp)
        {
            return KhachHangDAL.Xoa_KH(tmp);
        }
        public bool sua_KH(KhachHangDTO tmp)
        {
            return KhachHangDAL.Sua_KH(tmp);
        }
    }
}
