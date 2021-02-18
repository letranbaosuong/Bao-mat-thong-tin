package com.gdu.letranbaosuong.dhpm11.androidnotifications;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;

public class MainActivity extends AppCompatActivity {

    //1.Notification Channel
    //2.Notification Builder
    //3.Notification Manager

    private static final String CHANNEL_ID="suong_codeing";
    private static final String CHANNEL_Name="Suong Codeing";
    private static final String CHANNEL_DESC="Suong Codeing";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }
}