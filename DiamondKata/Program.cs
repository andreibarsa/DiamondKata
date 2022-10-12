// See https://aka.ms/new-console-template for more information

using DiamondKata;

Console.WriteLine("Diamond");

if (args.Length != 1)
{
    Console.WriteLine("No letter supplied!");
}
else
{
    var diamondService = new DiamondKataService();
    if (!char.TryParse(args[0], out var letter) || !diamondService.ValidateLetter(letter))
    {
        Console.WriteLine("Please supply an upper letter!");
    }
    else
    {
        Console.WriteLine(diamondService.GenerateDiamond(letter));
    }
}
