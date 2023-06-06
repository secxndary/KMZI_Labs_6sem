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

int[] P = { 106, 24 };
int[] Q = { 130, 14 };
int[] R = EC.Sum(P, Q, p);

int[] kP = EC.Multiply(k, P, a, p);
int[] lQ = EC.Multiply(l, Q, a, p);

Console.WriteLine($"P = {EC.Format(P)}\nQ = {EC.Format(Q)}");
Console.WriteLine($"а) kP = {k}P = {EC.Format(kP)}");
Console.WriteLine($"б) P + Q = R = {EC.Format(EC.Sum(P, Q, p))}");
Console.WriteLine($"в) kP + lQ - R = {EC.Format(EC.Sum(EC.Sum(kP, lQ, p), EC.InversePoint(R), p))}");
Console.WriteLine($"г) P - Q + R = {EC.Format(EC.Sum(EC.Sum(P, EC.InversePoint(Q), p), R, p))}");