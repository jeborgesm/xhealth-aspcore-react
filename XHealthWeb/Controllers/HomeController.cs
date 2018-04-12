using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XHealthWeb.Data;
using XHealthWeb.Export;
using XHealthWeb.ViewModels.ExportViewModels;

namespace XHealthWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HealthCareContext _context;
        private ExportStrategy _exportStrategy;

        public void SetExportStrategy(ExportStrategy exportstrategy, HealthCareContext _context)
        {
            this._exportStrategy = exportstrategy;
        }

        public HomeController(HealthCareContext context)
        {
            _context = context;
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ExportIndexData();
            viewModel.ExportHistories = await _context.ExportHistories
                  .Include(i => i.Client)
                  .OrderByDescending(i => i.ExportDate)
                  .ToListAsync();

            viewModel.Clients = await _context.Clients
                  .OrderBy(i => i.Name)
                  .ToListAsync();

            return View(viewModel);
        }

        public FileStreamResult Export(int Id)
        {
                
            var clientFileType = _context.Clients.Where(w => w.ClientID == Id).Select(s => s.FileType).FirstOrDefault();
            FileStreamResult fileStreamResult = null; ;
            if (clientFileType == Models.Client.CustomFileType.PipeDelimited)
            {
                var ctxt = _context.Accounts
                      .Include(i => i.Client)
                      .Include(i => i.Patient)
                      .Include(i => i.Facility).ToList();

                PipeDelimited pd = new PipeDelimited();
                pd.Accounts = ctxt;

                MemoryStream stream = pd.Format();
                fileStreamResult = new FileStreamResult(stream, "text/plain");
                fileStreamResult.FileDownloadName = pd.GetFileName();
            }
            else if (clientFileType == Models.Client.CustomFileType.CommaDelimited)
            {
                Dictionary<string, MemoryStream> streamList = new Dictionary<string, MemoryStream>();
                int filei = 0;
                foreach (var fac in _context.Facilities)
                {
                    filei++;
                    var ctxt = _context.AccountInsurances
                          .Include(i => i.Account.Client)
                          .Include(i => i.Account.Patient)
                          .Include(i => i.Account.Facility)
                          .Include(i => i.Insurance)
                          .ToList();

                    CommaDelimited cd = new CommaDelimited();
                    cd.AccountInsurances = ctxt;

                    MemoryStream stream = cd.Format();

                    string FileName = cd.GetFileName(fac.FacilityName);
                    streamList.Add(FileName, stream);
                }

                MultipleFiles mFiles = new MultipleFiles();
                byte[] zipFile = mFiles.Generate(streamList);

                fileStreamResult = new FileStreamResult(new MemoryStream(zipFile), System.Net.Mime.MediaTypeNames.Application.Zip);

                fileStreamResult.FileDownloadName = "FacilitiesExport.zip";
            }

            ///TO DO: Update the export table with the processed values.

            return fileStreamResult;
        }
    }
}
