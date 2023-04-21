namespace KMZI_Lab6;

public class Enigma
{
    const string alphabetOpen =  "abcdefghijklmnopqrstuvwxyz";
    static int length = alphabetOpen.Length;
    
    const string alphabetRigthRotor  =  "ajdksiruxblhwtmcqgznpyfvoe";
    const string alphabetMiddleRotor =  "bdfhjlcprtxvznyeiwgakmusqo";
    const string alphabetLeftRotor   =  "esovpzjayquirhxlnftgkdcmwb";

    static int rotorPositionRigth =  0;
    static int rotorPositionMiddle = 1;
    static int rotorPositionLeft  =  1;

    static int rotorOffsetRigth =  4;
    static int rotorOffsetMiddle = 1;
    static int rotorOffsetLeft  =  1;


    public static void Encrypt(char[] openText)
    {
        // берем букву текста
        var letter = openText[0];

        // 1. заменить на символ из правого ротора
        var letterAfterRigthRotor = EncryptWithRigthRotor(letter, rotorPositionRigth % length);

        // 2. заменить на символ из среднего ротора (првоерить поворот предыдущего, если был круг, то на 1 символ)
        var letterAfterMiddleRotor = EncryptWithMiddleRotor(letterAfterRigthRotor, rotorPositionMiddle % length);

        // 3. заменить на символ из левого ротора (првоерить поворот среднего, если был круг, то на 1 символ)
        var letterAfterLeftRotor = EncryptWithLeftRotor(letterAfterMiddleRotor, rotorPositionLeft % length);



        // 4. подставить символ из рефлектора
        // 5. заменить на символ левого ротора
        // 6. заменить на символ среднего ротора
        // 7. заменить на символ правого ротора




        // 1.1. повернуть ротор на 4 символа
        rotorPositionRigth += rotorOffsetRigth;

        // 1.2. изменить позиции среднего и левого роторов      // TODO: refactor
        rotorPositionMiddle = rotorPositionRigth / length;
        rotorPositionLeft = rotorPositionMiddle / length;

    }



    // тут просто замена одного символа на другой с учетом сдвига ротора 
    public static char EncryptWithRigthRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetRigthRotor[indexEncrypted];
        return letterEncrypted;
    }

    // средний ротор
    public static char EncryptWithMiddleRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetMiddleRotor[indexEncrypted];
        return letterEncrypted;
    }

    // левый ротор
    public static char EncryptWithLeftRotor(char letter, int offset)
    {
        var index = alphabetOpen.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetLeftRotor[indexEncrypted];
        return letterEncrypted;
    }
}
