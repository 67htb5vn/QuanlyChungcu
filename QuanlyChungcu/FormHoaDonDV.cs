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
    public partial class FormHoaDonDV : Form
    {
        public FormHoaDonDV()
        {
            InitializeComponent();
        }

        private void FormHoaDonDV_Load(object sender, EventArgs e)
        {
            loadHoaDonDV();
        }

        void loadHoaDonDV()
        {
            datagridViewHoaDonDV.DataSource = DataConnect.GetData("SELECT * FROM HoaDonDV");
            datagridViewHoaDonDV.AllowUserToAddRows = false;
            datagridViewHoaDonDV.RowHeadersVisible = false;
        }

        private void datagridViewHoaDonDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagridViewHoaDonDV.CurrentRow.Index;
            textBox1.Text=datagridViewHoaDonDV.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = datagridViewHoaDonDV.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = datagridViewHoaDonDV.Rows[i].Cells[7].Value.ToString();
            textBox4.Text = datagridViewHoaDonDV.Rows[i].Cells[8].Value.ToString();
            textBox5.Text = datagridViewHoaDonDV.Rows[i].Cells[10].Value.ToString();
        }
    }
}
