namespace FileIntegrity;

internal abstract class FileChecksumController : IFileChecksumController
{
	public abstract string ResolveChecksum(string filePath);

	public bool ValidateChecksum(string filePath, string validChecksum)
		=> ResolveChecksum(filePath) == validChecksum;
}