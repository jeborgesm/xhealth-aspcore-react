using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHealthWeb.Data;
using XHealthWeb.Models;

namespace XHealthWeb.Export
{
    public class ExportFile
    {
        private HealthCareContext _context;
        private ExportStrategy _exportStrategy;

        public void SetExportStrategy(ExportStrategy exportstrategy, HealthCareContext context)
        {
            this._context = context;
            this._exportStrategy = exportstrategy;
        }
    }
}
