using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using WinFormsApp2.bul;
using WinFormsApp2.data.entity;

namespace WinFormsApp2.views
{
    public partial class QLSV : Form
    {
        private readonly StudentBusiness _studentBusiness;
        private readonly ClassBusiness _classBusiness;

        public QLSV(StudentBusiness studentBusiness, ClassBusiness classBusiness)
        {
            InitializeComponent();
            _studentBusiness = studentBusiness;
            _classBusiness = classBusiness;

            Load -= Form1_Load;
            Load += GuardEvent(Form1_Load);
            btnAdd.Click -= button2_Click;
            btnAdd.Click += GuardEvent(BtnAdd_Click);
            btnRemove.Click -= button3_Click;
            btnRemove.Click += GuardEvent(BtnRemove_Click);
            btnShowAll.Click -= button6_Click;
            btnShowAll.Click += GuardEvent(BtnShowAll_Click);
            btnEdit.Click += GuardEvent(BtnEdit_Click);
            btnRefresh.Click += GuardEvent(BtnRefresh_Click);
            btnSearch.Click += GuardEvent(BtnSearch_Click);
            txtStudentId.Leave += GuardEvent(TxtStudentId_Leave);
            txtStudentId.KeyDown += GuardKeyEvent(TxtStudentId_KeyDown);
            cbClass.SelectedIndexChanged += GuardEvent(CbClass_SelectedIndexChanged);
            txtStudentId.TextChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.StudentId), txtStudentId));
            txtFullName.TextChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.FullName), txtFullName));
            txtEmail.TextChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.Email), txtEmail));
            txtPhone.TextChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.Phone), txtPhone));
            dtpDate.ValueChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.DateOfBirth), dtpDate));
            nudScore.ValueChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.Score), nudScore));
            cbStatus.SelectedIndexChanged += GuardEvent((_, _) => RevalidateField(nameof(Student.Status), cbStatus));

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.AutoGenerateColumns = false;
            ConfigureDataGrid();

            txtSearch.KeyDown += GuardKeyEvent(TxtSearch_KeyDown);
            txtSearchValue.KeyDown += GuardKeyEvent(TxtSearch_KeyDown);
        }

        private EventHandler GuardEvent(EventHandler handler)
        {
            return (sender, e) => HandleViewException(() => handler(sender, e));
        }

        private KeyEventHandler GuardKeyEvent(KeyEventHandler handler)
        {
            return (sender, e) => HandleViewException(() => handler(sender, e));
        }

        private void HandleViewException(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    this,
                    $"Không thể hoàn tất thao tác. Vui lòng kiểm tra kết nối cơ sở dữ liệu.\n\nChi tiết: {exception.Message}",
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGrid()
        {
            dgvStudents.Columns.Clear();
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentId",
                HeaderText = "StudentId",
                DataPropertyName = "StudentId",
                ReadOnly = true,
                Width = 90
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "Full Name",
                DataPropertyName = "FullName",
                Width = 160
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "DOB",
                DataPropertyName = "DateOfBirth",
                Width = 90
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                Width = 110
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScore",
                HeaderText = "Score",
                DataPropertyName = "Score",
                Width = 60,
                DefaultCellStyle = { Format = "N1" }
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 80
            });
            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colClass",
                HeaderText = "Class",
                DataPropertyName = "Classes",
                Width = 120
            });
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializePickers();
            RefreshGrid(_studentBusiness.GetAll());
            SetTabOrder();
            txtStudentId.Select();
        }

        private void InitializePickers()
        {
            cbClass.Items.Clear();
            cbClass.Items.AddRange(_classBusiness.GetAll().Select(classModel => classModel.Code).ToArray());
            if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;

            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new[] { "Active", "Inactive" });
            cbStatus.SelectedIndex = 0;

            cbSearchField.Items.Clear();
            cbSearchField.Items.AddRange(new[] { "StudentId", "FullName", "Email", "Class" });
            cbSearchField.SelectedIndex = 0;
        }

        private void SetTabOrder()
        {
            var order = new Control[]
            {
                txtStudentId,
                txtFullName,
                txtEmail,
                dtpDate,
                txtPhone,
                nudScore,
                cbClass,
                cbStatus,
                btnAdd,
                btnEdit,
                btnRemove,
                btnRefresh,
                txtSearch,
                cbSearchField,
                txtSearchValue,
                btnSearch,
                btnShowAll,
                dgvStudents
            };

            for (int i = 0; i < order.Length; i++)
            {
                order[i].TabIndex = i;
            }
        }

        private void RefreshGrid(IEnumerable<Student> source)
        {
            var view = source.Select(student => new StudentView
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth.ToShortDateString(),
                Phone = student.Phone,
                Score = student.Score,
                Status = student.Status,
                Classes = student.Class?.Code ?? string.Empty
            }).ToList();

            dgvStudents.DataSource = new BindingSource { DataSource = view };
            txtTotal.Text = view.Count.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearValidationErrors();
            var student = ReadStudentFromInputs();
            var classCode = cbClass.SelectedItem as string;
            if (!_studentBusiness.TryAddValidated(student, classCode, out var errors))
            {
                ShowValidationErrors(errors);
                return;
            }

            EnsureClassOption(classCode);
            RefreshGrid(_studentBusiness.GetAll());
            ClearInputs();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ClearValidationErrors();
            if (dgvStudents.CurrentRow is null) return;

            var id = dgvStudents.CurrentRow.Cells[0].Value as string;
            if (string.IsNullOrEmpty(id)) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn cập nhật thông tin sinh viên '{id}'?\nHành động này sẽ ghi đè dữ liệu hiện tại.",
                "Xác nhận cập nhật",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var updatedStudent = ReadStudentFromInputs();
            var classCode = cbClass.SelectedItem as string;
            if (!_studentBusiness.TryUpdateValidated(id, updatedStudent, classCode, out var errors))
            {
                ShowValidationErrors(errors);
                return;
            }

            EnsureClassOption(classCode);
            RefreshGrid(_studentBusiness.GetAll());
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow is null) return;
            var id = dgvStudents.CurrentRow.Cells[0].Value as string;
            if (id is null || _studentBusiness.GetById(id) is null) return;

            var confirm = MessageBox.Show(
                $"Bạn có thực sự muốn xóa sinh viên '{id}'? Hành động này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            _studentBusiness.Delete(id);
            RefreshGrid(_studentBusiness.GetAll());
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có muốn làm mới dữ liệu? Tất cả thay đổi chưa lưu (nếu có) sẽ bị ghi đè.",
                "Xác nhận làm mới",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                RefreshGrid(_studentBusiness.GetAll());
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var field = cbSearchField.SelectedItem as string ?? "StudentId";
            var keyword = txtSearchValue.Text?.Trim() ?? string.Empty;
            RefreshGrid(_studentBusiness.Search(field, keyword));
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnSearch_Click(sender, EventArgs.Empty);
            }
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            RefreshGrid(_studentBusiness.GetAll());
        }

        private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RevalidateField(nameof(Student.Class), cbClass);
            if (cbClass.SelectedItem is string classCode)
            {
                RefreshGrid(_studentBusiness.GetByClassCode(classCode));
            }
        }

        private Student ReadStudentFromInputs()
        {
            return new Student
            {
                StudentId = txtStudentId.Text?.Trim() ?? string.Empty,
                FullName = txtFullName.Text?.Trim() ?? string.Empty,
                Email = txtEmail.Text?.Trim() ?? string.Empty,
                DateOfBirth = dtpDate.Value,
                Phone = txtPhone.Text?.Trim() ?? string.Empty,
                Score = (double)nudScore.Value,
                Status = cbStatus.SelectedItem as string ?? string.Empty
            };
        }

        private void ShowValidationErrors(IEnumerable<ValidationResult> errors)
        {
            foreach (var error in errors)
            {
                var message = error.ErrorMessage ?? "Invalid student data.";
                var control = error.MemberNames.FirstOrDefault() switch
                {
                    nameof(Student.StudentId) => (Control)txtStudentId,
                    nameof(Student.FullName) => txtFullName,
                    nameof(Student.Email) => txtEmail,
                    nameof(Student.DateOfBirth) => dtpDate,
                    nameof(Student.Phone) => txtPhone,
                    nameof(Student.Score) => nudScore,
                    nameof(Student.Class) => cbClass,
                    nameof(Student.Status) => cbStatus,
                    _ => txtStudentId
                };

                errorProvider.SetError(control, errorProvider.GetError(control) is { Length: > 0 } existingError
                    ? $"{existingError}{Environment.NewLine}{message}"
                    : message);
            }
        }

        private void ClearValidationErrors()
        {
            errorProvider.Clear();
        }

        private void RevalidateField(string memberName, Control control)
        {
            var student = ReadStudentFromInputs();
            var classCode = cbClass.SelectedItem as string;
            var errors = _studentBusiness.ValidateStudent(student, classCode)
                .Where(error => error.MemberNames.Contains(memberName))
                .ToList();

            if (memberName == nameof(Student.StudentId) && btnAdd.Enabled &&
                _studentBusiness.GetById(student.StudentId) is not null)
            {
                errors.Add(new ValidationResult("StudentId already exists.", new[] { nameof(Student.StudentId) }));
            }

            errorProvider.SetError(control, string.Join(Environment.NewLine,
                errors.Select(error => error.ErrorMessage).Where(message => !string.IsNullOrWhiteSpace(message))));
        }

        private void EnsureClassOption(string? classCode)
        {
            if (!string.IsNullOrWhiteSpace(classCode) && !cbClass.Items.Contains(classCode))
            {
                cbClass.Items.Add(classCode);
            }
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            nudScore.Value = 0;
            if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;
        }

        private void TxtStudentId_Leave(object sender, EventArgs e)
        {
            LoadStudentById();
        }

        private void TxtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            LoadStudentById();
        }

        private void LoadStudentById()
        {
            ClearValidationErrors();
            var id = txtStudentId.Text?.Trim();
            if (string.IsNullOrEmpty(id))
            {
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                ClearInputs();
                txtStudentId.Text = string.Empty;
                return;
            }

            var student = _studentBusiness.GetById(id);
            if (student is not null)
            {
                var errors = _studentBusiness.ValidateStudent(student, student.Class?.Code);
                if (errors.Count > 0)
                {
                    ShowValidationErrors(errors);
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnRemove.Enabled = false;
                    return;
                }

                txtFullName.Text = student.FullName;
                txtEmail.Text = student.Email;
                dtpDate.Value = student.DateOfBirth == default ? DateTime.Today : student.DateOfBirth;
                txtPhone.Text = student.Phone;
                nudScore.Value = (decimal)student.Score;
                cbStatus.SelectedItem = student.Status;
                if (student.Class is not null)
                {
                    var index = cbClass.Items.IndexOf(student.Class.Code);
                    if (index >= 0) cbClass.SelectedIndex = index;
                }

                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                txtFullName.Clear();
                txtEmail.Clear();
                dtpDate.Value = DateTime.Today;
                txtPhone.Clear();
                nudScore.Value = 0;
                if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;

                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void radioButton5_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void MSV_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { BtnAdd_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { BtnRemove_Click(sender, e); }
        private void button6_Click(object sender, EventArgs e) { BtnShowAll_Click(sender, e); }

        private class StudentView
        {
            public string StudentId { get; set; } = string.Empty;
            public string FullName { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string DateOfBirth { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public double Score { get; set; }
            public string Status { get; set; } = string.Empty;
            public string Classes { get; set; } = string.Empty;
        }
    }
}
