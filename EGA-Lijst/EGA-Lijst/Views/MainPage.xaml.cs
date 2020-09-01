using EGA_Lijst.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EGA_Lijst
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public DateTime SelectedDate;
        public ObservableCollection<Weeklijst> weeklijst { get; set; }
        private ObservableCollection<Voeding> _voedingsLijst { get; set; }
        public ObservableCollection<Voeding> voedingsLijst
        {
            get
            {
                return _voedingsLijst;
            }
            set
            {
                _voedingsLijst = value;
                OnPropertyChanged("voedingsLijst");
            }
        }
        public MainPage()
        {
            InitializeComponent();
            SelectedDate = FindDateOfMondaySelectedWeek(DateTime.Now);
            DateLbl.Text = SelectedDate.Date.ToShortDateString() + " - " + SelectedDate.Date.AddDays(6).ToShortDateString();
            FillListViewAsync().ConfigureAwait(false);
            this.BindingContext = this;
        }
        public DateTime FindDateOfMondaySelectedWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
        public async Task FillListViewAsync()
        {
            WeeklijstDatabase wldb = new WeeklijstDatabase();
            List <Weeklijst> weekList= await wldb.GetWeeklijstAsync(SelectedDate);
            weeklijst = new ObservableCollection<Weeklijst>(await wldb.GetWeeklijstAsync(SelectedDate));
            if (weeklijst.Count == 0)
            {
                //No weeklijst found in database for SelectedDate, so create one
                weeklijst = new ObservableCollection<Weeklijst>(await wldb.GetWeeklijstAsync(SelectedDate));
                var nwl=await wldb.AddNewWeek(SelectedDate);
            }
            voedingsLijst = new ObservableCollection<Voeding>(await wldb.GetVoedingAsync(weeklijst.FirstOrDefault().WeekLijstId));
            if (voedingsLijst.Count==0 || voedingsLijst==null)
            {
                var nvw=await wldb.FillNewWeek(weeklijst.FirstOrDefault().WeekLijstId);
                voedingsLijst = new ObservableCollection<Voeding>(await wldb.GetVoedingAsync(weeklijst.FirstOrDefault().WeekLijstId));
            }
        }
        

        private void Left_Clicked(object sender, EventArgs e)
        {
            SelectedDate = SelectedDate.AddDays(-7);
            DateLbl.Text = SelectedDate.Date.ToShortDateString() + " - " + SelectedDate.Date.AddDays(6).ToShortDateString();
            FillListViewAsync().ConfigureAwait(false);
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            SelectedDate = SelectedDate.AddDays(7);
            DateLbl.Text = SelectedDate.Date.ToShortDateString() + " - " + SelectedDate.Date.AddDays(6).ToShortDateString();
            FillListViewAsync().ConfigureAwait(false);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            WeeklijstDatabase wldb = new WeeklijstDatabase();
            var sw=(Switch) sender;
            Voeding voeding = (Voeding)sw.BindingContext;
            if (voeding != null)
            {
                _ = wldb.SaveVoedingAsync(voeding);
            }
        }
    }
}
