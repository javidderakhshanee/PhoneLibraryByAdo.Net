using PhoneLibrary.Models.Enums;

namespace PhoneLibrary.Models;

public sealed class LogsViewModel
{
    public enumTypeLog TypeLog { get; set; }
    public string Log { get; set; } = string.Empty;
    public string Form { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Extra { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Trace { get; set; } = string.Empty;
}
