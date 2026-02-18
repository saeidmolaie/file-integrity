namespace FileIntegrity;

internal class FileSHA256ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		return string.Empty;
	}
}