using KMZI_Lab9;

var initialTerm = Cypher.GenerateRandomNumber(130);
int z = 6;
var sequence = Cypher.GenerateSuperIncreasingSequence(initialTerm, z);

Console.WriteLine("Super increasing sequence:");
foreach (var term in sequence)
{
    Console.WriteLine(term);
}