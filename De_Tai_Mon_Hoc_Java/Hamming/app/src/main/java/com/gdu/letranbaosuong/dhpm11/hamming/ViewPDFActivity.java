package com.gdu.letranbaosuong.dhpm11.hamming;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;

import com.github.barteksc.pdfviewer.PDFView;

import java.io.File;

public class ViewPDFActivity extends AppCompatActivity {
    private PDFView pdfView;
    private File file;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_pdf);
        pdfView = findViewById(R.id.pdfView);
        file = new File("/sdcard/Hamming.pdf");
        pdfView.fromFile(file)
                .enableSwipe(true)
                .swipeHorizontal(false)
                .enableDoubletap(true)
                .enableAntialiasing(true)
                .load();
    }
}
