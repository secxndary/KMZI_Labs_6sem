using KMZI_Lab6;

try
{
    var fileNameEncrypt = "encrypt_enigma.txt";
    var fileNameDecrypt = "decrypt_enigma.txt";

    var enigmaEncrypt = new Enigma(0, 0, 0);
    var enigmaDecrypt = new Enigma(0, 0, 0);
    var openMessage = EnigmaHelper.GetOpenText();


    var encryptedMessage = enigmaEncrypt.Encrypt(openMessage);
    Console.WriteLine($"Encrypt Enigma:\t{EnigmaHelper.WriteToFile(encryptedMessage, fileNameEncrypt)}");
    
    var decryptedMessage = enigmaDecrypt.Decrypt(encryptedMessage);
    Console.WriteLine($"Decrypt Enigma:\t{EnigmaHelper.WriteToFile(decryptedMessage, fileNameDecrypt)}");
}
catch (Exception ex)
{
    Console.WriteLine($"[ERROR] {ex.Message}");
}