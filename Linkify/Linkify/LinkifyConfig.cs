using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkify
{
    public class LinkifyConfig
    {
        public string Target { get; set; }
        public string ClassName { get; set; }
        public string Rel { get; set; }
        public bool ReplaceNewLineWithBr { get; set; }
        public string UrlPrependedText { get; set; }
        public string UrlAppendedText { get; set; }
    }
}
