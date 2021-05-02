using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_with_Entity_Framework_Core.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string  LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    //A student can enroll in any number of courses, and a course can have any number of students enrolled in it.
}
