using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace MobileAppDevFinalProject.Data
{
    public interface IRestService
    {
        Task<List<NotBoringActivity>> RefreshDataAsync(Xamarin.Forms.ProgressBar pb);
    }
}
