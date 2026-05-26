using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }

        public string DChiNCC { get;set; }
        public string SDTNCC { get; set; }
        public string EmailNCC { get; set; }
        public NhaCungCapDTO() { }  
        public NhaCungCapDTO(string maNCC, string tenNCC, string dChiNCC, string sDTNCC, string emailNCC)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DChiNCC = dChiNCC;
            SDTNCC = sDTNCC;
            EmailNCC = emailNCC;
        }
    }
}
