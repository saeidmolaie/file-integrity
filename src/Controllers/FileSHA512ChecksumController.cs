namespace FileIntegrity;

internal class FileSHA512ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		return string.Empty;
	}
}