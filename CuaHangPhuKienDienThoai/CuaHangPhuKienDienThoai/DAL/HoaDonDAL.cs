using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public HoaDonDAL()
        {
            conn = new SqlConnection(conStr);
        }
        public bool insertHoaDonDAL(string mahd, string makh, string tong, string giamgia, string phaitra,string manv)
        {
            try
            {
                
                string sql = "insert into HOADON (MAHD,MAKH,NGAYDATHANG,TONGTIEN,GIAMGIA,PHAITRA,MANV) values ('" + mahd + "'," + makh + ",GETDATE()," + tong + "," + giamgia + "," + phaitra + ",'"+manv+"')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kq = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if(kq>0)
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
        public List<HoaDonDTO> get_ds_HOADON_Thang(string thang, string nam)
        {
            List<HoaDonDTO> ds_=new List<HoaDonDTO>();
            string sql = "select * from HOADON where MONTH(NGAYDATHANG)=" + thang + " and YEAR(NGAYDATHANG)=" + nam + "";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonDTO d = new HoaDonDTO(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), float.Parse(reader[3].ToString()), float.Parse(reader[4].ToString()),float.Parse(reader[5].ToString()), reader[6].ToString());
                ds_.Add(d);
            }
            conn.Close();
            return ds_;
        }

        public List<HoaDonDTO> get_ds_HOADON_Nam(string nam)
        {
            List<HoaDonDTO> ds_ = new List<HoaDonDTO>();
            string sql = "select * from HOADON where  YEAR(NGAYDATHANG)=" + nam + "";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoaDonDTO d = new HoaDonDTO(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), float.Parse(reader[3].ToString()), float.Parse(reader[4].ToString()), float.Parse(reader[5].ToString()), reader[6].ToString());
                ds_.Add(d);
            }
            conn.Close();
            return ds_;
        }
    }
}
