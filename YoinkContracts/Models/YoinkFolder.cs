namespace YoinkContracts.Models
{
    public class YoinkFolder
    {
        public const string BaseFolder = "/";

        public YoinkFolder(string name, IEnumerable<YoinkFile> files)
        {
            Name = name;
            Files = files;
        }

        public string Name { get; }
        //public string Description { get; set; }
        //public int FileCount { get; set; }
        public IEnumerable<YoinkFile> Files { get; }
    }

    public class YoinkFile
    {
        public string Name { get; set; }
    }
}
