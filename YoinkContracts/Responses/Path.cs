namespace YoinkContracts.Responses;

public abstract record Path
{
    public abstract string FullName { get; init; }
    public abstract (bool isValid, string path) ParsePath(string windowsPath);
    public abstract override string ToString();
}