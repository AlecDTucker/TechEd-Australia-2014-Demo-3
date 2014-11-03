//using Speakers.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Speakers.Services
//{
//    public class DataService : Speakers.Services.IDataService
//    {
//        private readonly SQLiteConnection _connection;

//        public DataService()
//        {
//            _connection = DependencyService.Get<ISQLite>().GetConnection();
//            CreateTables();
//        }

//        private void CreateTables()
//        {
//            _connection.CreateTable<Speaker>();
//        }

//        public async Task<ObservableCollection<Speaker>> GetAllSpeakersAsync()
//        {
//            ObservableCollection<Speaker> theCollection = new ObservableCollection<Speaker>();

//            try
//            {
//                theCollection = await _getAllSpeakersAsync();
                
//                // Populate first time through
//                if (theCollection == null || theCollection.Count == 0)
//                {
//                    await _loadSpeakersAsync();
//                    theCollection = await _getAllSpeakersAsync();
//                }
//            }
//            catch(Exception ex)
//            {
//                // Handle the exception
//            }

//            return theCollection;
//        }

//        private async Task<ObservableCollection<Speaker>> _getAllSpeakersAsync()
//        {
//            List<Speaker> theList = new List<Speaker>();
//            ObservableCollection<Speaker> theCollection = new ObservableCollection<Speaker>();

//            try
//            {
//                theList = _connection.Table<Speaker>().ToList<Speaker>();

//                if (theList != null && theList.Count > 0)
//                {
//                    foreach(Speaker one in theList)
//                    {
//                        theCollection.Add(one);
//                    }
//                }
//            }
//            catch(Exception ex)
//            {

//            }

//            return theList;
//        }

//        private async Task _loadSpeakersAsync()
//        {
//            await InsertSpeakerAsync(new Speaker() { FirstName = "AlecDB", LastName = "TuckerDB" });
//            await InsertSpeakerAsync(new Speaker() { FirstName = "LarsDB", LastName = "KlintDB" });
//            await InsertSpeakerAsync(new Speaker() { FirstName = "FilipDB", LastName = "EkbergDB" });
//        }
//        public async Task<bool> InsertSpeakerAsync(Speaker speaker)
//        {
//            bool isSuccessful = false;

//            try
//            {
//                _connection.Insert(speaker);

//                isSuccessful = true;
//            }
//            catch(Exception ex)
//            {
//                // Handle exception
//            }

//            return isSuccessful;
//        }
//    }
//}
