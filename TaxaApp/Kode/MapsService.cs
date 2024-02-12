using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaxaApp.Kode
{
    public class GoogleMapsService
    {
        private readonly HttpClient _httpClient;

        public GoogleMapsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDistanceIKm(string startAddress, string destinationAddress)
        {
            try
            {
                string apiKey = "AIzaSyAMX2xaib8pawKfNoBlzSSFy5tCzo3RI7g"; // Erstat med din faktiske API-nøgle
                string apiUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={startAddress}&destinations={destinationAddress}&key={apiKey}";

                var response = await _httpClient.GetStringAsync(apiUrl);

                var distanceIndex = response.IndexOf("\"value\"");
                if (distanceIndex != -1)
                {
                    distanceIndex = response.IndexOf(":", distanceIndex) + 1;
                    var distanceEndIndex = response.IndexOf(",", distanceIndex);

                    if (distanceEndIndex != -1 && int.TryParse(response.Substring(distanceIndex, distanceEndIndex - distanceIndex), out int distanceInMeters))
                    {
                        int distanceInKm = distanceInMeters / 1000;

                        Console.WriteLine($"Afstand: {distanceInKm} km");
                        return distanceInKm;
                    }
                }

                Console.WriteLine("Fejl: Ugyldig afstandsinformation i svaret.");
                Console.WriteLine("Svaret fra Google Maps API:");
                Console.WriteLine(response);

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
                return 0;
            }
        }
    }
}
