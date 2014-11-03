using Speakers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Speakers
{
    public class App
    {
        public static Page GetMainPage()
        {
            ContentPage contentPage = new SpeakersView();
            NavigationPage navigationPage = new NavigationPage(contentPage);
            return navigationPage;
        }
    }
}
