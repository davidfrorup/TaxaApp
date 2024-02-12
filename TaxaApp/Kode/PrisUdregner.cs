using TaxaApp.Kode;

namespace TaxaApp.Kode
{
    public class PrisUdregner
    {
        public class PrisInformation
        {
            public double StartPris { get; set; }
            public double KilometerPris { get; set; }
            public double MinutPris { get; set; }
            public double TotalPris { get; set; }
        }

        public PrisInformation UdregnPris(Taxatur taxatur)
        {
            PrisInformation prisInfo = new PrisInformation();

            if (taxatur.VognType == "Almindelig vogn")
            {
                if (taxatur.Tidspunkt == "Dag")
                {
                    prisInfo.StartPris = 37;
                    prisInfo.KilometerPris = 12.75;
                    prisInfo.MinutPris = 5.75;
                }
                else
                {
                    prisInfo.StartPris = 47;
                    prisInfo.KilometerPris = 16;
                    prisInfo.MinutPris = 7;
                }
            }
            else if (taxatur.VognType == "Stor vogn")
            {
                if (taxatur.Tidspunkt == "Dag")
                {
                    prisInfo.StartPris = 77;
                    prisInfo.KilometerPris = 17;
                    prisInfo.MinutPris = 5.75;
                }
                else
                {
                    prisInfo.StartPris = 87;
                    prisInfo.KilometerPris = 19;
                    prisInfo.MinutPris = 7;
                }
            }

            // Opdateret: Brug afstand fra taxatur
            prisInfo.TotalPris = prisInfo.StartPris + (taxatur.DistanceIKm * prisInfo.KilometerPris);

            if (taxatur.HarCykel)
            {
                prisInfo.TotalPris += 30;
            }

            if (taxatur.HarLiftvogn)
            {
                prisInfo.TotalPris += 350;
            }

            return prisInfo;
        }
    }
}
