using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class AddCourseFrm : MetroFramework.Forms.MetroForm
    {
        public AddCourseFrm()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddCourseNameButton_Click(object sender, EventArgs e)
        {
            string courseName = CourseNameTextBox.Text;

        }

        private void RemoveCourseNameButton_Click(object sender, EventArgs e)
        {
            CourseNameTextBox.Text = "";
        }
        
    }
}
