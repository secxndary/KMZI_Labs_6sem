using KMZI_Lab5;
string  fileNameEncryptRoute = "encrypt_route.txt",
        fileNameDecryptRoute = "decrypt_route.txt",
        fileNameEncryptMultiple = "encrypt_multiple.txt",
        fileNameDecryptMultiple = "decrypt_multiple.txt";
var rows = 36;
var cols = 35;


var openText = Swap.GetOpenText();
var encryptRoute = Swap.EncryptRouteSwap(openText);
var decryptRoute = Swap.DecryptRouteSwap(encryptRoute, rows, cols);

Console.WriteLine($"Encrypt Route Swap:\t{Swap.WriteToFile(encryptRoute, fileNameEncryptRoute)}");
Console.WriteLine($"Decrypt Route Swap:\t{Swap.WriteToFile(decryptRoute, fileNameDecryptRoute)}");
Console.WriteLine("-------------------------------");

