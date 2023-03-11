using YoinkContracts.Results;

namespace YoinkServices.Interfaces;

public interface IFileSystemService
{
    public Task<ListFoldersResult> ListFolderAsync();
}