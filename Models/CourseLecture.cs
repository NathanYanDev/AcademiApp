using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiApp.Models
{
    public class CourseLecture
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        [ForeignKey("LectureId")]
        public int LectureId { get; set; }
    }
}
