using System.Security.Cryptography;
using System.Text;

namespace FileIntegrity;

internal class FileSHA512ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		ArgumentNullException.ThrowIfNull(stream);

		if (stream.CanSeek)
			stream.Position = 0;

		using var sha512 = SHA512.Create();
		var hashBytes = sha512.ComputeHash(stream);

		var stringBuilder = new StringBuilder(hashBytes.Length * 2);

		foreach (var bytes in hashBytes)
		{
			stringBuilder.Append(bytes.ToString("x2"));
		}

		return stringBuilder.ToString();
	}
}