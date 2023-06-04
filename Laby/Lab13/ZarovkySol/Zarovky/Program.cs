using Zarovky;

Zarovka kuchyn = new Zarovka() { Jmeno = "kuchyn" };
Zarovka obyvak = new Zarovka() { Jmeno = "obyvak" };
Vypinac vypinac = new Vypinac();

vypinac.AkcePriKliknuti += kuchyn.ZmenaStavu;
vypinac.AkcePriKliknuti += obyvak.ZmenaStavu;

vypinac.Prepnuti();
vypinac.Prepnuti();