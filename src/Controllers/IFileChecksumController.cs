namespace FileIntegrity;

internal interface IFileChecksumController
{
	string ResolveChecksum(FileStream fileStream);

	bool ValidateChecksum(FileStream fileStream, string validChecksum);

	string ResolveChecksum(string filePath);

	bool ValidateChecksum(string filePath, string validChecksum);
}