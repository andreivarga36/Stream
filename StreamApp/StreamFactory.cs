using System.IO.Compression;
using System.Security.Cryptography;

namespace StreamApp
{
    public static class StreamFactory
    {
        private static readonly Aes Aes = Aes.Create();

        public static Stream GetWriteStream(Stream stream, bool compression, bool encryption)
        {
            var writeStream = stream;

            if (compression)
            {
                writeStream = new GZipStream(writeStream, CompressionMode.Compress);
            }

            if (encryption)
            {
                writeStream = new CryptoStream(writeStream, Aes.CreateEncryptor(), CryptoStreamMode.Write);
            }

            return writeStream;
        }

        public static Stream GetReadStream(Stream stream, bool decompression, bool decryption)
        {
            var readStream = stream;

            if (decompression)
            {
                readStream = new GZipStream(readStream, CompressionMode.Decompress);
            }

            if (decryption)
            {
                readStream = new CryptoStream(readStream, Aes.CreateDecryptor(), CryptoStreamMode.Read);
            }

            return readStream;
        }
    }
}