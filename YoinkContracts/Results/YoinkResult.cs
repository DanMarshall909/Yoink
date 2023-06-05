namespace YoinkContracts.Results;

public abstract class YoinkResult
{
    private readonly List<ResultMessage> _messages = new();
    public IReadOnlyCollection<ResultMessage> Messages => _messages.AsReadOnly();
    public bool IsSuccess => Messages.All(m => m.Severity != Severity.Error);
    public void Error(string message) => AddMessage(Severity.Error, message); 
    public void Info(string message) => AddMessage(Severity.Info, message);
    public void Warning(string message) => AddMessage(Severity.Warning, message); 
    public void Error(Exception e) => Error(e.Message);
    private void AddMessage(Severity severity, string message) 
        => _messages.Add(new ResultMessage(severity, message));
}
