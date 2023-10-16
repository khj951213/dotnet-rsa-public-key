using JK_RSA_PUB;

Console.WriteLine("RSA Encryption");

var rsa = new RSAEnc();
var cypher = string.Empty;
var plainText = string.Empty;

Console.WriteLine("Enter your text to encrypt");
var text = Console.ReadLine();
if (!string.IsNullOrEmpty(text))
{
    cypher = rsa.Encrypt(text);
    Console.WriteLine("Encrypted Text: " +  cypher);
    plainText = rsa.Decrypt(cypher);
    Console.WriteLine("Decrypted Text: " + plainText);
}