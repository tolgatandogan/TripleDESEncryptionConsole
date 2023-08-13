using System.Security.Cryptography;
using System.Text;
using TripleDESEncryptionConsole.Utilities.Helper.Abstract;

public class EncryptionHelper : IEncryptionHelper
{
    private const string KEY = "TEST-KEY";

    /// <summary>
    /// This method uses the TripleDES algorithm to encrypt data.
    /// </summary>
    /// <param name="toEncrypt">Text to be encrypted.</param>
    /// <param name="useHashing">Whether to use hashing.</param>
    /// <returns>Encrypted text.</returns>
    public string Encrypt(string toEncrypt, bool useHashing = true)
    {
        if (string.IsNullOrEmpty(toEncrypt))
            return string.Empty;

        byte[] keyArray;
        byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

        if (useHashing)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();
        }
        else
            keyArray = Encoding.UTF8.GetBytes(KEY);

        var tdes = new TripleDESCryptoServiceProvider
        {
            Key = keyArray,
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };

        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    /// <summary>
    /// This method is used to decrypt data using the TripleDES algorithm.
    /// </summary>
    /// <param name="cipherString">Encrypted text.</param>
    /// <param name="useHashing">Whether to use hashing.</param>
    /// <returns>Decrypted text.</returns>
    public string Decrypt(string cipherString, bool useHashing = true)
    {
        if (string.IsNullOrEmpty(cipherString))
            return string.Empty;

        byte[] keyArray;

        byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        if (useHashing)
        {
            var hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();
        }
        else
        {
            keyArray = Encoding.UTF8.GetBytes(KEY);
        }

        var tdes = new TripleDESCryptoServiceProvider
        {
            Key = keyArray,
            Mode = CipherMode.ECB,
            Padding = PaddingMode.PKCS7
        };

        ICryptoTransform cTransform = tdes.CreateDecryptor();
        byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        tdes.Clear();
        return Encoding.UTF8.GetString(resultArray);
    }
}