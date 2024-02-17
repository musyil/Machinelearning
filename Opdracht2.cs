using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_1
{

    class Schijven
    {

        static void Main(string[] args)
        {
            //aantal standaardblokken en lijst aanmaken voor standaardblokken
            string n = Console.ReadLine();
            long aantalstandaardblokken = long.Parse(n.Split(' ')[0]);
            List<long> standaardblokken = new List<long>();
            // alle standaardblokken in een lijst zetten

            for (int i = 0; i < aantalstandaardblokken; i++)
            {
                string g = Console.ReadLine();
                standaardblokken.Add(long.Parse(g.Split(' ')[0]));

            }
            //aantal steunblokken en lijst aanmaken voor steunblokken
            string m = Console.ReadLine();
            long Aantalsteunblokken = long.Parse(m.Split(' ')[0]);
            List<long> Steunblokken = new List<long>();
            // alle steunblokken in een lijst zetten
            for (int i = 0; i < (Aantalsteunblokken); i++)
            {
                string g = Console.ReadLine();
                Steunblokken.Add(long.Parse(g.Split(' ')[0]));
            }

            // zet aantal schijven op nul en bereken dan voor elk steunblok het benodigde aantal schijfjes en tel die bij elkaar op.
            long Schijfjes = 0;
            for(int i=0; i < Steunblokken.Count; i++)
            {
                int Links = 0;
                int Rechts = standaardblokken.Count-1;
                long Schijf = BinarySearch(standaardblokken, (long)Steunblokken[i], Links, Rechts);
                Schijfjes = Schijfjes + Schijf;
                
             }
            // geef terug het aantal benodigde schijfjes
            Console.WriteLine(Schijfjes);
            Console.ReadKey();
        }


        static long BinarySearch(List<long> Standaardblokken, long Doel, int Links, int Rechts)
        {
            // pak altijd de linkerkant van het midden als het een even aantal standaardblokken zijn
            int Midden = (Rechts - Links) / 2;
            if (Links < Rechts)
            {
                // als er een standaard blok perfect op past zijn 0 schijfjes nodig
                if (Standaardblokken[Midden] == Doel)
                {
                    return 0;
                }
                // is het steunblok kleiner dan het midden, neem dan het midden als rechterkant
                else if (Standaardblokken[Midden] > Doel)
                {
                    return BinarySearch(Standaardblokken, Doel, Links, Midden);
                }
                // anders neem het midden als linkerkant + 1 want je weet dat ie ook niet de middelste is dus je hoeft die niet mee te nemen
                else
                    return BinarySearch(Standaardblokken, Doel, Midden + 1, Rechts);
            }
            else // Links = Rechts
            {
                
                if (Doel < Standaardblokken[Midden])

                    return Doel;

                if (Doel >= Standaardblokken[Midden])

                    return Doel - Standaardblokken[Midden];

            }
            
            return 0;

        }   
    }
}
