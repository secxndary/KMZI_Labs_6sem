using KMZI_Lab4;
var fileNameEncryptMonoalphabet = "encrypt_monoalphabet.txt";
var fileNameDecryptMonoalphabet = "decrypt_monoalphabet.txt";
var fileNameEncryptTrithemius = "encrypt_trithemius.txt";
var fileNameDecryptTrithemius = "decrypt_trithemius.txt";


Cypher.WriteToFile(Cypher.EncryptMonoAlphabet(), fileNameEncryptMonoalphabet);
Cypher.WriteToFile(Cypher.DecryptMonoAlphabet(), fileNameDecryptMonoalphabet);

Console.WriteLine("----------------------------------------------");

Cypher.WriteToFile(Cypher.EncryptTrithemius("enigma"), fileNameEncryptTrithemius);
Cypher.WriteToFile(Cypher.DecryptTrithemius("enigma"), fileNameDecryptTrithemius);