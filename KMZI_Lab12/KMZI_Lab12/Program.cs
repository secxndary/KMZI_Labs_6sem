using System.Numerics;
using KMZI_Lab12;

const string fileNameSignatureRSA = "signature_rsa.txt";
const string fileNameSignatureElGamal = "signature_elgamal.txt";
const string fileNameSignatureSchnorr = "signature_schnorr.txt";
var openText = CypherHelper.GetOpenText();



// Генерация и верификация ЭЦП на основе алгоритма RSA
byte[] rsaPublicKey;
byte[] rsaPrivateKey;

RSACypher.GenerateRSAKeys(out rsaPublicKey, out rsaPrivateKey);
byte[] rsaSignature = RSACypher.CreateRSASignature(openText, rsaPrivateKey);
bool rsaIsValid = RSACypher.VerifyRSASignature(openText, rsaSignature, rsaPublicKey);

CypherHelper.WriteToFile(rsaSignature, fileNameSignatureRSA);
Console.WriteLine("Is valid signature RSA:\t\t" + rsaIsValid);




// Генерация и верификация ЭЦП на основе алгоритма Эль-Гамаля
int p = 2137;  
int g = 2127; 
int x = 1116; 
int k = 7; 
int H = 2119;

byte[] signatureElGamal = ElGamalCypher.GenerateElGamalSignature(p, g, x, k, H);
int y = (int)BigInteger.ModPow(g, x, p);
bool isVerified = ElGamalCypher.VerifyElGamalSignature(p, g, y, H, signatureElGamal);

CypherHelper.WriteToFile(signatureElGamal, fileNameSignatureElGamal);
Console.WriteLine("Is valid signature El-Gamal:\t" + isVerified);





// Генерация и верификация ЭЦП на основе алгоритма Шнорра
byte[] schnorrPublicKey;
byte[] schnorrPrivateKey;

SchnorrCypher.GenerateSchnorrKeys(out schnorrPublicKey, out schnorrPrivateKey);
byte[] signatureSchnorr = SchnorrCypher.CreateSchnorrSignature(openText, schnorrPrivateKey);
bool schnorrIsValid = SchnorrCypher.VerifySchnorrSignature(openText, signatureSchnorr, schnorrPublicKey);

CypherHelper.WriteToFile(signatureSchnorr, fileNameSignatureSchnorr);
Console.WriteLine("Is valid signature Schnorr:\t" + schnorrIsValid);