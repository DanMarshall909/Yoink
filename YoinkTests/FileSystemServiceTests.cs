using YoinkContracts.Responses;

namespace YoinkTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task ListFolders_returns_subfolders()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResponse response = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        response.Subfolders.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_returns_files()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResponse response = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        response.Files.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_handles_invalid_paths_correctly()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResponse response = await fileSystemService.ListFolder("!@#$%^&*(", new FileFilter());

        response.IsSuccess.Should().BeFalse();
        response.Messages
            .Where(x => x.Severity == Severity.Error)
            .Should()
            .NotBeEmpty();
    }
}