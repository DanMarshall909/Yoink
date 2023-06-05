using YoinkContracts.Results;

namespace YoinkTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task ListFolders_returns_subfolders()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult folders = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        folders.Subfolders.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_returns_files()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult folders = await fileSystemService.ListFolder("C:\\", new FileFilter());
        
        folders.Files.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task ListFolders_handles_invalid_paths_correctly()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();
        ListFoldersResult folders = await fileSystemService.ListFolder("!@#$%^&*(", new FileFilter());
        
        folders.Files.Should().NotBeEmpty();
    }
}