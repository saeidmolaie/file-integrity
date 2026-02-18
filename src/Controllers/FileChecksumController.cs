namespace FileIntegrity;

internal abstract class FileChecksumController : IFileChecksumController
{
	public abstract string ResolveChecksum(FileStream stream);

	public bool ValidateChecksum(FileStream fileStream, string validChecksum)
	{
		return ResolveChecksum(fileStream) == validChecksum;
	}

	public string ResolveChecksum(string filePath)
	{
		ValidateFile(filePath);

		using var fileStream = File.OpenRead(filePath);

		return ResolveChecksum(fileStream);
	}

	public bool ValidateChecksum(string filePath, string validChecksum)
	{
		ValidateFile(filePath);

		using var fileStream = File.OpenRead(filePath);

		return ResolveChecksum(fileStream) == validChecksum;
	}

	private static void ValidateFile(string filePath)
	{
		if (string.IsNullOrWhiteSpace(filePath))
			throw new ArgumentNullException(nameof(filePath));

		if (!File.Exists(filePath))
			throw new FileNotFoundException("File not found.", filePath);
	}
}