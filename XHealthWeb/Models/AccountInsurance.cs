using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class AccountInsurance
    {
        public int AccountInsuranceId { get; set; }
        public Account Account { get; set; }
        public Insurance Insurance { get; set; }
    }
}
