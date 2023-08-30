using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionUtility
{
    static string Clave = "1Bt14$J&9n98whpV";

    public static string DecryptString(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(Clave);

            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            // Extraer el IV del texto cifrado (primeros 16 bytes)
            byte[] iv = new byte[aesAlg.IV.Length];
            Array.Copy(Convert.FromBase64String(cipherText), iv, iv.Length);
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Ignorar los primeros 16 bytes del texto cifrado (ya que son el IV)
            byte[] cipherBytes = new byte[Convert.FromBase64String(cipherText).Length - aesAlg.IV.Length];
            Array.Copy(Convert.FromBase64String(cipherText), aesAlg.IV.Length, cipherBytes, 0, cipherBytes.Length);

            using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    private static byte[] GenerateRandomIV()
    {
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            byte[] iv = new byte[16]; // Tamaño del IV (16 bytes para AES)
            rng.GetBytes(iv);
            return iv;
        }
    }
}




