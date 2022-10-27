namespace YoinkContracts.Results
{
    public class ListFoldersResult
    {
        public ListFoldersResult(YoinkFolder currentFolder)
        {
            CurrentFolder = currentFolder;
        }

        public YoinkFolder CurrentFolder { get; set; }
    }
}
