using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ThongKeDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public ThongKeDAL()
        {
            conn = new SqlConnection(conStr);
        }
        public List<string> get_Month()
        {
            List<string> list = new List<string>();
            string sql = "select DISTINCT MONTH( NGAYDATHANG) from HOADON ORDER BY MONTH( NGAYDATHANG)";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            conn.Close();
            return list;
        }

        public List<string> get_Year()
        {
            List<string> list = new List<string>();
            string sql = "select DISTINCT YEAR( NGAYDATHANG) from HOADON ORDER BY YEAR( NGAYDATHANG)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            conn.Close();
            return list;
        }

        public string get_DT_TheoThang(string thang,string nam)
        {
          
            string sql = "select sum(PHAITRA) from HOADON where MONTH(NGAYDATHANG)="+thang+" and YEAR( NGAYDATHANG)="+nam+"";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql,conn);
            string chiPhi_=cmd.ExecuteScalar().ToString();
            conn.Close();
            return chiPhi_;
        }

        public string get_DT_TheoNam(string nam)
        {
            
            string sql = "select sum(PHAITRA) from HOADON where  YEAR( NGAYDATHANG)=" + nam + "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            string chiPhi_ = cmd.ExecuteScalar().ToString();
            conn.Close();
            return chiPhi_;
        }
        public string get_CP_Nhap_Thang(string thang,string nam)
        {
            string sql = "select sum(TONGTIEN) from PHIEUNHAP where MONTH(NGAYNHAP)="+thang+" and YEAR( NGAYNHAP)="+nam+"";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            string chiPhi_ = cmd.ExecuteScalar().ToString();
            conn.Close();
            return chiPhi_;
        }

        public string get_CP_Nhap_Nam( string nam)
        {
            string sql = "select sum(TONGTIEN) from PHIEUNHAP where  YEAR( NGAYNHAP)=" + nam + "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            string chiPhi_ = cmd.ExecuteScalar().ToString();
            conn.Close();
            return chiPhi_;
        }


        public List<string> get_Month_CP()
        {
            List<string> list = new List<string>();
            string sql = "select DISTINCT MONTH( NGAYNHAP) from PHIEUNHAP ORDER BY MONTH( NGAYNHAP)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            conn.Close();
            return list;
        }

        public List<string> get_Year_CP()
        {
            List<string> list = new List<string>();
            string sql = "select DISTINCT YEAR( NGAYNHAP) from PHIEUNHAP ORDER BY YEAR( NGAYNHAP)";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            conn.Close();
            return list;
        }
    }
}
