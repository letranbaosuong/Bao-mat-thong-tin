package com.gdu.letranbaosuong.dhpm11.mahoadongian.GiaiThuat;

public abstract class CommonProcess
{
    public abstract String EncryptionStart(String text, String key, boolean IsTextBinary);
    public abstract String DecryptionStart(String text, String key, boolean IsTextBinary);
}
