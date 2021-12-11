using Banka;

UcetZaklad ucetA = new UcetZaklad();
UcetZaklad ucetB = new UcetZaklad();

ucetA.Majitel = "Tomas";
ucetB.Majitel = "Eva";

ucetA.Vklad(1000);
ucetB.Vklad(500);

ucetA.Vyber(500);
ucetB.Vyber(100);

Console.WriteLine(ucetA);

//ucetA.Vyber(1200);