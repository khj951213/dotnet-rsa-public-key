using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System.Security.Cryptography;
using System.Text;

namespace JK_RSA_PUB
{
    public class RSAManEnc
    {

        public string Encrypt(string publicKey, string plainText)
        {
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                var pkcs1Encoding = new Pkcs1Encoding(new RsaEngine());
                using (StringReader reader = new StringReader(publicKey))
                {
                    AsymmetricKeyParameter parameters = (AsymmetricKeyParameter) new PemReader(reader).ReadObject();
                    pkcs1Encoding.Init(true, parameters);
                }
                return Convert.ToBase64String(pkcs1Encoding.ProcessBlock(bytes, 0, bytes.Length));
            }
        }

    }
}
