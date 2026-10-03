namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ===== Tiêu đề =====
        private Label lblTitle;

        // ===== Group thông tin sinh viên =====
        private GroupBox grpStudentInfo;

        private Label lblMaSV;
        private Label lblHoTen;
        private Label lblNgaySinh;
        private Label lblGioiTinh;
        private Label lblEmail;
        private Label lblDienThoai;
        private Label lblLop;
        private Label lblDiem;
        private Label lblTrangThai;

        private TextBox txtMaSV;
        private TextBox txtHoTen;
        private DateTimePicker dtpNgaySinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private TextBox txtEmail;
        private TextBox txtDienThoai;
        private ComboBox cboLop;
        private NumericUpDown nudDiem;
        private ComboBox cboTrangThai;

        // ===== Button =====
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        // ===== Search =====
        private GroupBox grpSearch;

        private Label lblTuKhoa;
        private Label lblLocLop;
        private Label lblLocDiem;

        private TextBox txtTuKhoa;
        private ComboBox cboLocLop;
        private NumericUpDown nudLocDiem;

        private Button btnTimKiem;
        private Button btnHienThiTatCa;

        // ===== Danh sách =====
        private GroupBox grpDanhSach;
        private Label lblTongSo;

        private DataGridView dgvSinhVien;

        // ===== Footer =====
        private Label lblFooterLeft;
        private Label lblFooterRight;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            lblTitle = new Label();
            grpStudentInfo = new GroupBox();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblDiem = new Label();
            nudDiem = new NumericUpDown();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            grpSearch = new GroupBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            lblLocLop = new Label();
            cboLocLop = new ComboBox();
            lblLocDiem = new Label();
            nudLocDiem = new NumericUpDown();
            btnTimKiem = new Button();
            btnHienThiTatCa = new Button();
            grpDanhSach = new GroupBox();
            lblTongSo = new Label();
            dgvSinhVien = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            lblFooterLeft = new Label();
            lblFooterRight = new Label();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            label2 = new Label();
            grpStudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).BeginInit();
            grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLocDiem).BeginInit();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 78, 121);
            lblTitle.Location = new Point(29, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(571, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            // 
            // grpStudentInfo
            // 
            grpStudentInfo.Controls.Add(lblMaSV);
            grpStudentInfo.Controls.Add(txtMaSV);
            grpStudentInfo.Controls.Add(lblHoTen);
            grpStudentInfo.Controls.Add(txtHoTen);
            grpStudentInfo.Controls.Add(lblLop);
            grpStudentInfo.Controls.Add(cboLop);
            grpStudentInfo.Controls.Add(lblNgaySinh);
            grpStudentInfo.Controls.Add(dtpNgaySinh);
            grpStudentInfo.Controls.Add(lblGioiTinh);
            grpStudentInfo.Controls.Add(rdoNam);
            grpStudentInfo.Controls.Add(rdoNu);
            grpStudentInfo.Controls.Add(lblDiem);
            grpStudentInfo.Controls.Add(nudDiem);
            grpStudentInfo.Controls.Add(lblEmail);
            grpStudentInfo.Controls.Add(txtEmail);
            grpStudentInfo.Controls.Add(lblDienThoai);
            grpStudentInfo.Controls.Add(txtDienThoai);
            grpStudentInfo.Controls.Add(lblTrangThai);
            grpStudentInfo.Controls.Add(cboTrangThai);
            grpStudentInfo.Controls.Add(btnThem);
            grpStudentInfo.Controls.Add(btnSua);
            grpStudentInfo.Controls.Add(btnXoa);
            grpStudentInfo.Controls.Add(btnLamMoi);
            grpStudentInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpStudentInfo.Location = new Point(23, 87);
            grpStudentInfo.Margin = new Padding(3, 4, 3, 4);
            grpStudentInfo.Name = "grpStudentInfo";
            grpStudentInfo.Padding = new Padding(3, 4, 3, 4);
            grpStudentInfo.Size = new Size(1326, 273);
            grpStudentInfo.TabIndex = 1;
            grpStudentInfo.TabStop = false;
            grpStudentInfo.Text = "Thông tin sinh viên";
            // 
            // lblMaSV
            // 
            lblMaSV.Location = new Point(23, 47);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(103, 33);
            lblMaSV.TabIndex = 0;
            lblMaSV.Text = "Mã sinh viên *:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(131, 43);
            txtMaSV.Margin = new Padding(3, 4, 3, 4);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(205, 27);
            txtMaSV.TabIndex = 1;
            txtMaSV.KeyPress += txtMaSV_KeyPress;
            // 
            // lblHoTen
            // 
            lblHoTen.Location = new Point(377, 47);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(86, 33);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ và tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(469, 43);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(251, 27);
            txtHoTen.TabIndex = 3;
            // 
            // lblLop
            // 
            lblLop.Location = new Point(777, 47);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(74, 33);
            lblLop.TabIndex = 4;
            lblLop.Text = "Lớp học *:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Items.AddRange(new object[] { "Kỹ thuật phần mềm 01", "Kỹ thuật phần mềm 02", "Trí tuệ nhân tạo 01", "Khoa học dữ liệu 01" });
            cboLop.Location = new Point(857, 43);
            cboLop.Margin = new Padding(3, 4, 3, 4);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(251, 28);
            cboLop.TabIndex = 5;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.Location = new Point(23, 100);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(103, 33);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(131, 96);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(205, 27);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.Location = new Point(377, 100);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(86, 33);
            lblGioiTinh.TabIndex = 8;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // rdoNam
            // 
            rdoNam.Checked = true;
            rdoNam.Location = new Point(469, 97);
            rdoNam.Margin = new Padding(3, 4, 3, 4);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(69, 33);
            rdoNam.TabIndex = 9;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            // 
            // rdoNu
            // 
            rdoNu.Location = new Point(543, 97);
            rdoNu.Margin = new Padding(3, 4, 3, 4);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(69, 33);
            rdoNu.TabIndex = 10;
            rdoNu.Text = "Nữ";
            // 
            // lblDiem
            // 
            lblDiem.Location = new Point(777, 100);
            lblDiem.Name = "lblDiem";
            lblDiem.Size = new Size(74, 33);
            lblDiem.TabIndex = 11;
            lblDiem.Text = "Điểm:";
            // 
            // nudDiem
            // 
            nudDiem.DecimalPlaces = 1;
            nudDiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudDiem.Location = new Point(857, 96);
            nudDiem.Margin = new Padding(3, 4, 3, 4);
            nudDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDiem.Name = "nudDiem";
            nudDiem.Size = new Size(137, 27);
            nudDiem.TabIndex = 12;
            nudDiem.Value = new decimal(new int[] { 85, 0, 0, 65536 });
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(23, 153);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(103, 33);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email *:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(131, 149);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(205, 27);
            txtEmail.TabIndex = 14;
            // 
            // lblDienThoai
            // 
            lblDienThoai.Location = new Point(377, 153);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(86, 33);
            lblDienThoai.TabIndex = 15;
            lblDienThoai.Text = "Điện thoại *:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(469, 149);
            txtDienThoai.Margin = new Padding(3, 4, 3, 4);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(251, 27);
            txtDienThoai.TabIndex = 16;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Location = new Point(777, 153);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(74, 33);
            lblTrangThai.TabIndex = 17;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Items.AddRange(new object[] { "Đang học", "Bảo lưu", "Đã tốt nghiệp", "Thôi học" });
            cboTrangThai.Location = new Point(857, 149);
            cboTrangThai.Margin = new Padding(3, 4, 3, 4);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(182, 28);
            cboTrangThai.TabIndex = 18;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(40, 167, 69);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(777, 207);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(114, 43);
            btnThem.TabIndex = 19;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(0, 123, 255);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(903, 207);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(103, 43);
            btnSua.TabIndex = 20;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1017, 207);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(103, 43);
            btnXoa.TabIndex = 21;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1131, 207);
            btnLamMoi.Margin = new Padding(3, 4, 3, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(114, 43);
            btnLamMoi.TabIndex = 22;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(lblTuKhoa);
            grpSearch.Controls.Add(txtTuKhoa);
            grpSearch.Controls.Add(lblLocLop);
            grpSearch.Controls.Add(cboLocLop);
            grpSearch.Controls.Add(lblLocDiem);
            grpSearch.Controls.Add(nudLocDiem);
            grpSearch.Controls.Add(btnTimKiem);
            grpSearch.Controls.Add(btnHienThiTatCa);
            grpSearch.Location = new Point(23, 373);
            grpSearch.Margin = new Padding(3, 4, 3, 4);
            grpSearch.Name = "grpSearch";
            grpSearch.Padding = new Padding(3, 4, 3, 4);
            grpSearch.Size = new Size(1326, 100);
            grpSearch.TabIndex = 2;
            grpSearch.TabStop = false;
            grpSearch.Text = "Tìm kiếm / lọc";
            // 
            // lblTuKhoa
            // 
            lblTuKhoa.Location = new Point(23, 40);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(74, 33);
            lblTuKhoa.TabIndex = 0;
            lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(103, 36);
            txtTuKhoa.Margin = new Padding(3, 4, 3, 4);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txtTuKhoa.Size = new Size(297, 27);
            txtTuKhoa.TabIndex = 1;
            // 
            // lblLocLop
            // 
            lblLocLop.Location = new Point(423, 40);
            lblLocLop.Name = "lblLocLop";
            lblLocLop.Size = new Size(46, 33);
            lblLocLop.TabIndex = 2;
            lblLocLop.Text = "Lớp:";
            // 
            // cboLocLop
            // 
            cboLocLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocLop.Items.AddRange(new object[] { "Tất cả lớp", "Kỹ thuật phần mềm 01", "Kỹ thuật phần mềm 02", "Trí tuệ nhân tạo 01", "Khoa học dữ liệu 01" });
            cboLocLop.Location = new Point(474, 36);
            cboLocLop.Margin = new Padding(3, 4, 3, 4);
            cboLocLop.Name = "cboLocLop";
            cboLocLop.Size = new Size(205, 28);
            cboLocLop.TabIndex = 3;
            // 
            // lblLocDiem
            // 
            lblLocDiem.Location = new Point(703, 40);
            lblLocDiem.Name = "lblLocDiem";
            lblLocDiem.Size = new Size(74, 33);
            lblLocDiem.TabIndex = 4;
            lblLocDiem.Text = "Điểm từ:";
            // 
            // nudLocDiem
            // 
            nudLocDiem.DecimalPlaces = 1;
            nudLocDiem.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudLocDiem.Location = new Point(783, 36);
            nudLocDiem.Margin = new Padding(3, 4, 3, 4);
            nudLocDiem.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudLocDiem.Name = "nudLocDiem";
            nudLocDiem.Size = new Size(91, 27);
            nudLocDiem.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(0, 123, 255);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(891, 33);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(114, 43);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnHienThiTatCa
            // 
            btnHienThiTatCa.Location = new Point(1017, 33);
            btnHienThiTatCa.Margin = new Padding(3, 4, 3, 4);
            btnHienThiTatCa.Name = "btnHienThiTatCa";
            btnHienThiTatCa.Size = new Size(137, 43);
            btnHienThiTatCa.TabIndex = 7;
            btnHienThiTatCa.Text = "Hiển thị tất cả";
            btnHienThiTatCa.Click += btnHienThiTatCa_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(label2);
            grpDanhSach.Controls.Add(label1);
            grpDanhSach.Controls.Add(lblTongSo);
            grpDanhSach.Controls.Add(dgvSinhVien);
            grpDanhSach.Location = new Point(23, 487);
            grpDanhSach.Margin = new Padding(3, 4, 3, 4);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Padding = new Padding(3, 4, 3, 4);
            grpDanhSach.Size = new Size(1326, 393);
            grpDanhSach.TabIndex = 3;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sinh viên";
            // 
            // lblTongSo
            // 
            lblTongSo.Location = new Point(1086, 13);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(217, 33);
            lblTongSo.TabIndex = 0;
            lblTongSo.Text = "Tổng số: sinh viên";
            lblTongSo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(245, 248, 252);
            dgvSinhVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvSinhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvSinhVien.ColumnHeadersHeight = 35;
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Window;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.False;
            dgvSinhVien.DefaultCellStyle = dataGridViewCellStyle9;
            dgvSinhVien.Location = new Point(17, 53);
            dgvSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1291, 273);
            dgvSinhVien.TabIndex = 1;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã SV";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "MaSV";
            dataGridViewTextBoxColumn1.DataPropertyName = "MaSV";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Họ và tên";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "HoTen";
            dataGridViewTextBoxColumn2.DataPropertyName = "HoTen";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Ngày sinh";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "NgaySinh";
            dataGridViewTextBoxColumn3.DataPropertyName = "NgaySinh";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Giới tính";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "GioiTinh";
            dataGridViewTextBoxColumn4.DataPropertyName = "GioiTinh";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Email";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "Email";
            dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Điện thoại";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "DienThoai";
            dataGridViewTextBoxColumn6.DataPropertyName = "DienThoai";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Điểm";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "Diem";
            dataGridViewTextBoxColumn7.DataPropertyName = "Diem";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Lớp";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "Lop";
            dataGridViewTextBoxColumn8.DataPropertyName = "Lop";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "TrangThai";
            dataGridViewTextBoxColumn9.DataPropertyName = "TrangThai";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // lblFooterLeft
            // 
            lblFooterLeft.Font = new Font("Segoe UI", 8F);
            lblFooterLeft.ForeColor = Color.Gray;
            lblFooterLeft.Location = new Point(23, 907);
            lblFooterLeft.Name = "lblFooterLeft";
            lblFooterLeft.Size = new Size(571, 33);
            lblFooterLeft.TabIndex = 4;
            lblFooterLeft.Text = "Bài tập: xây dựng Windows Forms quản lý sinh viên";
            // 
            // lblFooterRight
            // 
            lblFooterRight.Font = new Font("Segoe UI", 8F);
            lblFooterRight.ForeColor = Color.Gray;
            lblFooterRight.Location = new Point(800, 907);
            lblFooterRight.Name = "lblFooterRight";
            lblFooterRight.Size = new Size(549, 33);
            lblFooterRight.TabIndex = 5;
            lblFooterRight.Text = "Thêm • Sửa • Xóa • Tìm kiếm • Lọc theo lớp";
            lblFooterRight.TextAlign = ContentAlignment.MiddleRight;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 353);
            label1.Name = "label1";
            label1.Size = new Size(389, 20);
            label1.TabIndex = 2;
            label1.Text = "Chọn một dòng để xem, sửa hoặc xóa thông tin sinh viên ";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1050, 351);
            label2.Name = "label2";
            label2.Size = new Size(220, 20);
            label2.TabIndex = 3;
            label2.Text = "Các trường có dấu * là bắt buộc";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1371, 960);
            Controls.Add(lblTitle);
            Controls.Add(grpStudentInfo);
            Controls.Add(grpSearch);
            Controls.Add(grpDanhSach);
            Controls.Add(lblFooterLeft);
            Controls.Add(lblFooterRight);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 851);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý sinh viên";
            Load += Form1_Load;
            grpStudentInfo.ResumeLayout(false);
            grpStudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDiem).EndInit();
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudLocDiem).EndInit();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private ErrorProvider errorProvider1;
        private Label label1;
        private Label label2;
    }
}