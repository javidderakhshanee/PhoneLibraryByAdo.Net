using PhoneLibrary.Models.Enums;
using PhoneLibrary.Models;
using System.Xml.Linq;
using System.Xml;

namespace PhoneLibrary.Helpers;

public sealed class Logger
{
    private object locker = new object();
    private string pathLog => Path.Combine(Application.StartupPath, "logs");
    private string pathLogFile => Path.Combine(pathLog, "logs", "log.xml");
    public void clearLog()
    {
        if (File.Exists(pathLogFile))
            try
            {
                File.Delete(pathLogFile);
            }
            catch { }
    }

    public List<LogsViewModel> loadDataByType(LogsViewModel data)
    {
        if (!Directory.Exists(pathLog))
            Directory.CreateDirectory(pathLog);

        var list = new List<LogsViewModel>();
        if (!File.Exists(pathLogFile))
            return new List<LogsViewModel>();

        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(pathLogFile);
            var filter = "@username=''";
            filter += (filter.Length > 0 && data.TypeLog != enumTypeLog.ALL ? " or " : "") + (data.TypeLog != enumTypeLog.ALL ? $"@typelog='{(int)data.TypeLog}'" : "");
            filter += (filter.Length > 0 && !string.IsNullOrEmpty(data.Username) ? " or " : "") + (!string.IsNullOrEmpty(data.Username) ? $"@username='{data.Username}'" : "");
            filter += (filter.Length > 0 && !string.IsNullOrEmpty(data.Form) ? " or " : "") + (!string.IsNullOrEmpty(data.Form) ? $"@form='{data.Form}'" : "");
            var nodelist = xmlDoc.SelectNodes($"//item[{filter}]");
            foreach (XmlNode xmlNode in nodelist)
            {
                var model = new LogsViewModel
                {
                    Username = $"{xmlNode?.Attributes["username"]?.Value!}",
                    Form = $"{xmlNode?.Attributes["form"]?.Value!}",
                    Extra = $"{xmlNode?.Attributes["extra"]?.Value!}",
                    Date = $"{xmlNode?.Attributes["date"]?.Value!}",
                    Trace = $"{xmlNode?.Attributes["trace"]?.Value!}",
                    Log = xmlNode?.InnerText!
                };

                int.TryParse(xmlNode?.Attributes["typelog"]?.Value, out var typeLog);

                model.TypeLog = (enumTypeLog)typeLog;

                list.Add(model);
            }
        }
        catch { }

        return list;
    }

    public void saveLog(LogsViewModel data)
    {
        if (!Directory.Exists(Path.Combine(Application.StartupPath, "logs")))
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "logs"));

        try
        {
            lock (locker)
            {
                var doc = new XDocument();
                XElement root = null;
                if (File.Exists(pathLogFile))
                {
                    doc = XDocument.Load(pathLogFile);
                    root = doc.Root;
                }
                else
                {
                    doc.Add(new XComment("Tracking Errors"));
                    root = new XElement("Root");
                }
                try
                {
                    var n = new XElement("item");
                    n.Add(new XAttribute("form", data.Form ?? ""));
                    n.Add(new XAttribute("username", "Admin"));
                    n.Add(new XAttribute("extra", data.Extra ?? ""));
                    n.Add(new XAttribute("typelog", (int)data.TypeLog));
                    n.Add(new XAttribute("date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                    n.Add(new XAttribute("trace", data.Trace));
                    n.Value = data.Log ?? "";
                    root?.Add(n);
                }
                catch
                {
                }
                if (!File.Exists(pathLogFile))
                {
                    doc.Add(root);
                }
                doc.Save(pathLogFile);
            }
        }
        catch (Exception ex)
        {
            var f = ex.Message;
        }
    }
}
