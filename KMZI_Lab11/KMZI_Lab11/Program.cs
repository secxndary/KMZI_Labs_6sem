using KMZI_Lab11;
const string fileNameSHA1 = "hash_sha1.txt";
const string fileNameMD5  = "hash_md5.txt";

var opentext = CypherHelper.GetOpenText();
var hashSHA1 = SHA1Hash.GetSHA1Hash(opentext);
var hashMD5  = MD5Hash.GetMD5Hash(opentext);

CypherHelper.WriteToFile(hashSHA1, fileNameSHA1);
CypherHelper.WriteToFile(hashMD5, fileNameMD5);