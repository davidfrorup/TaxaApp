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
            public double DistanceIKm { get; set; }
            public double durationIMin { get; set; }
            public string? DistanceText { get; set; }
            public string? DurationText { get; set; }


        }

        public PrisInformation UdregnPris(Taxatur taxatur)
        {
            PrisInformation prisInfo = new PrisInformation();

            if (taxatur.VognType == "Almindelig vogn")
            {
                if (ErDagtimer(taxatur.Tidspunkt))
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
                if (ErDagtimer(taxatur.Tidspunkt))
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

            prisInfo.TotalPris = prisInfo.StartPris + (prisInfo.DistanceIKm * prisInfo.KilometerPris);

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

        private bool ErDagtimer(DateTime tidspunkt)
        {
            // Kontroller om det er dagtimer (mandag-fredag kl. 06-18)
            if (tidspunkt.DayOfWeek >= DayOfWeek.Monday && tidspunkt.DayOfWeek <= DayOfWeek.Friday
                && tidspunkt.Hour >= 6 && tidspunkt.Hour < 18)
            {
                return true;
            }

            // Kontroller om det er nat (helligdag, d. 24. december, d. 31. december,
            // mandag-fredag kl. 18-06 og lørdag-søndag kl. 00-24)
            if (ErHelligdag(tidspunkt) || ErJuleaften(tidspunkt) || ErNytårsaften(tidspunkt)
                || (tidspunkt.DayOfWeek >= DayOfWeek.Monday && tidspunkt.DayOfWeek <= DayOfWeek.Friday
                    && (tidspunkt.Hour >= 18 || tidspunkt.Hour < 6))
                || (tidspunkt.DayOfWeek == DayOfWeek.Saturday || tidspunkt.DayOfWeek == DayOfWeek.Sunday))
            {
                return false;
            }

            return true;
        }

        private bool ErHelligdag(DateTime tidspunkt)
        {
        
            // Hvis det er søndag, betragt det som en helligdag
            if (tidspunkt.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }

            // Du kan tilføje yderligere betingelser baseret på kendte helligdage
            // Eksempelvis:

            
            if (tidspunkt.Month == 12 && tidspunkt.Day == 31)
            {
                return true;
            }

            
            if (tidspunkt.Month == 12 && tidspunkt.Day == 24)
            {
                return true;
            }

            // ... (tilføj andre helligdage efter behov)

            return false;
        }

        private bool ErJuleaften(DateTime tidspunkt)
        {
            return tidspunkt.Month == 12 && tidspunkt.Day == 24;
        }

        private bool ErNytårsaften(DateTime tidspunkt)
        {
            return tidspunkt.Month == 12 && tidspunkt.Day == 31;
        }





    }
}
