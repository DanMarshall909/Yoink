using YoinkContracts.Responses;

namespace YoinkServices.Interfaces;

public interface IFileSystemService
{
    public Task<ListFoldersResponse> ListFolder(string path, FileFilter filter);
    public FileInfo GetFileInfo(string path);
}