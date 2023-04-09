using KMZI_Lab4;
var fileNameDecrypt = "decrypt_text.txt";

Console.WriteLine($"Text Encryption:\t{Cypher.WriteToFile(Cypher.EncryptMonoAlphabet())}");
Console.WriteLine($"Text Decryption:\t{Cypher.WriteToFile(Cypher.DecryptMonoAlphabet(), fileNameDecrypt)}");