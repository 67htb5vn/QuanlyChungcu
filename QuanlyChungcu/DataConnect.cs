using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QuanlyChungcu
{
    public static class DataConnect  //do lớp này là static nên ko gần tạo đối tượng
    {                             
        private static SqlConnection conn;
                
        static DataConnect()            //khởi tạo này tự động chạy
        {                               //chạy đúng 1 lần duy nhất khi bất kỳ phương thức nào đầu tiên được gọi 
            conn = new SqlConnection("Data Source=DESKTOP-GAGBHJK\\HVNG24;Initial Catalog=QuanLyChungCu;Integrated Security=True;Trust Server Certificate=True");
        }

        public static DataTable GetData(String str)         //lấy dữ liệu đổ vào table
        {

            DataTable dt = new DataTable();

            //SqlDataAdapter adapter = new SqlDataAdapter(str, conn);

            SqlCommand cmd;                   //khai báo lệnh
            cmd=conn.CreateCommand();         //liên kết lệnh với kết nối
            cmd.CommandText=str;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;      //trung gian nhận thực thi lệnh, lấy kết quả 

            conn.Open();                      //khi kết nối bật, tiến hành truy vấn
            adapter.Fill(dt);                 //trung gian đổ kết quả vào table
            conn.Close();
            return dt;

        }


    }
}
