using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThongKeBLL
    {
        public ThongKeDAL tkDALL {  get; set; }
        public ThongKeBLL()
        {
            tkDALL = new ThongKeDAL();
        }
        public List<string>get_Month()
        {
            return tkDALL.get_Month();
        }

        public List<string> get_Year()
        {
            return tkDALL.get_Year();
        }
        public List<string> get_Month_CP()
        {
            return tkDALL.get_Month_CP();
        }

        public List<string> get_Year_CP()
        {
            return tkDALL.get_Year_CP();
        }
        public string get_ChiPhi_Thang(string thang,string nam)
        {         
            return tkDALL.get_DT_TheoThang(thang,nam);
        }
        public string get_ChiPhi_Nam(string nam)
        {
            return tkDALL.get_DT_TheoNam(nam);
        }

        public string get_CP_Thang(string thang,string nam)
        {
            return tkDALL.get_CP_Nhap_Thang(thang, nam);
        }

        public string get_CP_Nam( string nam)
        {
            return tkDALL.get_CP_Nhap_Nam( nam);
        }
    }
}
