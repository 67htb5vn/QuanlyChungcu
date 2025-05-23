namespace QuanlyChungcu
{
    partial class FormKhachHang
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
            groupBoxKhachHang1 = new GroupBox();
            groupBoxKhachHang2 = new GroupBox();
            datagridViewKhachHang = new DataGridView();
            buttonTimKiem = new Button();
            buttonThem = new Button();
            buttonSua = new Button();
            buttonXoa = new Button();
            buttonKhoiTao = new Button();
            groupBoxKhachHang2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datagridViewKhachHang).BeginInit();
            SuspendLayout();
            // 
            // groupBoxKhachHang1
            // 
            groupBoxKhachHang1.Location = new Point(0, 42);
            groupBoxKhachHang1.Name = "groupBoxKhachHang1";
            groupBoxKhachHang1.Size = new Size(691, 133);
            groupBoxKhachHang1.TabIndex = 0;
            groupBoxKhachHang1.TabStop = false;
            groupBoxKhachHang1.Text = "groupBoxKhachHang1";
            // 
            // groupBoxKhachHang2
            // 
            groupBoxKhachHang2.Controls.Add(datagridViewKhachHang);
            groupBoxKhachHang2.Location = new Point(0, 306);
            groupBoxKhachHang2.Name = "groupBoxKhachHang2";
            groupBoxKhachHang2.Size = new Size(691, 199);
            groupBoxKhachHang2.TabIndex = 1;
            groupBoxKhachHang2.TabStop = false;
            groupBoxKhachHang2.Text = "groupBoxKhachHang2";
            // 
            // datagridViewKhachHang
            // 
            datagridViewKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridViewKhachHang.Location = new Point(50, 52);
            datagridViewKhachHang.Name = "datagridViewKhachHang";
            datagridViewKhachHang.RowHeadersWidth = 51;
            datagridViewKhachHang.Size = new Size(562, 113);
            datagridViewKhachHang.TabIndex = 0;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(37, 195);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(94, 29);
            buttonTimKiem.TabIndex = 2;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.UseVisualStyleBackColor = true;
            // 
            // buttonThem
            // 
            buttonThem.Location = new Point(153, 195);
            buttonThem.Name = "buttonThem";
            buttonThem.Size = new Size(94, 29);
            buttonThem.TabIndex = 3;
            buttonThem.Text = "Thêm";
            buttonThem.UseVisualStyleBackColor = true;
            // 
            // buttonSua
            // 
            buttonSua.Location = new Point(270, 195);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(94, 29);
            buttonSua.TabIndex = 4;
            buttonSua.Text = "Sửa";
            buttonSua.UseVisualStyleBackColor = true;
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(391, 195);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(94, 29);
            buttonXoa.TabIndex = 5;
            buttonXoa.Text = "Xóa";
            buttonXoa.UseVisualStyleBackColor = true;
            // 
            // buttonKhoiTao
            // 
            buttonKhoiTao.Location = new Point(518, 195);
            buttonKhoiTao.Name = "buttonKhoiTao";
            buttonKhoiTao.Size = new Size(94, 29);
            buttonKhoiTao.TabIndex = 6;
            buttonKhoiTao.Text = "Khởi tạo";
            buttonKhoiTao.UseVisualStyleBackColor = true;
            // 
            // FormKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 537);
            Controls.Add(buttonKhoiTao);
            Controls.Add(buttonXoa);
            Controls.Add(buttonSua);
            Controls.Add(buttonThem);
            Controls.Add(buttonTimKiem);
            Controls.Add(groupBoxKhachHang2);
            Controls.Add(groupBoxKhachHang1);
            Name = "FormKhachHang";
            Text = "FormKhachHang";
            Load += FormKhachHang_Load;
            groupBoxKhachHang2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)datagridViewKhachHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxKhachHang1;
        private GroupBox groupBoxKhachHang2;
        private DataGridView datagridViewKhachHang;
        private Button buttonTimKiem;
        private Button buttonThem;
        private Button buttonSua;
        private Button buttonXoa;
        private Button buttonKhoiTao;
    }
}