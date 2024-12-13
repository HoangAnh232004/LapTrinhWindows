using LapTrinhWindows.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi6.QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private Model2 dbContext;
        private String studentID;

        public Form1()
        {
            InitializeComponent();
            dbContext = new Model2();
            LoadFaculties();
            LoadStudents();
        }

      
        private void LoadFaculties()
        {
            var faculties = dbContext.Faculties.ToList();
            cboFaculty.DataSource = faculties;
            cboFaculty.DisplayMember = "FacultyName";
            cboFaculty.ValueMember = "FacultyID";
        }

       
        private void LoadStudents()
        {
            var students = dbContext.Students
                .Select(s => new
                {
                    s.StudentID,
                    s.FullName,
                    FacultyName = s.Faculty.FacultyName, 
                    s.AverageScore
                }).ToList();

            dgvStudents.DataSource = students;
           

         ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    StudentID = txtStudentID.Text,
                    FullName = txtFullName.Text,
                    FacultyID = (int)cboFaculty.SelectedValue,
                    AverageScore = float.Parse(txtAverageScore.Text)
                };

                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo");
                LoadStudents();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi");
            }
        }

 
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var studentID = txtStudentID.Text;
                var student = dbContext.Students.FirstOrDefault(s => s.StudentID == studentID);

                if (student != null)
                {
                    student.FullName = txtFullName.Text;
                    student.FacultyID = (int)cboFaculty.SelectedValue;
                    student.AverageScore = float.Parse(txtAverageScore.Text);

                    dbContext.SaveChanges();
                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo");
                    LoadStudents();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sinh viên: {ex.Message}", "Lỗi");
            }
        }

     
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var studentID = txtStudentID.Text;
                var student = dbContext.Students.FirstOrDefault(s => s.StudentID == studentID);

                if (student != null)
                {
                    dbContext.Students.Remove(student);
                    dbContext.SaveChanges();
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo");
                    LoadStudents();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sinh viên: {ex.Message}", "Lỗi");
            }
        }

   
        private void ClearInputs()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtAverageScore.Clear();
            cboFaculty.SelectedIndex = -1;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2) 
            {
                btnQuanLyKhoa.PerformClick();
                return true;
            }
            if (keyData == (Keys.Control | Keys.F)) 
            {
                btnTimKiem.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnQuanLyKhoa_Click(object sender, EventArgs e)
        {
            var formQuanLyKhoa = new QuanLyKhoa.QuanLyKhoa();
            formQuanLyKhoa.ShowDialog();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var formTimKiem = new FormTimKiem();
            formTimKiem.ShowDialog();
        }

     
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                txtStudentID.Text = dgvStudents.CurrentRow.Cells["StudentID"].Value.ToString();
                txtFullName.Text = dgvStudents.CurrentRow.Cells["FullName"].Value.ToString();
                txtAverageScore.Text = dgvStudents.CurrentRow.Cells["AverageScore"].Value.ToString();
                cboFaculty.Text = dgvStudents.CurrentRow.Cells["FacultyName"].Value.ToString();
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvStudents.Rows.Count)
            {
              
                DataGridViewRow selectedRow = dgvStudents.Rows[e.RowIndex];
             
                studentID = selectedRow.Cells["StudentID"].Value?.ToString();
               
                string fullName = selectedRow.Cells["FullName"].Value?.ToString();
                string facultyName = selectedRow.Cells["FacultyName"].Value?.ToString();
                float averageScore = float.Parse(selectedRow.Cells["AverageScore"].Value?.ToString() ?? "0");
                txtStudentID.Text = studentID;
                txtFullName.Text = fullName;   
                txtAverageScore.Text = averageScore.ToString();
                cboFaculty.Text = facultyName;


            }
        }
    }
}
