﻿using TaxaApp.Kode;

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
            public double TotalTidsPris { get; set; }
            public double DistanceIKm { get; set; }
            public double durationIMin { get; set; }
            public string? DistanceText { get; set; }
            public string? DurationText { get; set; }


        }

        public PrisInformation UdregnPris(Taxatur taxatur, double distanceIKm, double durationIMin)
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

            prisInfo.TotalPris = prisInfo.StartPris + (distanceIKm * prisInfo.KilometerPris);
            prisInfo.TotalTidsPris = prisInfo.StartPris + (durationIMin * prisInfo.MinutPris);


            if (taxatur.HarCykel)
            {
                prisInfo.TotalPris += 30;
                prisInfo.TotalTidsPris += 30;
            }

            if (taxatur.HarLiftvogn)
            {
                prisInfo.TotalPris += 350;
                prisInfo.TotalTidsPris += 350;
            }


            return prisInfo;

        }

        private bool ErDagtimer(DateTime tidspunkt)
        {

            if (tidspunkt.Month == 12 && tidspunkt.Day == 24 || tidspunkt.Month == 12 && tidspunkt.Day == 31)
            {
                return false;
            }



            if (tidspunkt.DayOfWeek >= DayOfWeek.Monday && tidspunkt.DayOfWeek <= DayOfWeek.Friday)
            {
                if (tidspunkt.Hour >= 6 && tidspunkt.Hour < 18)
                {
                    return true;
                }
            }


            if (tidspunkt.DayOfWeek == DayOfWeek.Saturday || tidspunkt.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }


            return false;
        }



    }
}
