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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanlyChungcu
{
    public partial class FormPhieuNuoc : Form
    {
        public FormPhieuNuoc()
        {
            InitializeComponent();
            

        }
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GAGBHJK\\HVNG24;Initial Catalog=QuanLyChungCu;Integrated Security=True;Trust Server Certificate=True");
        public void loadDataPhieunuoc(DataTable dt = null)
        {
            if (dt == null)
            {
                dt = DataConnect.GetData("SELECT * FROM PHIEUSDNUOC");
            }
            dataGridViewPhieunuoc.DataSource = dt;
            dataGridViewPhieunuoc.AllowUserToAddRows = false;
            dataGridViewPhieunuoc.RowHeadersVisible = false;
            dataGridViewPhieunuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPhieunuoc.Columns["MaPhieuSDNuoc"].HeaderText = "Mã phiếu SD nước";
            dataGridViewPhieunuoc.Columns["CSCu"].HeaderText = "Chỉ số cũ";
            dataGridViewPhieunuoc.Columns["CSMoi"].HeaderText = "Chỉ số mới";
            dataGridViewPhieunuoc.Columns["DonGia"].HeaderText = "Đơn giá";
            dataGridViewPhieunuoc.Columns["ThangSD"].DefaultCellStyle.Format = "MM/yyyy";
            dataGridViewPhieunuoc.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dataGridViewPhieunuoc.Columns["MaHopDong"].HeaderText = "Mã hợp đồng";
            dataGridViewPhieunuoc.Columns["MaHoaDonDV"].HeaderText = "Mã hóa đơn DV";
        }
        private void FormPhieuNuoc_Load(object sender, EventArgs e)
        {
            loadDataPhieunuoc();
        }
        private void dataGridViewPhieunuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewPhieunuoc.Rows[e.RowIndex];
                textBoxma.Text = row.Cells["MaPhieuSDNuoc"].Value?.ToString();
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
        static void ThemPSDNuoc(string maPSDNuoc,int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.ThemPSDNuoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDNuoc", maPSDNuoc);
            cmd.Parameters.AddWithValue("@CSCu", csCu);
            cmd.Parameters.AddWithValue("@CSMoi", csMoi);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThangSD", thangSD);
            cmd.Parameters.AddWithValue("@MaHopDong", maHd);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHddv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void SuaPSDNuoc(string maPSDNuoc, int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.SuaPSDNuoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDNuoc", maPSDNuoc);
            cmd.Parameters.AddWithValue("@CSCu", csCu);
            cmd.Parameters.AddWithValue("@CSMoi", csMoi);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.Parameters.AddWithValue("@ThangSD", thangSD);
            cmd.Parameters.AddWithValue("@MaHopDong", maHd);
            cmd.Parameters.AddWithValue("@MaHoaDonDV", maHddv);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void XoaPSDNuoc(string maPSDNuoc)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.XoaPSDNuoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieuSDNuoc", maPSDNuoc);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static DataTable TimkiemPSDNuoc(string maPSDNuoc, int csCu, int csMoi, double donGia, DateTime thangSD, string maHd, string maHddv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.TimkiemPSDNuoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhieuSDNuoc", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maPSDNuoc) ? DBNull.Value : maPSDNuoc;
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
            string maPSDNuoc = textBoxma.Text.Trim();
            int csCu = 0;
            int csMoi = 0;
            double donGia = 0;
            DateTime thangSD = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            double thanhTien = 0;
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();

            if (!string.IsNullOrWhiteSpace(textBoxcscu.Text.Trim()))
            {
                if (!int.TryParse(textBoxcscu.Text.Trim(), out csCu))
                {
                    MessageBox.Show("Lỗi: Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (csCu < 0)
                {
                    MessageBox.Show("Lỗi: Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxcsmoi.Text.Trim()))
            {
                if (!int.TryParse(textBoxcsmoi.Text.Trim(), out csMoi))
                {
                    MessageBox.Show("Lỗi: Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (csMoi < 0)
                {
                    MessageBox.Show("Lỗi: Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxdongia.Text.Trim()))
            {
                if (!double.TryParse(textBoxdongia.Text.Trim(), out donGia))
                {
                    MessageBox.Show("Lỗi: Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (donGia < 0)
                {
                    MessageBox.Show("Lỗi: Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(textBoxthangsd.Text.Trim()))
            {
                if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out thangSD))
                {
                    MessageBox.Show("Lỗi: Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (thangSD.Month < 1 || thangSD.Month > 12)
                {
                    MessageBox.Show("Lỗi: Tháng phải nằm trong khoảng từ 1 đến 12.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            }

            DataTable searchResults = TimkiemPSDNuoc(maPSDNuoc, csCu, csMoi, donGia, thangSD, maHd, maHddv);
            loadDataPhieunuoc(searchResults);
            ClearTextBoxes();
            conn.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maPSDNuoc = textBoxma.Text.Trim();
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();

            if (string.IsNullOrWhiteSpace(maPSDNuoc) || string.IsNullOrWhiteSpace(maHd) || string.IsNullOrWhiteSpace(maHddv))
            {
                MessageBox.Show("Lỗi: Mã phiếu sử dụng nước, Mã hợp đồng và Mã hóa đơn dịch vụ không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcscu.Text.Trim(), out int csCu))
            {
                MessageBox.Show("Lỗi: Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csCu < 0)
            {
                MessageBox.Show("Lỗi: Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcsmoi.Text.Trim(), out int csMoi))
            {
                MessageBox.Show("Lỗi: Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < 0)
            {
                MessageBox.Show("Lỗi: Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < csCu)
            {
                MessageBox.Show("Lỗi: Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxdongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Lỗi: Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (donGia < 0)
            {
                MessageBox.Show("Lỗi: Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Lỗi: Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thangSD.Month < 1 || thangSD.Month > 12)
            {
                MessageBox.Show("Lỗi: Tháng phải nằm trong khoảng từ 1 đến 12.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);

            try
            {
                ThemPSDNuoc(maPSDNuoc, csCu, csMoi, donGia, thangSD, maHd, maHddv);
                loadDataPhieunuoc();
                ClearTextBoxes();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Lỗi: Mã phiếu sử dụng nước đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string maPSDNuoc = textBoxma.Text.Trim();
            string maHd = textBoxmahd.Text.Trim();
            string maHddv = textBoxmahddv.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPSDNuoc) || string.IsNullOrWhiteSpace(maHd) || string.IsNullOrWhiteSpace(maHddv))
            {
                MessageBox.Show("Lỗi: Mã phiếu sử dụng nước, Mã hợp đồng và Mã hóa đơn dịch vụ không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcscu.Text.Trim(), out int csCu))
            {
                MessageBox.Show("Lỗi: Chỉ số cũ phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csCu < 0)
            {
                MessageBox.Show("Lỗi: Chỉ số cũ không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBoxcsmoi.Text.Trim(), out int csMoi))
            {
                MessageBox.Show("Lỗi: Chỉ số mới phải là một số nguyên hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < 0)
            {
                MessageBox.Show("Lỗi: Chỉ số mới không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (csMoi < csCu)
            {
                MessageBox.Show("Lỗi: Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(textBoxdongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Lỗi: Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (donGia < 0)
            {
                MessageBox.Show("Lỗi: Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParseExact(textBoxthangsd.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime thangSD))
            {
                MessageBox.Show("Lỗi: Tháng sử dụng phải có định dạng MM/yyyy.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (thangSD.Month < 1 || thangSD.Month > 12)
            {
                MessageBox.Show("Lỗi: Tháng phải nằm trong khoảng từ 1 đến 12.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            thangSD = new DateTime(thangSD.Year, thangSD.Month, 1);
            SuaPSDNuoc(maPSDNuoc, csCu, csMoi, donGia, thangSD, maHd, maHddv);
            loadDataPhieunuoc();
            ClearTextBoxes();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maPSDNuoc = textBoxma.Text.Trim();
            if (string.IsNullOrWhiteSpace(maPSDNuoc))
            {
                MessageBox.Show("Lỗi: Mã phiếu sử dụng nước không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            XoaPSDNuoc(maPSDNuoc);
            loadDataPhieunuoc() ;
            ClearTextBoxes() ;
        }

        private void buttonKhoitao_Click(object sender, EventArgs e)
        {
            loadDataPhieunuoc();
            ClearTextBoxes();
        }
    }
}
