namespace FileIntegrity;

internal class FileMD5ChecksumController : FileChecksumController
{
	public override string ResolveChecksum(FileStream stream)
	{
		return string.Empty;
	}
}