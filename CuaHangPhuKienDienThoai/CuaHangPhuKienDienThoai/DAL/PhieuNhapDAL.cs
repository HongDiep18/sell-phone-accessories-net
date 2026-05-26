using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public PhieuNhapDAL()
        {
            conn = new SqlConnection(conStr);
        }
        public bool insert_PhieuNhap(PhieuNhapDTO tmp)
        {
            string sql = "insert into PHIEUNHAP(MAPN,MANCC,NGAYNHAP,TONGTIEN,MANV) values('"+tmp.MaPN+"','"+tmp.MaNCC+"','"+tmp.NgayNhap+"',"+tmp.TongTien+",'"+tmp.MaNV+"')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int k1= (int)cmd.ExecuteNonQuery();
            conn.Close();
            if(k1>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<PhieuNhapDTO> get_DS_PN_Thang(string thang,string nam)
        {
            List<PhieuNhapDTO> ds= new List<PhieuNhapDTO>();
            string sql = "select * from PHIEUNHAP where MONTH(NGAYNHAP)=" + thang+ "";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            while(r.Read())
            {
                PhieuNhapDTO tmp = new PhieuNhapDTO(r[0].ToString(), r[1].ToString(), r[2].ToString(), float.Parse(r[3].ToString()), r[4].ToString());
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public List<PhieuNhapDTO> get_DS_PN_Nam(string nam)
        {
            List<PhieuNhapDTO> ds = new List<PhieuNhapDTO>();
            string sql = "select * from PHIEUNHAP where YEAR(NGAYNHAP)=" + nam + "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                PhieuNhapDTO tmp = new PhieuNhapDTO(r[0].ToString(), r[1].ToString(), r[2].ToString(), float.Parse(r[3].ToString()), r[4].ToString());
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public int Dem_SL_PN()
        {
            string ngay = DateTime.Today.ToString("yyyy-MM-dd");
            string sql = "select count (*) from PHIEUNHAP where NGAYNHAP='"+ngay+"'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();
            if (kq > 0)
            {
                return kq;
            }
            else
            {
                return 0;
            }

        }
    }
}
