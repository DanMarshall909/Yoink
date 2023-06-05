using YoinkContracts.Results;

namespace YoinkTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task ListFolders_returns_subfolders()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult result = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        result.Subfolders.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_returns_files()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult result = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        result.Files.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_handles_invalid_paths_correctly()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult result = await fileSystemService.ListFolder("!@#$%^&*(", new FileFilter());

        result.IsSuccess.Should().BeFalse();
        result.Messages
            .Where(x => x.Severity == Severity.Error)
            .Should()
            .NotBeEmpty();
    }
}