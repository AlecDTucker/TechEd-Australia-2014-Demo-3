using Speakers.Models;
using Speakers.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.ViewModels
{
    public class SpeakersViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;

        #region Constructors
        public SpeakersViewModel()
        {
            _dataService = ServiceLocator.DataService;
            _constructor();
        }
        private async void _constructor()
        {
            this.Speakers = await LoadSpeakers();
            this.Title = "speakers 3";
        }
        #endregion

        #region Properties
        private ObservableCollection<Speaker> _speakers;
        public ObservableCollection<Speaker> Speakers
        {
            get { return _speakers; }
            set { if (_speakers != value) { _speakers = value; RaisePropertyChanged(() => Speakers); } }
        }
        #endregion

        #region Methods
        private async Task<ObservableCollection<Speaker>> LoadSpeakers()
        {
            ObservableCollection<Speaker> theCollection = new ObservableCollection<Speaker>();

            try
            {
                theCollection = await _dataService.GetAllSpeakersAsync();
            }
            catch(Exception ex)
            {
                // Handle the exception
            }

            return theCollection;
        }
        #endregion
    }
}
