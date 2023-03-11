namespace YoinkContracts.Results
{
    public class ListFoldersResult
    {
        public ListFoldersResult(YoinkFolder folder)
        {
            Folder = folder;
        }

        public YoinkFolder Folder { get; set; }
    }
}