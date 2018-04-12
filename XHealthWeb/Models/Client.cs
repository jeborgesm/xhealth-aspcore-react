using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthWeb.Models
{
    public class Client
    {
        public enum CustomFileType { CommaDelimited, PipeDelimited }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ClientID { get; set; }
        public string Name { get; set; }
        public CustomFileType FileType { get; set; }
    }
}
