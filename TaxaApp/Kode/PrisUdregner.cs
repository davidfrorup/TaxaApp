using TaxaApp.Kode;

namespace TaxaApp.Kode
{
    public class PrisUdregner
    {
        

        public double Pris(Taxatur taxatur)
        {

            double StartPris = 0;
            double KilometerPris = 0;
            double MinutPris = 0;

            if (taxatur.VognType == "Almindelig vogn")
            {
                if (taxatur.Tidspunkt == "Dag")
                {
                    StartPris = 37;
                    KilometerPris = 12.75;
                    MinutPris = 5.75;
                }
                else
                {
                    StartPris = 47;
                    KilometerPris = 16;
                    MinutPris = 7;
                }
            }
            else if (taxatur.VognType == "Stor vogn")
            {
                if (taxatur.Tidspunkt == "Dag")
                {
                    StartPris = 77;
                    KilometerPris = 17;
                    MinutPris = 5.75;
                }
                else
                {
                    StartPris = 87;
                    KilometerPris = 19;
                    MinutPris = 7;
                }
            }

            double TotalPris = StartPris + KilometerPris;

            if (taxatur.HarCykel)
            {
                TotalPris += 30;
            }

            if (taxatur.HarLiftvogn)
            {
                TotalPris += 350;
            }

            return TotalPris;


        }

    }
}
