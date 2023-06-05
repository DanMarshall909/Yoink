namespace YoinkContracts.Results;

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