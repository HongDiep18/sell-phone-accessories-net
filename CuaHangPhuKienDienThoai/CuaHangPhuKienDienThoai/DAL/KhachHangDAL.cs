using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class KhachHangDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public KhachHangDAL()
        {
            conn = new SqlConnection(conStr);
        }

        public List<KhachHangDTO> get_DanhSach_KhachHang()
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            string sql = "select * from KHACHANG";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ma = dr[0].ToString();
                string ten = dr[1].ToString();
                string email = dr[2].ToString();
                string sdt = dr[3].ToString();
                string dchi = dr[4].ToString();
               
                KhachHangDTO tmp = new KhachHangDTO(ma, ten, email, sdt, dchi);
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public bool KT_TrungMaKH(string ma)
        {
            string sql = "select count(*) from KHACHANG where MAKH='" + ma + "'";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            int kt=(int)cmd.ExecuteScalar();
            conn.Close();
            if (kt > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool InsertKH(string ma, string ten, string email, string sdt, string dc)
        {
            try
            {
                string sql = "insert into KHACHANG values ('" + ma + "',N'" + ten + "','" + email + "','" + sdt + "',N'" + dc + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kt = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if (kt > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        public bool Xoa_KH(KhachHangDTO tmp)
        {
            try
            {
                string sql = "delete from KHACHANG where MAKH='" + tmp.MaKH + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kt = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if (kt > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool Sua_KH(KhachHangDTO tmp)
        {
            try
            {
                string sql = "update KHACHANG set TENKH=N'" + tmp.TenKH + "',EMAIL='" + tmp.Email + "',SDT='" + tmp.SDT + "',DIACHI=N'" + tmp.DChi + "' where MAKH='" + tmp.MaKH + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kt = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if (kt > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false;}
        }
    }
}
