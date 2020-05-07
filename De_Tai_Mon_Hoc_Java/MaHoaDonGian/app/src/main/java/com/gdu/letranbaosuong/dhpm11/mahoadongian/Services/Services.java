package com.gdu.letranbaosuong.dhpm11.mahoadongian.Services;

public class Services {
    public static String padRight(String original, int padToLength) {
        return padRight(original, padToLength, '0');
    }

    public static String padRight(String original, int padToLength, char padWith) {
        if (original.length() >= padToLength) {
            return original;
        }
        StringBuilder sb = new StringBuilder(padToLength);
        sb.append(original);
        for (int i = original.length(); i < padToLength; ++i) {
            sb.append(padWith);
        }
        return sb.toString();
    }

    public static String trimEnd(String s, String suffix) {

        if (s.endsWith(suffix)) {

            return s.substring(0, s.length() - suffix.length());

        }
        return s;
    }
}
