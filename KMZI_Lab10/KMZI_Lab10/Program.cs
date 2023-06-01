using System.Security.Cryptography;
using KMZI_Lab10;

const string fileNameEncryptRSA = "encrypt_rsa.txt";
//const string fileNameDecryptRSA = "decrypt_rsa.txt";
//const string fileNameEncryptElGamal = "encrypt_el_gamal.txt";
//const string fileNameDecryptElGamal = "decrypt_el_gamal.txt";

var openText = CypherHelper.GetOpenText();
RSAParameters publicKey;
RSAParameters privateKey;


using (var rsa = new RSACryptoServiceProvider())
{
    publicKey = rsa.ExportParameters(false);
    privateKey = rsa.ExportParameters(true);
}


var encryptedText = RSACypher.Encrypt(openText, publicKey);
CypherHelper.WriteToFile(encryptedText, fileNameEncryptRSA);