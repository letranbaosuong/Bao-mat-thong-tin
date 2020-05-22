package com.gdu.letranbaosuong.dhpm11.des;

import android.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.spec.SecretKeySpec;

public class Des {
    public static String ALGO = "DES/ECB/PKCS5PADDING";

    public static String _encrypt(String message, String secretKey) throws Exception {
        Cipher cipher = Cipher.getInstance(ALGO);
        cipher.init(Cipher.ENCRYPT_MODE, getSecreteKey(secretKey));
        byte[] byteEncrypted = cipher.doFinal(message.getBytes("UTF-8"));
        String encrypted = new String(Base64.encode(byteEncrypted, Base64.DEFAULT));
        return encrypted;
    }

    public static String _decrypt(String encryptedText, String secretKey) throws Exception {
        Cipher cipher = Cipher.getInstance(ALGO);
        cipher.init(Cipher.DECRYPT_MODE, getSecreteKey(secretKey));
        byte[] byteDecrypted = cipher.doFinal(Base64.decode(encryptedText, Base64.DEFAULT));
        String decrypted = new String(byteDecrypted);
        return decrypted;
    }

    public static SecretKeySpec getSecreteKey(String secretKey) {
        SecretKeySpec skeySpec = new SecretKeySpec(secretKey.getBytes(), "DES");
        return skeySpec;
    }

}
