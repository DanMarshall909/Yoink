
namespace YoinkContracts.Results
{
    public class ListFoldersResult : YoinkResult
    {
        public ListFoldersResult(
            IReadOnlyCollection<Folder> subfolders,
            IReadOnlyCollection<File> files,
            Folder? parent,
            IReadOnlyCollection<ResultMessage> messages)
        {
            this.Subfolders = subfolders;
            this.Files = files;
            this.Messages = messages;
        }

        public IReadOnlyCollection<Folder> Subfolders { get; }

        public IReadOnlyCollection<File> Files { get; }

        public new IReadOnlyCollection<ResultMessage> Messages { get; }
    }
}