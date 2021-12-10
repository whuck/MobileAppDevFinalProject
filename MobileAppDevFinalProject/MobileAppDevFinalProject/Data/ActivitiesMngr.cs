using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace MobileAppDevFinalProject.Data
{
    public class ActivitiesManager
    {
        IRestService restService;
        public ActivitiesManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<NotBoringActivity>> GetTasksAsync(Xamarin.Forms.ProgressBar pb)
        {
            return restService.RefreshDataAsync(pb);
        }
    }
}
