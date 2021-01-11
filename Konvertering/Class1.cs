using System;

namespace Konvertering
{
    public class Class1
    {

        public static double TilSvenskeKroner(double danskeKroner)
        {
            double svenskeKrone = danskeKroner * 0.7041;
            return svenskeKrone;
        }

        public static double TilDanskeKroner(double svenskeKrone)
        {
            double danskeKroner = svenskeKrone / 0.7041;
            return danskeKroner;
        }
    }
}

