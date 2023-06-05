namespace YoinkContracts.Results
{
    public class ListFoldersResult : IListFoldersResult
    {
        public ListFoldersResult(IReadOnlyCollection<Folder> subfolders,
            IReadOnlyCollection<File> files,
            Folder? parent,
            IReadOnlyCollection<ResultMessage> messages)
        {
            Subfolders = subfolders;
            Files = files;
            Messages = messages;
        }
        public IReadOnlyCollection<Folder> Subfolders { get; }
        public IReadOnlyCollection<File> Files { get; }
        public IReadOnlyCollection<ResultMessage> Messages { get; }
    }
}