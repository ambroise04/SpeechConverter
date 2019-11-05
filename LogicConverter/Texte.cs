using System;
using System.Collections.Generic;
using System.Text;

namespace LogicConverter
{
    public class Texte
    {
        public string Content { get; internal set; }
        public long StatusCode { get; internal set; }
        public Dictionary<string, object> Headers { get; internal set; }
    }
}
