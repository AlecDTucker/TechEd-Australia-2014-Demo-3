using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Services
{
    public static class ServiceLocator
    {
        private static IDataService _dataService = null;
        public static IDataService DataService
        {
            get 
            {
                if (_dataService == null)
                {
                    //_dataService = new DataService();
                    _dataService = new AzureService();
                }
                return _dataService; 
            }
        }
    }
}
