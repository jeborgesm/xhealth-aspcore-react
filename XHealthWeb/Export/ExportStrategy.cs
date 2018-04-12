using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHealthWeb.Data;
using XHealthWeb.Models;

namespace XHealthWeb.Export
{
    // The Export Data 'Strategy' abstract class
    public abstract class ExportStrategy
    {
        public abstract MemoryStream Format();
        public abstract string GetFileName();
    }
}
