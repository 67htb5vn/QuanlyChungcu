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
    public partial class FormPhieudien : Form
    {
        public FormPhieudien()
        {
            InitializeComponent();
        }
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GAGBHJK\\HVNG24;Initial Catalog=QuanLyChungCu;Integrated Security=True;Trust Server Certificate=True");
        public void LoadDataPhieudien(DataTable dt = null)
        {
            if (dt == null)
            {
                dt = DataConnect.GetData("SELECT * FROM PHIEUSDDIEN");
            }
            datagridviewPhieudien.DataSource = dt;
            datagridviewPhieudien.AllowUserToAddRows = false;
            datagridviewPhieudien.RowHeadersVisible = false;
            datagridviewPhieudien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridviewPhieudien.Columns["MaPhieuSDDien"].HeaderText = "Mã phiếu SD điện";
            datagridviewPhieudien.Columns["CSCu"].HeaderText = "Chỉ số cũ";
            datagridviewPhieudien.Columns["CSMoi"].HeaderText = "Chỉ số mới";
            datagridviewPhieudien.Columns["DonGia"].HeaderText = "Đơn giá";
            datagridviewPhieudien.Columns["ThangSD"].DefaultCellStyle.Format = "MM/yyyy";
            datagridviewPhieudien.Columns["ThanhTien"].HeaderText = "Thành tiền";
            datagridviewPhieudien.Columns["MaHopDong"].HeaderText = "Mã hợp đồng";
            datagridviewPhieudien.Columns["MaHoaDonDV"].HeaderText = "Mã hóa đơn DV";
        }
        private void FormPhieudien_Load(object sender, EventArgs e)
        {
            LoadDataPhieudien();
        }

        private void datagridviewPhieudien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = datagridviewPhieudien.Rows[e.RowIndex];
                textBoxma.Text = row.Cells["MaPhieuSDDien"].Value?.ToString();
                textBoxcscu.Text = row.Cells["CSCu"].Value?.ToString();
                textBoxcsmoi.Text = row.Cells["CSMoi"].Value?.ToString();
                textBoxdongia.Text = row.Cells["DonGia"].Value?.ToString();
                if (row.Cells["ThangSD"].Value != null && DateTime.TryParse(row.Cells["ThangSD"].Value.ToString(), out DateTime thangSD))
                {
                    textBoxthangsd.Text = thangSD.ToString("MM/yyyy");
                }
                else
                {
                    textBoxthangsd.Text = string.Empty;
                }
                textBoxthanhtien.Text = row.Cells["ThanhTien"].Value?.ToString();
                textBoxmahd.Text = row.Cells["MaHopDong"].Value?.ToString();
                textBoxmahddv.Text = row.Cells["MaHoaDonDV"].Value?.ToString();
            }
        }
        private void ClearTextBoxes()
        {
            textBoxma.Clear();
            textBoxcscu.Clear();
            textBoxcsmoi.Clear();
            textBoxdongia.Clear();
            textBoxthangsd.Clear();
            textBoxthanhtien.Clear();
            textBoxmahd.Clear();
            textBoxmahddv.Clear();
        }
        static void ThemPSDDien(string maPSDDien, int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.ThemPSDDien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDien", maPSDDien);
            cmd.Parameters.AddWithValue("@CSCu", csCu);
            cmd.Parameters.AddWithValue("@CSMoi", csMoi);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThangSD", thangSD);
            cmd.Parameters.AddWithValue("@MaHopDong", maHd);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHddv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void SuaPSDDien(string maPSDDien, int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.SuaPSDDien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDien", maPSDDien);
            cmd.Parameters.AddWithValue("@CSCu", csCu);
            cmd.Parameters.AddWithValue("@CSMoi", csMoi);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThangSD", thangSD);
            cmd.Parameters.AddWithValue("@MaHopDong", maHd);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHddv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void XoaPSDDien(string maPSDDien)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.XoaPSDDien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDDien", maPSDDien);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static DataTable TimkiemPSDDien(string maPSDDien, int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.TimkiemPSDDien", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhieuSDDien", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maPSDDien) ? DBNull.Value : maPSDDien;
            cmd.Parameters.Add("@CSCu", SqlDbType.Int).Value = csCu <= 0 ? DBNull.Value : csCu;
            cmd.Parameters.Add("@CSMoi", SqlDbType.Int).Value = csMoi <= 0 ? DBNull.Value : csMoi;
            cmd.Parameters.Add("@DonGia", SqlDbType.Float).Value = donGia <= 0 ? DBNull.Value : donGia;
            cmd.Parameters.Add("@ThangSD", SqlDbType.DateTime).Value = thangSD == new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) ? DBNull.Value : thangSD;
            cmd.Parameters.Add("@MaHopDong", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maHd) ? DBNull.Value : maHd;
            cmd.Parameters.Add("@MaHoaDonDV", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maHddv) ? DBNull.Value : maHddv;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {
            string maPSDDien = textBoxma.Text.Trim();
            int csCu = 0;
            int csMoi = 0;
            double donGia = 0;
            DateTime thangSD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();

            if (!string.IsNullOrWhiteSpace(textBoxcscu.Text.Trim()))
            {
                if (!int.TryParse(textBoxcscu.Text.Trim(), out csCu))
                {
                    MessageBox.Show("Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (csCu < 0)
                {
                    MessageBox.Show("Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxcsmoi.Text.Trim()))
            {
                if (!int.TryParse(textBoxcsmoi.Text.Trim(), out csMoi))
                {
                    MessageBox.Show("Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (csMoi < 0)
                {
                    MessageBox.Show("Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxdongia.Text.Trim()))
            {
                if (!double.TryParse(textBoxdongia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (donGia < 0)
                {
                    MessageBox.Show("Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxthangsd.Text.Trim()))
            {
                if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out thangSD))
                {
                    MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            }
            DataTable searchResults = TimkiemPSDDien(maPSDDien, csCu, csMoi, donGia, thangSD, maHd, maHddv);
            LoadDataPhieudien(searchResults);
            ClearTextBoxes();
            conn.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maPSDDien = textBoxma.Text.Trim();
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDien) || string.IsNullOrWhiteSpace(maHd) || string.IsNullOrWhiteSpace(maHddv))
            {
                MessageBox.Show("Mã phiếu SD điện, mã hợp đồng và mã hóa đơn DV không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcscu.Text.Trim(), out int csCu))
            {
                MessageBox.Show("Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csCu < 0)
            {
                MessageBox.Show("Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcsmoi.Text.Trim(), out int csMoi))
            {
                MessageBox.Show("Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < 0)
            {
                MessageBox.Show("Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < csCu)
            {
                MessageBox.Show("Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxdongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (donGia < 0)
            {
                MessageBox.Show("Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);

            try
            {
                ThemPSDDien(maPSDDien, csCu, csMoi, donGia, thangSD, maHd, maHddv);
                LoadDataPhieudien();
                ClearTextBoxes();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Mã phiếu SD điện đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string maPSDDien = textBoxma.Text.Trim();
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDien) || string.IsNullOrWhiteSpace(maHd) || string.IsNullOrWhiteSpace(maHddv))
            {
                MessageBox.Show("Mã phiếu SD điện, mã hợp đồng và mã hóa đơn DV không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcscu.Text.Trim(), out int csCu))
            {
                MessageBox.Show("Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csCu < 0)
            {
                MessageBox.Show("Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcsmoi.Text.Trim(), out int csMoi))
            {
                MessageBox.Show("Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < 0)
            {
                MessageBox.Show("Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < csCu)
            {
                MessageBox.Show("Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxdongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (donGia < 0)
            {
                MessageBox.Show("Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            SuaPSDDien(maPSDDien, csCu, csMoi, donGia, thangSD , maHd, maHddv);
            LoadDataPhieudien();
            ClearTextBoxes();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maPSDDien = textBoxma.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDDien))
            {
                MessageBox.Show("Mã phiếu SD điện không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XoaPSDDien(maPSDDien);
            LoadDataPhieudien();
            ClearTextBoxes();
        }

        private void buttonKhoitao_Click(object sender, EventArgs e)
        {
            LoadDataPhieudien();
            ClearTextBoxes();
        }
    }
}
