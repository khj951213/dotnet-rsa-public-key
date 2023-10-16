using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace JK_RSA_PUB
{
    public class RSAEnc
    {
        private static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;

        public RSAEnc()
        {
            _privateKey = csp.ExportParameters(true);
            _publicKey = csp.ExportParameters(false);
        }

        public string GetPublicKey()
        {
            var writer = new StringWriter();
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(writer, _publicKey);
            return writer.ToString();
        }

        public string Encrypt(string plainText)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);
            var data = Encoding.Unicode.GetBytes(plainText);
            var cypher = csp.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string cypherText)
        {
            var dataByts = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataByts, false);
            return Encoding.Unicode.GetString(plainText);
        }
    }
}