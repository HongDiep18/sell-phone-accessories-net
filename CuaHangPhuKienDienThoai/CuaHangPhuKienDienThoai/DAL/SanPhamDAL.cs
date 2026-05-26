using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
namespace DAL
{
    public class SanPhamDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public SanPhamDAL() 
        {
            conn = new SqlConnection(conStr);
        }
        public List<SanPhamDTO>get_DanhSachSP()
        {
            List<SanPhamDTO> ds = new List<SanPhamDTO>();
            string sql = "select * from SANPHAM";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ma = dr[0].ToString();
                string ten = dr[1].ToString();
                string mota = dr[2].ToString();
                string gia = dr[3].ToString();
                string sl = dr[4].ToString();
                string madm = dr[5].ToString();
                SanPhamDTO tmp = new SanPhamDTO(ma,ten, mota, float.Parse(gia), int.Parse(sl),madm);
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public bool insert_sanPham(SanPhamDTO sanPham)
        {
            try
            {
                string sql = "insert into SANPHAM values ('" + sanPham.MaSP + "',N'" + sanPham.TenSP + "',N'" + sanPham.MoTa + "'," + sanPham.Gia + "," + sanPham.SLTonKo + ",'" + sanPham.MaDM + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if (kq > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<SanPhamDTO> get_DanhSachSP_TheoDanhMuc(string MaDanhMuc)
        {
            List<SanPhamDTO> ds = new List<SanPhamDTO>();
            string sql = "select * from SANPHAM where MADM='" + MaDanhMuc + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string ma = dr[0].ToString();
                string ten = dr[1].ToString();
                string mota = dr[2].ToString();
                string gia = dr[3].ToString();
                string sl = dr[4].ToString();
                string madm = dr[5].ToString();
                SanPhamDTO tmp = new SanPhamDTO(ma, ten, mota, float.Parse(gia), int.Parse(sl), madm);
                ds.Add(tmp);
            }
            conn.Close();
            return ds;
        }
        public int DemSLSP_TheoDanhMuc(string ma)
        {
            string sql = "select count(*) from SANPHAM where MADM='" + ma + "'";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            int kq=(int)cmd.ExecuteScalar();
            conn.Close();
            return kq;
        }
        public bool Xoa_SP(string ma)
        {
            try
            {
                string sql = "DELETE from SANPHAM where MASP='" + ma + "'";
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
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool XuaSanPham( SanPhamDTO tmp)
        {
            try
            {
                string sql = "update SANPHAM set TENSP=N'" + tmp.TenSP + "' ,MOTA=N'" + tmp.MoTa + "',GIA=" + tmp.Gia + ",MADM='" + tmp.MaDM + "' where MASP='" + tmp.MaSP + "'";
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
            catch (Exception ex)
            {
                return false;
            }
        }
        public int Dem_SL_HD()
        {
            string ngay = DateTime.Today.ToString("yyyy-MM-dd");
            string sql = "select count (*) from HOADON where NGAYDATHANG='"+ngay+"'";
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
