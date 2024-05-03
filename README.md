# Stream

  - **MemoryStreamHandler** is a utility class designed to handle read and write operations on streams with optional compression and encryption functionalities. This class provides flexibility in managing memory streams by allowing users to apply compression and encryption to the data being written and decompression and decryption to the data being read.

## Note:

  - **Compression** and **Encryption** can be enabled or disabled by passing the respective boolean parameters to the constructor.
  - For writing, if compression or encryption is enabled, the data will be processed accordingly before being written to the stream.
  - For reading, if decompression or decryption is enabled, the data will be processed accordingly after being read from the stream.

### Technologies and Tools Used:

  - **C#**: The primary programming language for implementing the MemoryStreamHandler class.
  - **System.Security.Cryptography**: The namespace used for cryptographic operations.
  - **System.IO.Compression**: The namespace used for compression and decompression operations.

#### Documentation:

- [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream?view=net-8.0)
