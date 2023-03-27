using KMZI_Lab2;

const string pathToFolder = "../../../Alphabets";
const string myName = "ValdaitsevAlexanderDenisovich";
var symbolsQty = myName.Length;

var pathKyrgyz = $"{pathToFolder}/kyrgyz.txt";
var pathLithuanian = $"{pathToFolder}/lithuanian.txt";
var pathBinary = $"{pathToFolder}/binary.txt";

var textKyrgyz = "";
var textLithuanian = "";
var textBinary = "";

using (var sr = new StreamReader(pathKyrgyz)) { textKyrgyz = sr.ReadToEnd().ToLower(); }
using (var sr = new StreamReader(pathLithuanian)) { textLithuanian = sr.ReadToEnd().ToLower(); }
using (var sr = new StreamReader(pathBinary)) { textBinary = sr.ReadToEnd().ToLower(); }


Console.WriteLine("\n============================================\n");
Console.WriteLine($"Entropy of Language (kyrgyz):      {Entropy.GetShannonEntropy(textKyrgyz)}");
Console.WriteLine($"Entropy of Language (lithuanian):  {Entropy.GetShannonEntropy(textLithuanian)}");
Console.WriteLine($"Entropy of Language (binary):      {Entropy.GetShannonEntropy(textBinary)}");
Console.WriteLine("\n============================================\n");

Console.WriteLine($"Information Amount (kyrgyz):       {Entropy.GetShannonEntropy(textKyrgyz) * symbolsQty}");
Console.WriteLine($"Information Amount (lithuanian):   {Math.Round(Entropy.GetShannonEntropy(textLithuanian) * symbolsQty, 3)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetShannonEntropy(textBinary) * symbolsQty * 8}");
Console.WriteLine("\n============================================\n");

Console.WriteLine("\t\t--- P = 0.1 ---");
Console.WriteLine($"Information Amount (kyrgyz):       {Math.Round(Entropy.GetShannonEntropy(textKyrgyz) * symbolsQty * Entropy.GetEffectiveEntropy(0.1), 3)}");
Console.WriteLine($"Information Amount (lithuanian):   {Math.Round(Entropy.GetShannonEntropy(textLithuanian) * symbolsQty * Entropy.GetEffectiveEntropy(0.1), 3)}");
Console.WriteLine($"Information Amount (binary):       {Math.Round(Entropy.GetShannonEntropy(textBinary) * symbolsQty * Entropy.GetEffectiveEntropy(0.1), 3)}");
Console.WriteLine("\n============================================\n");

Console.WriteLine("\t\t--- P = 0.5 ---");
Console.WriteLine($"Information Amount (kyrgyz):       {Math.Round(Entropy.GetShannonEntropy(textKyrgyz) * symbolsQty * Entropy.GetEffectiveEntropy(0.5), 3)}");
Console.WriteLine($"Information Amount (lithuanian):   {Math.Round(Entropy.GetShannonEntropy(textLithuanian) * symbolsQty * Entropy.GetEffectiveEntropy(0.5), 3)}");
Console.WriteLine($"Information Amount (binary):       {Math.Round(Entropy.GetShannonEntropy(textBinary) * symbolsQty * Entropy.GetEffectiveEntropy(0.5), 3)}");
Console.WriteLine("\n============================================\n");

Console.WriteLine("\t\t --- P = 1 ---");
Console.WriteLine($"Information Amount (kyrgyz):       {Math.Round(Entropy.GetShannonEntropy(textKyrgyz) * symbolsQty * Entropy.GetEffectiveEntropy(1), 3)}");
Console.WriteLine($"Information Amount (lithuanian):   {Math.Round(Entropy.GetShannonEntropy(textLithuanian) * symbolsQty * Entropy.GetEffectiveEntropy(1), 3)}");
Console.WriteLine($"Information Amount (binary):       {Math.Round(Entropy.GetShannonEntropy(textBinary) * symbolsQty * Entropy.GetEffectiveEntropy(1), 3)}");
Console.WriteLine("\n============================================\n");
