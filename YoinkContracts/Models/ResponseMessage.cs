using Serilog;
using YoinkContracts.Responses;

namespace YoinkContracts.Models;

public class ResponseMessage
{
    public ResponseMessage(Severity severity, string message)
    {
        Severity = severity;
        Message = message;
    }

    public ResponseMessage(Exception exception, string userMessage = "An error occurred")
    {
        Severity = Severity.Error;
        Message = userMessage;
        Log.Error(exception,"Exception occured: {Exception}");
    }

    public Severity Severity { get; }
    public string Message { get; }
}