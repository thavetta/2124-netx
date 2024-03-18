using Banka;
// See https://aka.ms/new-console-template for more information
UcetZaklad ucetA = new UcetZaklad();
UcetZaklad ucetB = new UcetZaklad();

ucetA = null;

ucetA?.NastavMajitele("Tomas");
ucetB.NastavMajitele("Eva");

ucetA?.Vklad(1000);
ucetB.Vklad(500);

ucetA?.Vyber(500);
ucetB.Vyber(100);

Console.WriteLine(ucetA);

ucetA?.Vyber(1200);