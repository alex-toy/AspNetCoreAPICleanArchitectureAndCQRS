using Social.Application.Enums;

namespace Social.Application.Models;

public class Error
{
    public ErrorCode Code { get; set; }
    public string Message { get; set; }
}