namespace TaxaApp.Kode
{
    public class Taxatur
    {


        public string? StartAdresse { get; set; }
        public string? SlutAdresse { get; set; }
        public double? DistanceIKm { get; set; }
        public double? durationIMin { get; set; }
        public string? VognType { get; set; }
        public DateTime Tidspunkt { get; set; } = DateTime.Now;
        public bool HarCykel { get; set; }
        public bool HarLiftvogn { get; set; }
        public string? MapUrl { get; set; }
        public string? DistanceResult { get; set; }
        public string? TimeResult { get; set; }


    }
}
