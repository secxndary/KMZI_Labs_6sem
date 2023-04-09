using KMZI_Lab4;
var fileNameEncryptMonoalphabet = "encrypt_monoalphabet.txt";
var fileNameDecryptMonoalphabet = "decrypt_monoalphabet.txt";
var fileNameEncryptTrithemius = "encrypt_trithemius.txt";
var fileNameDecryptTrithemius = "decrypt_trithemius.txt";


Console.WriteLine($"Encryption Monoalphabet:\t{Cypher.WriteToFile(Cypher.EncryptMonoAlphabet(), fileNameEncryptMonoalphabet)}");
Console.WriteLine($"Decryption Monoalphabet:\t{Cypher.WriteToFile(Cypher.DecryptMonoAlphabet(), fileNameDecryptMonoalphabet)}\n");

Console.WriteLine($"Encryption Trithemius table:\t{Cypher.WriteToFile(Cypher.EncryptTrithemius("qwerty"), fileNameEncryptTrithemius)}");
Console.WriteLine($"Encryption Trithemius table:\t{Cypher.WriteToFile(Cypher.DecryptTrithemius("qwerty"), fileNameDecryptTrithemius)}");