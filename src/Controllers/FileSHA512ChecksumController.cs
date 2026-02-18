namespace FileIntegrity;

internal class FileSHA512ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(string filePath)
	{
		return string.Empty;
	}
}