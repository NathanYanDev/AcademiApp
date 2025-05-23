﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AcademiApp.Models
{
    public class CourseLecture
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int CourseId { get; set; }

        [Indexed]
        public int LectureId { get; set; }
    }
}
