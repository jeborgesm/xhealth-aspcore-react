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
    // Comma Delimited 'ConcreteStrategy' class
    public class CommaDelimited : ExportStrategy
    {
        //public List<Account> Accounts { get; set; }
        public List<AccountInsurance> AccountInsurances {get; set;}
        private char StandardDelimiter = ',';
        private string facilityFileName = "[]"; 

        public string GetFileName(string facilityName)
        {
            facilityFileName = "[" + facilityName + "]";
            return GetFileName();
        }

        public override string GetFileName()
        {
            FileName fn = new FileName()
            {
                Prefix = "export-",
                FileDate = DateTime.Now,
                Postfix = "." + facilityFileName,
                Extension = "csv",
                DateType = Export.FileName.DatePrefixType.Dashes
            };
            return fn.Get();
        }

        public override MemoryStream Format()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin(StandardDelimiter, new object[] {
                    "Account Number",
                    "Patient SSN",
                    "Balance",
                    "Facility",
                    "Admit Date",
                    "Discharge Date",
                    "Insurance Plan Name",
                    "Policy",
                    "Group Number",
                    "Facility Name",
                    "Address Line 1",
                    "Address Line 2",
                    "City",
                    "State",
                    "Zip"
                });
            sb.AppendLine();
            foreach (Account acc in AccountInsurances
                                        .Select(s => s.Account)
                                        .Where(w=> w.Balance >= 100))
            {
                
                AccountInsurance accins = AccountInsurances.Where(w => w.Account == acc).FirstOrDefault();
                sb.AppendJoin(StandardDelimiter, new object[] {
                    acc.AccountNumber,
                    acc.Patient.SocialSecurityNumber,
                    acc.Balance,
                    acc.Facility.FacilityName,
                    acc.AdmitDate.ToString("MM-dd-yyyy"),
                    acc.DischargeDate.ToString("MM-dd-yyyy"),
                    accins.Insurance.PlanName,
                    accins.Insurance.Policy,
                    accins.Insurance.GroupNumber,
                    acc.Facility.FacilityName,
                    acc.Facility.AddressLine1,
                    acc.Facility.AddressLine2,
                    acc.Facility.City,
                    acc.Facility.State,
                    acc.Facility.Zip

                });
                sb.AppendLine();
            }
            return new MemoryStream(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
        }
    }
}
