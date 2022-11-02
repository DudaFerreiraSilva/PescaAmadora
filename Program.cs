const double MaxAguasContinentais = 10;
const double MaxAguasMarinhas = 15;

const decimal MultaBase = 1000;
const decimal MultaExcesso = 20;

Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("--- Pesca Amadora ---\n");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Peso (em kg)...: ");
double pesoPescado = Convert.ToDouble(Console.ReadLine());
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Águas [c]ontinentais ou [m]arinhas? ");
string localPesca = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();
Console.ResetColor();

Console.WriteLine();

if (localPesca != "C" && localPesca != "M")
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Local não reconhecido.");
    Console.ResetColor();
    return;
}

Console.ForegroundColor = ConsoleColor.Green;
if (localPesca == "C" && pesoPescado <= MaxAguasContinentais ||
    localPesca == "M" && pesoPescado <= MaxAguasMarinhas)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Pescaria dentro dos limites legais.");
    Console.ResetColor();
    return;
}
Console.ResetColor();

double pesoPermitido = localPesca == "C" ? MaxAguasContinentais : MaxAguasMarinhas;
double pesoExcesso = pesoPescado - pesoPermitido;
decimal multa = MultaBase + MultaExcesso * Convert.ToDecimal(pesoExcesso);

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine($"Pescaria excede os limites legais em {pesoExcesso}kg.\nSujeito a multa de {multa:C}.");
Console.ResetColor();
