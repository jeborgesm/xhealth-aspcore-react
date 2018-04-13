using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.FileFactory
{
    public class ExportFilePipeDelimitedProcessor : IFileProcessor
    {
        string StandardDelimiter = "|";
        public ExportFile ProcessFile(ExportFile exportfile)
        {

            if (LoadSchema())
            {
                if (CheckFileIntegrity())
                {
                    exportfile.ProcessedFileData = CreateDataTable();
                }
            }
            Console.WriteLine("PipeDelimited");
            return exportfile;
        }
        private bool LoadSchema()
        {
            //Load the XML Schema.
            //if not loaded properly returns false.
            //else
            return true;
        }

        private bool CheckFileIntegrity()
        {
            //Check if the Header and Trailer format on the data file matches with the defined schema.
            //Checks if the actual number of rows on the file matches with Header /trailer count
            //returns false if any of the above it false
            //else
            return true;
        }

        private DataTable CreateDataTable()
        {
            //this will parse through the file against the loaded schema and return a Data Table
            return new DataTable();
        }
    }
}
