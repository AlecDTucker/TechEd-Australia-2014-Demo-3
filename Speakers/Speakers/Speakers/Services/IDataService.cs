using System;
namespace Speakers.Services
{
    public interface IDataService
    {
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Speakers.Models.Speaker>> GetAllSpeakersAsync();
        System.Threading.Tasks.Task<bool> InsertSpeakerAsync(Speakers.Models.Speaker speaker);
    }
}
