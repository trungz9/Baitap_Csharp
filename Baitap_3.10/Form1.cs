using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        // ===== Dữ liệu giống cấu trúc bài mẫu =====
        List<SinhVien> sinhViens = new List<SinhVien>();
        List<LopHoc> lopHocs = new List<LopHoc>();

        public Form1()
        {
            InitializeComponent();
        }

        // ==========================================
        // LOAD DỮ LIỆU
        // ==========================================
        void LoadData()
        {
            lopHocs.Clear();
            sinhViens.Clear();

            lopHocs.Add(new LopHoc
            {
                MaLop = "CSE01",
                TenLop = "Kỹ thuật phần mềm 01"
            });

            lopHocs.Add(new LopHoc
            {
                MaLop = "CSE02",
                TenLop = "Kỹ thuật phần mềm 02"
            });

            lopHocs.Add(new LopHoc
            {
                MaLop = "AI01",
                TenLop = "Trí tuệ nhân tạo 01"
            });

            lopHocs.Add(new LopHoc
            {
                MaLop = "DS01",
                TenLop = "Khoa học dữ liệu 01"
            });

            LopHoc lop1 = lopHocs[0];
            LopHoc lop2 = lopHocs[1];
            LopHoc lop3 = lopHocs[2];
            LopHoc lop4 = lopHocs[3];

            sinhViens.Add(new SinhVien
            {
                MaSV = "CSE0001",
                HoTen = "Nguyễn Văn An",
                NgaySinh = new DateTime(2004, 5, 12),
                GioiTinh = "Nam",
                Email = "an.cse@example.com",
                DienThoai = "0912345678",
                Diem = 8.5m,
                LopHoc = lop1,
                TrangThai = "Đang học"
            });

            sinhViens.Add(new SinhVien
            {
                MaSV = "CSE0002",
                HoTen = "Trần Thị Bình",
                NgaySinh = new DateTime(2004, 8, 20),
                GioiTinh = "Nữ",
                Email = "binh.cse@example.com",
                DienThoai = "0987654321",
                Diem = 9.0m,
                LopHoc = lop2,
                TrangThai = "Đang học"
            });

            sinhViens.Add(new SinhVien
            {
                MaSV = "CSE0003",
                HoTen = "Lê Minh Châu",
                NgaySinh = new DateTime(2005, 2, 15),
                GioiTinh = "Nữ",
                Email = "chau.cse@example.com",
                DienThoai = "0901234567",
                Diem = 7.5m,
                LopHoc = lop3,
                TrangThai = "Đang học"
            });

            sinhViens.Add(new SinhVien
            {
                MaSV = "CSE0004",
                HoTen = "Phạm Quốc Dũng",
                NgaySinh = new DateTime(2004, 11, 3),
                GioiTinh = "Nam",
                Email = "dung.cse@example.com",
                DienThoai = "0934567890",
                Diem = 8.0m,
                LopHoc = lop4,
                TrangThai = "Đang học"
            });

            // Quan hệ 1-n: một lớp có nhiều sinh viên.
            foreach (SinhVien sv in sinhViens)
            {
                if (sv.LopHoc != null && !sv.LopHoc.SinhViens.Contains(sv))
                {
                    sv.LopHoc.SinhViens.Add(sv);
                }
            }
        }

        // ==========================================
        // FORM LOAD
        // ==========================================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

            cboLop.DataSource = null;
            cboLop.DataSource = lopHocs;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboLocLop.Items.Clear();
            cboLocLop.Items.Add("Tất cả lớp");

            foreach (LopHoc lop in lopHocs)
            {
                cboLocLop.Items.Add(lop.TenLop);
            }

            cboLocLop.SelectedIndex = 0;

            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = sinhViens;

            CapNhatTongSo();
            DatTrangThaiNut(true);
            XoaTrangThongTin();

            txtMaSV.Focus();
        }

        // ==========================================
        // NHẬP MÃ SINH VIÊN - NHẤN ENTER
        // ==========================================
        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            e.Handled = true;

            string maSV = txtMaSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã sinh viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaSV.Focus();
                return;
            }

            SinhVien sv = sinhViens.FirstOrDefault(
                x => string.Equals(x.MaSV, maSV, StringComparison.OrdinalIgnoreCase));

            if (sv != null)
            {
                HienThiSinhVien(sv);

                txtMaSV.Enabled = false;
                DatTrangThaiNut(false);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtHoTen.Focus();
            }
            else
            {
                XoaThongTinTruMaSV();

                txtMaSV.Enabled = true;
                DatTrangThaiNut(true);

                txtHoTen.Focus();
            }
        }

        // ==========================================
        // NÚT THÊM
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = TaoSinhVienTuForm();

            if (sv == null)
                return;

            if (sinhViens.Any(x =>
                string.Equals(x.MaSV, sv.MaSV, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Mã sinh viên đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaSV.Focus();
                return;
            }

            List<ValidationResult> validationResults = sv.IsInvalid();

            if (validationResults != null)
            {
                HienThiLoi(validationResults);
                return;
            }

            sv.LopHoc.SinhViens.Add(sv);
            sinhViens.Add(sv);

            LamMoiDataGridView();

            MessageBox.Show(
                "Thêm sinh viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            btnLamMoi.PerformClick();
        }

        // ==========================================
        // NÚT SỬA
        // ==========================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            SinhVien sv = sinhViens.FirstOrDefault(
                x => string.Equals(x.MaSV, txtMaSV.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (sv == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn sửa thông tin sinh viên này?",
                "Xác nhận sửa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            LopHoc lopMoi = LayLopDangChon();

            if (lopMoi == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn lớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            sv.HoTen = txtHoTen.Text.Trim();
            sv.NgaySinh = dtpNgaySinh.Value.Date;
            sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            sv.Email = txtEmail.Text.Trim();
            sv.DienThoai = txtDienThoai.Text.Trim();
            sv.Diem = nudDiem.Value;
            sv.TrangThai = cboTrangThai.Text;

            if (sv.LopHoc != lopMoi)
            {
                if (sv.LopHoc != null)
                {
                    sv.LopHoc.SinhViens.Remove(sv);
                }

                sv.LopHoc = lopMoi;

                if (!sv.LopHoc.SinhViens.Contains(sv))
                {
                    sv.LopHoc.SinhViens.Add(sv);
                }
            }

            List<ValidationResult> validationResults = sv.IsInvalid();

            if (validationResults != null)
            {
                HienThiLoi(validationResults);
                return;
            }

            LamMoiDataGridView();

            MessageBox.Show(
                "Cập nhật sinh viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            btnLamMoi.PerformClick();
        }

        // ==========================================
        // NÚT XÓA
        // ==========================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVien sv = sinhViens.FirstOrDefault(
                x => string.Equals(x.MaSV, txtMaSV.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (sv == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (sv.LopHoc != null)
            {
                sv.LopHoc.SinhViens.Remove(sv);
            }

            sinhViens.Remove(sv);

            LamMoiDataGridView();

            MessageBox.Show(
                "Xóa sinh viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            btnLamMoi.PerformClick();
        }

        // ==========================================
        // NÚT LÀM MỚI
        // ==========================================
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaTrangThongTin();

            txtMaSV.Enabled = true;
            DatTrangThaiNut(true);

            txtMaSV.Focus();

            HienThiTatCaDuLieu();
        }

        // ==========================================
        // TÌM KIẾM / LỌC
        // ==========================================
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTuKhoa.Text.Trim();

            string lop = cboLocLop.Text;

            decimal diem = nudLocDiem.Value;

            IEnumerable<SinhVien> ketQua = sinhViens;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower();

                ketQua = ketQua.Where(sv =>
                    sv.MaSV.ToLower().Contains(keyword)
                    || sv.HoTen.ToLower().Contains(keyword)
                    || sv.Email.ToLower().Contains(keyword)
                    || sv.DienThoai.ToLower().Contains(keyword));
            }

            if (!string.IsNullOrWhiteSpace(lop) && lop != "Tất cả lớp")
            {
                ketQua = ketQua.Where(sv =>
                    sv.Lop == lop);
            }

            if (diem > 0)
            {
                ketQua = ketQua.Where(sv =>
                    sv.Diem >= diem);
            }

            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = ketQua.ToList();

            lblTongSo.Text =
                $"Tổng số: {ketQua.Count()} sinh viên";
        }

        // ==========================================
        // HIỂN THỊ TẤT CẢ
        // ==========================================
        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            HienThiTatCaDuLieu();

            txtTuKhoa.Clear();

            if (cboLocLop.Items.Count > 0)
                cboLocLop.SelectedIndex = 0;

            nudLocDiem.Value = 0;
        }

        // ==========================================
        // CLICK DÒNG TRONG DATAGRIDVIEW
        // ==========================================
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string maSV = dgvSinhVien.Rows[e.RowIndex]
                .Cells["MaSV"].Value?.ToString();

            SinhVien sv = sinhViens.FirstOrDefault(
                x => string.Equals(x.MaSV, maSV, StringComparison.OrdinalIgnoreCase));

            if (sv == null)
                return;

            HienThiSinhVien(sv);

            txtMaSV.Enabled = false;
            DatTrangThaiNut(false);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        // ==========================================
        // CÁC HÀM HỖ TRỢ
        // ==========================================
        private SinhVien TaoSinhVienTuForm()
        {
            LopHoc lop = LayLopDangChon();

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã sinh viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return null;
            }

            if (lop == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn lớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboLop.Focus();
                return null;
            }

            return new SinhVien
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                Email = txtEmail.Text.Trim(),
                DienThoai = txtDienThoai.Text.Trim(),
                Diem = nudDiem.Value,
                LopHoc = lop,
                TrangThai = cboTrangThai.Text
            };
        }

        private LopHoc LayLopDangChon()
        {
            return cboLop.SelectedItem as LopHoc;
        }

        private void HienThiSinhVien(SinhVien sv)
        {
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;

            rdoNam.Checked = sv.GioiTinh == "Nam";
            rdoNu.Checked = sv.GioiTinh == "Nữ";

            txtEmail.Text = sv.Email;
            txtDienThoai.Text = sv.DienThoai;
            nudDiem.Value = Math.Max(nudDiem.Minimum,
                Math.Min(nudDiem.Maximum, sv.Diem));

            cboLop.SelectedItem = sv.LopHoc;

            if (cboTrangThai.Items.Contains(sv.TrangThai))
                cboTrangThai.SelectedItem = sv.TrangThai;
        }

        private void XoaTrangThongTin()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();

            dtpNgaySinh.Value = DateTime.Now.Date;

            rdoNam.Checked = true;

            nudDiem.Value = 0;

            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
        }

        private void XoaThongTinTruMaSV()
        {
            txtHoTen.Clear();
            txtEmail.Clear();
            txtDienThoai.Clear();

            dtpNgaySinh.Value = DateTime.Now.Date;
            rdoNam.Checked = true;
            nudDiem.Value = 0;

            if (cboLop.Items.Count > 0)
                cboLop.SelectedIndex = 0;

            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;
        }

        private void DatTrangThaiNut(bool choThem)
        {
            btnThem.Enabled = choThem;
            btnSua.Enabled = !choThem;
            btnXoa.Enabled = !choThem;
        }

        private void LamMoiDataGridView()
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = sinhViens;

            CapNhatTongSo();
        }

        private void HienThiTatCaDuLieu()
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = sinhViens;

            CapNhatTongSo();
        }

        private void CapNhatTongSo()
        {
            lblTongSo.Text =
                $"Tổng số: {sinhViens.Count} sinh viên";
        }

        private void HienThiLoi(List<ValidationResult> validationResults)
        {
            string message = string.Join(
                Environment.NewLine,
                validationResults.Select(x => "- " + x.ErrorMessage));

            MessageBox.Show(
                message,
                "Dữ liệu không hợp lệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }

    // =========================================================
    // LỚP HỌC
    // =========================================================
    public class LopHoc
    {
        [Required]
        public string MaLop { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string TenLop { get; set; }

        // Quan hệ 1-n: một lớp có nhiều sinh viên.
        public List<SinhVien> SinhViens { get; set; } =
            new List<SinhVien>();

        public override string ToString()
        {
            return TenLop;
        }

        public List<ValidationResult> IsInvalid()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);

            var kt = Validator.TryValidateObject(
                this,
                validationContext,
                validationResults,
                true);

            if (kt)
            {
                return null;
            }
            else
            {
                return validationResults;
            }
        }
    }

    // =========================================================
    // SINH VIÊN
    // =========================================================
    public class SinhVien
    {
        [Required]
        [RegularExpression(
            @"^CSE[0-9]{4}$",
            ErrorMessage = "Mã SV phải có dạng CSExxxx.")]
        public string MaSV { get; set; }

        [Required]
        [StringLength(
            30,
            MinimumLength = 2,
            ErrorMessage = "Họ tên phải từ 2 đến 30 ký tự.")]
        public string HoTen { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        public string GioiTinh { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(
            @"^0[0-9]{9}$",
            ErrorMessage = "Điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.")]
        public string DienThoai { get; set; }

        [Range(
            0,
            10,
            ErrorMessage = "Điểm phải nằm trong khoảng 0 đến 10.")]
        public decimal Diem { get; set; }

        [Required]
        public LopHoc LopHoc { get; set; }

        [Required]
        public string TrangThai { get; set; }

        // Thuộc tính dùng để hiển thị trên DataGridView.
        public string Lop
        {
            get { return LopHoc?.TenLop ?? ""; }
        }

        public List<ValidationResult> IsInvalid()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(this);

            var kt = Validator.TryValidateObject(
                this,
                validationContext,
                validationResults,
                true);

            if (kt)
            {
                return null;
            }
            else
            {
                return validationResults;
            }
        }
    }
}
