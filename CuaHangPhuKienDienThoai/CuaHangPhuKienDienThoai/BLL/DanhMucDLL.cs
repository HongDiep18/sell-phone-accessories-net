using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucDLL
    {
        public DanhMucDAL dmDAL {  get; set; }
        public DanhMucDTO dmDTO { get; set; }
        public DanhMucDLL()
        {
            dmDAL = new DanhMucDAL();
            dmDTO = new DanhMucDTO();
        }
        public List<DanhMucDTO> getData()
        {
            return dmDAL.get_DS_danhmuc();
        }
        public bool insert_DM(DanhMucDTO tmp)
        {
            return dmDAL.insert_danhMuc(tmp);
        }
        public bool sua_DM(string ma, string ten)
        {
            return dmDAL.Sua_DANHMUC(ma, ten);
        }
        public bool xoa_DanhMuc(string ma)
        {
            return dmDAL.Xoa_DANHMUC(ma);
        }

    }
}
