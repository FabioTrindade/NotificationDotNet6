namespace NotificationDotNet6.Domain.Commands;

public class GenericCommandResult
{ 
    public GenericCommandResult(bool success,
        string message,
        object? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    // Properties
    public bool Success { get; private set; }

    public string Message { get; private set; }

    public object? Data { get; private set; }
}