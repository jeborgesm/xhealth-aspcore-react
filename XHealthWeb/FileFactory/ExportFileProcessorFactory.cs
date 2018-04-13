using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.FileFactory
{
    public class ExportFileProcessorFactory 
    {
        public IFileProcessor processor;
        public ExportFile exportFile;

        public ExportFileProcessorFactory(ExportFile _exportfile)
        {
            exportFile = _exportfile;
        }

        public IFileProcessor GetFileProcessor()
        {

            switch (exportFile.FileType)
            {
                case CustomFileType.PipeDelimited:
                    processor = new ExportFilePipeDelimitedProcessor();
                    break;
                case CustomFileType.CommaDelimited:
                    processor = new ExportFileCommaDelimitedProcessor();
                    break;
            }
            return processor;
        }
    }
}
