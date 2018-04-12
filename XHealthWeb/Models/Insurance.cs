using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class Insurance
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InsuranceID { get; set; }
        public string PlanName { get; set; }
        public string Policy { get; set; }
        public string GroupNumber { get; set; }
    }
}
