using System;
using System.IO;
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

        public async Task<int> GetDistanceInKm(string startAddress, string destinationAddress)
        {
            try
            {
                // Erstat 'YOUR_API_KEY' med din faktiske Google Maps API-nøgle
                string apiKey = "AIzaSyAMX2xaib8pawKfNoBlzSSFy5tCzo3RI7g";
                string apiUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={startAddress}&destinations={destinationAddress}&key={apiKey}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var reader = new StreamReader(stream))
                    {
                        string result = await reader.ReadToEndAsync(); // Ændring her

                        // Implementer logikken til at trække afstanden fra JSON-svaret her
                        // I dette eksempel antages det, at afstanden findes i kilometer
                        // Du skal parse og behandle resultatet i overensstemmelse hermed
                        Console.WriteLine(result);

                        return 0; // Erstat denne linje med logikken til at hente den faktiske afstand
                    }
                }
                else
                {
                    // Håndter fejl ved API-opkald her
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // Håndter eventuelle undtagelser her
                Console.WriteLine($"Fejl: {ex.Message}");
                return 0;
            }
        }
    }
}