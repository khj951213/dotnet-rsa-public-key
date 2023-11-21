using OpenSSL

namespace JD_OpenSSL
{
    public class GenKeyPair
    {
        private readonly int _keySize;
        private readonly string privateKeyPemPath;
        private readonly string publicKeyPemPath;
        public GenKeyPair(int keySize, string privateKeyPemPath, string publicKeyPemPath)
        {
            _keySize = keySize;
            this.privateKeyPemPath = privateKeyPemPath;
            this.publicKeyPemPath = publicKeyPemPath;
        }

       public string Gen()
        {
            using var key = CryptoKey
        }


    }
}
