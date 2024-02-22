namespace TaxaApp.Kode
{
    public class Taxatur
    {


        public string StartAdresse { get; set; }
        public string SlutAdresse { get; set; }
        public double DistanceIKm { get; set; }
        public string VognType { get; set; }
        public string Tidspunkt { get; set; }
        public bool HarCykel { get; set; }
        public bool HarLiftvogn { get; set; }

        public string? MapUrl { get; set; }

        public string? DistanceResult { get; set; }


    }
}
