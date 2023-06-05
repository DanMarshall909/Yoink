
using YoinkContracts.Models;
using File = YoinkContracts.Models.File;

namespace YoinkContracts.Responses
{
    public class ListFoldersResponse : YoinkResponse
    {
        public ListFoldersResponse(
            IReadOnlyCollection<Folder> subfolders,
            IReadOnlyCollection<File> files)
        {
            Subfolders = subfolders;
            Files = files;
        }
        
        public static ListFoldersResponse From(Exception exception)
        {
            var result = new ListFoldersResponse(new List<Folder>(), new List<File>());
            result.AddError(exception);
            
            return result;
        }

        public IReadOnlyCollection<Folder> Subfolders { get; }

        public IReadOnlyCollection<File> Files { get; }
    }
}