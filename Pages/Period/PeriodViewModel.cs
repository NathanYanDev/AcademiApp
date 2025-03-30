using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AcademiApp.Pages.Period
{
    class PeriodViewModel
    {
        public required ObservableCollection<Period> Periods { get; set; }

        public ICommand ItemClickedCommand { get; }

        public PeriodViewModel()
        {
            ItemClickedCommand = new Command<Period>(OnItemClicked);
            Periods = new ObservableCollection<Period>();
            OnLoadingTestData();
        }

        public async void OnItemClicked(Period selectedPeriod)
        {
            await Shell.Current.Navigation.PushAsync(new PeriodInfoPage(selectedPeriod));
        }

        private void OnLoadingTestData()
        {
            Periods.Add(new Period { PeriodCode = "01-2025", PeriodName = "1º Semestre / 2025", PeriodYear = "2025" });
            Periods.Add(new Period { PeriodCode = "02-2025", PeriodName = "2º Semestre / 2025", PeriodYear = "2025" });
            Periods.Add(new Period { PeriodCode = "01-2026", PeriodName = "1º Semestre / 2026", PeriodYear = "2026" });
            Periods.Add(new Period { PeriodCode = "02-2025", PeriodName = "2º Semestre / 2026", PeriodYear = "2026" });
        }
    }
}
