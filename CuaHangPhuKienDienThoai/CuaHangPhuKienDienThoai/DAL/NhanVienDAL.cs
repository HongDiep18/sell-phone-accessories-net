using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public NhanVienDAL()
        {
            conn = new SqlConnection(conStr);
        }
        public List<NhanVienDTO> getdata()
        {
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            string sql = "select * from NHANVIEN";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ma = dr[0].ToString();
                string ten = dr[1].ToString();
                string cv = dr[2].ToString();
                string sdt = dr[3].ToString();
                string email = dr[4].ToString();
                string luong = dr[5].ToString();
                string mk = dr[6].ToString();
                NhanVienDTO tmp = new NhanVienDTO(ma, ten, cv, sdt, email,float.Parse(luong),mk);
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public bool insert_NV(NhanVienDTO tmp)
        {
            string sql = "INSERT INTO NHANVIEN  VALUES('"+tmp.MaNV+"', N'"+tmp.TenNV+"', '"+tmp.ChucVu+"', '"+tmp.SDT+"', '"+tmp.Email+"', "+tmp.Luong+", '"+tmp.Password+"')";
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
        public bool Xoa_NV(NhanVienDTO tmp)
        {
            string sql = "delete from NHANVIEN where MANV='" + tmp.MaNV + "'";
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
        public bool Sua_NV(NhanVienDTO tmp)
        {
            string sql = "update NHANVIEN set TENNV='"+tmp.TenNV+"',CHUCVU='"+tmp.ChucVu+"',SDT='"+tmp.SDT+"',EMAIL='"+tmp.Email+"',LUONG= "+tmp.Luong+",MATKHAU='"+tmp.Password+"' where MANV='"+tmp.MaNV+"'";
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
        public string Lay_Chuc_Vu(string ma)
        {
            string mk=string.Empty;
            string sql = "select CHUCVU from NHANVIEN where MANV='" + ma + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                mk = rdr[0].ToString();
            }
            conn.Close();
            return mk;
        }
        public bool Doi_MK(string mkm,string ma)
        {
            string sql = "update NHANVIEN set MATKHAU='"+mkm+"' where MANV='"+ma+"'";
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
    }
}
