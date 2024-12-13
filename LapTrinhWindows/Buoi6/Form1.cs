using LapTrinhWindows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LapTrinhWindows.Buoi6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
     
            Model2 model = new Model2();    
              var students = model.Students
                    .Select(s => new
                    {
                        s.StudentID,
                        s.FullName,
                        s.AverageScore,
                        FacultyName = s.Faculty.FacultyName 
                    })
                    .ToList();

                dataGridView1.DataSource = students;
           
        

    }
}
}
