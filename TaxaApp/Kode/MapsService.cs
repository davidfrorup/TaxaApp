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

        
    }
}