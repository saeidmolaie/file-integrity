namespace FileIntegrity;

internal class FileMD5ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(string filePath)
	{
		return string.Empty;
	}
}