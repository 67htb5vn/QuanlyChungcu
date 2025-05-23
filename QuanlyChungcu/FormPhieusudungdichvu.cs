using Microsoft.Data.SqlClient;
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
    public partial class FormPhieusudungdichvu : Form
    {
        public FormPhieusudungdichvu()
        {
            InitializeComponent();
        }
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GAGBHJK\\HVNG24;Initial Catalog=QuanLyChungCu;Integrated Security=True;Trust Server Certificate=True");
        public void loadDataPSDDV(DataTable dt = null)
        {
            if (dt == null)
            {
                dt = DataConnect.GetData("SELECT * FROM PHIEUSDDV");
            }
            dataGridViewPSDDV.DataSource = dt;
            dataGridViewPSDDV.AllowUserToAddRows = false;
            dataGridViewPSDDV.RowHeadersVisible = false;
            dataGridViewPSDDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPSDDV.Columns["MaPhieuSDDV"].HeaderText = "Mã phiếu SDDV";
            dataGridViewPSDDV.Columns["TongTienDV"].HeaderText = "Tổng tiền DV";
            dataGridViewPSDDV.Columns["ThangSD"].DefaultCellStyle.Format = "MM/yyyy";
            dataGridViewPSDDV.Columns["SoDV"].HeaderText = "Số dịch vụ";
            dataGridViewPSDDV.Columns["MaHopDong"].HeaderText = "Mã hợp đồng";
            dataGridViewPSDDV.Columns["MaHoaDonDV"].HeaderText = "Mã hóa đơn DV";
            
        }
        private void FormPhieusudungdichvu_Load(object sender, EventArgs e)
        {
            loadDataPSDDV();
        }
        static void ThemPSDDV(string maPSDDV, double tongTien, DateTime thangDV, int soDV, string maHD, string maHDDV)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.ThemPSDDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDV", maPSDDV);
            cmd.Parameters.AddWithValue("@TongTienDV", tongTien);
            cmd.Parameters.AddWithValue("@ThangSD", thangDV);
            cmd.Parameters.AddWithValue("@SoDV", soDV);
            cmd.Parameters.AddWithValue("@MaHopDong", maHD);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHDDV);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void SuaPSDDV(string maPSDDV, double tongTien, DateTime thangDV, int soDV, string maHD, string maHDDV)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.SuaPSDDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDV", maPSDDV);
            cmd.Parameters.AddWithValue("@TongTienDV", tongTien);
            cmd.Parameters.AddWithValue("@ThangSD", thangDV);
            cmd.Parameters.AddWithValue("@SoDV", soDV);
            cmd.Parameters.AddWithValue("@MaHopDong", maHD);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHDDV);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void XoaPSDDV(string maPSDDV)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.XoaPSDDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDV", maPSDDV);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static DataTable TimkiemPSDDV(string maPSDDV, double tongTien, DateTime thangDV, int soDV, string maHD, string maHDDV)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.TimkiemPSDDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhieuSDDV", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maPSDDV) ? DBNull.Value : maPSDDV;
            cmd.Parameters.Add("@TongTienDV", SqlDbType.Float).Value = tongTien <= 0 ? DBNull.Value : tongTien;
            cmd.Parameters.Add("@ThangSD", SqlDbType.DateTime).Value = thangDV == new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) ? DBNull.Value : thangDV;
            cmd.Parameters.Add("@SoDV", SqlDbType.Int).Value = soDV <= 0 ? DBNull.Value : soDV;
            cmd.Parameters.Add("@MaHopDong", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maHD) ? DBNull.Value : maHD;
            cmd.Parameters.Add("@MaHoaDonDV", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maHDDV) ? DBNull.Value : maHDDV;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            string maPSDDV = textBoxmaPSDDV.Text.Trim();
            string maHD = textBoxMaHd.Text.Trim();
            string maHDDV = textBoxMaHddv.Text.Trim();
            double tongTien = 0;
            int soDV = 0;
            DateTime thangDV = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            if (!string.IsNullOrWhiteSpace(textBoxTongtien.Text.Trim()))
            {
                if (!double.TryParse(textBoxTongtien.Text.Trim(), out tongTien))
                {
                    MessageBox.Show("Tổng tiền DV phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tongTien < 0)
                {
                    MessageBox.Show("Tổng tiền DV không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxSoDV.Text.Trim()))
            {
                if (!int.TryParse(textBoxSoDV.Text.Trim(), out soDV))
                {
                    MessageBox.Show("Số dịch vụ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (soDV < 0)
                {
                    MessageBox.Show("Số dịch vụ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxThangSD.Text.Trim()))
            {
                if (!DateTime.TryParseExact(textBoxThangSD.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out thangDV))
                {
                    MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thangDV = new DateTime(thangDV.Year, thangDV.Month, 1); 
            }
            DataTable searchResults = TimkiemPSDDV(maPSDDV, tongTien, thangDV, soDV, maHD, maHDDV);
            loadDataPSDDV(searchResults);
            ClearTextBoxes();
            conn.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maPSDDV = textBoxmaPSDDV.Text.Trim();
            string maHD = textBoxMaHd.Text.Trim();
            string maHDDV = textBoxMaHddv.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDV) || string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maHDDV))
            {
                MessageBox.Show("Mã phiếu SDDV, mã hợp đồng và mã hóa đơn DV không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxTongtien.Text.Trim(), out double tongTien))
            {
                MessageBox.Show("Tổng tiền DV phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tongTien < 0)
            {
                MessageBox.Show("Tổng tiền DV không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxThangSD.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            if (!int.TryParse(textBoxSoDV.Text.Trim(), out int soDV))
            {
                MessageBox.Show("Số dịch vụ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soDV < 0)
            {
                MessageBox.Show("Số dịch vụ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ThemPSDDV(maPSDDV, tongTien, thangSD, soDV, maHD, maHDDV);
                loadDataPSDDV();
                ClearTextBoxes();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Mã phiếu SDDV đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string maPSDDV = textBoxmaPSDDV.Text.Trim();
            string maHD = textBoxMaHd.Text.Trim();
            string maHDDV = textBoxMaHddv.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDV) || string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maHDDV))
            {
                MessageBox.Show("Mã phiếu SDDV, mã hợp đồng và mã hóa đơn DV không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxTongtien.Text.Trim(), out double tongTien))
            {
                MessageBox.Show("Tổng tiền DV phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tongTien < 0)
            {
                MessageBox.Show("Tổng tiền DV không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxThangSD.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            if (!int.TryParse(textBoxSoDV.Text.Trim(), out int soDV))
            {
                MessageBox.Show("Số dịch vụ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soDV < 0)
            {
                MessageBox.Show("Số dịch vụ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SuaPSDDV(maPSDDV, tongTien, thangSD, soDV, maHD, maHDDV);
            loadDataPSDDV();
            ClearTextBoxes();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maPSDDV = textBoxmaPSDDV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDV))
            {
                MessageBox.Show("Mã phiếu SDDV không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            XoaPSDDV(maPSDDV);
            loadDataPSDDV();
            ClearTextBoxes();
        }

        private void buttonKhoitao_Click(object sender, EventArgs e)
        {
            loadDataPSDDV();
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            textBoxmaPSDDV.Clear();
            textBoxTongtien.Clear();
            textBoxThangSD.Clear();
            textBoxSoDV.Clear();
            textBoxMaHd.Clear();
            textBoxMaHddv.Clear();
        }

        private void dataGridViewPSDDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPSDDV.Rows[e.RowIndex];
                textBoxmaPSDDV.Text = row.Cells["MaPhieuSDDV"].Value?.ToString();
                textBoxTongtien.Text = row.Cells["TongTienDV"].Value?.ToString();
                if (row.Cells["ThangSD"].Value != null && DateTime.TryParse(row.Cells["ThangSD"].Value.ToString(), out DateTime thangSD))
                {
                    textBoxThangSD.Text = thangSD.ToString("MM/yyyy");
                }
                else
                {
                    textBoxThangSD.Text = string.Empty;
                }
                textBoxSoDV.Text = row.Cells["SoDV"].Value?.ToString();
                textBoxMaHd.Text = row.Cells["MaHopDong"].Value?.ToString();
                textBoxMaHddv.Text = row.Cells["MaHoaDonDV"].Value?.ToString();
            }
        }
    }
}
