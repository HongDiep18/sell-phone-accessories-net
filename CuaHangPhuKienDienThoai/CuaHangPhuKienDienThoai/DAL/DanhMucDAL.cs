using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhMucDAL
    {
        string conStr = "Data Source=DESKTOP-JARJMT7\\SA;Initial Catalog=Nhom7_CuaHangPhuKienDienThoai;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn;
        public DanhMucDAL()
        {
            conn = new SqlConnection(conStr);
        }

        public List<DanhMucDTO> get_DS_danhmuc()
        {
            List<DanhMucDTO> ds_=new List<DanhMucDTO>();
            string sql = "select * from DANHMUC";
            conn.Open();
            SqlCommand cmd= new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DanhMucDTO dto = new DanhMucDTO(dr[0].ToString(), dr[1].ToString());
                ds_.Add(dto);
            }
            conn.Close();
            return ds_;
        }
        public bool insert_danhMuc(DanhMucDTO tmp)
        {
            try
            {
                string sql = "insert into DANHMUC values('" + tmp.MaDM.Trim() + "',N'" + tmp.TenDM.Trim() + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                int kt = (int)cmd.ExecuteNonQuery();
                conn.Close();
                if (kt > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch 
            {
                return false;
            }   

        }
        public bool Sua_DANHMUC (string ma, string ten)
        {
            string sql = "update DANHMUC set TENDM =N'" + ten + "' where MADM='" + ma + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int kt=(int)cmd.ExecuteNonQuery();
            conn.Close();
            if(kt>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Xoa_DANHMUC(string ma)
        {
            try
            {
                string sql = "DELETE from DANHMUC where MADM='" + ma + "'";
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

    }
}
