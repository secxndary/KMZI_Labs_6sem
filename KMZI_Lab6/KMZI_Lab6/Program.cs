using KMZI_Lab6;

var enigma = new Enigma();
var enigma2 = new Enigma();
var message = "hello world".ToCharArray();
var message2 = "qfuod brsqq".ToCharArray();

Console.WriteLine($"{enigma.Encrypt(message)}");    // qfuod brsqq - v0.1 (but norm)
                                                    // qfuod brsga - gavno
Console.WriteLine($"{enigma2.Encrypt(message2)}");