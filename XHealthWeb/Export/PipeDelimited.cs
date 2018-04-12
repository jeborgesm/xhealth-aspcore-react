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
    // Pipe Delimited 'ConcreteStrategy' class
    public class PipeDelimited : ExportStrategy
    {
        public List<Account> Accounts { get; set; }
        private char StandardDelimiter = '|';

        public override string GetFileName()
        {
            FileName fn = new FileName()
            {
                Prefix = "",
                FileDate = DateTime.Now,
                Postfix = "-gh.data",
                Extension = "dat",
                DateType = Export.FileName.DatePrefixType.Simple
            };
            return fn.Get();
        }

        public override MemoryStream Format()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(StandardDelimiter, new object[] {
                    "Account Number",
                    "Patient Name",
                    "Balance",
                    "Facility",
                    "AdmitDate",
                    "DischargeDate"
                });
            sb.AppendLine();
            foreach (Account acc in Accounts)
            {
                sb.AppendJoin(StandardDelimiter, new object[] {
                    acc.AccountNumber,
                    LastNameFirst(acc.Patient.FirstName, acc.Patient.LastName),
                    String.Format("{0:C}", acc.Balance),
                    acc.Facility.FacilityName,
                    acc.AdmitDate.ToString("MM-dd-yyyy"),
                    acc.DischargeDate.ToString("MM-dd-yyyy")
                });
                sb.AppendLine();
            }
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
        }

        public string LastNameFirst(string firstName, string lastName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(lastName);
            sb.Append(", ");
            sb.Append(firstName);
            return sb.ToString();
        }

    }
}
