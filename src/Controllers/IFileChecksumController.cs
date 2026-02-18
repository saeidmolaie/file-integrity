namespace FileIntegrity;

internal interface IFileChecksumController
{
	string ResolveChecksum(string filePath);

	bool ValidateChecksum(string filePath, string validChecksum);
}