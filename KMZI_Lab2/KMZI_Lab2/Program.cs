using KMZI_Lab2;

const string pathToFolder = "../../../Alphabets";
var pathKyrgyz = $"{pathToFolder}/kyrgyz.txt";
var pathLithuanian = $"{pathToFolder}/lithuanian.txt";
var pathBinary = $"{pathToFolder}/binary.txt";

var textKyrgyz = "";
var textLithuanian = "";
var textBinary = "";

using (StreamReader sr = new StreamReader(pathKyrgyz)) { textKyrgyz = sr.ReadToEnd().ToLower(); }
using (StreamReader sr = new StreamReader(pathLithuanian)) { textLithuanian = sr.ReadToEnd().ToLower(); }
using (StreamReader sr = new StreamReader(pathBinary)) { textBinary = sr.ReadToEnd().ToLower(); }


Console.WriteLine("Entropy of kyrgyz language:      " + Entropy.GetShannonEntropy(textKyrgyz));
Console.WriteLine("Entropy of lithuanian language:  " + Entropy.GetShannonEntropy(textLithuanian));
Console.WriteLine("Entropy of binary language:      " + Entropy.GetShannonEntropy(textBinary));