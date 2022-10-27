namespace YoinkTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task ListFolders_Should_DisplayRoot_WhenNoPathIsProvidedAsync()
    {
        IFileSystemService fileSystemService = new FileSystemService();
        var folders = await fileSystemService.ListFoldersAsync();

        folders.CurrentFolder.Name.Should().Be(YoinkFolder.BaseFolder);
    }
}