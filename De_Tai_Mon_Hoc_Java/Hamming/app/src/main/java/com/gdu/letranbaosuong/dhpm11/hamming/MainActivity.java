package com.gdu.letranbaosuong.dhpm11.hamming;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.content.DialogInterface;
import android.content.Entity;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.pdf.PdfDocument;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

@RequiresApi(api = Build.VERSION_CODES.KITKAT)
public class MainActivity extends AppCompatActivity {
    private Button btnTinhToan;
    private EditText txtAHexStr, txtBHexStr;
    private String txtABinStr, txtATrongSo, txtBBinStr, txtBTrongSo, txtAxorBHexStr, txtAxorBBinStr, txtKhoangCach;
    private Bitmap bmp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        AnhXa();
        CapQuyen();
        XuLy();
        TinhToan();
    }

    private void TinhToan() {
        btnTinhToan.setOnClickListener(new View.OnClickListener() {
            @RequiresApi(api = Build.VERSION_CODES.KITKAT)
            @Override
            public void onClick(View v) {
                XuLyTinhToan();
            }
        });
    }

    private void XuLyTinhToan() {
        txtABinStr = HexStrToBinStr(txtAHexStr.getText().toString().trim());
        txtATrongSo = String.valueOf(BinStrToTrongSoHamming(txtABinStr));
        txtBBinStr = HexStrToBinStr(txtBHexStr.getText().toString().trim());
        txtBTrongSo = String.valueOf(BinStrToTrongSoHamming(txtBBinStr));
        txtAxorBHexStr = HexStrXorHexStr(txtAHexStr.getText().toString().trim(), txtBHexStr.getText().toString().trim());
        txtAxorBBinStr = HexStrToBinStr(txtAxorBHexStr);
        int TrongSoAxorB = BinStrToTrongSoHamming(txtAxorBBinStr);
        int KhoangCachHammingAvaB = BinStrKhoangCachHamming(txtABinStr, txtBBinStr);
        txtKhoangCach = String.valueOf(KhoangCachHammingAvaB);
        if (TrongSoAxorB == KhoangCachHammingAvaB) {
            CreatePDF();
            OpenDialog("Chương trình Hamming tính đúng trọng số và khoảng cách");
        } else {
            OpenDialog("Chương trình bị lỗi sai");
        }
    }

    private void OpenDialog(String s) {
//        MyDialog myDialog = new MyDialog();
//        myDialog.show(getSupportFragmentManager(), "example dialog");

        new AlertDialog.Builder(MainActivity.this)
                .setTitle("Bài toán Hamming")
                .setMessage(s)
                .setCancelable(false)
                .setPositiveButton("ok", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                    }
                }).show();
    }

    private void XuLy() {
        txtAHexStr.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                btnTinhToan.setEnabled(HexStrHopLe(txtAHexStr.getText().toString().trim()) && HexStrHopLe(txtBHexStr.getText().toString().trim()));
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

        txtBHexStr.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                btnTinhToan.setEnabled(HexStrHopLe(txtAHexStr.getText().toString().trim()) && HexStrHopLe(txtBHexStr.getText().toString().trim()));
            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });
    }

    private void AnhXa() {
        btnTinhToan = findViewById(R.id.btnTinhToan);
        txtAHexStr = findViewById(R.id.txtAHexStr);
        txtBHexStr = findViewById(R.id.txtBHexStr);
        bmp= BitmapFactory.decodeResource(getResources(),R.drawable.axorb);
    }

    private void CapQuyen() {
        ActivityCompat.requestPermissions(MainActivity.this
                , new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}
                , PackageManager.PERMISSION_GRANTED);
    }

    private void CreatePDF() {

        PdfDocument myPdfDocument = new PdfDocument();
        Paint myPaint = new Paint();

        PdfDocument.PageInfo myPageInfo = new PdfDocument.PageInfo.Builder(250, 400, 1).create();
        PdfDocument.Page myPage = myPdfDocument.startPage(myPageInfo);
        Canvas canvas = myPage.getCanvas();
        canvas.drawText("Lê Trần Bảo Sương - Trang 1", 40, 50, myPaint);
        myPdfDocument.finishPage(myPage);

        PdfDocument.PageInfo myPageInfo1 = new PdfDocument.PageInfo.Builder(250, 400, 1).create();
        PdfDocument.Page myPage1 = myPdfDocument.startPage(myPageInfo1);
        Canvas canvas1 = myPage1.getCanvas();
        canvas1.drawText("Lê Trần Bảo Sương - Trần Nguyên Vẹn 2", 40, 50, myPaint);
        myPdfDocument.finishPage(myPage1);

        File file = new File(Environment.getExternalStorageDirectory(), "/TenTuiPDF.pdf");

        try {
            myPdfDocument.writeTo(new FileOutputStream(file));
        } catch (IOException e) {
            e.printStackTrace();
        }

        myPdfDocument.close();
    }

    private boolean HexHopLe(char c) {
        return ((c >= '0' && c <= '9') || (c > 'A') || (c <= 'F'));
    }

    private boolean HexStrHopLe(String s) {
        if (s.length() != 16) return false;
        for (int i = 0; i < s.length(); i++)
            if (!HexHopLe(s.charAt(i))) return false;
        return true;
    }

    private int HexToInt(char c) {
        return (c < 'A') ? c - 48 : c - 55;
    }

    private char IntToHex(int n) {
        return (n <= 9) ? (char) (n + 48) : (char) (n + 55); // 0 -> 9 : 10 -> 15
    }

    private String HexToBinStr(char c) {
        int n = HexToInt(c);
        String s = "";
        for (int i = 0; i < 4; i++) {
            String d = (n % 2 == 1) ? "1" : "0";
            s = d + s; // them ben trai
            n /= 2; // chu phai bien mat
            // bit tu phai sang trai
        }
        return s;
    }

    private String HexStrToBinStr(String s) {
        String kq = "";
        for (int i = 0; i < s.length(); i++)
            kq += HexToBinStr(s.charAt(i)); // them vao ben phai
        return kq;
    }

    private char HexXorHex(char c1, char c2) {
        int n1 = HexToInt(c1);
        int n2 = HexToInt(c2);
        return IntToHex(n1 ^ n2); // ^ là Bitwise XOR
    }

    private String HexStrXorHexStr(String s1, String s2) {
        String s = "";
        for (int i = 0; i < s1.length(); i++)
            s += HexXorHex(s1.charAt(i), s2.charAt(i));
        return s;
    }

    private int BinStrToTrongSoHamming(String s) {
        // Trọng số của dãy số nhị phân (so 1)
        int count = 0;
        for (int i = 0; i < s.length(); i++)
            if (s.charAt(i) == '1') count++;
        return count;
    }

    private int BinStrKhoangCachHamming(String s1, String s2) {
        // Khoảng cách Hamming giữa hai dãy nhị phân
        int count = 0;
        for (int i = 0; i < s1.length(); i++)
            if (s1.charAt(i) != s2.charAt(i)) count++;
        return count;
    }
}
