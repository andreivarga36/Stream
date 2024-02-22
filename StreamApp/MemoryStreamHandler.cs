using System.Security.Cryptography;

namespace StreamApp
{
    public class MemoryStreamHandler
    {
        private readonly Stream stream;
        private readonly bool compression;
        private readonly bool encryption;
        private readonly bool decompression;
        private readonly bool decryption;

        public MemoryStreamHandler(Stream stream, bool compression = false, bool encryption = false, bool decompression = false, bool decryption = false)
        {
            this.stream = stream;
            this.compression = compression;
            this.encryption = encryption;
            this.decompression = decompression;
            this.decryption = decryption;
        }

        public void Write(string text)
        {
            var writeStream = StreamFactory.GetWriteStream(stream, compression, encryption);

            using var streamWriter = new StreamWriter(writeStream, leaveOpen: true);
            streamWriter.Write(text);
            streamWriter.Flush();

            if (writeStream is not CryptoStream crypto)
            {
                return;
            }

            crypto.FlushFinalBlock();
        }

        public string Read()
        {
            var readStream = StreamFactory.GetReadStream(stream, decompression, decryption);
            stream.Seek(0, SeekOrigin.Begin);

            using var streamReader = new StreamReader(readStream, leaveOpen: true);
            return streamReader.ReadToEnd();
        }
    }
}
