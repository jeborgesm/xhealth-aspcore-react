using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class ExportHistory
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int Accounts { get; set; }
        public double Balance { get; set; } 
        public DateTime ExportDate { get; set; }
    }
}
