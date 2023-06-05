namespace YoinkContracts.Results;

public interface IListFoldersResult : IYoinkResult
{
    IReadOnlyCollection<Folder> Subfolders { get; }
    IReadOnlyCollection<File> Files { get; }
}

public interface IYoinkResult
{
    IReadOnlyCollection<ResultMessage> Messages { get; }
}

public class ResultMessage
{
    public ResultMessage(Severity severity, string message)
    {
        Severity = severity;
        Message = message;
    }

    public ResultMessage(Exception exception)
    {
        Severity = Severity.Error;
        Message = exception.Message;
    }

    public Severity Severity { get; }
    public string Message { get; }
}

public enum Severity
{
    Error = 10,
    Warning = 20,
    Info = 30,
    Debug = 40,
}