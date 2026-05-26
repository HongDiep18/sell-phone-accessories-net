using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMucDTO
    {
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public DanhMucDTO() { }
        public DanhMucDTO(string maDM, string tenDM)
        {
            MaDM = maDM;
            TenDM = tenDM;
        }
    }
}
