using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AcademiApp.Models;

namespace AcademiApp.Pages.Periods
{
    class PeriodViewModel
    {
        public required ObservableCollection<Period> Periods { get; set; }

        public ICommand ItemClickedCommand { get; }

        public PeriodViewModel()
        {
            ItemClickedCommand = new Command<Period>(OnItemClicked);
            Periods = new ObservableCollection<Period>();
        }

        public async void OnItemClicked(Period selectedPeriod)
        {
            await Shell.Current.Navigation.PushAsync(new PeriodInfoPage(selectedPeriod));
        }
    }
}
