namespace QuanlyChungcu
{
    partial class FormDichvu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxDichVu1 = new GroupBox();
            textBoxDongia = new TextBox();
            textBoxTenDv = new TextBox();
            textBoxMaDv = new TextBox();
            lbTenDV = new Label();
            lbDongia = new Label();
            lbMaDV = new Label();
            buttonTimKiem = new Button();
            buttonThem = new Button();
            buttonSua = new Button();
            buttonXoa = new Button();
            buttonKhoitao = new Button();
            groupBoxDichvu2 = new GroupBox();
            dataGridViewDichvu = new DataGridView();
            groupBoxDichVu1.SuspendLayout();
            groupBoxDichvu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDichvu).BeginInit();
            SuspendLayout();
            // 
            // groupBoxDichVu1
            // 
            groupBoxDichVu1.Controls.Add(textBoxDongia);
            groupBoxDichVu1.Controls.Add(textBoxTenDv);
            groupBoxDichVu1.Controls.Add(textBoxMaDv);
            groupBoxDichVu1.Controls.Add(lbTenDV);
            groupBoxDichVu1.Controls.Add(lbDongia);
            groupBoxDichVu1.Controls.Add(lbMaDV);
            groupBoxDichVu1.Location = new Point(-2, 46);
            groupBoxDichVu1.Name = "groupBoxDichVu1";
            groupBoxDichVu1.Size = new Size(662, 177);
            groupBoxDichVu1.TabIndex = 0;
            groupBoxDichVu1.TabStop = false;
            groupBoxDichVu1.Text = "groupBoxDichVu1";
            // 
            // textBoxDongia
            // 
            textBoxDongia.Location = new Point(216, 125);
            textBoxDongia.Name = "textBoxDongia";
            textBoxDongia.Size = new Size(326, 27);
            textBoxDongia.TabIndex = 5;
            // 
            // textBoxTenDv
            // 
            textBoxTenDv.Location = new Point(216, 81);
            textBoxTenDv.Name = "textBoxTenDv";
            textBoxTenDv.Size = new Size(326, 27);
            textBoxTenDv.TabIndex = 4;
            // 
            // textBoxMaDv
            // 
            textBoxMaDv.Location = new Point(216, 37);
            textBoxMaDv.Name = "textBoxMaDv";
            textBoxMaDv.Size = new Size(324, 27);
            textBoxMaDv.TabIndex = 3;
            // 
            // lbTenDV
            // 
            lbTenDV.AutoSize = true;
            lbTenDV.Location = new Point(85, 88);
            lbTenDV.Name = "lbTenDV";
            lbTenDV.Size = new Size(83, 20);
            lbTenDV.TabIndex = 2;
            lbTenDV.Text = "Tên dịch vụ";
            // 
            // lbDongia
            // 
            lbDongia.AutoSize = true;
            lbDongia.Location = new Point(87, 132);
            lbDongia.Name = "lbDongia";
            lbDongia.Size = new Size(62, 20);
            lbDongia.TabIndex = 1;
            lbDongia.Text = "Đơn giá";
            // 
            // lbMaDV
            // 
            lbMaDV.AutoSize = true;
            lbMaDV.Location = new Point(87, 44);
            lbMaDV.Name = "lbMaDV";
            lbMaDV.Size = new Size(81, 20);
            lbMaDV.TabIndex = 0;
            lbMaDV.Text = "Mã dịch vụ";
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(29, 249);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(94, 29);
            buttonTimKiem.TabIndex = 1;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.UseVisualStyleBackColor = true;
            buttonTimKiem.Click += buttonTimKiem_Click;
            // 
            // buttonThem
            // 
            buttonThem.Location = new Point(146, 249);
            buttonThem.Name = "buttonThem";
            buttonThem.Size = new Size(94, 29);
            buttonThem.TabIndex = 2;
            buttonThem.Text = "Thêm";
            buttonThem.UseVisualStyleBackColor = true;
            buttonThem.Click += buttonThem_Click;
            // 
            // buttonSua
            // 
            buttonSua.Location = new Point(271, 249);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(94, 29);
            buttonSua.TabIndex = 3;
            buttonSua.Text = "Sửa";
            buttonSua.UseVisualStyleBackColor = true;
            buttonSua.Click += buttonSua_Click;
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(401, 249);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(94, 29);
            buttonXoa.TabIndex = 4;
            buttonXoa.Text = "Xóa";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // buttonKhoitao
            // 
            buttonKhoitao.Location = new Point(526, 249);
            buttonKhoitao.Name = "buttonKhoitao";
            buttonKhoitao.Size = new Size(94, 29);
            buttonKhoitao.TabIndex = 5;
            buttonKhoitao.Text = "Khởi tạo";
            buttonKhoitao.UseVisualStyleBackColor = true;
            buttonKhoitao.Click += buttonKhoitao_Click;
            // 
            // groupBoxDichvu2
            // 
            groupBoxDichvu2.Controls.Add(dataGridViewDichvu);
            groupBoxDichvu2.Location = new Point(-2, 351);
            groupBoxDichvu2.Name = "groupBoxDichvu2";
            groupBoxDichvu2.Size = new Size(655, 201);
            groupBoxDichvu2.TabIndex = 6;
            groupBoxDichvu2.TabStop = false;
            groupBoxDichvu2.Text = "groupBoxDichvu2";
            // 
            // dataGridViewDichvu
            // 
            dataGridViewDichvu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDichvu.Location = new Point(56, 55);
            dataGridViewDichvu.Name = "dataGridViewDichvu";
            dataGridViewDichvu.RowHeadersWidth = 51;
            dataGridViewDichvu.Size = new Size(566, 119);
            dataGridViewDichvu.TabIndex = 0;
            dataGridViewDichvu.CellClick += dataGridViewDichvu_CellClick;
            // 
            // FormDichvu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 564);
            Controls.Add(groupBoxDichvu2);
            Controls.Add(buttonKhoitao);
            Controls.Add(buttonXoa);
            Controls.Add(buttonSua);
            Controls.Add(buttonThem);
            Controls.Add(buttonTimKiem);
            Controls.Add(groupBoxDichVu1);
            Name = "FormDichvu";
            Text = "FormDichvu";
            Load += FormDichvu_Load;
            groupBoxDichVu1.ResumeLayout(false);
            groupBoxDichVu1.PerformLayout();
            groupBoxDichvu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewDichvu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxDichVu1;
        private Button buttonTimKiem;
        private Button buttonThem;
        private Button buttonSua;
        private Button buttonXoa;
        private Button buttonKhoitao;
        private GroupBox groupBoxDichvu2;
        private DataGridView dataGridViewDichvu;
        private Label lbTenDV;
        private Label lbDongia;
        private Label lbMaDV;
        private TextBox textBoxDongia;
        private TextBox textBoxTenDv;
        private TextBox textBoxMaDv;
    }
}