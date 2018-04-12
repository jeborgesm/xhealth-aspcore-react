using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Export
{
    public class MultipleFiles
    {
        public byte[] Generate(Dictionary<string, MemoryStream> streamList)
        {
            FileStreamResult fileStreamResult;
            MemoryStream msZip = new MemoryStream();
            ZipStorer zip = ZipStorer.Create(msZip, "Facilities Export", true);
            foreach (var ms in streamList)
            {
                // Stores a new file directly from the stream
                zip.AddStream(ZipStorer.Compression.Store, ms.Key, ms.Value, DateTime.Now, ms.Key);
                ms.Value.Close();
            }
            zip.Close();

            byte[] zipArray = msZip.ToArray();

            return zipArray;
        }
    }
}
