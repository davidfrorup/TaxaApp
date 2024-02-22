using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace TaxaApp.Kode
{
    public class GoogleMapsService
    {
        public readonly HttpClient _httpClient;

        public GoogleMapsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDistance(string StartAdresse, string SlutAdresse)
        {

            string apiKey = "AIzaSyAMX2xaib8pawKfNoBlzSSFy5tCzo3RI7g";
            string apiUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={Uri.EscapeDataString(StartAdresse)}&destinations={Uri.EscapeDataString(SlutAdresse)}&key={apiKey}";

            var response = await _httpClient.GetStringAsync(apiUrl);
            Console.WriteLine($"API Response: {response}");
            return response;

        }

        //public async Task<int> GetDistanceIKm(string startAddresse, string slutAddresse)
        //{
        //    try
        //    {
        //        string apiKey = "AIzaSyAMX2xaib8pawKfNoBlzSSFy5tCzo3RI7g"; // Replace with your actual API key
        //        string apiUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={startAddresse}&destinations={slutAddresse}&key={apiKey}";

        //        var response = await _httpClient.GetStringAsync(apiUrl);



        //        using (var jsonDoc = JsonDocument.Parse(response))
        //        {
        //            var rows = jsonDoc.RootElement.GetProperty("rows");
        //            if (rows.EnumerateArray().Any())
        //            {
        //                var elements = rows[0].GetProperty("elements");
        //                if (elements.EnumerateArray().Any())
        //                {
        //                    var distance = elements[0].GetProperty("distance").GetProperty("value").GetInt32();
        //                    int distanceInKm = distance! / 1000;

        //                    Console.WriteLine($"Afstand: {distanceInKm} km");
        //                    return distanceInKm;
        //                }
        //            }
        //        }

        //        Console.WriteLine("Fejl: Ugyldig afstandsinformation i svaret.");
        //        Console.WriteLine("Svaret fra Google Maps API:");
        //        Console.WriteLine(response);

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Fejl: {ex.Message}");
        //        return 0;
        //    }
        //}
    }
}