using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AcademiApp.Models;

namespace AcademiApp.Helpers
{
    public class PeriodHelper
    {
        readonly SQLiteDatabaseHelpers _db;

        public PeriodHelper(SQLiteDatabaseHelpers db)
        {
            _db = db;
        }

        public List<Period> GetAllPeriods()
        {
            return _db.GetAll<Period>();
        }

        public void AddPeriod(Period period)
        {
            _db.Insert(period);
        }

        public void UpdatePeriod(Period period)
        {
            _db.Update(period);
        }

        public void DeletePeriod(int id)
        {
            _db.Delete<Period>(id);
        }
    }
}
