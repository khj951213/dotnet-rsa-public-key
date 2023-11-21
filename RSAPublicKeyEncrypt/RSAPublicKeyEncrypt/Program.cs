//using JK_RSA_PUB;

//Console.WriteLine("RSA Encryption");

//var rsa = new RSAEnc();
//var cypher = string.Empty;
//var plainText = string.Empty;
//Console.WriteLine("PUB Key: " + rsa.GetPublicKey());
//Console.WriteLine("Enter your text to encrypt");
//var text = Console.ReadLine();
//if (!string.IsNullOrEmpty(text))
//{
//    cypher = rsa.Encrypt(text);
//    Console.WriteLine("Encrypted Text: " + cypher);
//    plainText = rsa.Decrypt(cypher);
//    Console.WriteLine("Decrypted Text: " + plainText);
//    var newRSA = new RSAEnc();
//    Console.WriteLine("New Decrypted Text: " + newRSA.Decrypt(cypher));
//}

//var c = "WCfIZvjgtQM2OOnzggzIb2ZMjvZxBaigMWtehhefPdm+4wG0+7wloM1DsLMxq8xaAJhVlh2G9uOcIj/TKuiEsMsOyHhIlxpGC9Aj2wFwHEfLruxGPwj1DwH8qUj+bisXbW+pYpCedm+9EKhlQ0A+KZsUTvqItVzy4zzAETfXls2mJSZDrub8hWcZlzW4P6qVsiwJr/qQLWeEawGeDIZmYlRch4W3i9F2RQ7V0nxUQbySW6MA1oopnRs4ND9qmQCJN/iFifarDrgSCTjG/hI2kDHeGZRVQ2PjrRtqymkV+m465PSI6Gu000EY+uzQmOPLq8jU9GVihvdTubizVFQ3XQ==";

//var c2 = new RSAEnc();
//Console.WriteLine(c2.Decrypt(c));

//var enc = new RSAManEnc();
//var file = File.ReadAllText("public_key.pem");
//var e = enc.Encrypt(@"-----BEGIN PUBLIC KEY-----
//MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlUCQZso6P43gKqw0CfTl
//wYb3N+m4v6IME4nPA3WXe52wFpDM/JCFWSdXa7BewlwzDYjblgwL4u59CPxNTPTh
//7LTD4xXOaGDJHjX5+YgqK4fb9rsImjMpIACrND/LAdrq5mctWWzw3UtW3F+o+sNw
//IZM8n65ysS+Vhq9IypFlfuQbWrKjAcWZ3u1iLtplzyf/pjhOEyyZiBUnh6D219+p
//MiE9nhCpc4xkH1gnlGszIDBqZMMULtGJvFXydA1vv5HxxCYJ2ydEzmAKYxVgA9BG
//XPEGE89dQbeJsieTj+FSsp9oTm+4vi345opRvH8DWhmZc4OPSwBEL8pwgS7cUnKP
//twIDAQAB
//-----END PUBLIC KEY-----", "test");
//Console.WriteLine(e);


//This is the public key
using Org.BouncyCastle.Crypto;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;

string publicKey = "<RSAKeyValue><Modulus>uznzVPilsR1rWPkpq6m6IALaafDnVZTDDcnEyBD3A/PBx2JZTKM0DTgiTDDwCEmQBNBpPILcIBdtg3aSUgicair+2ksYrVFT+uiy0Zy1nU6qoJ+SsapLKrpCa1zHpV4LMO/pFo4Foqzw0C1FNe56FXo1xj77GPgeYl0MHUVtAUc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

//This is the private and public key.
String privateKey = "<RSAKeyValue><Modulus>uznzVPilsR1rWPkpq6m6IALaafDnVZTDDcnEyBD3A/PBx2JZTKM0DTgiTDDwCEmQBNBpPILcIBdtg3aSUgicair+2ksYrVFT+uiy0Zy1nU6qoJ+SsapLKrpCa1zHpV4LMO/pFo4Foqzw0C1FNe56FXo1xj77GPgeYl0MHUVtAUc=</Modulus><Exponent>AQAB</Exponent><P>+jPKs9JxpCSzNY+YNanz49Eo/A6RaU1DZWoFm/bawffZOompeL1jzpUlJUIrKVZJkNFvlxE90uXVwjxWBLv9BD==</P><Q>v5CVWKZ5Wo7W0QyoEOQS/OD8tkKS9DjzZnbnuo6lhcMaxsBrCWLstac1Xm2oFNtZgLtrPGbPfCNC5Su4Rz/P5w==</Q><DP>ZnyikmgobqEt20m3gnvcUDxT+nOJMsYYTklQhONoFj4M+EJ9bdy+Lle/gHSLM4KJ3c08VXgVh/bnSYnnfkb20Q==</DP><DQ>sSYGRfWk0W64Dpfyr7QKLxnr+Kv186zawU2CG44gWWNEVrnIAeUeWxnmi41CWw9BZH9sum2kv/pnuT/F6PWEzw==</DQ><InverseQ>XpWZQKXa1IXhF4FX3XRXVZGnIQP8YJFJlSiYx6YcdZF24Hg3+Et6CZ2/rowMFYVy+o999Y5HDC+4Qa1yWvW1vA==</InverseQ><D>Kkfb+8RrJqROKbma/3lE3xXNNQ7CL0F5CxQVrGcN8DxL9orvVdyjlJiopiwnCLgUHgIywceLjnO854Q/Zucq6ysm2ZRq36dpGLOao9eg+Qe8pYYO70oOkEe1HJCtP1Laq+f3YK7vCq7GkgvKAI9uzOd1vjQv7tIwTIADK19ObgE=</D></RSAKeyValue>";

//Encrypting the text using the public key
RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
cipher.FromXmlString(publicKey);
byte[] data = Encoding.UTF8.GetBytes("abcd");
byte[] cipherText = cipher.Encrypt(data, false);
var cipherTextBase64 = Convert.ToBase64String(cipherText);

//    decryptText();

//Trying to decrypt the text using the private key

cipher = new RSACryptoServiceProvider();
cipher.FromXmlString(privateKey);

byte[] ciphterText = Convert.FromBase64String(cipherTextBase64);
byte[] plainText = cipher.Decrypt(ciphterText, false);
var decryptBase64String = Convert.ToBase64String(plainText);
var decryptString = Convert.ToString(plainText);

Console.WriteLine(decryptBase64String);
Console.WriteLine(decryptString);