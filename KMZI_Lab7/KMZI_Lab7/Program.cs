﻿using KMZI_Lab7;

var fileNameEncrypt = "encrypt_eee2.txt";
var fileNameDecrypt = "decrypt_eee2.txt";
var firstKey  = CypherHelper.GetBytes("my1stKey");
var secondKey = CypherHelper.GetBytes("my2ndKey");
var plainText = CypherHelper.GetOpenText();


var encryptedText = Cypher.EncryptEEE2(plainText, firstKey, secondKey);
CypherHelper.WriteToFile(encryptedText, fileNameEncrypt);

var decryptedText = Cypher.DecryptEEE2(encryptedText, firstKey, secondKey);
CypherHelper.WriteToFile(decryptedText, fileNameDecrypt);