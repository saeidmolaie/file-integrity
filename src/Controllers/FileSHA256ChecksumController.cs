namespace FileIntegrity;

internal class FileSHA256ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(string filePath)
	{
		return string.Empty;
	}
}