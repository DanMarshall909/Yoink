using YoinkContracts.Models;

namespace YoinkContracts.Responses;

public abstract class YoinkResponse
{
    private readonly List<ResponseMessage> _messages = new();
    public IReadOnlyCollection<ResponseMessage> Messages => _messages.AsReadOnly();
    public bool IsSuccess => Messages.All(m => m.Severity != Severity.Error);
    public void AddError(string message) => AddMessage(Severity.Error, message); 
    public void AddInfo(string message) => AddMessage(Severity.Info, message);
    public void AddWarning(string message) => AddMessage(Severity.Warning, message); 
    public void AddError(Exception e) => AddError(e.Message);
    private void AddMessage(Severity severity, string message) 
        => _messages.Add(new ResponseMessage(severity, message));
}
