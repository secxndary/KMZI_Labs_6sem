using KMZI_Lab5;

var res = Swap.ConvertToTwoDimentionalArray(Swap.ReadFromFile());
var encrypt = Swap.EncryptRouteSwap(res);
foreach (var item in encrypt)
    Console.Write($"{item}");