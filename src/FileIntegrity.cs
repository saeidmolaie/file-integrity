namespace FileIntegrity;

internal class FileIntegrity
{
	private static readonly
		Dictionary<ChecksumHashingMethod, Func<IFileChecksumController>>
			_checksumControllerFactoryMap = new()
			{
				{ ChecksumHashingMethod.MD5, () => new FileMD5ChecksumController() },
				{ ChecksumHashingMethod.SHA256, () => new FileSHA256ChecksumController() },
				{ ChecksumHashingMethod.SHA512, () => new FileSHA512ChecksumController() }
			};

	public static string ResolveChecksum(string filePath, ChecksumHashingMethod checksumHashingMethod)
	{
		var controller =
				ResolveController(checksumHashingMethod);

		return controller.ResolveChecksum(filePath);
	}

	public static bool ValidateChecksum(string filePath, string checksum, ChecksumHashingMethod checksumHashingMethod)
	{
		var controller =
				ResolveController(checksumHashingMethod);

		return controller.ValidateChecksum(filePath, checksum);
	}

	public static string ResolveChecksum(FileStream fileStream, ChecksumHashingMethod checksumHashingMethod)
	{
		var controller =
				ResolveController(checksumHashingMethod);

		return controller.ResolveChecksum(fileStream);
	}

	public static bool ValidateChecksum(FileStream fileStream, string checksum, ChecksumHashingMethod checksumHashingMethod)
	{
		var controller =
				ResolveController(checksumHashingMethod);

		return controller.ValidateChecksum(fileStream, checksum);
	}

	private static IFileChecksumController ResolveController(ChecksumHashingMethod method)
	{
		if (!_checksumControllerFactoryMap.TryGetValue(method, out var factory))
			throw new NotSupportedException(
				$"Hashing method {method} is not supported.");

		return factory();
	}
}