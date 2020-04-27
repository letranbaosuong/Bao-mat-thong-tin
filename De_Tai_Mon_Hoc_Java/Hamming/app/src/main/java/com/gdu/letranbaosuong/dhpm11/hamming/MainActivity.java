package com.gdu.letranbaosuong.dhpm11.hamming;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.content.DialogInterface;
import android.content.Entity;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.graphics.Typeface;
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
import java.lang.reflect.Type;

@RequiresApi(api = Build.VERSION_CODES.KITKAT)
public class MainActivity extends AppCompatActivity {
    private Button btnTinhToan;
    private EditText txtAHexStr, txtBHexStr;
    private String txtABinStr, txtATrongSo, txtBBinStr, txtBTrongSo, txtAxorBHexStr, txtAxorBBinStr, txtKhoangCach;
    private Bitmap bmp, scaleBitmap;
    private int pageWidth = 1200;

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
        OpenDialog(TrongSoAxorB == KhoangCachHammingAvaB);
    }

    private void OpenDialog(boolean kiemTra) {
//        MyDialog myDialog = new MyDialog();
//        myDialog.show(getSupportFragmentManager(), "example dialog");

        if (kiemTra) {
            CreatePDF();
            new AlertDialog.Builder(MainActivity.this)
                    .setTitle("Bài toán Hamming")
                    .setMessage("Chương trình Hamming tính đúng trọng số và khoảng cách")
                    .setCancelable(false)
                    .setPositiveButton("Xem", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            Intent intent = new Intent(MainActivity.this, ViewPDFActivity.class);
                            startActivity(intent);
                        }
                    }).show();
        } else {
            new AlertDialog.Builder(MainActivity.this)
                    .setTitle("Bài toán Hamming")
                    .setMessage("Chương trình bị lỗi sai")
                    .setCancelable(false)
                    .setPositiveButton("Đóng", new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {

                        }
                    }).show();
        }
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
        bmp = BitmapFactory.decodeResource(getResources(), R.drawable.axorb);
        scaleBitmap = Bitmap.createScaledBitmap(bmp, 50, 30, false);
    }

    private void CapQuyen() {
        ActivityCompat.requestPermissions(MainActivity.this
                , new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}
                , PackageManager.PERMISSION_GRANTED);
    }

    private void CreatePDF() {

        PdfDocument myPdfDocument = new PdfDocument();
        Paint myPaint = new Paint();
        Paint titlePaint = new Paint();

        PdfDocument.PageInfo myPageInfo = new PdfDocument.PageInfo.Builder(pageWidth, 2010, 1).create();
        PdfDocument.Page myPage = myPdfDocument.startPage(myPageInfo);
        Canvas canvas = myPage.getCanvas();

        // Title
        titlePaint.setTextAlign(Paint.Align.CENTER);
        titlePaint.setTypeface(Typeface.create(Typeface.DEFAULT, Typeface.BOLD_ITALIC));
        titlePaint.setTextSize(70);
        canvas.drawText("Hamming", pageWidth / 2, 270, titlePaint);

        // Row - khung - title
//        myPaint.setStyle(Paint.Style.STROKE);
//        myPaint.setStrokeWidth(2);
        myPaint.setColor(Color.RED);
        canvas.drawRect(20, 300, pageWidth - 20, 340, myPaint);

        // Row - title
        myPaint.setTextAlign(Paint.Align.LEFT);
        myPaint.setStyle(Paint.Style.FILL);
        myPaint.setTextSize(20);
        myPaint.setColor(Color.WHITE);
        canvas.drawText("16 ký số Hex", 40, 330, myPaint);
        canvas.drawText("Số Hexadecimal", 200, 330, myPaint);
        canvas.drawText("Số nhị phân", 400, 330, myPaint);
        canvas.drawText("Trọng số Hamming", 1000, 330, myPaint);

        myPaint.setStyle(Paint.Style.STROKE);
        myPaint.setStrokeWidth(2);
        myPaint.setColor(Color.BLACK);
        canvas.drawLine(20, 300, pageWidth - 20, 300, myPaint);
        canvas.drawLine(20, 300, 20, 340, myPaint);
        canvas.drawLine(180, 300, 180, 340, myPaint);
        canvas.drawLine(380, 300, 380, 340, myPaint);
        canvas.drawLine(980, 300, 980, 340, myPaint);
        canvas.drawLine(pageWidth - 20, 300, pageWidth - 20, 340, myPaint);

        // Row - khung - A
        myPaint.setStyle(Paint.Style.STROKE);
        myPaint.setStrokeWidth(2);
        canvas.drawRect(20, 340, pageWidth - 20, 380, myPaint);

        // Row - A
        myPaint.setTextAlign(Paint.Align.LEFT);
        myPaint.setStyle(Paint.Style.FILL);
        myPaint.setTextSize(16);
        canvas.drawText("A", 40, 370, myPaint);
        canvas.drawText(txtAHexStr.getText().toString().trim(), 200, 370, myPaint);
        canvas.drawText(txtABinStr, 400, 370, myPaint);
        canvas.drawText(txtATrongSo, 1000, 370, myPaint);

        canvas.drawLine(180, 340, 180, 380, myPaint);
        canvas.drawLine(380, 340, 380, 380, myPaint);
        canvas.drawLine(980, 340, 980, 380, myPaint);

        // Row - khung - B
        myPaint.setStyle(Paint.Style.STROKE);
        myPaint.setStrokeWidth(2);
        canvas.drawRect(20, 380, pageWidth - 20, 420, myPaint);

        // Row - B
        myPaint.setTextAlign(Paint.Align.LEFT);
        myPaint.setStyle(Paint.Style.FILL);
        myPaint.setTextSize(16);
        canvas.drawText("B", 40, 410, myPaint);
        canvas.drawText(txtBHexStr.getText().toString().trim(), 200, 410, myPaint);
        canvas.drawText(txtBBinStr, 400, 410, myPaint);
        canvas.drawText(txtBTrongSo, 1000, 410, myPaint);

        canvas.drawLine(180, 380, 180, 420, myPaint);
        canvas.drawLine(380, 380, 380, 420, myPaint);
        canvas.drawLine(980, 380, 980, 420, myPaint);

        // Row - khung - khoang cach hamming
//        myPaint.setStyle(Paint.Style.STROKE);
//        myPaint.setStrokeWidth(2);
        myPaint.setColor(Color.GREEN);
        canvas.drawRect(20, 420, pageWidth - 20, 460, myPaint);

        // Row - khoang cach hamming
        myPaint.setTextAlign(Paint.Align.LEFT);
        myPaint.setStyle(Paint.Style.FILL);
        myPaint.setTextSize(16);
        myPaint.setColor(Color.BLUE);
        canvas.drawText("Khoảng cách Hamming", 1000, 450, myPaint);

        myPaint.setColor(Color.GREEN);
        canvas.drawLine(980, 420, 980, 460, myPaint);

        // Row - khung - AxorB
        myPaint.setStyle(Paint.Style.STROKE);
        myPaint.setStrokeWidth(2);
        myPaint.setColor(Color.BLACK);
        canvas.drawRect(20, 460, pageWidth - 20, 500, myPaint);

        // Row - AxorB
        myPaint.setTextAlign(Paint.Align.LEFT);
        myPaint.setStyle(Paint.Style.FILL);
        myPaint.setTextSize(16);
        canvas.drawBitmap(scaleBitmap, 40, 465, myPaint);
        canvas.drawText(txtAxorBHexStr, 200, 490, myPaint);
        canvas.drawText(txtAxorBBinStr, 400, 490, myPaint);
        canvas.drawText(txtKhoangCach, 1000, 490, myPaint);

        canvas.drawLine(180, 460, 180, 500, myPaint);
        canvas.drawLine(380, 460, 380, 500, myPaint);
        canvas.drawLine(980, 460, 980, 500, myPaint);

        myPdfDocument.finishPage(myPage);
        File file = new File(Environment.getExternalStorageDirectory(), "/Hamming.pdf");

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
