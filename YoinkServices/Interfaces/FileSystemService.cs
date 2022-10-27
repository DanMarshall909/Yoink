using YoinkContracts.Results;

namespace YoinkServices.Interfaces
{
    public interface IFileSystemService
    {
        Task<ListFoldersResult> ListFoldersAsync();
    }
}