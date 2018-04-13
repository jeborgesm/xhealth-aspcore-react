using System;
using System.Data;

namespace XHealthWeb.FileFactory
{
    internal class ExportFileCommaDelimitedProcessor : IFileProcessor
    {
        string StandardDelimiter = ",";
        //You may declare this as a property to have other delimiters - passed in from UI.
        public ExportFile ProcessFile(ExportFile exportfile)
        {
            Console.WriteLine("CommaDelimited");
            return exportfile;
        }
        private DataTable CreateDataTable()
        {
            //this will parse through the file for the delimiter and return DataTable
            return new DataTable();
        }
    }
}