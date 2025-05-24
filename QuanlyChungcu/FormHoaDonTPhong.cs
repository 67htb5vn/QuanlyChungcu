using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyChungcu
{
    public partial class FormHoaDonTPhong : Form
    {
        public FormHoaDonTPhong()
        {
            InitializeComponent();
        }

        private void FormHoaDonTPhong_Load(object sender, EventArgs e)
        {
            loadHoaDonTPhong();
        }

        void loadHoaDonTPhong()
        {
            datagridViewHoaDonTP.DataSource = DataConnect.GetData("SELECT * FROM HoaDonTPhong");
            datagridViewHoaDonTP.AllowUserToAddRows = false;
            datagridViewHoaDonTP.RowHeadersVisible = false;
        }
    }
}
