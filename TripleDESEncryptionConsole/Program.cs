namespace TripleDESEncryptionConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create an instance of the EncryptionHelper class
            EncryptionHelper encryptionHelper = new EncryptionHelper();

            Console.WriteLine("TripleDES Encryption and Decryption Example");

            // Get text to be encrypted from the user
            Console.Write("Enter text to encrypt: ");
            string originalText = Console.ReadLine();

            // Encrypt the text
            string encryptedText = encryptionHelper.Encrypt(originalText);

            // Display the encrypted text
            Console.WriteLine("Encrypted Text: " + encryptedText);

            // Get encrypted text to be decrypted from the user
            Console.Write("Enter encrypted text to decrypt: ");
            string encryptedInput = Console.ReadLine();

            // Decrypt the encrypted text
            string decryptedText = encryptionHelper.Decrypt(encryptedInput);

            // Display the decrypted text
            Console.WriteLine("Decrypted Text: " + decryptedText);
        }
    }
}