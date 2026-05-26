using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPN_DAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public ChiTietPN_DAL()
        {
            conn = new SqlConnection(conStr);
        }
        public bool insert_ChiTietPN(ChiTietPN_DTO tmp)
        {
            string sql = "insert into CHITIETPN values ('" + tmp.MaPN + "','" + tmp.MaSP + "'," + tmp.SL + "," + tmp.Gia + "," + tmp.ThnanhTien + ")";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq=(int)cmd.ExecuteNonQuery();
            conn.Close();
            if (kq>0)
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
