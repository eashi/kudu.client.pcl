using System.Collections.Generic;

namespace Kudu.Core.PCL.SourceControl
{
    public interface IFileFinder
    {
        IEnumerable<string> ListFiles(string path, SearchOption searchOption, params string[] lookupList);
    }
}
