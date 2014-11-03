using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Services
{
    public class AzureSyncHandler : IMobileServiceSyncHandler
    {
        public Task<Newtonsoft.Json.Linq.JObject> ExecuteTableOperationAsync(IMobileServiceTableOperation operation)
        {
            System.Diagnostics.Debug.WriteLine("Executing operation '{0}' for table '{1}'", operation.Kind, operation.Table.TableName);
            return operation.ExecuteAsync();
        }

        public Task OnPushCompleteAsync(MobileServicePushCompletionResult result)
        {
            System.Diagnostics.Debug.WriteLine("Push result: {0}", result.Status);
            foreach(var error in result.Errors)
            {
                System.Diagnostics.Debug.WriteLine("  Push error: {0}", error.Status);
                if (error.Status == System.Net.HttpStatusCode.Conflict)
                {
                    // Simplistic conflict handling - server wins
                    error.Handled = true;
                    error.CancelAndUpdateItemAsync(error.Item);
                }
            }

            

            return Task.FromResult(0);
        }
    }
}
