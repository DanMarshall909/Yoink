using YoinkContracts.Results;

namespace YoinkServices.Interfaces;

public interface IFileSystemService
{
    public Task<ListFoldersResult> ListFolder(string path, FileFilter filter);
    public FileInfo GetFileInfo(string path);
}