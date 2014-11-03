using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Speakers.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Services
{
    public class AzureService : IDataService
    {
        private readonly MobileServiceClient mobileService = new MobileServiceClient
            (
            "https://wpd313.azure-mobile.net/",
            #region Hide the key
            ""
            #endregion
            );

        IMobileServiceSyncHandler syncHandler = null;

        public AzureService()
        {
            Initialise();
        }

        private async void Initialise()
        {
            if (!mobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("speakers.db");
                store.DefineTable<Speaker>();
                syncHandler = new AzureSyncHandler();
                await mobileService.SyncContext.InitializeAsync(store, syncHandler);
            }
        }

        public async Task<System.Collections.ObjectModel.ObservableCollection<Models.Speaker>> GetAllSpeakersAsync()
        {
            ObservableCollection<Speaker> theCollection = new ObservableCollection<Speaker>();

            try
            {
                var theTable = mobileService.GetSyncTable<Speaker>();

                // TEMP: Force pull to test SyncHandler
                await theTable.PullAsync();

                // Read data from the local DB
                theCollection = await theTable.ToCollectionAsync<Speaker>();

                // If this found nothing, pull data from the cloud and try again
                if (theCollection == null || theCollection.Count == 0)
                {
                    await theTable.PullAsync();
                    theCollection = await theTable.ToCollectionAsync<Speaker>();

                    // If this still found nothing, load data locally (and push to the cloud) then try again
                    if (theCollection == null || theCollection.Count == 0)
                    {
                        await LoadSpeakers();
                        theCollection = await theTable.ToCollectionAsync<Speaker>();
                    }
                }
            }
            catch(Exception ex)
            {
                // Handle the error
            }

            return theCollection;
        }

        public async Task<bool> InsertSpeakerAsync(Models.Speaker speaker)
        {
            bool isSuccessful = false;

            try
            {
                var theTable = mobileService.GetSyncTable<Speaker>();
                await theTable.InsertAsync(speaker);
                isSuccessful = true;
            }
            catch(Exception ex)
            {
                // Handle the error
            }

            return isSuccessful;
        }

        public async Task LoadSpeakers()
        {
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Alec", LastName = "Tucker" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Lars", LastName = "Klint" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Filip", LastName = "Ekberg" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Nick", LastName = "Randolph" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Mitch", LastName = "Denny" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Dave", LastName = "Glover" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Tatham", LastName = "Oddie" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Vaughan", LastName = "Knight" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Ash", LastName = "de Zylva" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Rocky", LastName = "Heckman" });
            await this.InsertSpeakerAsync(new Speaker() { FirstName = "Jordan", LastName = "Knight" });


            // Send to azure
            mobileService.SyncContext.PushAsync();
        }
    }
}
