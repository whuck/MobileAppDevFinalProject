using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MobileAppDevFinalProject.Data
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public List<NotBoringActivity> NotBoringActivities { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }

        //public async Task<List<CatFact>> RefreshDataAsync()
        //{
        //    Facts = new List<CatFact>();

        //    var uri = new Uri(string.Format(Constants.Endpoint, string.Empty));

        //    try
        //    {
        //        for (int i = 0; i < 30; i++)
        //        {
        //            var response = await _client.GetAsync(uri);
        //            Debug.WriteLine("XXXX: " + response.ToString());
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                // Debug.WriteLine(content);
        //                CatFact catFact = JsonConvert.DeserializeObject<CatFact>(content);
        //                Debug.WriteLine(catFact);
        //                Facts.Add(catFact);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(@"\tERROR {0}", ex.Message);
        //    }

        //    return Facts;
        //}
        public async Task<List<NotBoringActivity>> RefreshDataAsync(Xamarin.Forms.ProgressBar pb)
        {
            NotBoringActivities = new List<NotBoringActivity>();

            var uri = new Uri(string.Format(Constants.APIBoredURL, string.Empty));

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    var response = await _client.GetAsync(uri);
                    Debug.WriteLine("XXXX: " + response.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        pb.Progress = pb.Progress + 0.2;
                        var content = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(content);
                        NotBoringActivity nba = JsonConvert.DeserializeObject<NotBoringActivity>(content);
                        Debug.WriteLine(nba);
                        NotBoringActivities.Add(nba);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return NotBoringActivities;
        }

    }
}
