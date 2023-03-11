namespace YoinkTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task ListFolders_should_return_root_when_no_path_is_provided()
    {
        IFileSystemService fileSystemService = new FileSystemService();
        var folders = await fileSystemService.ListFolderAsync();

        folders.Folder.Name.Should().Be(YoinkFolder.BaseFolder);
    }
}