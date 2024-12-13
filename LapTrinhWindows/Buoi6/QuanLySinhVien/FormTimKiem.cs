using LapTrinhWindows.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi6.QuanLySinhVien
{
    public partial class FormTimKiem : Form
    {
        private Model2 dbContext;

        public FormTimKiem()
        {
            InitializeComponent();
            dbContext = new Model2();
            LoadFaculties();
        }

        private void LoadFaculties()
        {
            var faculties = dbContext.Faculties.ToList();
            faculties.Insert(0, new Faculty { FacultyID = 0, FacultyName = "Tất cả" });
            cboFaculty.DataSource = faculties;
            cboFaculty.DisplayMember = "FacultyName";
            cboFaculty.ValueMember = "FacultyID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentID = txtStudentID.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            int facultyID = (int)cboFaculty.SelectedValue;

            var query = dbContext.Students.AsQueryable();

            if (!string.IsNullOrEmpty(studentID))
                query = query.Where(s => s.StudentID.Contains(studentID));
            if (!string.IsNullOrEmpty(fullName))
                query = query.Where(s => s.FullName.Contains(fullName));
            if (facultyID > 0)
                query = query.Where(s => s.FacultyID == facultyID);

            var results = query.Select(s => new
            {
                s.StudentID,
                s.FullName,
                FacultyName = s.Faculty.FacultyName,
                s.AverageScore
            }).ToList();

            dgvResults.DataSource = results;
            lblResultCount.Text = $"Kết quả tìm kiếm: {results.Count}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            cboFaculty.SelectedIndex = 0;
            dgvResults.DataSource = null;
            lblResultCount.Text = "Kết quả tìm kiếm: 0";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
