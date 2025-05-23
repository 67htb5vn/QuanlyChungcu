using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DataConnect;   //kết nối đến cơ sở dữ liệu

namespace QuanlyChungcu
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        //DataConnect này là static class trong project QuanlyChungCu, ko liên quan đến project DataConnect
        //ko xóa project DataConnect
        public void loadDataKH()
        {
            datagridViewKhachHang.DataSource = DataConnect.GetData("SELECT * FROM KhachHang");
            datagridViewKhachHang.AllowUserToAddRows = false;    //ẩn dòng trắng cuối
            datagridViewKhachHang.RowHeadersVisible = false;     //ẩn cột trắng đầu
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            loadDataKH();
        }
    }
}
