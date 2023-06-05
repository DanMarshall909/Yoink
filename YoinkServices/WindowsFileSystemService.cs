using Serilog;
using YoinkContracts.Results;
using File = YoinkContracts.Results.File;

namespace YoinkServices
{
    public class WindowsFileSystemService : IFileSystemService
    {
        public Task<ListFoldersResult> ListFolder(string path, FileFilter filter)
        {
            try
            {
                DirectoryInfo di = new(path);
                List<File> files = di.GetFiles()
                    .Select(x => new File(new WindowsFilePath { FullName = x.FullName }))
                    .ToList();
                var baseFolderPath = new WindowsFolderPath(di);
                var baseFolder = new Folder(baseFolderPath, null);
                var subfolders = GetSubfolders(di: di, baseFolder: baseFolder).ToList();
                
                return Task.FromResult(new ListFoldersResult(subfolders, files,
                    new Folder(baseFolderPath,
                        null), new List<ResultMessage>()));
            }
            catch (Exception e)
            {
                var messages = new List<ResultMessage>();
                messages.Add(new ResultMessage(e));
                Log.Error(e, "Error while listing folder");
                return Task.FromResult(new ListFoldersResult(new List<Folder>(), new List<File>(), null, messages));
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