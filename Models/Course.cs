﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AcademiApp.Models;

namespace AcademiApp.Models
{
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        [ForeignKey("PeriodId")]
        public int PeriodId { get; set; }

        [Ignore]
        public Period Period { get; set; }

        [Ignore]
        public List<Lecture> Lectures { get; set; } = new();

    }
}
