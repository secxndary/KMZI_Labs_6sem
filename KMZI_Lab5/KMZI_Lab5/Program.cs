using KMZI_Lab5;
var fileNameOpen = "open_text.txt";
var fileNameEncryptRoute = "encrypt_route.txt";
var fileNameDecryptRoute = "decrypt_route.txt";
var fileNameEncryptMultiple = "encrypt_multiple.txt";
var fileNameDecryptMultiple = "decrypt_multiple.txt";
var rows = 66;
var cols = 66;


Swap.WriteToFile(Swap.EncryptRouteSwap(rows, cols), fileNameEncryptRoute);
Swap.WriteToFile(Swap.DecryptRouteSwap(rows, cols), fileNameDecryptRoute);
Console.WriteLine("----------------------------------------------");

Swap.WriteToFile(Swap.EncryptMultiple("Alexander", "Valdaitsev"), fileNameEncryptMultiple);
