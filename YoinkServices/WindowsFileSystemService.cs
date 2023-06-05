using YoinkContracts.Models;
using YoinkContracts.Responses;
using File = YoinkContracts.Models.File;

namespace YoinkServices
{
    public class WindowsFileSystemService : IFileSystemService
    {
        public Task<ListFoldersResponse> ListFolder(string path, FileFilter filter)
        {
            try
            {
                DirectoryInfo di = new(path);
                List<File> files = di.GetFiles()
                    .Select(fi => new File(new WindowsFilePath { FullName = fi.FullName }))
                    .ToList();
                var baseFolderPath = new WindowsFolderPath(di);
                var baseFolder = new Folder(baseFolderPath, null);
                var subfolders = GetSubfolders(di: di, baseFolder: baseFolder).ToList();
                
                return Task.FromResult(new ListFoldersResponse(subfolders, files));
            }
            catch (Exception e)
            {
                return Task.FromResult(ListFoldersResponse.From(e));
            }
        }

        private static IEnumerable<Folder> GetSubfolders(DirectoryInfo di, Folder baseFolder)
        {
            IEnumerable<Folder> subfolders = di.GetDirectories()
                .Select(subDirectory =>
                {
                    var windowsFolderPath = new WindowsFolderPath(new DirectoryInfo(subDirectory.FullName));
                    var parentFolder = baseFolder;
                    return new Folder(windowsFolderPath, parentFolder);
                });
            return subfolders;
        }

        public FileInfo GetFileInfo(string path) => new(path);
    }
}