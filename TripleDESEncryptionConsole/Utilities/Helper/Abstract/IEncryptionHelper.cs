namespace TripleDESEncryptionConsole.Utilities.Helper.Abstract
{
    public interface IEncryptionHelper
    {
        string Encrypt(string toEncrypt, bool useHashing = true);

        string Decrypt(string cipherString, bool useHashing = true);
    }
}