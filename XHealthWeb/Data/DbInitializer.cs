using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XHealthWeb.Models;

namespace XHealthWeb.Data
{
    public class DbInitializer
    {
        public static void Initialize(HealthCareContext context)
        {
            context.Database.EnsureCreated();

            if(context.Accounts.Any())
            {
                return; //Database contains data no need to initialize it.
            }

            //Patient Mock Data
            #region
            var patients = new Patient[]
            {
                new Patient {FirstName="Carol", LastName="Peters", MiddleName="Rose", SocialSecurityNumber = "100-200-1234"},
                new Patient {FirstName="Barbara", LastName="Camuy", MiddleName="Angelica", SocialSecurityNumber = "101-201-1235"}
            };

            foreach (Patient pt in patients)
            {
                context.Patients.Add(pt);
            }
            context.SaveChanges();
            int[] PatientIDs = context.Patients.Select(s => s.PatientID).ToArray();
            #endregion

            //Facility Mock Data
            #region
            var facilities = new Facility[]
            {
                new Facility {FacilityName="Meno Hospital", AddressLine1="4382 Howard Avenue", AddressLine2="Suite 500", City="Springfield", State="TN", Zip="12563"},
                new Facility {FacilityName="Pleno Health", AddressLine1="438 Hill Side", AddressLine2="Office 123", City="Vienna", State="TN", Zip="18663"}
            };

            foreach (Facility fac in facilities)
            {
                context.Facilities.Add(fac);
            }
            context.SaveChanges();
            int[] FacilityIDs = context.Facilities.Select(s => s.FacilityID).ToArray();
            #endregion

            #region Insurance Mock Data
            var insurances = new Insurance[]
            {
                new Insurance {GroupNumber="GN12-6359-9632563", PlanName="United Health", Policy="PN-F-H-V"},
                new Insurance {GroupNumber="GN12-6357-9689653", PlanName="MedStar Health", Policy="P-H-V"}
            };

            foreach (Insurance ins in insurances)
            {
                context.Insurances.Add(ins);
            }
            context.SaveChanges();
            int[] InsuranceIDs = context.Insurances.Select(s => s.InsuranceID).ToArray();
            #endregion

            #region Client Mock Data
            var clients = new Client[]
            {
                new Client {Name = "General Hospital", FileType = Client.CustomFileType.PipeDelimited},
                new Client {Name = "Veteran Hospital", FileType = Client.CustomFileType.CommaDelimited}
            };

            foreach (Client cl in clients)
            {
                context.Clients.Add(cl);
            }
            context.SaveChanges();
            int[] ClientIDs = context.Clients.Select(s => s.ClientID).ToArray();
            #endregion
            
            #region Account Mock Data
            var accounts = new Account[]
            {
                new Account {
                    Client = context.Clients.ToList()[0],
                    AccountNumber = "AC5623-86965",
                    Balance = 1256.25,
                    Facility = context.Facilities.ToList()[0],
                    AdmitDate = Convert.ToDateTime("10/20/2017"),
                    DischargeDate = Convert.ToDateTime("10/23/2017"),
                    Patient = context.Patients.ToList()[0]
                },
                new Account {
                    Client = context.Clients.ToList()[1],
                    AccountNumber = "AC5413-86935",
                    Balance = 165.75,
                    Facility = context.Facilities.ToList()[1],
                    AdmitDate = Convert.ToDateTime("8/17/2017"),
                    DischargeDate = Convert.ToDateTime("8/20/2017"),
                    Patient = context.Patients.ToList()[1]
                },
            };
            
            foreach (Account act in accounts)
            {
                context.Accounts.Add(act);
            }
            context.SaveChanges();
            int[] AccountIDs = context.Accounts.Select(s => s.AccountID).ToArray();
            #endregion
            
            #region Account Insurance Mock Data
            var accountInsurance = new AccountInsurance[]
            {
                new AccountInsurance {Account = context.Accounts.ToList()[0], Insurance = context.Insurances.ToList()[0]},
                new AccountInsurance {Account = context.Accounts.ToList()[1], Insurance = context.Insurances.ToList()[1]},
            };

            foreach (AccountInsurance ains in accountInsurance)
            {
                context.AccountInsurances.Add(ains);
            }
            context.SaveChanges();
            #endregion 

            #region Export History Mock Data
            var exportHistory = new ExportHistory[]
            {
                new ExportHistory {
                    Client = context.Clients.ToList()[0],
                    Accounts = 3,
                    Balance =5236.89,
                    ExportDate = Convert.ToDateTime("4/8/2018")},
                new ExportHistory {
                    Client = context.Clients.ToList()[0],
                    Accounts = 14,
                    Balance =4336.79,
                    ExportDate = Convert.ToDateTime("4/8/2018")},
                new ExportHistory {
                    Client = context.Clients.ToList()[1],
                    Accounts = 20,
                    Balance =1236.95,
                    ExportDate = Convert.ToDateTime("4/7/2018")},
                new ExportHistory {
                    Client = context.Clients.ToList()[1],
                    Accounts = 7,
                    Balance =8936.54,
                    ExportDate = Convert.ToDateTime("4/7/2018")},
            };

            foreach (ExportHistory eh in exportHistory)
            {
                context.ExportHistories.Add(eh);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
