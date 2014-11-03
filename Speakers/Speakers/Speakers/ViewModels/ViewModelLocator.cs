using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.ViewModels
{
    public static class ViewModelLocator
    {
        private static SpeakersViewModel _speakersViewModel = null;
        public static SpeakersViewModel SpeakersViewModel
        {
            get 
            {
                if (_speakersViewModel == null)
                {
                    _speakersViewModel = new SpeakersViewModel();
                }
                return _speakersViewModel; 
            }
        }
    }
}
