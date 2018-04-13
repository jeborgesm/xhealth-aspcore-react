using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Data;

namespace XHealthWeb.FileFactory
{
    public enum CustomFileType { CommaDelimited, PipeDelimited }
    public class ExportFile
    {
        string _FileName = string.Empty;
        CustomFileType _FileType;
        DataTable _FileData = new DataTable();

        public string FileName
        {
            get { return _FileName; }
        }
        public CustomFileType FileType
        {
            get { return _FileType; }
        }

        public DataTable ProcessedFileData
        {
            get { return _FileData; }
            set { _FileData = value; }
        }

        public ExportFile(string FileName, CustomFileType fileType)
        {
            _FileName = FileName;
            _FileType = fileType;
        }
    }
}
