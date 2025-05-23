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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanlyChungcu
{
    public partial class FormDichvu : Form
    {

        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GAGBHJK\\HVNG24;Initial Catalog=QuanLyChungCu;Integrated Security=True;Trust Server Certificate=True");
        public FormDichvu()
        {
            InitializeComponent();
        }
        public void loadDataDichvu(DataTable dt = null)
        {
            if (dt == null)
            {
                dt = DataConnect.GetData("SELECT * FROM DICHVU");
            }
            dataGridViewDichvu.DataSource = dt;
            dataGridViewDichvu.AllowUserToAddRows = false;
            dataGridViewDichvu.RowHeadersVisible = false;
            dataGridViewDichvu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDichvu.Columns["MaDV"].HeaderText = "Mã dịch vụ";
            dataGridViewDichvu.Columns["TenDV"].HeaderText = "Tên dịch vụ";
            dataGridViewDichvu.Columns["DonGia"].HeaderText = "Đơn giá";
        }
        private void FormDichvu_Load(object sender, EventArgs e)
        {
            loadDataDichvu();
        }
        static void ThemDV(string maDV, string tenDV, double donGia)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.ThemDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDV", maDV);
            cmd.Parameters.AddWithValue("@TenDV", tenDV);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void SuaDV(string maDV, string tenDV, double donGia)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.SuaDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDV", maDV);
            cmd.Parameters.AddWithValue("@TenDV", tenDV);
            cmd.Parameters.AddWithValue("@DonGia", donGia);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static void XoaDV(string maDV)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.XoaDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaDV", maDV);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        static DataTable TimkiemDV(string maDV, string tenDV, double donGia)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.TimkiemDV", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.NVarChar, 50).Value = string.IsNullOrWhiteSpace(maDV) ? DBNull.Value : maDV;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 100).Value = string.IsNullOrWhiteSpace(tenDV) ? DBNull.Value : tenDV;
            cmd.Parameters.Add("@DonGia", SqlDbType.Float).Value = donGia <= 0 ? DBNull.Value : donGia;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string maDV = textBoxMaDv.Text.Trim();
            string tenDV = textBoxTenDv.Text.Trim();
            double donGia =0;
            if (!string.IsNullOrWhiteSpace(textBoxDongia.Text.Trim()))
            {
                if (!double.TryParse(textBoxDongia.Text.Trim(), out donGia))
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
            DataTable searchResults = TimkiemDV(maDV, tenDV, donGia);
            loadDataDichvu(searchResults);
            ClearTextBoxes();
            conn.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maDV = textBoxMaDv.Text.Trim();
            string tenDV = textBoxTenDv.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDV) || string.IsNullOrWhiteSpace(tenDV))
            {
                MessageBox.Show("Lỗi: Mã dịch vụ và Tên dịch vụ không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBoxDongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Lỗi: Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (donGia < 0)
            {
                MessageBox.Show("Lỗi: Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ThemDV(maDV, tenDV, donGia);
                loadDataDichvu();
                ClearTextBoxes();
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Lỗi: Mã dịch vụ đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maDV = textBoxMaDv.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Lỗi: Mã dịch vụ không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            XoaDV(maDV);
            loadDataDichvu();
            ClearTextBoxes();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string maDV = textBoxMaDv.Text.Trim();
            string tenDV = textBoxTenDv.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDV) || string.IsNullOrWhiteSpace(tenDV))
            {
                MessageBox.Show("Lỗi: Mã dịch vụ và tên dịch vụ không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBoxDongia.Text.Trim(), out double donGia))
            {
                MessageBox.Show("Lỗi: Đơn giá phải là một số hợp lệ.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (donGia < 0)
            {
                MessageBox.Show("Lỗi: Đơn giá không được âm.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SuaDV(maDV, tenDV, donGia);
            loadDataDichvu();
            ClearTextBoxes();
        }


        private void dataGridViewDichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDichvu.Rows[e.RowIndex];
                textBoxMaDv.Text = row.Cells["MaDV"].Value?.ToString();
                textBoxTenDv.Text = row.Cells["TenDV"].Value?.ToString();
                textBoxDongia.Text = row.Cells["DonGia"].Value?.ToString();
            }
        }

        private void buttonKhoitao_Click(object sender, EventArgs e)
        {
            loadDataDichvu();
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            textBoxMaDv.Clear();
            textBoxTenDv.Clear();
            textBoxDongia.Clear();
        }
    }

}
