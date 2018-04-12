using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class Patient
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string SocialSecurityNumber { get; set; }
    }
}
