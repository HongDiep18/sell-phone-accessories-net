using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public NhaCungCapDAL() 
        {
            conn = new SqlConnection(conStr);
        }
        public List<NhaCungCapDTO> get_ds_NCC()
        {
            List<NhaCungCapDTO> ds_= new List<NhaCungCapDTO>();
            string sql = "select * from NHACC";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader[0].ToString();
                string ten = reader[1].ToString();
                string dc = reader[2].ToString();
                string sdt = reader[3].ToString();
                string email = reader[4].ToString();
                NhaCungCapDTO tmp = new NhaCungCapDTO(ma,ten,dc,sdt,email);
                ds_.Add(tmp);
            }
            conn.Close();
            return ds_;
        }
        public bool ktTrung(string maNCC)
        {
            conn.Open();
            string select = "select count(*) from NHACC where MANCC = '" + maNCC + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            int kq = (int)cmd.ExecuteScalar();
            conn.Close();

            return kq == 0;
        }
        public bool addValue(NhaCungCapDTO ncc)
        {
            //if (ktTrung(ncc.MaNCC) == false)
            //{
            //    return false;
            //}
            try
            {
                conn.Open();
                string insert = "insert into NHACC values('" + ncc.MaNCC + "',N'" + ncc.TenNCC + "',N'" + ncc.DChiNCC + "','" + ncc.SDTNCC + "','" + ncc.EmailNCC + "')";
                SqlCommand cmd = new SqlCommand(insert, conn);
                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool deleteValue(string ma)
        {
            try
            {
                conn.Open();
                string delete = "delete from NHACC where MANCC = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(delete, conn);
                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool editValue(NhaCungCapDTO ncc)
        {
            try
            {
                conn.Open();
                string edit = "update NHACC set TENNCC= N'" + ncc.TenNCC + "', DIACHI =N'" + ncc.DChiNCC + "',SDT= '" + ncc.SDTNCC + "', EMAIL = '" + ncc.EmailNCC + "'   where  MANCC = '" + ncc.MaNCC + "'";
                SqlCommand cmd = new SqlCommand(edit, conn);
                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
