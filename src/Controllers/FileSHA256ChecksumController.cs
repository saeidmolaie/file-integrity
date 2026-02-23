using System.Security.Cryptography;
using System.Text;

namespace FileIntegrity;

internal class FileSHA256ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		ArgumentNullException.ThrowIfNull(stream);

		if (!stream.CanRead)
			throw new ArgumentException(
				"Stream must be readable.", nameof(stream));

		if (stream.CanSeek)
			stream.Position = 0;

		using var sha256 = SHA256.Create();
		var hashBytes = sha256.ComputeHash(stream);

		var stringBuilder = new StringBuilder(hashBytes.Length * 2);

		foreach (var bytes in hashBytes)
		{
			stringBuilder.Append(bytes.ToString("x2"));
		}

		return stringBuilder.ToString();
	}
}