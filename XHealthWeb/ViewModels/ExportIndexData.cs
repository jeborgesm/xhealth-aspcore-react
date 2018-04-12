using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHealthWeb.Models;

namespace XHealthWeb.ViewModels.ExportViewModels
{
    public class ExportIndexData
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<ExportHistory> ExportHistories { get; set; }

    }
}
