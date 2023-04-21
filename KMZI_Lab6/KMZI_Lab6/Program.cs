using KMZI_Lab6;

var enigma = new Enigma();
var message = "hello world".ToCharArray();

Console.WriteLine($"{enigma.Encrypt(message)}");    // qfuod brsqq