using Speakers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Views
{
    public partial class SpeakersView
    {
        public SpeakersView()
        {
            InitializeComponent();
            this.BindingContext = ViewModelLocator.SpeakersViewModel;
        }
    }
}
