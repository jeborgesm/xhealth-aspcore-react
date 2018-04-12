using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class Account
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public Client Client { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public Facility Facility { get; set; }
        public DateTime AdmitDate { get; set; }
        public DateTime DischargeDate { get; set; }
        public Patient Patient { get; set; }
    }
}
