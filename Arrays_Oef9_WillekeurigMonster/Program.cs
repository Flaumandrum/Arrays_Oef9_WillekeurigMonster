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
            {   // Keuze menu
                    Console.Clear();
                try
                {
                    

                    // Keuze menu
                    Console.WriteLine("Maak uw keuze uit volgend menu:");
                    Console.WriteLine("\n\n   1) Invoegen monsters\n   2) monsters aanpassen \n   3) monsters verwijderen\n   4) Alle monsters tonen \n   5) willekeurig monster tonen \n   6) Afsluiten   ");
                    Console.Write("\n\nUw keuze: ");

                    keuze = byte.Parse(Console.ReadLine());

                    // Scherm leegmaken 
                    Console.Clear();

                    // Als Invoegen 
                    if (keuze == 1)
                    {
                        // Zoek een lege plaats
                        int plaats =  ZoekLegePlaats();

                        if(plaats != -1)
                        {
                            // Vraag de gegevens van het monster
                            Console.Write("Geef de naam van het monster:");
                            string naam = Console.ReadLine();

                            Console.Write("\nGeef het level van het monster (max 5)");
                            String lvl = Console.ReadLine();

                            bool gelukt = MonsterOpslaan(naam, lvl, plaats);

                            // Scherm leegmaken 
                            Console.Clear();

                            if (gelukt)
                            {
                                // fout code 
                                Console.WriteLine(StandaardAntwoorden(6));
                            }
                            else
                            {
                                // fout code 
                                Console.WriteLine(StandaardAntwoorden(7));
                            }
                            
                            Console.WriteLine(StandaardAntwoorden(0));
                            Console.ReadKey();
                        }
                        else
                        {
                            // fout code 
                            Console.WriteLine(StandaardAntwoorden(5));
                            Console.WriteLine(StandaardAntwoorden(0));
                            Console.ReadKey();
                        }

                    }
                    // Als aanpassen 
                    else if (keuze == 2)
                    {
                        Console.WriteLine(ToonMonsters());
                        Console.WriteLine();
                        // Vraag het nummer van het mosnter
                        Console.Write("Geef het nummer van het monster dat u wilt aanpassen: ");
                        int nummer = (int.Parse(Console.ReadLine())-1);

                        // Vraag de gegevens van het monster
                        Console.Write("Geef de juiste naam van het monster:");
                        string naam = Console.ReadLine();

                        Console.Write("\nGeef het juiste level van het monster (max 5)");
                        String lvl = Console.ReadLine();

                        bool gelukt = MonsterOpslaan(naam, lvl, nummer);

                        // Scherm leegmaken 
                        Console.Clear();

                        if (gelukt)
                        {
                            // fout code 
                            Console.WriteLine(StandaardAntwoorden(8));
                        }
                        else
                        {
                            // fout code 
                            Console.WriteLine(StandaardAntwoorden(7));
                        }

                        Console.WriteLine(StandaardAntwoorden(0));
                        Console.ReadKey();
                    }
                    // als Verwijderen 
                    else if (keuze == 3)
                    {
                        Console.WriteLine(ToonMonsters());
                        Console.WriteLine();
                        // Vraag het nummer van het mosnter
                        Console.Write("Geef het nummer van het monster dat u wilt aanpassen: ");
                        int nummer = (int.Parse(Console.ReadLine()) - 1);

                        bool gelukt = MonsterOpslaan(null, "0", nummer);

                        // Scherm leegmaken 
                        Console.Clear();

                        if (gelukt)
                        {
                            // fout code 
                            Console.WriteLine(StandaardAntwoorden(9));
                        }
                        else
                        {
                            // fout code 
                            Console.WriteLine(StandaardAntwoorden(7));
                        }

                        Console.WriteLine(StandaardAntwoorden(0));
                        Console.ReadKey();

                    }
                    // Als Tonen
                    else if (keuze == 4)
                    {
                        Console.WriteLine(ToonMonsters());
                        Console.WriteLine();
                        Console.WriteLine(StandaardAntwoorden(0));
                        Console.ReadKey();
                    }
                    // Als Willekeurig monster tonen
                    else if (keuze == 5)
                    {
                        Console.Write("Geef het level van de speler: ");
                        int lvl = int.Parse(Console.ReadLine());

                        Console.WriteLine(KiesWillekeurigMonster(lvl));
                        Console.WriteLine();
                        Console.WriteLine(StandaardAntwoorden(0));
                        Console.ReadKey();
                    }
                    // Als Afsluiten 
                    else if (keuze == 6)
                    {
                        // fout code 
                        Console.WriteLine(StandaardAntwoorden(4));
                        Console.WriteLine(StandaardAntwoorden(2));
                        Console.ReadKey();
                    }

                    // in elk ander geval 
                    else
                    {
                        // fout code 
                        Console.WriteLine(StandaardAntwoorden(3));
                        Console.WriteLine(StandaardAntwoorden(0));
                        Console.ReadKey();
                    }
                }
                catch
                {
                    // Scherm leegmaken 
                    Console.Clear();

                    // fout code 
                    Console.WriteLine(StandaardAntwoorden(1));
                    Console.WriteLine(StandaardAntwoorden(0));
                    Console.ReadKey();
                }
            }
            while (keuze != 6);


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
                if (_monsters[i] == null)
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
            
                if (level <= 5 && level > 0)
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
                    antwoord += $"{(i+1).ToString()}) monster: {_monsters[i]} ( lvl:{_level[i].ToString()} )\n";
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

            if (code == 0)
            {
                antwoord = "Druk op een toets om terug te keren naar het hoofdmenu";
            }
            else if (code == 1)
            {
                antwoord = "U gaf geen getal in.";
            }
            else if (code == 2)
            {
                antwoord = "Druk op een toets om af te sluiten";
            }
            else if (code == 3)
            {
                antwoord =  "U gaf geen geldige keuze in";
            }
            else if (code == 4)
            {
                antwoord = "Tot een volgende keer";
            }
            else if (code == 5)
            {
                antwoord = "Er is geen plaats meer.";
            }
            else if (code == 6)
            {
                antwoord = "Het monster werd opgeslagen.";
            }
            else if (code == 7)
            {
                antwoord = "U gaf geen juist lvl in.";
            }
            else if (code == 8)
            {
                antwoord = "Het monster werd aangepast.";
            }
            else if (code == 9)
            {
                antwoord = "Het monster werd verwijderd.";
            }
            return antwoord;
        }

    }
}
