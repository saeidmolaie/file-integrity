namespace FileIntegrity;

internal class FileMD5ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		stream.Seek(0, SeekOrigin.Begin);

		using var md5 = System.Security.Cryptography.MD5.Create();

		int bytesRead;
		long bytesProcessed = 0;

		var buffer = new byte[8192];
		var totalBytes = stream.Length;

		while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
		{
			bytesProcessed += bytesRead;

			if (bytesProcessed == totalBytes)
			{
				md5.TransformFinalBlock(buffer, 0, bytesRead);
			}
			else
			{
				md5.TransformBlock(buffer, 0, bytesRead, buffer, 0);
			}
		}

		var hashBytes = md5.Hash;

		return hashBytes == null
			? throw new Exception("Unable to generate MD5 hash!")
			: Convert.ToHexStringLower(hashBytes);
	}
}