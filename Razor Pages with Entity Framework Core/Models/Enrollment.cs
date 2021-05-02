using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Pages_with_Entity_Framework_Core.Models
{

    public enum Grade
    {
        A,B,C,D,F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText="No Grade")]
        public Grade? Grade { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }
    }
}
