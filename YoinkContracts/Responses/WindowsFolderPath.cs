using Serilog;

namespace YoinkContracts.Responses;

public record WindowsFolderPath : Path
{
    private readonly string _path = string.Empty;

    public WindowsFolderPath(FileSystemInfo di)
    {
        FullName = di.FullName;
    }

    public sealed override string FullName
    {
        get => _path;
        init
        {
            var (isValid, path) = ParsePath(value);
            if (isValid)
                _path = value;
            else throw new ArgumentException($"Invalid path: {value}");
        }
    }

    public override (bool isValid, string path) ParsePath(string windowsPath)
    {
        try
        {
            FileInfo fi = new(windowsPath);
            return (true, fi.FullName);
        }
        catch (Exception e)
        {
            Log.Error(e, "Invalid path '{WindowsPath}'");
            return (false, $"Invalid path '{windowsPath}'");
        }
    }

    public override string ToString() => FullName;
}