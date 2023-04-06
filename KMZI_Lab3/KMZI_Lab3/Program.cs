using KMZI_Lab3;
const ulong m = 421;
const ulong n = 457;

Console.WriteLine($"НОД ({m}, {n}) = {Modular.GetGCD(m, n)}");
Console.WriteLine($"НОД (4, 8, 32) = {Modular.GetGCD(4, Modular.GetGCD(32, 8))}");

Console.WriteLine($"\nПростые числа от 2 до {n} ({Modular.GetPrimesCount(n)} чисел):");
foreach (var item in Modular.GetPrimes(n))
    Console.Write($"{item} ");

Console.WriteLine($"\n\nПростые числа от {m} до {n} ({Modular.GetPrimesCount(m, n)} чисел):");
foreach (var item in Modular.GetPrimes(m, n))
    Console.Write($"{item} ");

Console.WriteLine($"\n\n{n} / ln({n}) = {Modular.GetApproximatePrimesCount(n)}");