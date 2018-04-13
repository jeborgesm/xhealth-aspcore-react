using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.FileFactory
{
    public interface IFileProcessor
    {
        ExportFile ProcessFile(ExportFile exportFile);
    }
}
