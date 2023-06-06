using KMZI_Lab13;

var a = -1;
var b = 1;
var p = 751;



// Задание 1.1
var xMin = 106;
var xMax = 140;

var points = EC.GetPoints(xMin, xMax, a, b, p);
foreach (var point in points)
    Console.WriteLine($"x = {point.Item1}, y = {point.Item2}");
Console.WriteLine("\n\n");



// Задание 1.2
var k = 9;
var l = 7;

int[] P = { 74, 170 };
int[] Q = { 53, 277 };
int[] R = { 86, 25 };

int[] kP = EC.Multiply(k, P, a, p);
int[] lQ = EC.Multiply(l, Q, a, p);

Console.WriteLine($"а) kP = {k}P = {EC.FormatPoint(kP)}");
Console.WriteLine($"б) P + Q = {EC.FormatPoint(EC.CalculateSum(P, Q, p))}");