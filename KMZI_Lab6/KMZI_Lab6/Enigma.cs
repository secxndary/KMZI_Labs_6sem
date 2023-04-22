namespace KMZI_Lab6;

public class Enigma
{
    // октрытые данные
    const string alphabetOpen =  "abcdefghijklmnopqrstuvwxyz";
    Dictionary<char, char> alphabetReflector;
    int length = alphabetOpen.Length;
    
    // алфавиты для роторов
    string alphabetRightRotor  =  "ajdksiruxblhwtmcqgznpyfvoe";
    string alphabetMiddleRotor =  "bdfhjlcprtxvznyeiwgakmusqo";
    string alphabetLeftRotor   =  "esovpzjayquirhxlnftgkdcmwb";

    // текущая позиция ротора (0-25)
    int rotorRightCurrentPostition =  0;
    int rotorMiddleCurrentPostition = 0;
    int rotorLeftCurrentPostition  =  0;

    // общее количество смещений ротора за все время
    // (т.е. на сколько шагов в общем сдвинулся)
    int rotorRightTotalOffsets =  0;
    int rotorMiddleTotalOffsets = 0;
    int rotorLeftTotalOffsets  =  0;

    // количество полных оборотов роторов
    int rotorRightFullRotations =  0;
    int rotorMiddleFullRotations = 0;
    int rotorLeftFullRotations  =  0;

    // шаги смещения роторов
    int rotorRightStep =  4;
    int rotorMiddleStep = 1;
    int rotorLeftStep  =  1;

    public Enigma(int rightRotorPosition, int middleRotorPosition, int leftRotorPosition) 
    {
        if (rightRotorPosition >= 0  && rightRotorPosition  < length &&
            middleRotorPosition >= 0 && middleRotorPosition < length &&
            leftRotorPosition  >= 0  && leftRotorPosition  <  length)
        {
            rotorRightCurrentPostition =  rightRotorPosition;
            rotorMiddleCurrentPostition = middleRotorPosition;
            rotorLeftCurrentPostition  =  leftRotorPosition;
        }
        else
        {
            throw new Exception($"Rotors positions must be between 0 and {length - 1}");
        }
        alphabetReflector = FillTheRelector(); 
    }



    public char[] Encrypt(char[] openText)
    {
        // если роторы установлены в ненулевую стартовую позицию,
        // то необходимо принять общее кол-во сдвигов
        // равным текущей позиции (нужно для вычислений ниже)
        rotorRightTotalOffsets = rotorRightCurrentPostition;
        rotorMiddleTotalOffsets = rotorMiddleCurrentPostition;
        rotorLeftTotalOffsets = rotorLeftCurrentPostition;
        var sb = new System.Text.StringBuilder();


        foreach (char letter in openText)
        {
            if (alphabetOpen.Contains(letter))
            {
                // 1. заменить на символ из правого ротора
                var letterAfterRightRotor = EncryptWithRotor(letter, alphabetOpen, alphabetRightRotor, rotorRightCurrentPostition);

                // 2. заменить на символ из среднего ротора
                var letterAfterMiddleRotor = EncryptWithRotor(letterAfterRightRotor, alphabetOpen, alphabetMiddleRotor, rotorMiddleCurrentPostition);

                // 3. заменить на символ из левого ротора
                var letterAfterLeftRotor = EncryptWithRotor(letterAfterMiddleRotor, alphabetOpen, alphabetLeftRotor, rotorLeftCurrentPostition);

                // 4. подставить символ из рефлектора
                var letterAfterReflector = EncryptWithReflector(letterAfterLeftRotor);

                // 5. заменить на символ левого ротора в обратном порядке
                var letterAfterLeftRotorBackwards = EncryptWithRotor(letterAfterReflector, alphabetLeftRotor, alphabetOpen, rotorLeftCurrentPostition);

                // 6. заменить на символ среднего ротора в обратном порядке
                var letterAfterMiddleRotorBackwards = EncryptWithRotor(letterAfterLeftRotorBackwards, alphabetMiddleRotor, alphabetOpen, rotorMiddleCurrentPostition);

                // 7. заменить на символ правого ротора в обратном порядке
                var letterAfterRightRotorBackwards = EncryptWithRotor(letterAfterMiddleRotorBackwards, alphabetRightRotor, alphabetOpen, rotorRightCurrentPostition);

                // 8. сместить правый ротор
                rotorRightTotalOffsets += rotorRightStep;
                rotorRightCurrentPostition = rotorRightTotalOffsets % length;   // смещаем правый ротор

                // 9. сместить средний и левый роторы
                if (rotorRightTotalOffsets / length > 0)    // если правый ротор уже сделал 1 оборот или более
                {
                    rotorRightFullRotations = rotorRightTotalOffsets / length;   // кол-во полных оборотов правого ротора
                    rotorMiddleTotalOffsets = rotorRightFullRotations * rotorMiddleStep;   // общее кол-во смещений среднего ротора
                    rotorMiddleCurrentPostition = rotorMiddleTotalOffsets % length;     // текущая позиция среднего ротора
                }
                if (rotorMiddleTotalOffsets / length > 0)    // если средний ротор сделал 1 оборот или более
                {
                    rotorMiddleFullRotations = rotorMiddleTotalOffsets / length;    // кол-во полных оборотов среднего ротора
                    rotorLeftTotalOffsets = rotorMiddleFullRotations * rotorLeftStep;  // общее кол-во смещений левого ротора
                    rotorLeftCurrentPostition = rotorLeftTotalOffsets % length;     // текущая позиция левого ротора
                }
                if (rotorLeftTotalOffsets / length > 0)     // если левый ротор сделал 1 оборот или более
                {
                    rotorLeftFullRotations = rotorLeftTotalOffsets / length;    // кол-во полных оборотов левого ротора
                }

                // 10. записать символ в итоговую строку
                sb.Append(letterAfterRightRotorBackwards);
            }
            else
                sb.Append(letter);
        }
        return sb.ToString().ToCharArray();   
    }



    // аналогичный метод для расшифрования, изменяется только
    // EncryptWithRotor() -> DecryptWithRotor()
    public char[] Decrypt(char[] openText)
    {
        rotorRightTotalOffsets = rotorRightCurrentPostition;
        rotorMiddleTotalOffsets = rotorMiddleCurrentPostition;
        rotorLeftTotalOffsets = rotorLeftCurrentPostition;
        var sb = new System.Text.StringBuilder();

        foreach (char letter in openText)
        {
            if (alphabetOpen.Contains(letter))
            {
                var letterAfterRightRotor = DecryptWithRotor(letter, alphabetOpen, alphabetRightRotor, rotorRightCurrentPostition);
                var letterAfterMiddleRotor = DecryptWithRotor(letterAfterRightRotor, alphabetOpen, alphabetMiddleRotor, rotorMiddleCurrentPostition);
                var letterAfterLeftRotor = DecryptWithRotor(letterAfterMiddleRotor, alphabetOpen, alphabetLeftRotor, rotorLeftCurrentPostition);
                var letterAfterReflector = EncryptWithReflector(letterAfterLeftRotor);
                var letterAfterLeftRotorBackwards = DecryptWithRotor(letterAfterReflector, alphabetLeftRotor, alphabetOpen, rotorLeftCurrentPostition);
                var letterAfterMiddleRotorBackwards = DecryptWithRotor(letterAfterLeftRotorBackwards, alphabetMiddleRotor, alphabetOpen, rotorMiddleCurrentPostition);
                var letterAfterRightRotorBackwards = DecryptWithRotor(letterAfterMiddleRotorBackwards, alphabetRightRotor, alphabetOpen, rotorRightCurrentPostition);

                rotorRightTotalOffsets += rotorRightStep;
                rotorRightCurrentPostition = rotorRightTotalOffsets % length;

                if (rotorRightTotalOffsets / length > 0)  
                {
                    rotorRightFullRotations = rotorRightTotalOffsets / length; 
                    rotorMiddleTotalOffsets = rotorRightFullRotations * rotorMiddleStep; 
                    rotorMiddleCurrentPostition = rotorMiddleTotalOffsets % length; 
                }
                if (rotorMiddleTotalOffsets / length > 0)  
                {
                    rotorMiddleFullRotations = rotorMiddleTotalOffsets / length; 
                    rotorLeftTotalOffsets = rotorMiddleFullRotations * rotorLeftStep;
                    rotorLeftCurrentPostition = rotorLeftTotalOffsets % length;
                }
                if (rotorLeftTotalOffsets / length > 0)
                {
                    rotorLeftFullRotations = rotorLeftTotalOffsets / length; 
                }

                sb.Append(letterAfterRightRotorBackwards);
            }
            else
                sb.Append(letter);
        }
        return sb.ToString().ToCharArray();
    }




    // зашифровать поворотом ротора
    private char EncryptWithRotor(char letter, string alphabet, string alphabetEncryption, int offset)
    {
        var index = alphabet.IndexOf(letter);
        var indexEncrypted = (index + offset) % length;
        var letterEncrypted = alphabetEncryption[indexEncrypted];
        return letterEncrypted;
    }


    // дешифровать поворотом ротора
    private char DecryptWithRotor(char letter, string alphabet, string alphabetEncryption, int offset)
    {
        var index = alphabet.IndexOf(letter);
        var indexEncrypted = (index - offset + length) % length;
        var letterEncrypted = alphabetEncryption[indexEncrypted];
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


    // заполнить рефлектор
    private Dictionary<char, char> FillTheRelector() => new Dictionary<char, char> 
    { 
        { 'a', 'r' }, { 'b', 'd' }, { 'c', 'o' }, { 'e', 'j' }, { 'f', 'n' },
        { 'g', 't' }, { 'h', 'k' }, { 'i', 'v' }, { 'l', 'm' }, { 'p', 'w' },
        { 'q', 'z' }, { 's', 'x' }, { 'u', 'y' }
    };
}
