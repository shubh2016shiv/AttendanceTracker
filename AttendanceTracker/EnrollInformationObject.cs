using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTracker
{
    public class EnrollInformationObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EnrollmentDate { get; set; }
        public string AssignedCourse { get; set; }
        public string RollNumber { get; set; }
        public string AssignedTeacher { get; set; }
        public string ContactNumber { get; set; }
        public string fullName;
        public string FullName
        {
            get
            {
                
                string fullName = FirstName + " " + MiddleName + " " + LastName;
                return fullName;
            }
            set { fullName = value; }


        }

        public EnrollInformationObject()
        {

        }

        public EnrollInformationObject(string firstName,string lastName, string middleName,string enrollmentDate,string assignedCourse,string rollNumber,string assignedTeacher,string contactNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.EnrollmentDate = enrollmentDate;
            this.AssignedCourse = assignedCourse;
            this.RollNumber = rollNumber;
            this.AssignedTeacher = assignedTeacher;
            this.ContactNumber = contactNumber;
        }
    }
}
