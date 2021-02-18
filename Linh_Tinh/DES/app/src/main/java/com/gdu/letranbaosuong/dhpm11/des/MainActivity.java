package com.gdu.letranbaosuong.dhpm11.des;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import static com.gdu.letranbaosuong.dhpm11.des.TrippleDes._decrypt;
import static com.gdu.letranbaosuong.dhpm11.des.TrippleDes._encrypt;

import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;

import android.util.Base64;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.spec.SecretKeySpec;

public class MainActivity extends AppCompatActivity {

    private EditText inputText, inputPassword;
    private TextView outputText;
    private Button encBtn, decBtn;
    private String outputString;
    private String DES = "DES";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        inputText = findViewById(R.id.inputText);
        inputPassword = findViewById(R.id.inputPassword);
        outputText = findViewById(R.id.outputText);
        encBtn = findViewById(R.id.encBtn);
        decBtn = findViewById(R.id.decBtn);

        encBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    outputString = _encrypt(inputText.getText().toString().trim(),
                            inputPassword.getText().toString().trim());

                    outputText.setText(outputString);
                } catch (Exception e) {
                    Toast.makeText(MainActivity.this,
                            e.getMessage(),
                            Toast.LENGTH_SHORT)
                            .show();
                }

///                Test thoi
//                String SECRET_KEY = "12345678";
//                SecretKeySpec skeySpec = new SecretKeySpec(SECRET_KEY.getBytes(), "DES");
//
//                String original = "stackjava.com";
//
//                Cipher cipher = null;
//                try {
//                    cipher = Cipher.getInstance("DES/ECB/PKCS5PADDING");
//                    cipher.init(Cipher.ENCRYPT_MODE, skeySpec);
//                    byte[] byteEncrypted = cipher.doFinal(original.getBytes());
//                    String encrypted = new String(Base64.encode(byteEncrypted, Base64.DEFAULT));
//
//                    cipher.init(Cipher.DECRYPT_MODE, skeySpec);
//                    byte[] byteDecrypted = cipher.doFinal(byteEncrypted);
//                    String decrypted = new String(byteDecrypted);
//
//                    System.out.println("original  text: " + original);
//                    System.out.println("encrypted text: " + encrypted);
//                    System.out.println("decrypted text: " + decrypted);
//                } catch (NoSuchAlgorithmException e) {
//                    e.printStackTrace();
//                } catch (NoSuchPaddingException e) {
//                    e.printStackTrace();
//                } catch (BadPaddingException e) {
//                    e.printStackTrace();
//                } catch (IllegalBlockSizeException e) {
//                    e.printStackTrace();
//                } catch (InvalidKeyException e) {
//                    e.printStackTrace();
//                }

            }
        });

        decBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    outputString = _decrypt(outputString,
                            inputPassword.getText().toString().trim());
                } catch (Exception e) {
                    Toast.makeText(MainActivity.this,
                            e.getMessage(),
                            Toast.LENGTH_SHORT)
                            .show();
                }
                outputText.setText(outputString);
            }
        });

    }
}
