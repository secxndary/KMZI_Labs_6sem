using KMZI_Lab2;

var kyrgyz = Entropy.ReadFromFile("kyrgyz.txt");
var lithuanian = Entropy.ReadFromFile("lithuanian.txt");
var binary = Entropy.ReadFromFile("binary.txt");
var myName = Entropy.ReadFromFile("myName.txt");
var myNameASCII = Entropy.ReadFromFile("myNameASCII.txt");


Console.WriteLine("\n==========================================");
Console.WriteLine($"Entropy of Language (kyrgyz):      {Entropy.GetShannonEntropy(kyrgyz)}");
Console.WriteLine($"Entropy of Language (lithuanian):  {Entropy.GetShannonEntropy(lithuanian)}");
Console.WriteLine($"Entropy of Language (binary):      {Entropy.GetShannonEntropy(binary)}");

Console.WriteLine("\n================  P = 0  =================");
Console.WriteLine($"Information Amount (kyrgyz):       {Entropy.GetInformationAmount(kyrgyz, myName)}");
Console.WriteLine($"Information Amount (lithuanian):   {Entropy.GetInformationAmount(lithuanian, myName)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(myNameASCII, myNameASCII)}");

Console.WriteLine("\n===============  P = 0.1  ================");
Console.WriteLine($"Information Amount (kyrgyz):       {Entropy.GetInformationAmount(kyrgyz, myName, 0.1)}");
Console.WriteLine($"Information Amount (lithuanian):   {Entropy.GetInformationAmount(lithuanian, myName, 0.1)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(myNameASCII, myNameASCII, 0.1)}");

Console.WriteLine("\n===============  P = 0.5  ================");
Console.WriteLine($"Information Amount (kyrgyz):       {Entropy.GetInformationAmount(kyrgyz, myName, 0.5)}");
Console.WriteLine($"Information Amount (lithuanian):   {Entropy.GetInformationAmount(lithuanian, myName, 0.5)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(myNameASCII, myNameASCII, 0.5)}");

Console.WriteLine("\n================  P = 1  =================");
Console.WriteLine($"Information Amount (kyrgyz):       {Entropy.GetInformationAmount(kyrgyz, myName, 1)}");
Console.WriteLine($"Information Amount (lithuanian):   {Entropy.GetInformationAmount(lithuanian, myName, 1)}");
Console.WriteLine($"Information Amount (ASCII):        {Entropy.GetInformationAmount(myNameASCII, myNameASCII, 1)}");
