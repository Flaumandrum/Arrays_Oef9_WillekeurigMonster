using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Oef9_WillekeurigMonster
{
    internal class Program
    {
        //Tom Adriaen s
        // 18/03/2024
        // Project willekeurigmonster

        // Velden
        static public String[] _monsters = new string[10];
        static public int[] _level = new int[10];


        // GUI
        static void Main(string[] args)
        {
            // Lokale varialben 
            byte keuze = 0;

            // Scherm leegmaken 
            Console.Clear();

            do
            {
                try
                {
                    // Keuze menu
                    Console.Clear();

                    // Keuze menu
                    Console.WriteLine("Maak uw keuze uit volgend menu:");
                    Console.WriteLine("\n\n   1) Invoegen monsters")

                }
                catch
                {

                }
            }
            while ();


        }



        //Functies

        /// <summary>
        /// Zoek of er nog een lege plaats in de array zit
        /// </summary>
        /// <returns></returns>
        static public int ZoekLegePlaats()
        {
            int antwoord = -1;

            for(int i = 0; i < _monsters.Count(); i ++)
            {
                if (_monsters[i] != null)
                {
                    antwoord = i;
                    break;
                }
            }

            return antwoord;
        }

        /// <summary>
        ///  Kijkt of het lvl max 5 is en slaat dan het monster op
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="lvl"></param>
        /// <param name="nrIndex"></param>
        /// <returns></returns>
        static public bool MonsterOpslaan(String naam, String lvl, int nrIndex)
        {
            bool antwoord = false;
            try
            {

                int level = int.Parse(lvl);
            
                if (level <= 5)
                {
                    _monsters[nrIndex] = naam;
                    _level[nrIndex] = level;
                    antwoord = true;
                }

            }
            catch
            {

            }
            return antwoord;
        }


        /// <summary>
        /// Overloopt de array's en zet alle monsters onder elkaar. 
        /// </summary>
        /// <returns></returns>
        static public String ToonMonsters()
        {
            String antwoord = null;

            for (int i = 0; i < _monsters.Count(); i++)
            {
                if (_monsters[i] != null)
                {
                    antwoord += $"{(i+1).ToString()}) monster: {_monsters[i]} ( lvl:{_level[i].ToString()} \n)";
                }
            }

            return antwoord;
        }

        static public String KiesWillekeurigMonster(int lvlSpeler)
        {
            String antwoord = null;

            // maak random aan 
            Random rdm = new Random();
            int willekeurigIndex = 0;

            // Blijf dit doen tot het monster aan de voorwaarden voldoet
            do
            {
            
                // maak een willekeurige index aan van 0 tot het aantal indexen van de array
                willekeurigIndex = rdm.Next(0, _monsters.Count());
            

                if (_level[willekeurigIndex] == (lvlSpeler -1 ))
                {
                    antwoord = $"De deelnemer ontvangt 3 stuk(s) van {_monsters[willekeurigIndex]} ( level {_level[willekeurigIndex].ToString()})";      
                }
                else if(_level[willekeurigIndex] == lvlSpeler)
                {
                    antwoord = $"De deelnemer ontvangt 2 stuk(s) van {_monsters[willekeurigIndex]} ( level {_level[willekeurigIndex].ToString()})";
                }
                else if(_level[willekeurigIndex] == (lvlSpeler+1))
                {
                    antwoord = $"De deelnemer ontvangt 1 stuk(s) van {_monsters[willekeurigIndex]} ( level {_level[willekeurigIndex].ToString()})";
                }

            }while(antwoord == null );

            return antwoord;
        }

        static public String StandaardAntwoorden(int code)
        {
            String antwoord = null;

            return antwoord;
        }

    }
}
