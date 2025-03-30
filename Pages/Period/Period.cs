using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiApp.Pages.Period
{
    public class Period
    {
        public required string PeriodName { get; set; }
        public required string PeriodCode { get; set; }

        public string? PeriodYear { get; set; }
    }
}
