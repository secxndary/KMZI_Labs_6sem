package by.valdaitsevv;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.KeyGenerator;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.DESKeySpec;
import java.io.*;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;


class Program {
    public static void main(String[] args) throws IOException, NoSuchAlgorithmException, InvalidKeyException, InvalidKeySpecException, NoSuchPaddingException, IllegalBlockSizeException, BadPaddingException {
        //String we want to encrypt
        String message = "hello world hello world hello world hello world hello world hello world hello world";
        byte[] myMessage = message.getBytes(); //string to byte array as DES works on bytes

        //If you want to use your own key
        SecretKeyFactory MyKeyFactory = SecretKeyFactory.getInstance("DES");
        DESKeySpec myMaterial = new DESKeySpec(DES.weakKey2);
        SecretKey myDesKey = MyKeyFactory.generateSecret(myMaterial);

        //Generating Key
        KeyGenerator myGenerator = KeyGenerator.getInstance("DES");
//         SecretKey myDesKey = myGenerator.generateKey();


        //initializing crypto algorithm
        Cipher myCipher = Cipher.getInstance("DES");

        //setting encryption mode
        myCipher.init(Cipher.ENCRYPT_MODE, myDesKey);
        byte[] myEncryptedBytes = myCipher.doFinal(myMessage);


        //setting decryption mode
        myCipher.init(Cipher.DECRYPT_MODE, myDesKey);
        byte[] myDecryptedBytes = myCipher.doFinal(myEncryptedBytes);

        //print message in byte format
        //System.out.println(Arrays.toString(myEncryptedBytes));
        //System.out.println(Arrays.toString(myDecryptedBytes));

        String encryptedData = new String(myEncryptedBytes);
        String decryptedData = new String(myDecryptedBytes);

        System.out.println("Message:\t\t\t" + message);
        System.out.println("Encrypted:\t\t\t" + encryptedData);
        System.out.println("Decrypted:\t\t\t" + decryptedData);
        System.out.println("Avalanche Effect:\t" + DES.GetAvalancheEffect(myMessage, myEncryptedBytes) + " bits changed");
        System.out.println("Total bits:\t\t\t" + myEncryptedBytes.length * 8 + " bits");
    }
}
