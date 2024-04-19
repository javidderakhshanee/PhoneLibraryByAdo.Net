using System.ComponentModel;

namespace PhoneLibrary.Models.Enums;

public enum enumTypeLog
{
    [Description("All")]
    ALL = 0,
    [Description("Error")]
    ERROR = 1,
    [Description("Warning")]
    WARNING = 2,
    [Description("Success")]
    SUCCESS = 3,
    [Description("Log")]
    LOG = 4
}
