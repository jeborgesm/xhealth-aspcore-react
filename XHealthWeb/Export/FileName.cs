using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XHealthWeb.Data;

namespace XHealthWeb.Export
{
    public class FileName 
    {
        public enum DatePrefixType { Simple, Dashes }

        public DatePrefixType DateType { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public string Extension { get; set; }
        public DateTime FileDate { get; set; }

        public string Get()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Prefix);
            if(DateType == DatePrefixType.Simple)
            {
                sb.Append(FileDate.ToString("yyyyMMdd"));
            }
            else if(DateType == DatePrefixType.Dashes )
            {
                sb.Append(FileDate.ToString("yyyy-MM-dd"));
            }
            sb.Append(Postfix);
            sb.Append(".");
            sb.Append(Extension);

            return sb.ToString();
        }
    }
}
