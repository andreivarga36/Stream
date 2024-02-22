using Xunit;

namespace StreamApp
{
    public class MemoryStreamHandlerFacts
    {
        [Fact]
        public void Write_WriteTextInMemoryStream_ShouldReturnExpectedResult()
        {
            const string text = "inter milan";

            var streamHandler = new MemoryStreamHandler(new MemoryStream());
            streamHandler.Write(text);

            Assert.Equal(text, streamHandler.Read());
        }

        [Fact]
        public void Write_TwoTextsAreWrittenInTheSameStream_ShouldReturnExpectedResult()
        {
            string name = "gervonta";
            string surname = "davis";

            var streamHandler = new MemoryStreamHandler(new MemoryStream());
            streamHandler.Write(name);
            streamHandler.Write(surname);

            Assert.Equal(name + surname, streamHandler.Read());
        }

        [Fact]
        public void Write_TextIsCompressedButNotDecompressed_ShouldReturnExpectedResult()
        {
            const string text = "team";

            var streamHandler = new MemoryStreamHandler(new MemoryStream(), compression: true);
            streamHandler.Write(text);

            Assert.True(text != streamHandler.Read());
        }

        [Fact]
        public void Read_TextIsCompressed_ShouldReturnExpectedResult()
        {
            const string text = "food";
            var streamHandler = new MemoryStreamHandler(new MemoryStream(), compression: true, decompression: true);
            streamHandler.Write(text);

            Assert.Equal(text, streamHandler.Read());
        }

        [Fact]
        public void Write_TextIsCrypted_ShouldReturnExpectedResult()
        {
            const string text = "password";

            var streamHandler = new MemoryStreamHandler(new MemoryStream(), encryption: true, decryption: true);
            streamHandler.Write(text);

            Assert.Equal(text, streamHandler.Read());
        }

        [Fact]
        public void Write_TextIsCompressedAndCrypted_ShouldReturnExpectedResult()
        {
            const string text = "abcd";

            var streamHandler = new MemoryStreamHandler(
                new MemoryStream(), 
                compression: true, 
                encryption: true, 
                decompression: true, 
                decryption: true);
            streamHandler.Write(text);

            Assert.Equal(text, streamHandler.Read());
        }
    }
}