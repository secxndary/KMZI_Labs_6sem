using System.Text;

namespace KMZI_Lab6;

public class Enigma
{
    const string alphabetOpen =  "abcdefghijklmnopqrstuvwxyz";
    Dictionary<char, char> alphabetReflector = FillTheRelector();
    int length = alphabetOpen.Length;
    
    string alphabetRightRotor  =  "ajdksiruxblhwtmcqgznpyfvoe";
    string alphabetMiddleRotor =  "bdfhjlcprtxvznyeiwgakmusqo";
    string alphabetLeftRotor   =  "esovpzjayquirhxlnftgkdcmwb";

    int rotorPositionRight =  0;
    int rotorPositionMiddle = 0;
    int rotorPositionLeft  =  0;

    int rotorOffsetRight =  4;
    //int rotorOffsetMiddle = 1;
    //int rotorOffsetLeft  =  1;


    public string Encrypt(char[] openText)
    {
        var sb = new StringBuilder();

        foreach (char letter in openText)
        {
            if (alphabetOpen.Contains(letter))
            {
                // 1. заменить на символ из правого ротора
                var letterAfterRightRotor = EncryptWithRightRotor(letter, rotorPositionRight % length);

                // 2. заменить на символ из среднего ротора (првоерить поворот предыдущего, если был круг, то на 1 символ)
                var letterAfterMiddleRotor = EncryptWithMiddleRotor(letterAfterRightRotor, rotorPositionMiddle % length);

                // 3. заменить на символ из левого ротора (првоерить поворот среднего, если был круг, то на 1 символ)
                var letterAfterLeftRotor = EncryptWithLeftRotor(letterAfterMiddleRotor, rotorPositionLeft % length);

                // 4. подставить символ из рефлектора
                var letterAfterReflector = EncryptWithReflector(letterAfterLeftRotor);

                // 5. заменить на символ левого ротора в обратном порядке
                var letterAfterLeftRotorBackwards = EncryptWithLeftRotorBackwards(letterAfterReflector, rotorPositionLeft % length);

                // 6. заменить на символ среднего ротора в обратном порядке
                var letterAfterMiddleRotorBackwards = EncryptWithMiddleRotorBackwards(letterAfterLeftRotorBackwards, rotorPositionMiddle % length);

                // 7. заменить на символ правого ротора в обратном порядке
                var letterAfterRightRotorBackwards = EncryptWithRightRotorBackwards(letterAfterMiddleRotorBackwards, rotorPositionRight % length);

                // 8. повернуть ротор на 4 символа
                rotorPositionRight += rotorOffsetRight;

                // 9. изменить позиции среднего и левого роторов      // TODO: refactor
                rotorPositionMiddle = rotorPositionRight / length;
                rotorPositionLeft = rotorPositionMiddle / length;

                // 10. записать символ в итоговую строку
                sb.Append(letterAfterRightRotorBackwards);
            }
            else
                sb.Append(letter);
        }
        return sb.ToString();   
    }



    // тут просто замена одного символа на другой с учетом сдвига ротора 
    private char EncryptWithRightRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetRightRotor[indexEncrypted];
        return letterEncrypted;
    }

    // средний ротор
    private char EncryptWithMiddleRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetMiddleRotor[indexEncrypted];
        return letterEncrypted;
    }

    // левый ротор
    private char EncryptWithLeftRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetLeftRotor[indexEncrypted];
        return letterEncrypted;
    }

    // зашифровать с рефлектором
    private char EncryptWithReflector(char letter)
    {
        if (alphabetReflector.ContainsKey(letter))
            return alphabetReflector[letter];
        else if (alphabetReflector.ContainsValue(letter))
            return alphabetReflector.FirstOrDefault(x => x.Value == letter).Key;
        else
            return letter;
    }

    // левый ротор в обратном порядке
    private char EncryptWithLeftRotorBackwards(char letter, int offset)
    {
        var index = alphabetLeftRotor.IndexOf(letter);
        var indexDecrypted = (index + offset) % length;
        var letterDecrypted = alphabetOpen[indexDecrypted];
        return letterDecrypted;
    }

    // средний ротор в обратном порядке
    private char EncryptWithMiddleRotorBackwards(char letter, int offset)
    {
        var index = alphabetMiddleRotor.IndexOf(letter);
        var indexDecrypted = (index + offset) % length;
        var letterDecrypted = alphabetOpen[indexDecrypted];
        return letterDecrypted;
    }

    // правый ротор в обратном порядке
    private char EncryptWithRightRotorBackwards(char letter, int offset)
    {
        var index = alphabetRightRotor.IndexOf(letter);
        var indexDecrypted = (index + offset) % length;
        var letterDecrypted = alphabetOpen[indexDecrypted];
        return letterDecrypted;
    }



    // заполнить рефлектор
    private Dictionary<char, char> FillTheRelector() => new Dictionary<char, char> 
    { 
        { 'a', 'r' }, { 'b', 'd' }, { 'c', 'o' }, { 'e', 'j' }, { 'f', 'n' },
        { 'g', 't' }, { 'h', 'k' }, { 'i', 'v' }, { 'l', 'm' }, { 'p', 'w' },
        { 'q', 'z' }, { 's', 'x' }, { 'u', 'y' }
    };
}
