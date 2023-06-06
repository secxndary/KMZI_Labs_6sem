using KMZI_Lab13;

var a = -1;
var b = 1;
var p = 751;

var xMin = 106;
var xMax = 140;


// Задание 1.1
var points = EC.GetPoints(xMin, xMax, a, b, p);
foreach (var point in points)
    Console.WriteLine($"x = {point.Item1}, y = {point.Item2}");

// Задание 1.2
