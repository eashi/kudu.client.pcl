using System.Collections.Generic;

namespace Kudu.Contracts.PCL.Settings
{
    public interface ISettingsProvider
    {
        IEnumerable<KeyValuePair<string, string>> GetValues();
        string GetValue(string key);
        int Priority { get; }
    }
}
