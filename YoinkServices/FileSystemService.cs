using System.Reflection.Metadata.Ecma335;
using YoinkContracts.Models;
using YoinkContracts.Results;

namespace YoinkServices
{
    public class FileSystemService : IFileSystemService
    {
        public async Task<ListFoldersResult> ListFoldersAsync()
        {
            return new ListFoldersResult(new YoinkFolder(YoinkFolder.BaseFolder, new List<YoinkFile>()));
        }
    }
}